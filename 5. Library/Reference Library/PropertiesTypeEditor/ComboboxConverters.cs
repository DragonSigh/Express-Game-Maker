using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Controls;
using System.Windows.Forms;
using EGMGame.Dialogs;

namespace EGMGame.Library
{
    public class FontTypeConvert : UITypeEditor
    {   // this is a container for strings, which can be 
        // picked-out
        ListBox Box1 = new ListBox();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public FontTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.Click += new EventHandler(Box1_Click);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Items.Clear();
            strList = new string[GameData.Fonts.Values.Count + 1];
            List<FontData> fonts = new List<FontData>();

            strList[0] = "(none)";
            FontData f = new FontData();
            f.ID = -1;
            fonts.Add(f);

            int i = 1;
            int index = 0;
            foreach (FontData font in GameData.Fonts.Values)
            {
                strList[i] = font.Name;
                fonts.Add(font);

                if (font.ID == ((FontData)value).ID)
                {
                    index = i;
                }
                i++;
            }

            Box1.Items.AddRange(strList);
            Box1.Height = (Box1.PreferredHeight > 25 * Box1.ItemHeight ? 25 * Box1.ItemHeight : Box1.PreferredHeight);
            Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedIndex == 0)
                    return fonts[0];
                else if (Box1.SelectedIndex == -1)
                    return value;
                else
                    return fonts[Box1.SelectedIndex];

            }
            return value;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            base.PaintValue(e);
            if ((int)e.Value == -1)
                e.Graphics.DrawString("(none)", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else if (GameData.Fonts.ContainsKey((int)e.Value))
                e.Graphics.DrawString(GameData.Fonts[(int)e.Value].Name, new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else
                e.Graphics.DrawString("Font Not Found", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        private void Box1_Click(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }

    }

    public class PropertyTypeConvert : UITypeEditor
    {   // this is a container for strings, which can be 
        // picked-out
        ListBox Box1 = new ListBox();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public PropertyTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.Click += new EventHandler(Box1_Click);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Items.Clear();
            strList = new string[GameData.Databases[0].Properties.Count];
            List<DataProperty> fonts = new List<DataProperty>();

            int i = 0;
            int index = 0;
            foreach (DataProperty data in GameData.Databases[0].Properties)
            {

                if (data.ValueType == DataType.Number || data.ID < 15)
                {
                    strList[i] = data.Name;
                    fonts.Add(data);
                }

                if (data.Name == (string)value)
                {
                    index = i;
                }
                i++;
            }

            Box1.Items.AddRange(strList);
            Box1.Height = (Box1.PreferredHeight > 25 * Box1.ItemHeight ? 25 * Box1.ItemHeight : Box1.PreferredHeight);
            Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedIndex == -1)
                    return fonts[index].ID.ToString();
                else
                    return fonts[Box1.SelectedIndex].ID.ToString();

            }
            return value;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            base.PaintValue(e);
            if ((int)e.Value == -1)
                e.Graphics.DrawString("(none)", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else if (GameData.Fonts.ContainsKey((int)e.Value))
                e.Graphics.DrawString(GameData.Fonts[(int)e.Value].Name, new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else
                e.Graphics.DrawString("Property Not Found", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        private void Box1_Click(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }

    }

    public class MenuTypeConvert : UITypeEditor
    {   // this is a container for strings, which can be 
        // picked-out
        ListBox Box1 = new ListBox();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public MenuTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.Click += new EventHandler(Box1_Click);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Items.Clear();
            strList = new string[GameData.Menus.Values.Count + 1];
            List<MenuData> menus = new List<MenuData>();

            strList[0] = "(none)";
            MenuData m = new MenuData();
            m.ID = -1;
            menus.Add(m);

            int i = 1;
            int index = 0;
            foreach (MenuData menu in GameData.Menus.Values)
            {
                strList[i] = menu.Name;
                menus.Add(menu);

                if (menu.ID == ((MenuData)value).ID)
                {
                    index = i;
                }
                i++;
            }

            Box1.Items.AddRange(strList);
            Box1.Height = (Box1.PreferredHeight > 25 * Box1.ItemHeight ? 25 * Box1.ItemHeight : Box1.PreferredHeight);
            Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedIndex == 0)
                    return menus[0];
                else if (Box1.SelectedIndex == -1)
                    return value;
                else
                    return menus[Box1.SelectedIndex];

            }
            return value;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            base.PaintValue(e);
            if ((int)e.Value == -1)
                e.Graphics.DrawString("(none)", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else if (GameData.Menus.ContainsKey((int)e.Value))
                e.Graphics.DrawString(GameData.Menus[(int)e.Value].Name, new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
            else
                e.Graphics.DrawString("Font Not Found", new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(0, 0));
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        private void Box1_Click(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class VariableTypeConvert : UITypeEditor
    {// this is a container for strings, which can be 
        // picked-out
        AddRemoveListTreeView Box1 = new AddRemoveListTreeView();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public VariableTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.MouseClick += new MouseEventHandler(Box1_MouseClick);
            Box1.MouseDoubleClick += new MouseEventHandler(Box1_MouseDoubleClick);
            Box1.Category = true;
            Box1.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            Box1.ToolboxCategoryOffset = new System.Drawing.Point(20, 0);
            Box1.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            Box1.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.plus16;
            Box1.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 2);
            Box1.ToolboxExpandedImage = global::EGMGame.Properties.Resources.minus16;
            Box1.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 2);
            Box1.FullRowSelect = true;
        }



        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Nodes.Clear();


            TreeNode firstNode = null;
            TreeNode node;
            TreeNode selectedNode = null;
            int catIndex = 0;
            bool noneable = true;

            // Add All Items To list
            if (noneable)
            {
                catIndex = 1;
                VariableData an = new VariableData();
                an.ID = -1;
                an.Name = "(none)";
                node = new TreeNode(an.Name);
                node.Tag = an;
                firstNode = node;
                Box1.Nodes.Add(node);
            }

            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(VariableData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                Box1.Nodes.Add(n);
            }
            // Add All Items To list
            foreach (VariableData e in GameData.Variables.Values)
            {
                node = new TreeNode(e.Name);
                node.Tag = e;
                Box1.Nodes[e.Category + catIndex].Nodes.Add(node);
                if (firstNode == null) firstNode = node;
                if (categories[e.Category].Expand)
                    Box1.Nodes[e.Category + catIndex].Expand();

                if (e.ID == ((VariableData)value).ID)
                    selectedNode = node;
            }


            if (firstNode != null && Box1.SelectedNode == null)
                Box1.SelectedNode = firstNode;

            if (selectedNode != null) Box1.SelectedNode = selectedNode;

            Box1.Height = 200;

            //Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedNode == null)
                    return value;
                else if (Box1.SelectedNode.Tag == null)
                    return value;
                else
                    return (VariableData)Box1.SelectedNode.Tag;

            }
            return value;
        }

        void Box1_MouseClick(object sender, MouseEventArgs e)
        {
            //int height = 0;

            //foreach (TreeNode node in Box1.Nodes)
            //{
            //    height += node.Bounds.Height;

            //    if (node.IsExpanded)
            //    {
            //        foreach (TreeNode cNode in node.Nodes)
            //        {
            //            height += cNode.Bounds.Height;
            //        }
            //    }
            //}
            //Box1.Height = Math.Min(height, 200);
        }

        void Box1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class StringTypeConvert : UITypeEditor
    {// this is a container for strings, which can be 
        // picked-out
        AddRemoveListTreeView Box1 = new AddRemoveListTreeView();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public StringTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.MouseClick += new MouseEventHandler(Box1_MouseClick);
            Box1.MouseDoubleClick += new MouseEventHandler(Box1_MouseDoubleClick);
            Box1.Category = true;
            Box1.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            Box1.ToolboxCategoryOffset = new System.Drawing.Point(20, 0);
            Box1.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            Box1.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.plus16;
            Box1.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 2);
            Box1.ToolboxExpandedImage = global::EGMGame.Properties.Resources.minus16;
            Box1.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 2);
            Box1.FullRowSelect = true;
        }



        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Nodes.Clear();


            TreeNode firstNode = null;
            TreeNode node;
            TreeNode selectedNode = null;
            int catIndex = 0;
            bool noneable = true;

            // Add All Items To list
            if (noneable)
            {
                catIndex = 1;
                StringData an = new StringData();
                an.ID = -1;
                an.Name = "(none)";
                node = new TreeNode(an.Name);
                node.Tag = an;
                firstNode = node;
                Box1.Nodes.Add(node);
            }

            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(StringData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                Box1.Nodes.Add(n);
            }
            // Add All Items To list
            foreach (StringData e in GameData.Strings.Values)
            {
                node = new TreeNode(e.Name);
                node.Tag = e;
                Box1.Nodes[e.Category + catIndex].Nodes.Add(node);
                if (firstNode == null) firstNode = node;
                if (categories[e.Category].Expand)
                    Box1.Nodes[e.Category + catIndex].Expand();

                if (e.ID == ((StringData)value).ID)
                    selectedNode = node;
            }


            if (firstNode != null && Box1.SelectedNode == null)
                Box1.SelectedNode = firstNode;

            if (selectedNode != null) Box1.SelectedNode = selectedNode;

            Box1.Height = 200;

            //Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedNode == null)
                    return value;
                else if (Box1.SelectedNode.Tag == null)
                    return value;
                else
                    return (StringData)Box1.SelectedNode.Tag;

            }
            return value;
        }

        void Box1_MouseClick(object sender, MouseEventArgs e)
        {
            //int height = 0;

            //foreach (TreeNode node in Box1.Nodes)
            //{
            //    height += node.Bounds.Height;

            //    if (node.IsExpanded)
            //    {
            //        foreach (TreeNode cNode in node.Nodes)
            //        {
            //            height += cNode.Bounds.Height;
            //        }
            //    }
            //}
            //Box1.Height = Math.Min(height, 200);
        }

        void Box1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class SkinTypeConvert : UITypeEditor
    {// this is a container for strings, which can be 
        // picked-out
        ListBox Box1 = new ListBox();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public SkinTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.Click += new EventHandler(Box1_Click);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Items.Clear();
            strList = new string[GameData.Skins.Values.Count + 1];
            List<SkinData> fonts = new List<SkinData>();

            strList[0] = "(none)";
            SkinData f = new SkinData();
            f.ID = -1;
            fonts.Add(f);

            int i = 1;
            int index = 0;
            foreach (SkinData font in GameData.Skins.Values)
            {
                strList[i] = font.Name;
                fonts.Add(font);

                if (font.ID == ((SkinData)value).ID)
                {
                    index = i;
                }
                i++;
            }

            Box1.Items.AddRange(strList);
            Box1.Height = (Box1.PreferredHeight > 25 * Box1.ItemHeight ? 25 * Box1.ItemHeight : Box1.PreferredHeight);
            Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedIndex == 0)
                    return fonts[0];
                else if (Box1.SelectedIndex == -1)
                    return value;
                else
                    return fonts[Box1.SelectedIndex];

            }
            return value;
        }

        private void Box1_Click(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class ListTypeConvert : UITypeEditor
    {// this is a container for strings, which can be 
        // picked-out
        AddRemoveListTreeView Box1 = new AddRemoveListTreeView();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public ListTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.MouseClick += new MouseEventHandler(Box1_MouseClick);
            Box1.MouseDoubleClick += new MouseEventHandler(Box1_MouseDoubleClick);
            Box1.Category = true;
            Box1.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            Box1.ToolboxCategoryOffset = new System.Drawing.Point(20, 0);
            Box1.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            Box1.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.plus16;
            Box1.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 2);
            Box1.ToolboxExpandedImage = global::EGMGame.Properties.Resources.minus16;
            Box1.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 2);
            Box1.FullRowSelect = true;
        }



        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Nodes.Clear();


            TreeNode firstNode = null;
            TreeNode node;
            TreeNode selectedNode = null;
            int catIndex = 0;
            bool noneable = true;

            // Add All Items To list
            if (noneable)
            {
                catIndex = 1;
                ListData an = new ListData();
                an.ID = -1;
                an.Name = "(none)";
                node = new TreeNode(an.Name);
                node.Tag = an;
                firstNode = node;
                Box1.Nodes.Add(node);
            }

            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(ListData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                Box1.Nodes.Add(n);
            }
            // Add All Items To list
            foreach (ListData e in GameData.Lists.Values)
            {
                node = new TreeNode(e.Name);
                node.Tag = e;
                Box1.Nodes[e.Category + catIndex].Nodes.Add(node);
                if (firstNode == null) firstNode = node;
                if (categories[e.Category].Expand)
                    Box1.Nodes[e.Category + catIndex].Expand();

                if (e.ID == ((ListData)value).ID)
                    selectedNode = node;
            }


            if (firstNode != null && Box1.SelectedNode == null)
                Box1.SelectedNode = firstNode;

            if (selectedNode != null) Box1.SelectedNode = selectedNode;

            Box1.Height = 200;

            //Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                if (Box1.SelectedNode == null)
                    return value;
                else if (Box1.SelectedNode.Tag == null)
                    return value;
                else
                    return (ListData)Box1.SelectedNode.Tag;

            }
            return value;
        }

        void Box1_MouseClick(object sender, MouseEventArgs e)
        {
            //int height = 0;

            //foreach (TreeNode node in Box1.Nodes)
            //{
            //    height += node.Bounds.Height;

            //    if (node.IsExpanded)
            //    {
            //        foreach (TreeNode cNode in node.Nodes)
            //        {
            //            height += cNode.Bounds.Height;
            //        }
            //    }
            //}
            //Box1.Height = Math.Min(height, 200);
        }

        void Box1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class AnimationTypeConvert : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                AnimationListDialog dialog = new AnimationListDialog();
                dialog.SelectedAnimation = ((AnimationData)value).ID;

                if (context.Instance is AnimationPartStatic)
                {
                    dialog.SelectedAction = ((AnimationPartStatic)context.Instance).Action;
                }

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    value = dialog.Animation;
                    if (context.Instance is AnimationPartStatic)
                    {
                        ((AnimationPartStatic)context.Instance).Action = dialog.SelectedAction;
                    }
                }
            }
            return value;
        }
    }

    public class DirectionTypeConvert : UITypeEditor
    {// this is a container for strings, which can be 
        // picked-out
        ListBox Box1 = new ListBox();
        IWindowsFormsEditorService edSvc;
        // this is a string array for drop-down list
        public static string[] strList;

        public DirectionTypeConvert()
        {
            Box1.BorderStyle = BorderStyle.None;
            // add event handler for drop-down box when item 
            // will be selected
            Box1.Click += new EventHandler(Box1_Click);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        // Displays the UI for value selection.
        public override object EditValue
           (System.ComponentModel.ITypeDescriptorContext
           context, System.IServiceProvider provider,
           object value)
        {
            Box1.Items.Clear();
            strList = new string[] 
            {   
                "Up",
                "Down",
                "Left",
                "Right",
                "Up/Left",
                "Up/Right",
                "Down/Left",
                "Down/Right"
            };
            int index = 0;

            switch ((string)value)
            {
                case "Up":
                    index = 0;
                    break;
                case "Down":
                    index = 1;
                    break;
                case "Left":
                    index = 2;
                    break;
                case "Right":
                    index = 3;
                    break;
                case "Up/Left":
                    index = 4;
                    break;
                case "Up/Right":
                    index = 5;
                    break;
                case "Down/Left":
                    index = 6;
                    break;
                case "Down/Right":
                    index = 7;
                    break;
            }

            Box1.Items.AddRange(strList);
            Box1.Height = (Box1.PreferredHeight > 25 * Box1.ItemHeight ? 25 * Box1.ItemHeight : Box1.PreferredHeight);
            Box1.SelectedIndex = index;
            // Uses the IWindowsFormsEditorService to 
            // display a drop-down UI in the Properties 
            // window.
            edSvc =
               (IWindowsFormsEditorService)provider.
               GetService(typeof
               (IWindowsFormsEditorService));
            if (edSvc != null)
            {
                edSvc.DropDownControl(Box1);
                value = Box1.Text;
                return value;

            }
            return value;
        }

        private void Box1_Click(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }

    public class MaterialTypeConvert : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }


        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                if (MainForm.chooseMaterialDialog == null)
                    MainForm.chooseMaterialDialog = new EGMGame.Dialogs.ChooseMaterialDialog();
                MainForm.chooseMaterialDialog.Setup(((MaterialData)value).ID);

                MainForm.chooseMaterialDialog.ShowDialog();
                if (MainForm.chooseMaterialDialog.IsOK)
                {
                    value = MainForm.chooseMaterialDialog.Data();
                }
            }
            return value;
        }

    }

    public class DatabaseTypeConvert : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                DatabaseDialog dialog;
                if (context.Instance is TextPartSource)
                {
                    dialog = new DatabaseDialog(new List<DataType>() { DataType.Number, DataType.Text });
                    TextPartSource data = (TextPartSource)context.Instance;
                    dialog.Setup(data.Database, data.Data, data.Property);
                }
                else
                {
                    dialog = new DatabaseDialog(new List<DataType>());
                }

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (context.Instance is TextPartSource)
                    {
                        TextPartSource data = (TextPartSource)context.Instance;
                        data.Database = dialog.databaseBox.Data().ID;
                        data.Data = dialog.dataBox.Data().ID;
                        data.Property = dialog.propertyBox.Data().ID;
                    }
                }
            }
            return value;
        }
    }

    public class AnimationTileConvert : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                AnimatedTileDialog dialog = new AnimatedTileDialog();

                dialog.SetupTile(((TileData)context.Instance));


                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    value = dialog.animation;
                }
            }
            return value;
        }
    }
}
