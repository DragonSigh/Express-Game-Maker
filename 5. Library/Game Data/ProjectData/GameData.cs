//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

namespace EGMGame.Library
{
    [Serializable]
    public class GameData
    {
        public static Dictionary<int, AnimationData> Animations
        {
            get { return animations; }
            set { animations = value; }
        }
        static Dictionary<int, AnimationData> animations = new Dictionary<int, AnimationData>();

        public static Dictionary<int, AudioData> Audios
        {
            get { return audios; }
            set { audios = value; }
        }
        static Dictionary<int, AudioData> audios = new Dictionary<int, AudioData>();

        public static Dictionary<int, TilesetData> Tilesets
        {
            get { return tilesets; }
            set { tilesets = value; }
        }
        static Dictionary<int, TilesetData> tilesets = new Dictionary<int, TilesetData>();

        public static Dictionary<string, Dictionary<int, TextData>> Texts
        {
            get { return texts; }
            set { texts = value; }
        }
        static Dictionary<string, Dictionary<int, TextData>> texts = new Dictionary<string, Dictionary<int, TextData>>() 
        { 
            {"English", new Dictionary<int, TextData>()}
        };

        public static Dictionary<int, FontData> Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }
        static Dictionary<int, FontData> fonts = new Dictionary<int, FontData>();

        public static Dictionary<int, Data> Databases
        {
            get { return databases; }
            set { databases = value; }
        }
        static Dictionary<int, Data> databases = new Dictionary<int, Data>();

        public static Dictionary<int, EventData> Events
        {
            get { return events; }
            set { events = value; }
        }
        static Dictionary<int, EventData> events = new Dictionary<int, EventData>();

        public static Dictionary<int, GlobalEventData> GlobalEvents
        {
            get { return gevents; }
            set { gevents = value; }
        }
        static Dictionary<int, GlobalEventData> gevents = new Dictionary<int, GlobalEventData>();

        public static Dictionary<int, VariableData> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
        static Dictionary<int, VariableData> variables = new Dictionary<int, VariableData>();

        public static Dictionary<int, StringData> Strings
        {
            get { return strings; }
            set { strings = value; }
        }
        static Dictionary<int, StringData> strings = new Dictionary<int, StringData>();

        public static Dictionary<int, SwitchData> Switches
        {
            get { return switches; }
            set { switches = value; }
        }
        static Dictionary<int, SwitchData> switches = new Dictionary<int, SwitchData>();

        public static Dictionary<int, MapData> Maps
        {
            get { return maps; }
            set { maps = value; }
        }
        static Dictionary<int, MapData> maps = new Dictionary<int, MapData>();

        public static Dictionary<int, ListData> Lists
        {
            get { return lists; }
            set { lists = value; }
        }
        static Dictionary<int, ListData> lists = new Dictionary<int, ListData>();

        public static Dictionary<int, MenuData> Menus
        {
            get { return menus; }
            set { menus = value; }
        }
        static Dictionary<int, MenuData> menus = new Dictionary<int, MenuData>();

        public static Dictionary<int, IMenuParts> MenuParts
        {
            get { return menuParts; }
            set { menuParts = value; }
        }
        static Dictionary<int, IMenuParts> menuParts = new Dictionary<int, IMenuParts>();

        public static Dictionary<int, ItemData> Items
        {
            get { return items; }
            set { items = value; }
        }
        static Dictionary<int, ItemData> items = new Dictionary<int, ItemData>();

        public static Dictionary<int, MaterialData> Materials
        {
            get { return materials; }
            set { materials = value; }
        }
        static Dictionary<int, MaterialData> materials = new Dictionary<int, MaterialData>();

        public static Dictionary<int, ParticleSystemData> ParticleSystems
        {
            get { return particleSystems; }
            set { particleSystems = value; }
        }
        static Dictionary<int, ParticleSystemData> particleSystems = new Dictionary<int, ParticleSystemData>();

        public static Dictionary<int, SkinData> Skins
        {
            get { return skins; }
            set { skins = value; }
        }
        static Dictionary<int, SkinData> skins = new Dictionary<int, SkinData>();


        public static Dictionary<int, HeroData> Heroes
        {
            get { return heroes; }
            set { heroes = value; }
        }
        static Dictionary<int, HeroData> heroes = new Dictionary<int, HeroData>();

        public static Dictionary<int, EnemyData> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        static Dictionary<int, EnemyData> enemies = new Dictionary<int, EnemyData>();


        public static Dictionary<int, StateData> States
        {
            get { return states; }
            set { states = value; }
        }
        static Dictionary<int, StateData> states = new Dictionary<int, StateData>();

        public static Dictionary<int, EquipmentData> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }
        static Dictionary<int, EquipmentData> equipments = new Dictionary<int, EquipmentData>();

        public static Dictionary<int, SkillData> Skills
        {
            get { return skills; }
            set { skills = value; }
        }
        static Dictionary<int, SkillData> skills = new Dictionary<int, SkillData>();

        public static Dictionary<int, ProjectileGroupData> Projectiles
        {
            get { return projectiles; }
            set { projectiles = value; }
        }
        static Dictionary<int, ProjectileGroupData> projectiles = new Dictionary<int, ProjectileGroupData>();

        public static Dictionary<int, ComboData> Combos
        {
            get { return combos; }
            set { combos = value; }
        }
        static Dictionary<int, ComboData> combos = new Dictionary<int, ComboData>();

        public static int TemplateEventIDs
        {
            get { return templateEventIDs; }
            set { templateEventIDs = value; }
        }
        static int templateEventIDs = 0;

        public static PlayerData Player
        {
            get { return player; }
            set { player = value; }
        }
        static PlayerData player = new PlayerData(true);

        public static List<PhysQuicksetData> PhysQuicksets
        {
            get { return physQuicksets; }
            set { physQuicksets = value; }
        }
        static List<PhysQuicksetData> physQuicksets = new List<PhysQuicksetData>();

        internal static void Reset()
        {
            animations = new Dictionary<int, AnimationData>();
            audios = new Dictionary<int, AudioData>();
            tilesets = new Dictionary<int, TilesetData>();
            texts = new Dictionary<string, Dictionary<int, TextData>>()         { 
            {"English", new Dictionary<int, TextData>()}        };
            fonts = new Dictionary<int, FontData>();
            databases = new Dictionary<int, Data>();
            events = new Dictionary<int, EventData>();
            gevents = new Dictionary<int, GlobalEventData>();
            variables = new Dictionary<int, VariableData>();            
            strings = new Dictionary<int, StringData>();
            switches = new Dictionary<int, SwitchData>();
            maps = new Dictionary<int, MapData>();
            lists = new Dictionary<int, ListData>();
            menus = new Dictionary<int, MenuData>();
            menuParts = new Dictionary<int, IMenuParts>();
            items = new Dictionary<int, ItemData>();
            materials = new Dictionary<int, MaterialData>();
            particleSystems = new Dictionary<int, ParticleSystemData>();
            skins = new Dictionary<int, SkinData>();
            heroes = new Dictionary<int, HeroData>();
            enemies = new Dictionary<int, EnemyData>();
            states = new Dictionary<int, StateData>();
            equipments = new Dictionary<int, EquipmentData>();
            skills = new Dictionary<int, SkillData>();
            projectiles = new Dictionary<int, ProjectileGroupData>();
            combos = new Dictionary<int, ComboData>();
            templateEventIDs = 0;
            player = new PlayerData(true);
            physQuicksets = new List<PhysQuicksetData>();
        }
    }
}
