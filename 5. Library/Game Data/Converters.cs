//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EGMGame.Library;
using System.Windows.Forms.Design;

namespace EGMGame.Library
{

    public class SEListConverter : StringConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, but allow free-form entry
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] s = new string[Global.GetSECount()];

            s[0] = "None";
            int i = 1;
            foreach (AudioData d in GameData.Audios.Values)
                    s[i] = d.Name; i++;
            return new StandardValuesCollection(s);
        }
    }

}
