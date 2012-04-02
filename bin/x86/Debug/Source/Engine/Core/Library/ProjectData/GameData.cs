//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using System.IO;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    
    public class GameData
    {
        public static Dictionary<int, AnimationData> Animations;
        public static  Dictionary<int, AudioData> Audios;
        public static Dictionary<int, SkinData> Skins;
        public static Dictionary<int, TilesetData> Tilesets;
        public static Dictionary<int, TextData> Texts
        {
            get
            {
                if (texts == null)
                {
                    // Loading Texts                    
                    string lang = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

#if WINDOWS
    #if VISUAL
                    if (File.Exists(Directory.GetParent(Global.ContentManager.RootDirectory).FullName + @"\Texts." + lang + ".egm"))
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts." + lang + ".egm");
                    else
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts.en.egm");
    #else
                    if (Global.Assembly.GetManifestResourceNames().Contains("Texts." + lang + ".egm"))
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts." + lang + ".egm");
                    else
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts.eng.egm");    

    #endif
#elif XBOX
                    if (File.Exists(Global.ContentManager.RootDirectory + @"\Texts." + lang + ".egm"))
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts." + lang + ".egm");
                    else
                        texts = Marshal.LoadData<Dictionary<int, TextData>>("Texts.eng.egm");
#elif SILVERLIGHT
 
#endif
                }
                return texts;
            }
            set { texts = value; }
        }
        static Dictionary<int, TextData> texts = new Dictionary<int, TextData>();
        public static Dictionary<int, FontData> Fonts;
        public static Dictionary<int, Data> Databases;
        public static Dictionary<int, EventData> Events;
        public static Dictionary<int, GlobalEventData> GlobalEvents;
        public static Dictionary<int, VariableData> Variables;
        public static Dictionary<int, StringData> Strings;
        public static Dictionary<int, SwitchData> Switches;
        public static Dictionary<int, MapData> Scenes;
        public static Dictionary<int, ListData> Lists;
        public static Dictionary<int, MenuData> Menus;
        public static Dictionary<int, IMenuParts> MenuParts;
        public static Dictionary<int, ItemData> Items;
        public static Dictionary<int, MaterialData> Materials;
        public static Dictionary<int, ParticleSystemData> ParticleSystems;
        public static Dictionary<int, HeroData> Heroes;
        public static Dictionary<int, EnemyData> Enemies;
        public static Dictionary<int, StateData> States;
        public static Dictionary<int, EquipmentData> Equipments;
        public static Dictionary<int, SkillData> Skills;
        public static Dictionary<int, ProjectileGroupData> Projectiles
        {
            get { return projectiles; }
            set { projectiles = value; }
        }
        static Dictionary<int, ProjectileGroupData> projectiles = new Dictionary<int, ProjectileGroupData>();
        public static Dictionary<int, ComboData> Combos;
        public static PlayerData Player;
    }
}
