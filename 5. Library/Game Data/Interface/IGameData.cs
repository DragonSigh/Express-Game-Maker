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
    [XmlInclude(typeof(VariableData))]
    [XmlInclude(typeof(GlobalEventData))]
    [XmlInclude(typeof(PlayerData))]
    [XmlInclude(typeof(SkinData))]
    [XmlInclude(typeof(StringData))]
    [XmlInclude(typeof(FontData))]
    [XmlInclude(typeof(FontStyleData))]
    [XmlInclude(typeof(PlayerData))]
    [XmlInclude(typeof(ParticleSystemData))]
    [XmlInclude(typeof(ItemEffect))]
    [XmlInclude(typeof(ItemData))]
    [XmlInclude(typeof(ParticleVertex))]
    [XmlInclude(typeof(ParticleEmitter))]
    [XmlInclude(typeof(ComboData))]
    [XmlInclude(typeof(HeroData))]
    [XmlInclude(typeof(EnemyData))]
    [XmlInclude(typeof(EquipmentData))]
    [XmlInclude(typeof(SkillData))]
    [XmlInclude(typeof(ProjectileData))]
    [XmlInclude(typeof(ProjectileGroupData))]
    [XmlInclude(typeof(MaterialData))]
    [XmlInclude(typeof(IEventProgram))]
    [XmlInclude(typeof(Hotkey))]
    [Serializable]
    public abstract class IGameData
    {
        public abstract string Name { get; set; }

        public abstract int ID { get; set; }

        public abstract int Category { get; set; }
    }
}
