//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EGMGame.Library
{
    [XmlInclude(typeof(AnimationAction))]
    [XmlInclude(typeof(AnimationData))]
    [XmlInclude(typeof(AnimationFrame))]
    [XmlInclude(typeof(AnimationAnchor))]
    [XmlInclude(typeof(AnimationSprite))]
    [XmlInclude(typeof(ListData))]
    [XmlInclude(typeof(MapInfo))]
    [XmlInclude(typeof(AudioData))]
    [XmlInclude(typeof(EventProgramData))]
    [XmlInclude(typeof(Data))]
    [XmlInclude(typeof(DataProperty))]
    [XmlInclude(typeof(EventData))]
    [XmlInclude(typeof(FontData))]
    [XmlInclude(typeof(ItemData))]
    [XmlInclude(typeof(MenuData))]
    [XmlInclude(typeof(IMenuParts))]
    [XmlInclude(typeof(MapData))]
    [XmlInclude(typeof(LayerData))]
    [XmlInclude(typeof(SwitchData))]
    [XmlInclude(typeof(TextData))]
    [XmlInclude(typeof(TilesetData))]
    [XmlInclude(typeof(GlobalEventData))]
    [XmlInclude(typeof(PlayerData))]
    [XmlInclude(typeof(SkinData))]
    [XmlInclude(typeof(ParticleEmitterData))]
    [XmlInclude(typeof(ProjectileData))]
    [XmlInclude(typeof(ParticleSystemData))]
    [XmlInclude(typeof(HeroData))]
    [XmlInclude(typeof(EnemyData))]
    [XmlInclude(typeof(EquipmentData))]
    [XmlInclude(typeof(SkillData))]
    [XmlInclude(typeof(StateData))]
    [XmlInclude(typeof(AutoTileData))]
    [XmlInclude(typeof(PhysicsPin))]
    [XmlInclude(typeof(ComboData))]
    [XmlInclude(typeof(Hotkey))]
    [XmlInclude(typeof(LocalSwitchCondition))]
    [XmlInclude(typeof(LocalVariableCondition))]
    [XmlInclude(typeof(SwitchCondition))]
    [XmlInclude(typeof(VariableCondition))]
    [XmlInclude(typeof(VariableData))]
    [XmlInclude(typeof(StringData))]
    [XmlInclude(typeof(FontStyleData))]
    [XmlInclude(typeof(LayerData))]
    [XmlInclude(typeof(ProjectileGroupData))]
    
    public abstract class IGameData
    {
        public abstract string Name { get; set; }

        public abstract int ID { get; set; }

        public abstract int Category { get; set; }
    }
}
