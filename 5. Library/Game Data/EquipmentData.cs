using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the item data.
    /// </summary>
    [Serializable]
    public class EquipmentData : IGameData
    {
        /// <summary>
        /// Name
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        [Browsable(false)]
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        [Browsable(false)]
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;

        public int Icon
        {
            get { return iconMaterialID; }
            set { iconMaterialID = value; }
        }
        int iconMaterialID = -1;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        int price = 0;

        public List<int> UsableBy
        {
            get { return usableBy; }
            set { usableBy = value; }
        }
        List<int> usableBy = new List<int>();

        public List<int> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        List<int> elements = new List<int>();

        public List<int> InflictState
        {
            get { return inflictState; }
            set { inflictState = value; }
        }
        List<int> inflictState = new List<int>();

        public List<int> RemoveState
        {
            get { return removeState; }
            set { removeState = value; }
        }
        List<int> removeState = new List<int>();

        public List<int> EquipmentSlots
        {
            get { return equipmentSlots; }
            set { equipmentSlots = value; }
        }
        List<int> equipmentSlots = new List<int>();

        public bool WhileDefending
        {
            get { return whileDefending; }
            set { whileDefending = value; }
        }
        bool whileDefending;

        public bool IgnoreDefense
        {
            get { return ignoreDefense; }
            set { ignoreDefense = value; }
        }
        bool ignoreDefense;

        public bool CriticalBonus
        {
            get { return criticalBonus; }
            set { criticalBonus = value; }
        }
        bool criticalBonus;

        public bool PreventCritical
        {
            get { return preventCrit; }
            set { preventCrit = value; }
        }
        bool preventCrit;

        public bool TwoSlots
        {
            get { return twoSlots; }
            set { twoSlots = value; }
        }
        bool twoSlots;

        public bool VisualAnchor
        {
            get { return visualAnchor; }
            set { visualAnchor = value; }
        }
        bool visualAnchor;

        public int VisualAnimation
        {
            get { return visualAnimation; }
            set { visualAnimation = value; }
        }
        int visualAnimation;

        public EquipType EquipType
        {
            get { return equipType; }
            set { equipType = value; }
        }
        EquipType equipType = EquipType.Offensive;

        public int Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        int animation = -1;

        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = -1;

        public int Particle
        {
            get { return particle; }
            set { particle = value; }
        }
        int particle = -1;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }
        int range = 1;

        public int Knockback
        {
            get { return knockback; }
            set { knockback = value; }
        }
        int knockback = 0;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value = 0;

        public ItemValueType ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }
        ItemValueType valueType = ItemValueType.Constant;
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = 0;

        public int Projectile
        {
            get { return projectile; }
            set { projectile = value; }
        }
        int projectile = -1;

        public int AmmoID
        {
            get { return ammoID; }
            set { ammoID = value; }
        }
        int ammoID = -1;

        public Dictionary<int, List<int>> HeroActions
        {
            get { return heroActions; }
            set { heroActions = value; }
        }
        Dictionary<int, List<int>> heroActions = new Dictionary<int, List<int>>();

        public int Mash
        {
            get { return _mash; }
            set { _mash = value; }
        }
        int _mash = 60;

        public int KnockbackSpeed
        {
            get { return knockbacSpeed; }
            set { knockbacSpeed = value; }
        }
        int knockbacSpeed = 4;

        public int UseAnchor
        {
            get { return useAnchor; }
            set { useAnchor = value; }
        }
        int useAnchor = 1;

        public int AnchorTo
        {
            get { return anchorTo; }
            set { anchorTo = value; }
        }
        int anchorTo = 1;

        public int PropertyType
        {
            get { return propertyType; }
            set { propertyType = value; }
        }
        int propertyType;

        //public int PropertyToDamage
        //{
        //    get { return propertyDamage; }
        //    set { propertyDamage = value; }
        //}
        //int propertyDamage;
    }

    public enum EquipType
    {
        Offensive,
        Defensive
    }
}
