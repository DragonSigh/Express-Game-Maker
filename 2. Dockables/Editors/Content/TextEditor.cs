using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using WeifenLuo.WinFormsUI.Docking;
using GenericUndoRedo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls;
using EGMGame.Docking.Explorers;
using Microsoft.Xna.Framework.Content;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EGMGame.Docking.Editors
{
    public partial class TextEditor : DockContent, IEditor, IHistory
    {
        // Drawing variables
        SpriteBatch spriteBatch;
        List<SpriteFont> spriteFonts = new List<SpriteFont>();
        ContentManager contentManager;
        List<FontData> fonts = new List<FontData>();

        Dictionary<string, int> openTags = new Dictionary<string, int>();

        bool isTypingTag = false;

        // Other variables
        bool allowEdit = true;

        public TextEditor()
        {
            MainForm.TextHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();

            dockContextMenu1.owner = this;

            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            Application.Idle += delegate { graphicsControl.Invalidate(); };

            openTags.Add("c", 0);
            openTags.Add("s", 0);
            openTags.Add("x", 0);

            messageEditor1.TextChangeEvent += new EventHandler(messageEditor1_TextChanged);
        }

        private void TextEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.TextHistory[this];
        }

        private void TextEditor_Shown(object sender, EventArgs e)
        {
            SetupFontList();

            RefreshLanguagesHere();

            addRemoveList.SetupList(GameData.Texts["English"], typeof(TextData));
            messageEditor1.Repopulate();
        }

        public void SetupFontList()
        {
            fonts.Clear();
            fontList.Items.Clear();
            foreach (FontData font in GameData.Fonts.Values)
            {
                fontList.Items.Add(font.Name);
                fonts.Add(font);
            }
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            foreach (string lang in Global.Project.Languages)
                GameData.Texts[lang].Add(data.ID, (TextData)data);
            addRemoveList.AddNode(data);

        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            foreach (string lang in Global.Project.Languages)
                GameData.Texts[lang].Remove(data.ID);

            addRemoveList.RemoveNode(data);
        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                TextData a = new TextData();
                a.Name = Global.GetName("Text", GameData.Texts[cbLanguages.Text]);
                a.ID = Global.GetID(GameData.Texts[cbLanguages.Text]);
                a.Category = ca.Category;
                a.LineSpacing = 20;
                foreach (string lang in Global.Project.Languages)
                    GameData.Texts[lang].Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.TextHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "50x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
                {

                    // History
                    MainForm.TextHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    foreach (string lang in Global.Project.Languages)
                        GameData.Texts[lang].Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "50x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            if (e.Index >= 0 && GameData.Texts[cbLanguages.Text].ContainsKey(e.ID))
                SetupProperty(GameData.Texts[cbLanguages.Text][e.ID]);
            else
                SetupProperty(null);
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(TextData obj)
        {
            if (obj != null)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                nbLineSpacing.Value = (decimal)obj.LineSpacing;
                nbLetterSpacing.Value = (decimal)obj.LetterSpacing;
                allowEdit = false;
                SetupFontList();
                allowEdit = true;
                fontList.SelectedIndex = GetFontIndex(obj.FontName);
                messageEditor1.Text = obj.Text;
            }
            else
            {
                allowEdit = false;
                SetupFontList();
                allowEdit = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private int GetFontIndex(string p)
        {
            int i = 0;
            foreach (object d in fontList.Items)
            {
                if (d.ToString() == p)
                    return i;
                i++;
            }
            return -1;
        }

        private void fontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowEdit && addRemoveList.SelectedIndex > -1 && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
            {
                if (fonts[fontList.SelectedIndex] != null)
                {
                    int i = fonts[fontList.SelectedIndex].ID;
                    foreach (string lang in Global.Project.Languages)
                        GameData.Texts[lang][addRemoveList.SelectedID].FontID = i;
                    LoadFont();
                    messageEditor1.SetupProperty(fonts[fontList.SelectedIndex]);
                }
                else
                {

                    foreach (string lang in Global.Project.Languages)
                        GameData.Texts[lang][addRemoveList.SelectedID].FontID = 0;
                    LoadFont();
                    messageEditor1.SetupProperty(fonts[fontList.SelectedIndex]);
                }
            }
        }

        private void lineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (allowEdit && addRemoveList.SelectedIndex > -1 && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
            {
                GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID].LineSpacing = (int)nbLineSpacing.Value;
            }
        }

        private void letterSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (allowEdit && addRemoveList.SelectedIndex > -1 && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
            {
                GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID].LetterSpacing = (int)nbLetterSpacing.Value;
            }
        }

        public void messageEditor1_TextChanged(object sender, EventArgs e)
        {
            if (GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.Data().ID))
            {
                GameData.Texts[cbLanguages.Text][addRemoveList.Data().ID].Text = messageEditor1.Text;
            }
        }

        public void RefreshLanguages()
        {
            allowEdit = false;
            int i = cbLanguages.SelectedIndex;
            cbLanguages.Items.Clear();
            allowEdit = true;
            // Look For Additions
            Dictionary<int, TextData> clone;
            foreach (string lang in Global.Project.Languages)
            {
                if (!GameData.Texts.ContainsKey(lang))
                {
                    clone = Global.Duplicate<Dictionary<int, TextData>>(GameData.Texts["English"]);
                    foreach (TextData t in clone.Values)
                    {
                        t.Text = "";
                    }
                    GameData.Texts.Add(lang, clone);
                }
            }
            // Look For Delations
            Dictionary<string, Dictionary<int, TextData>>.KeyCollection keys = Global.Duplicate<Dictionary<string, Dictionary<int, TextData>>.KeyCollection>(GameData.Texts.Keys);

            foreach (string lang in keys)
            {
                if (!Global.Project.Languages.Contains(lang))
                {
                    GameData.Texts.Remove(lang);
                }
            }


            foreach (string lang in Global.Project.Languages)
            {
                cbLanguages.Items.Add(lang);
            }

            cbLanguages.SelectedIndex = i;
        }

        public void RefreshLanguagesHere()
        {
            allowEdit = false;
            cbLanguages.Items.Clear();
            allowEdit = true;

            foreach (string lang in Global.Project.Languages)
            {
                cbLanguages.Items.Add(lang);
            }

            cbLanguages.SelectedIndex = 0;
        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowEdit && addRemoveList.Data().ID > -1)
            {
                SetupProperty(GameData.Texts[cbLanguages.Text][addRemoveList.Data().ID]);
            }
        }

        #region IEditor Members

        public void SetupList()
        {

        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void simpleGraphicsControl1_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(graphicsControl.GraphicsDevice);
            LoadFont();
        }

        private void simpleGraphicsControl1_OnDraw(object sender, EventArgs e)
        {
            graphicsControl.GraphicsDevice.Clear(Color.White);

            if (addRemoveList.Count > 0 && spriteFonts != null && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
            {
                CheckFontParams();
                DrawText();
            }
        }
        private void CheckFontParams()
        {
            foreach (SpriteFont font in spriteFonts)
            {
                font.LineSpacing = GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID].LineSpacing;
                font.Spacing = GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID].LetterSpacing;
            }
        }
        private void DrawText()
        {

            if (spriteFonts.Count > 0)
            {
                spriteBatch.Begin();

                string remainingText = GameData.Texts[cbLanguages.Text][addRemoveList.SelectedID].Text;


                Global.DrawText(spriteBatch, contentManager, fonts[fontList.SelectedIndex], fonts[fontList.SelectedIndex].Styles[0], remainingText, new Vector2(10, 10), Color.Black);

                spriteBatch.End();
                return;
                TextProperties properties = new TextProperties(spriteFonts[0], Color.Black, new Vector2(10, 10));

                // RegEx Templates: 
                //
                // 2 Value (Variable and Text) e.g. [url=x]blah[/x]. ($) Group1 = variable, ($) Group2 = text
                //    new Regex(@"\[tag=([^\]]+)\]([^\]]+)\[\/tag\]");
                //
                // Single Value (Text only) e.g. [Tag]Text[/Tag]. $1 = text
                //     new Regex(@"\[u\](.+?)\[\/u\]");
                Regex styleExp = new Regex(@"\[s=([^\]]+)\](.+)\[\/s\]"); //@"\[s=([^\]]+)\]([^\]]+)\[\/s\]");
                Regex colorExp = new Regex(@"\[c=([0-9a-fA-F]{6})\](.+)\[\/c\]"); //@"\[c=([0-9a-fA-F]{6})\]([^\]]+)\[\/c\]");//new Regex(@"\[c=([^\]]+)\]([^\]]+)\[\/c\]");            
                Regex variableExp = new Regex(@"\[v=(\d+)\]");
                Regex databaseExp = new Regex(@"\[d=(\d+[,]\d+[,]\d+)\]");

                //foreach (string line in lines)
                //{
                properties.currentPosition = new Vector2(10, 10);
                //properties.currentPosition.Y += li * properties.styles[properties.currentStyle].MeasureString("I").Y;
                //remainingText = line;
                remainingText = messageEditor1.Text;

                DrawParsedText(spriteBatch, remainingText, properties, styleExp, colorExp, variableExp, databaseExp);
                spriteBatch.DrawString(spriteFonts[0], "Width: " + properties.GetSize().X.ToString() + "; Height: " + properties.GetSize().Y.ToString(),
                    new Vector2(10, 200), Color.Black);
                //}

                #region ParseText
                //while (remainingText.Length > 0)
                //{
                //    int i = remainingText.IndexOf('[');
                //    if (i > 0)
                //    {
                //        switch (remainingText[i + 1])
                //        {
                //            case 's':
                //                Match m = styleExp.Match(remainingText);
                //                if (m.Groups[0].Captures.Count > 0)
                //                {
                //                    string drawString = remainingText.Substring(0, i - 1);
                //                    spriteBatch.DrawString(styles[currentStyle], drawString, currentPosition, colors[currentColor]);

                //                    Vector2 textSize = styles[currentStyle].MeasureString(drawString);

                //                    currentPosition.X += textSize.X;
                //                    remainingText = remainingText.Remove(0, i - 1);

                //                    if (spriteFonts[int.Parse(m.Groups[0].Captures[1].Value)] != null)
                //                    {
                //                        styles.Add(spriteFonts[int.Parse(m.Groups[0].Captures[1].Value)]);
                //                        currentStyle++;

                //                        string centerText = m.Groups[0].Captures[2].Value;
                //                        // Perform same
                //                        while (centerText.Length > 0)
                //                        {

                //                        }
                //                    }
                //                    remainingText.Remove(0, m.Groups[0].Length);
                //                }
                //                break;
                //            case 'c':
                //                break;
                //            case 'v':
                //                break;
                //            case 'd':
                //                break;

                //        }
                //    }
                //    else
                //    {
                //        spriteBatch.DrawString(styles[currentStyle], remainingText, currentPosition, colors[currentColor]);
                //        remainingText = "";
                //    } 
                #endregion
                #region OldParse
                //if (spriteFonts.Count > 0)
                //{
                //    Color currentColor = Color.Black;
                //    SpriteFont currentStyle = spriteFonts[0];

                //    Vector2 currentPosition = new Vector2(10, 10);

                //    string[] lines = messageEditor1.Text.Split('\n');
                //    int li = -1;
                //    foreach (string line in lines)
                //    {
                //        currentPosition = new Vector2(10, 10);
                //        li++;
                //        currentPosition.Y += li * currentStyle.MeasureString("I").Y;
                //        string remainingText = line;

                //        string drawText;

                //        // try to stop checks while tags are manually inserted
                //        if (remainingText.EndsWith("["))
                //            isTypingTag = true;

                //        if (isTypingTag && remainingText.EndsWith("]"))
                //            isTypingTag = false;

                //        if (isTypingTag)
                //        {
                //            spriteBatch.DrawString(currentStyle, remainingText,
                //                    currentPosition, currentColor);
                //            continue;
                //        }

                //while (remainingText.Length > 0)
                //{
                //Check:
                //    // Draw text until next tag with current settings
                //    int i = remainingText.IndexOf('[');
                //    // if there is a tag found
                //    if (i > -1 && remainingText.Contains(']'))
                //    {
                //        // get the text from the start of the remaining draw text until the next tag
                //        drawText = remainingText.Substring(0, i);
                //        // draw the text with the current style and color at the position
                //        spriteBatch.DrawString(currentStyle, drawText,
                //            currentPosition, currentColor)
                //        // update the position so the next text is drawn correctly
                //        Vector2 textSize = currentStyle.MeasureString(drawText);
                //        currentPosition.X += textSize.X;
                //        // remove the already drawn string from the total draw string
                //        remainingText = remainingText.Remove(0, i);
                //        // we are left with the beginning of the tag onwards, so analyze the tag.
                //        // get the tag ending
                //        int z = remainingText.IndexOf(']');
                //        if (z > -1)
                //        {
                //            string tag = remainingText.Substring(0, z + 1);
                //            //remove parenthesis
                //            tag = tag.TrimStart('[');
                //            tag = tag.TrimEnd(']');
                //            // check if tag is close tag
                //            if (tag.StartsWith("/"))
                //            {
                //                // trim opening /
                //                tag = tag.TrimStart('/');
                //                // tag is now only a string with the tagType
                //                // check if  a tag is already open to close
                //                if (tag != "" && openTags.ContainsKey(tag))
                //                {
                //                    if (openTags[tag] > 0)
                //                    {
                //                        // decrease the open tags.
                //                        openTags[tag]--;
                //                        // default closed tag
                //                        switch (tag)
                //                        {
                //                            case "s":
                //                                currentStyle = spriteFonts[0];
                //                                break;
                //                            case "c":
                //                                currentColor = Color.Black;
                //                                break;
                //                        }
                //                    }
                //                    else
                //                        DrawError("Closing tag without opening tag.");
                //                }
                //            }
                //            // tag is an open tag
                //            else
                //            {
                //                // get the value and the type
                //                int equalsIndex = tag.IndexOf('=');
                //                if (equalsIndex > -1)
                //                {
                //                    string tagType = tag.Substring(0, equalsIndex);
                //                    string tagValue = tag.Substring(tag.IndexOf('=') + 1);
                //                    int parsedTagValue;
                //                    //bool tagTest = int.TryParse(tagValue, out parsedTagValue);
                //                    if (tagValue != "")
                //                    {
                //                        // check the data and update the style/color as needed
                //                        switch (tagType)
                //                        {
                //                            case "s":
                //                                currentStyle = spriteFonts[int.Parse(tagValue)];
                //                                openTags[tagType]++;
                //                                break;
                //                            case "c":
                //                                currentColor = ParseHexData(tagValue);
                //                                openTags[tagType]++;
                //                                break;
                //                            case "v":
                //                                string variableValue;
                //                                if (GameData.Variables.ContainsKey(int.Parse(tagValue)))
                //                                    variableValue = GameData.Variables[int.Parse(tagValue)].Value.ToString();
                //                                else
                //                                    variableValue = "#NoData";
                //                                spriteBatch.DrawString(currentStyle, variableValue,
                //                                    currentPosition, currentColor);
                //                                // update the position so the next text is drawn correctly
                //                                Vector2 variableSize = currentStyle.MeasureString(variableValue);
                //                                currentPosition.X += variableSize.X;
                //                                break;
                //                            case "d":
                //                                string[] dataValues = tagValue.Split(',');

                //                                if (dataValues.Length == 3)
                //                                {
                //                                    if (dataValues[0] != "" && dataValues[1] != "" && dataValues[2] != "")
                //                                    {
                //                                        string databaseString = "";
                //                                        int databaseID = int.Parse(dataValues[0]);
                //                                        int datasetID = int.Parse(dataValues[1]);
                //                                        int propertyID = int.Parse(dataValues[2]);

                //                                        if (GameData.Databases.ContainsKey(databaseID) && GameData.Databases[databaseID].Datas.ContainsKey(datasetID) && GameData.Databases[databaseID].Datas[datasetID].Properties.Count > propertyID)
                //                                        {
                //                                            Data db;
                //                                            db = GameData.Databases[databaseID];
                //                                            DataProperty prop = db.Datas[datasetID].Properties[propertyID];
                //                                            if (prop.ValueType == DataType.Text || prop.ValueType == DataType.Number)
                //                                                databaseString = prop.Value.ToString();
                //                                            else
                //                                                databaseString = "#WrongData";
                //                                        }
                //                                        else
                //                                            databaseString = "#NoData";

                //                                        spriteBatch.DrawString(currentStyle, databaseString,
                //                                            currentPosition, currentColor);
                //                                        // update the position so the next text is drawn correctly
                //                                        Vector2 databaseSize = currentStyle.MeasureString(databaseString);
                //                                        currentPosition.X += databaseSize.X;
                //                                    }
                //                                }
                //                                break;
                //                        }
                //                    }
                //                }
                //            }

                //            // remove the tag from the overall draw string
                //            remainingText = remainingText.Remove(0, z + 1);
                //        }

                //        // Repeat!
                //        goto Check;
                //    }
                //    else
                //    {
                //        // no more tags, so just draw the rest! :)
                //        spriteBatch.DrawString(currentStyle, remainingText,
                //            currentPosition, currentColor);
                //        continue;
                //    }
                //}
                //}
                //}
                #endregion

                spriteBatch.End();
            }
        }
        private void DrawParsedText(SpriteBatch spriteBatch, string text, TextProperties properties, Regex styleExp, Regex colorExp, Regex variableExp, Regex databaseExp)
        {
            string remainingText = text;

            while (remainingText.Length > 0)
            {
                int i = remainingText.IndexOf('[');
                int x = remainingText.IndexOf('\n');
                if (x != -1 && x < i || (i == -1 && x != -1))
                {
                    properties.NewLine();

                    string drawString = remainingText.Substring(0, x);
                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                    properties.lines[properties.currentLine].Text += drawString;

                    Vector2 textSize;
                    if (drawString != "")
                    {
                        textSize = properties.styles[properties.currentStyle].MeasureString(drawString);
                        properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X + textSize.X);
                    }
                    else
                    {
                        //textSize = properties.styles[properties.currentStyle].MeasureString("I");
                        properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X);
                    }

                    properties.currentPosition.Y += properties.lines[properties.currentLine].Height; //textSize.Y;
                    properties.currentPosition.X = properties.basePosition.X;
                    remainingText = remainingText.Remove(0, x + ('\n').ToString().Length);
                    properties.currentLine++;
                }
                else
                {
                    if (i > -1 && (i + 1) < remainingText.Length)
                    {
                        switch (remainingText[i + 1])
                        {
                            case 's':
                                Match m = styleExp.Match(remainingText);
                                int z;
                                if (m.Groups[0].Captures.Count > 0 && int.TryParse(m.Groups[1].Captures[0].Value, out z))
                                {
                                    properties.tagLevel++;
                                    properties.tagIndexes.Add(m.Groups[0].Index);

                                    string drawString = remainingText.Substring(0, i);
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, i);

                                    if (int.Parse(m.Groups[1].Captures[0].Value) < spriteFonts.Count)
                                    {
                                        properties.styles.Add(spriteFonts[int.Parse(m.Groups[1].Captures[0].Value)]);
                                        properties.currentStyle++;
                                        properties.lines[properties.currentLine].Styles.Add(spriteFonts[int.Parse(m.Groups[1].Captures[0].Value)]);

                                        string centerText = m.Groups[2].Captures[0].Value;

                                        DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp);

                                        properties.styles.RemoveAt(properties.currentStyle);
                                        properties.currentStyle--;
                                    }
                                    else
                                    {
                                        string centerText = m.Groups[2].Captures[0].Value;
                                        DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp);
                                    }

                                    remainingText = remainingText.Remove(m.Groups[0].Index - drawString.Length, m.Groups[0].Length);
                                }
                                else
                                {
                                    int temp = remainingText.IndexOf(']') + 1;
                                    string drawString = remainingText.Substring(0, temp);
                                    if (drawString == "" && remainingText.Length > 1)
                                    {
                                        drawString = remainingText.Substring(0, 1);
                                        temp = 1;
                                    }
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, temp);
                                    //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                    //remainingText = "";
                                }
                                break;
                            case 'c':
                                m = colorExp.Match(remainingText);
                                z = 0;
                                if (m.Groups[0].Captures.Count > 0)
                                {
                                    properties.tagLevel++;
                                    properties.tagIndexes.Add(m.Groups[0].Index);

                                    string drawString = remainingText.Substring(0, i);
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, i);

                                    properties.colors.Add(ParseHexData(m.Groups[1].Captures[0].Value));
                                    properties.currentColor++;

                                    string centerText = m.Groups[2].Captures[0].Value;

                                    DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp);

                                    properties.colors.RemoveAt(properties.currentColor);
                                    properties.currentColor--;

                                    remainingText = remainingText.Remove(m.Groups[0].Index - drawString.Length, m.Groups[0].Length);
                                }
                                else
                                {
                                    int temp = remainingText.IndexOf(']') + 1;
                                    string drawString = remainingText.Substring(0, temp);
                                    if (drawString == "" && remainingText.Length > 1)
                                    {
                                        drawString = remainingText.Substring(0, 1);
                                        temp = 1;
                                    }
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, temp);
                                    //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                    //remainingText = "";
                                }
                                break;
                            case 'v':
                                m = variableExp.Match(remainingText);
                                z = 0;
                                if (m.Groups[0].Captures.Count > 0 && int.TryParse(m.Groups[1].Captures[0].Value, out z))
                                {
                                    string drawString = remainingText.Substring(0, i);

                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, i);

                                    int variableID = int.Parse(m.Groups[1].Captures[0].Value);
                                    string variableValue;
                                    if (GameData.Variables.ContainsKey(variableID))
                                        variableValue = GameData.Variables[variableID].Value.ToString();
                                    else
                                        variableValue = "#NoData";

                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], variableValue, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += variableValue;

                                    Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(variableValue);

                                    properties.currentPosition.X += textSize.X;

                                    remainingText = remainingText.Remove(0, m.Groups[0].Length);
                                }
                                else
                                {
                                    int temp = remainingText.IndexOf(']') + 1;
                                    string drawString = remainingText.Substring(0, temp);
                                    if (drawString == "" && remainingText.Length > 1)
                                    {
                                        drawString = remainingText.Substring(0, 1);
                                        temp = 1;
                                    }
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, temp);



                                    //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                    //remainingText = "";
                                }
                                break;
                            case 'd':
                                m = databaseExp.Match(remainingText);
                                z = 0;
                                if (m.Groups[0].Captures.Count > 0)
                                {
                                    properties.tagLevel++;
                                    properties.tagIndexes.Add(m.Groups[0].Index);

                                    string drawString = remainingText.Substring(0, i);
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, i);

                                    string[] dataValues = m.Groups[1].Captures[0].Value.Split(',');

                                    if (dataValues.Length == 3)
                                    {
                                        if (dataValues[0] != "" && dataValues[1] != "" && dataValues[2] != "")
                                        {
                                            string databaseString = "";
                                            int databaseID = int.Parse(dataValues[0]);
                                            int datasetID = int.Parse(dataValues[1]);
                                            int propertyID = int.Parse(dataValues[2]);
                                            if (GameData.Databases.ContainsKey(databaseID) && GameData.Databases[databaseID].Datas.ContainsKey(datasetID) && GameData.Databases[databaseID].Datas[datasetID].Properties.Count > propertyID)
                                            {
                                                Data db;
                                                db = GameData.Databases[databaseID];
                                                DataProperty prop = db.Datas[datasetID].Properties[propertyID];
                                                if (prop.ValueType == DataType.Text || prop.ValueType == DataType.Number)
                                                    databaseString = prop.Value.ToString();
                                                else
                                                    databaseString = "#WrongData";
                                            }
                                            else
                                                databaseString = "#NoData";

                                            spriteBatch.DrawString(properties.styles[properties.currentStyle], databaseString, properties.currentPosition, properties.colors[properties.currentColor]);

                                            properties.lines[properties.currentLine].Text += databaseString;

                                            Vector2 databaseSize = properties.styles[properties.currentStyle].MeasureString(databaseString);
                                            properties.currentPosition.X += databaseSize.X;
                                        }
                                    }

                                    remainingText = remainingText.Remove(0, m.Groups[0].Length);
                                }
                                else
                                {
                                    int temp = remainingText.IndexOf(']') + 1;
                                    string drawString = remainingText.Substring(0, temp);
                                    if (drawString == "" && remainingText.Length > 1)
                                    {
                                        drawString = remainingText.Substring(0, 1);
                                        temp = 1;
                                    }
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawString;

                                    Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                    properties.currentPosition.X += textSize.X;
                                    remainingText = remainingText.Remove(0, temp);
                                    //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                    //remainingText = "";
                                }
                                break;

                            default:
                                int y;
                                if (remainingText[i + 1] == '\n')
                                    y = i + 1;
                                else
                                    y = i + 2;
                                string drawText = remainingText.Substring(0, y);
                                spriteBatch.DrawString(properties.styles[properties.currentStyle], drawText, properties.currentPosition, properties.colors[properties.currentColor]);

                                properties.lines[properties.currentLine].Text += drawText;

                                Vector2 textSize3 = properties.styles[properties.currentStyle].MeasureString(drawText);

                                properties.currentPosition.X += textSize3.X;
                                remainingText = remainingText.Remove(0, y);
                                break;

                        }
                    }
                    else
                    {
                        spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);

                        properties.lines[properties.currentLine].Text += remainingText;

                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(remainingText);
                        if (remainingText != "")
                        {
                            textSize = properties.styles[properties.currentStyle].MeasureString(remainingText);
                            properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X + textSize.X);
                        }
                        else
                        {
                            properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X);
                        }
                        properties.currentPosition.X += textSize.X;
                        remainingText = "";

                    }
                }
            }
        }

        private void DrawError(string error)
        {

        }

        private Color ParseHexData(string hexdata)
        {
            if (hexdata.Length != 6)
                return Color.Black;

            string rtext, gtext, btext;
            int r, g, b;

            rtext = hexdata.Substring(0, 2);
            gtext = hexdata.Substring(2, 2);
            btext = hexdata.Substring(4, 2);

            bool red = int.TryParse(rtext, System.Globalization.NumberStyles.HexNumber, null, out r);
            bool green = int.TryParse(gtext, System.Globalization.NumberStyles.HexNumber, null, out g);
            bool blue = int.TryParse(btext, System.Globalization.NumberStyles.HexNumber, null, out b);

            Color c;
            if (red && blue && green)
                c = new Color((byte)r, (byte)g, (byte)b, 255);
            else
                c = Color.Black;

            return c;
        }

        private void LoadFont()
        {
            if (cbLanguages.SelectedIndex == -1) cbLanguages.SelectedIndex = 0;
            if (addRemoveList.Count > 0 && GameData.Fonts.Count > 0 && GameData.Texts[cbLanguages.Text].ContainsKey(addRemoveList.SelectedID))
            {
                int fontIndex = GetFontIndex(fontList.SelectedItem.ToString());
                if (fontIndex > -1)
                {
                    foreach (FontStyleData style in GameData.Fonts[fontIndex].Styles)
                    {
                        if (style.MaterialID > -1)
                        {
                            spriteFonts.Add(
                                Loader.SpriteFont(
                                contentManager,
                                style.MaterialID // Loads all font styles in the specified font
                                )
                                );
                        }
                    }
                }
            }
        }

        internal void ResetProject()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            SetupFontList();
            if (cbLanguages.Text != "")
                addRemoveList.SetupList(GameData.Texts[cbLanguages.Text], typeof(TextData));
            else
                addRemoveList.SetupList(GameData.Texts["English"], typeof(TextData));

            messageEditor1.Repopulate();
        }

        private void messageEditor1_Load(object sender, EventArgs e)
        {

        }




        internal void Unload()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
           
        }

        internal void Repopulate()
        {
            messageEditor1.Repopulate();
        }
    }
    public class TextProperties
    {
        public List<TextLine> lines = new List<TextLine>();
        public int currentLine = 0;

        public int tagLevel = 0;
        public List<int> tagIndexes = new List<int>();

        public List<Color> colors = new List<Color>();
        public int currentColor = 0;

        public List<SpriteFont> styles = new List<SpriteFont>();
        public int currentStyle = 0;

        public Vector2 currentPosition;
        public Vector2 basePosition;

        SpriteFont baseStyle;

        public TextProperties(SpriteFont initialStyle, Color initialColor, Vector2 initialPosition)
        {
            colors.Add(initialColor);
            styles.Add(initialStyle);
            baseStyle = initialStyle;
            currentPosition = basePosition = initialPosition;
            NewLine();
        }

        public void NewLine()
        {
            TextLine temp = new TextLine();
            temp.Styles.Add(baseStyle);
            lines.Add(temp);
        }

        public Vector2 GetSize()
        {
            int maxWidth = 0;
            int totalHeight = 0;
            foreach (TextLine line in lines)
            {
                totalHeight += line.Height;
                if (line.Width > maxWidth)
                    maxWidth = line.Width;
            }

            return new Vector2(maxWidth, totalHeight);
        }
    }

    public class TextLine
    {
        public List<SpriteFont> Styles = new List<SpriteFont>();
        public string Text = "";
        public int Width = 0;

        public int Height { get { return GetHeight(); } }

        public int GetHeight()
        {
            int maxHeight = 0;
            string t;

            if (Text == "")
                t = "I";
            else
                t = Text;

            foreach (SpriteFont font in Styles)
            {
                if (font.MeasureString(t).Y > maxHeight)
                    maxHeight = (int)font.MeasureString(t).Y;
            }
            return maxHeight;
        }
    }
}
