//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//* Graphics Helper
//* Contains methods for drawing shapes and text. Also contains a blank texture that can
//* be reusable for drawing operations.
namespace EGMGame.Extensions
{
    public class GraphicsHelper
    {
        public static Texture2D Texture = CreateTexture();
        public static Texture2D LastTexture = null;
        public static int LastTextureID = -10;
        static List<SpriteFont> spriteFonts = new List<SpriteFont>();
        static TextProperties properties = new TextProperties();
        // RegEx Templates: 
        //
        // 2 Value (Variable and Text) e.g. [url=x]blah[/x]. ($) Group1 = variable, ($) Group2 = text
        //    new Regex(@"\[tag=([^\]]+)\]([^\]]+)\[\/tag\]");
        //
        // Single Value (Text only) e.g. [Tag]Text[/Tag]. $1 = text
        //     new Regex(@"\[u\](.+?)\[\/u\]");
        public static Regex stringExp = new Regex(@"\[t=(\d+)\]");
        public static Regex styleExp = new Regex(@"\[s=([^\]]+)\](.+)\[\/s\]", RegexOptions.Singleline); //@"\[s=([^\]]+)\]([^\]]+)\[\/s\]");
        public static Regex colorExp = new Regex(@"\[c=([0-9a-fA-F]{6})\](.+)\[\/c\]", RegexOptions.Singleline); //@"\[c=([0-9a-fA-F]{6})\]([^\]]+)\[\/c\]");//new Regex(@"\[c=([^\]]+)\]([^\]]+)\[\/c\]");            
        public static Regex variableExp = new Regex(@"\[v=(\d+)\]");
        public static Regex databaseExp = new Regex(@"\[d=(\d+[,]\d+[,]\d+)\]");

        public static Regex tags = new Regex(@"\[s=([^\]]+)\]|\[\/s\]|\[c=([0-9a-fA-F]{6})\]|\[\/c\]");

        /// <summary>
        /// Creates a static texture that can be re used.
        /// </summary>
        /// <returns></returns>
        private static Texture2D CreateTexture()
        {
            Texture2D texture = new Texture2D(Global.Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            // Set the color data and make the sprite texture pure white 
            texture.SetData<Color>(new Color[] { Color.White });

            return texture;
        }
        /// <summary>
        /// Gradient
        /// </summary>
        /// <param name="ColorTop"></param>
        /// <param name="ColorBottom"></param>
        public static void FillGradient(Rectangle rect, Color ColorTop, Color ColorBottom)
        {
            // Store the screen width and height into here. 
            // These values are used in 'texture', forloop,  
            // and used in the color function. 
            // 
            // You could change this in anyway you seem fit! 
            int width = rect.Width;
            int height = rect.Height;

            // Init all ColorTop & ColorBottom values.  
            float R1 = ColorTop.R, R2 = ColorBottom.R; // Red 
            float G1 = ColorTop.G, G2 = ColorBottom.G; // Green 
            float B1 = ColorTop.B, B2 = ColorBottom.B; // Blue 
            float A1 = ColorTop.A, A2 = ColorBottom.A; // Alpha

            // Make a forloop that goes from the top of the 
            // screen to the bottom of the screen 
            for (int i = 0; i < height; i++)
            {
                // This color function to make the top colors 
                // blend with the bottom colors gradually. 
                // 
                // This also works for alpha too! You can make the bottom 
                // or top trasparent! 
                float a = (A1 + (i * (A2 - A1) / height)) / 255; // Aplha Channels 
                float r = (R1 + (i * (R2 - R1) / height)) / 255; // Red Colors 
                float g = (G1 + (i * (G2 - G1) / height)) / 255; // Green Colors 
                float b = (B1 + (i * (B2 - B1) / height)) / 255; // Blue Colors 

                // Put all colors into 'colordata' 
                Color color = new Color(r, g, b, a);
                color *= a;
                // Draw the spriteline on the screen with the color data 
                Global.SpriteBatch.Draw(Texture,           // Texture 
                    new Vector2(rect.X, rect.Y + i),              // Position 
                    new Rectangle(0, 0, width, 1), // Coverage Area 
                    color);                     // Color 
            }
        }
        /// <summary>
        /// Fill Rectangle
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="spriteBatch"></param>
        public static void FillRectangle(Texture2D texture, Vector2 position, Vector2 size, Color color)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int height = (int)size.Y;
            int width = (int)size.X;
            Global.SpriteBatch.Draw(texture, new Rectangle(x, y, width, height), color);

        }
        /// <summary>
        /// Fill Rectangle
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="spriteBatch"></param>
        public static void FillRectangle(Texture2D texture, Rectangle rect, Color color)
        {
            Global.SpriteBatch.Draw(texture, rect, color);
        }
        /// <summary>
        /// Draw Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="borderColor"></param>
        /// <param name="priority"></param>
        public static void DrawRectangle(Texture2D texture, Rectangle rectangle, Color borderColor)
        {
            // Top Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), borderColor, 1, texture);
            // Right Side
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, 1, texture);
            // Bottom Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, 1, texture);
            // Left Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), borderColor, 1, texture);
        }
        /// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
        public static void DrawLine(Vector2 PointA, Vector2 PointB, Color color, int thickness, Texture2D texture)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            float rotation;

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            Global.SpriteBatch.Draw(texture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, thickness), null, color, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }


        #region Draw Text
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="style"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public static Vector2 DrawText(FontData font, FontStyleData style, string text, Vector2 position, Color color)
        {
            if (font != null)
            {
                LoadFont(font);
                properties.Setup(Content.SpriteFont(style.MaterialID), color, position);

                return ProcessAndDraw(text);
            }
            return Vector2.Zero;
        }

        private static Vector2 ProcessAndDraw(string text)
        {
            int styleTagCount = 0;
            Match startStyleTag = null;
            Match endStyleTag = null;
            int currentPosition = 0;
            if (text == null) text = "";
            MatchCollection tagCollection = tags.Matches(text, 0);
            for (int t = 0; t < tagCollection.Count; t++)
            {
                if (currentPosition - tagCollection[t].Index != 0 && styleTagCount == 0)
                    DrawParsedText(text.Substring(currentPosition, tagCollection[t].Index - currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                if (!tagCollection[t].Value.Contains('/'))
                {
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index;
                        startStyleTag = tagCollection[t];
                    }
                    styleTagCount++;
                }
                else
                {
                    styleTagCount--;
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index + tagCollection[t].Length;
                        endStyleTag = tagCollection[t];
                    }
                }

                if (styleTagCount == 0 && startStyleTag != null && endStyleTag != null)
                {
                    string substr = text.Substring(startStyleTag.Index, (endStyleTag.Index + endStyleTag.Length) - startStyleTag.Index);
                    //ProcessAndDraw(Global.SpriteBatch, substr);
                    DrawParsedText(substr, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
                    startStyleTag = null;
                    endStyleTag = null;
                }
            }
            if (styleTagCount != 0 || tagCollection.Count == 0 || currentPosition < text.Length)
            {
                DrawParsedText(text.Substring(currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
            }
            return properties.GetSize();
        }

        public static void DrawParsedText(string text, TextProperties properties, Regex styleExp, Regex colorExp, Regex variableExp, Regex databaseExp, Regex stringExp)
        {
            string remainingText = text;

            if (!string.IsNullOrEmpty(text))
            {
                while (remainingText.Length > 0)
                {
                    int i = remainingText.IndexOf('[');
                    int x = remainingText.IndexOf('\n');
                    if (x != -1 && x < i || (i == -1 && x != -1))
                    {
                        properties.NewLine();

                        string drawString = remainingText.Substring(0, x);
                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

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
                        properties.NewLine();
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
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        properties.tagLevel++;
                                        properties.tagIndexes.Add(m.Groups[0].Index);

                                        string drawString = remainingText.Substring(0, i);
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

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

                                            ProcessAndDraw(centerText);
                                            //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                                            properties.styles.RemoveAt(properties.currentStyle);
                                            properties.currentStyle--;
                                        }
                                        else
                                        {
                                            string centerText = m.Groups[2].Captures[0].Value;
                                            ProcessAndDraw(centerText);
                                            //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        properties.colors.Add(ParseHexData(m.Groups[1].Captures[0].Value));
                                        properties.currentColor++;

                                        string centerText = m.Groups[2].Captures[0].Value;

                                        ProcessAndDraw(centerText);
                                        //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 'v':
                                    m = variableExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);

                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

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

                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], variableValue, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += variableValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(variableValue);

                                        properties.currentPosition.X += textSize2.X;

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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



                                        //Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 't':
                                    m = stringExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);

                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        int stringID = int.Parse(m.Groups[1].Captures[0].Value);
                                        string stringValue;
                                        if (Global.Instance.Strings.ContainsKey(stringID))
                                            stringValue = Global.Instance.Strings[stringID].Value.ToString();
                                        else
                                            stringValue = "#NoData";

                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], stringValue, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += stringValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(stringValue);

                                        properties.currentPosition.X += textSize2.X;

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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



                                        //Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

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

                                                Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], databaseString, properties.currentPosition, properties.colors[properties.currentColor]);

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
                                        Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
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
                                    Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], drawText, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawText;

                                    Vector2 textSize3 = properties.styles[properties.currentStyle].MeasureString(drawText);

                                    properties.currentPosition.X += textSize3.X;
                                    remainingText = remainingText.Remove(0, y);
                                    break;

                            }
                        }
                        else
                        {
                            Global.SpriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);

                            if (properties.currentLine >= properties.lines.Count)
                                properties.NewLine();

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
        }

        /// <summary>
        /// Instead of drawing the text, gets its size.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="style"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Vector2 GetTextSize(FontData font, FontStyleData style, string text)
        {
            if (font != null)
            {
                LoadFont(font);
                properties.Setup(Content.SpriteFont(style.MaterialID), Color.Black, Vector2.Zero);

                return GetTextSize(text, properties, styleExp, colorExp, variableExp, databaseExp);
            }
            return Vector2.Zero;
        }
        /// <summary>
        /// Instead of drawing the text, gets its size.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="properties"></param>
        /// <param name="styleExp"></param>
        /// <param name="colorExp"></param>
        /// <param name="variableExp"></param>
        /// <param name="databaseExp"></param>
        /// <returns></returns>
        private static Vector2 GetTextSize(string text, TextProperties properties, Regex styleExp, Regex colorExp, Regex variableExp, Regex databaseExp)
        {
            int styleTagCount = 0;
            Match startStyleTag = null;
            Match endStyleTag = null;
            int currentPosition = 0;
            MatchCollection tagCollection = tags.Matches(text, 0);
            for (int t = 0; t < tagCollection.Count; t++)
            {
                if (currentPosition - tagCollection[t].Index != 0 && styleTagCount == 0)
                    GetTextSize(text.Substring(currentPosition, tagCollection[t].Index - currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                if (!tagCollection[t].Value.Contains('/'))
                {
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index;
                        startStyleTag = tagCollection[t];
                    }
                    styleTagCount++;
                }
                else
                {
                    styleTagCount--;
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index + tagCollection[t].Length;
                        endStyleTag = tagCollection[t];
                    }
                }

                if (styleTagCount == 0 && startStyleTag != null && endStyleTag != null)
                {
                    string substr = text.Substring(startStyleTag.Index, (endStyleTag.Index + endStyleTag.Length) - startStyleTag.Index);
                    //ProcessAndDraw(Global.SpriteBatch, substr);
                    GetTextSize(substr, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
                    startStyleTag = null;
                    endStyleTag = null;
                }
            }
            if (styleTagCount != 0 || tagCollection.Count == 0 || currentPosition < text.Length)
            {
                GetTextSize(text.Substring(currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
            }
            return properties.GetSize();
        }

        public static void GetTextSize(string text, TextProperties properties, Regex styleExp, Regex colorExp, Regex variableExp, Regex databaseExp, Regex stringExp)
        {
            string remainingText = text;

            if (!string.IsNullOrEmpty(text))
            {
                while (remainingText.Length > 0)
                {
                    int i = remainingText.IndexOf('[');
                    int x = remainingText.IndexOf('\n');
                    if (x != -1 && x < i || (i == -1 && x != -1))
                    {
                        properties.NewLine();

                        string drawString = remainingText.Substring(0, x);

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
                        properties.NewLine();
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
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        properties.tagLevel++;
                                        properties.tagIndexes.Add(m.Groups[0].Index);

                                        string drawString = remainingText.Substring(0, i);
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

                                            GetTextSize(centerText);
                                            //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                                            properties.styles.RemoveAt(properties.currentStyle);
                                            properties.currentStyle--;
                                        }
                                        else
                                        {
                                            string centerText = m.Groups[2].Captures[0].Value;
                                            GetTextSize(centerText);
                                            //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
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

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
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

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        properties.colors.Add(ParseHexData(m.Groups[1].Captures[0].Value));
                                        properties.currentColor++;

                                        string centerText = m.Groups[2].Captures[0].Value;

                                        GetTextSize(centerText);
                                        //DrawParsedText(Global.SpriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

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

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //remainingText = "";
                                    }
                                    break;
                                case 'v':
                                    m = variableExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);

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


                                        properties.lines[properties.currentLine].Text += variableValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(variableValue);

                                        properties.currentPosition.X += textSize2.X;

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
                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



                                        //remainingText = "";
                                    }
                                    break;
                                case 't':
                                    m = stringExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);


                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        int stringID = int.Parse(m.Groups[1].Captures[0].Value);
                                        string stringValue;
                                        if (GameData.Strings.ContainsKey(stringID))
                                            stringValue = GameData.Strings[stringID].Value.ToString();
                                        else
                                            stringValue = "#NoData";


                                        properties.lines[properties.currentLine].Text += stringValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(stringValue);

                                        properties.currentPosition.X += textSize2.X;

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

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



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

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
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

                                    properties.lines[properties.currentLine].Text += drawText;

                                    Vector2 textSize3 = properties.styles[properties.currentStyle].MeasureString(drawText);

                                    properties.currentPosition.X += textSize3.X;
                                    remainingText = remainingText.Remove(0, y);
                                    break;

                            }
                        }
                        else
                        {

                            if (properties.currentLine >= properties.lines.Count)
                                properties.NewLine();

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
        }

        private static Vector2 GetTextSize(string text)
        {
            int styleTagCount = 0;
            Match startStyleTag = null;
            Match endStyleTag = null;
            int currentPosition = 0;
            MatchCollection tagCollection = tags.Matches(text, 0);
            for (int t = 0; t < tagCollection.Count; t++)
            {
                if (currentPosition - tagCollection[t].Index != 0 && styleTagCount == 0)
                    GetTextSize(text.Substring(currentPosition, tagCollection[t].Index - currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                if (!tagCollection[t].Value.Contains('/'))
                {
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index;
                        startStyleTag = tagCollection[t];
                    }
                    styleTagCount++;
                }
                else
                {
                    styleTagCount--;
                    if (styleTagCount == 0)
                    {
                        currentPosition = tagCollection[t].Index + tagCollection[t].Length;
                        endStyleTag = tagCollection[t];
                    }
                }

                if (styleTagCount == 0 && startStyleTag != null && endStyleTag != null)
                {
                    string substr = text.Substring(startStyleTag.Index, (endStyleTag.Index + endStyleTag.Length) - startStyleTag.Index);
                    //ProcessAndDraw(Global.SpriteBatch, substr);
                    GetTextSize(substr, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
                    startStyleTag = null;
                    endStyleTag = null;
                }
            }
            if (styleTagCount != 0 || tagCollection.Count == 0 || currentPosition < text.Length)
            {
                GetTextSize(text.Substring(currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
            }
            return properties.GetSize();
        }

        private static Color ParseHexData(string hexdata)
        {
            if (hexdata.Length != 6)
                return Color.Black;

            string rtext, gtext, btext;
            int r, g, b;

            rtext = hexdata.Substring(0, 2);
            gtext = hexdata.Substring(2, 2);
            btext = hexdata.Substring(4, 2);

            bool red = TryParse(rtext, System.Globalization.NumberStyles.HexNumber, null, out r);
            bool green = TryParse(gtext, System.Globalization.NumberStyles.HexNumber, null, out g);
            bool blue = TryParse(btext, System.Globalization.NumberStyles.HexNumber, null, out b);

            Color c;
            if (red && blue && green)
                c = new Color((byte)r, (byte)g, (byte)b, 255);
            else
                c = Color.Black;

            return c;
        }

        private static bool TryParse(string p, out int z)
        {
#if WINDOWS || SILVERLIGHT
            return int.TryParse(p, out z);
#elif XBOX
            z = int.Parse(p);
            return true;
#endif
        }

        private static bool TryParse(string p, System.Globalization.NumberStyles style, IFormatProvider format, out int result)
        {
#if WINDOWS || SILVERLIGHT
            return int.TryParse(p, style, format, out result);
#elif XBOX
            result = int.Parse(p, style, format);
            return true;
#endif
        }

        public static void LoadFont(FontData font)
        {
            spriteFonts.Clear();
            for (int i = 0; i < font.Styles.Count; i++)
            {
                if (font.Styles[i].MaterialID > -1)
                {
                    spriteFonts.Add(
                        Content.SpriteFont(font.Styles[i].MaterialID)
                        );
                }
            }
        }
        #endregion


    }

    public class DrawToTexture
    {
        static List<Vector2> positions = new List<Vector2>();
        static List<Texture2D> textures = new List<Texture2D>();
        public static void AddTexture(Texture2D tex, Vector2 position)
        {
            textures.Add(tex);
            positions.Add(position);
        }
        public static void Clear()
        {
            textures.Clear();
            positions.Clear();
        }

        public static Texture2D GetTexture(GraphicsDevice device, SpriteBatch sprite, int w, int h)
        {
            RenderTarget2D renderTarget;
            PresentationParameters pp = device.PresentationParameters;
            renderTarget = new RenderTarget2D(device, w, h, true, device.DisplayMode.Format, DepthFormat.Depth24);
            device.SetRenderTarget(renderTarget);

            device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);

            sprite.Begin();
            for (int i = 0; i < textures.Count; i++)
            {
                sprite.Draw(textures[i], positions[i], null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
            }
            sprite.End();

            device.SetRenderTarget(null);
            return (Texture2D)renderTarget;
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

        public TextProperties()
        {
        }

        public void Setup(SpriteFont initialStyle, Color initialColor, Vector2 initialPosition)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Reset();
            }
            currentLine = 0;
            tagLevel = 0;
            tagIndexes.Clear();
            colors.Clear();
            currentColor = 0;
            styles.Clear();
            currentStyle = 0;

            colors.Add(initialColor);
            styles.Add(initialStyle);
            baseStyle = initialStyle;
            currentPosition = basePosition = initialPosition;
            NewLine();
        }

        public void NewLine()
        {
            if (currentLine >= lines.Count)
            {
                TextLine temp = new TextLine();
                temp.Styles.Add(baseStyle);
                lines.Add(temp);
            }
            else
            {
                lines[currentLine].Reset();
                lines[currentLine].Styles.Add(baseStyle);
            }
        }

        public Vector2 GetSize()
        {
            int maxWidth = 0;
            int totalHeight = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                totalHeight += lines[i].Height;
                if (lines[i].Width > maxWidth)
                    maxWidth = lines[i].Width;
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

            for (int i = 0; i < Styles.Count; i++)
            {
                if (Styles[i].MeasureString(t).Y > maxHeight)
                    maxHeight = (int)Styles[i].MeasureString(t).Y;
            }
            return maxHeight;
        }

        internal void Reset()
        {
            Styles.Clear();
            Text = "";
            Width = 0;
        }
    }
}
