using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame
{
    
    public class PhysicsSettings : IGameData
    {

        public override string Name { get { return ""; } set { } }

        public override int ID { get { return 0; } set { } }

        public override int Category { get { return 0; } set { } }

        public bool IgnoreGravity;
        public bool CustomMass;
        public bool CustomForce;
        public bool CustomLinearDrag;
        public bool CustomRotationalDrag;
        public bool CustomFriction;
        public bool CustomBounce;
        public bool CustomImpulse;
        public bool CustomMOI;

        public float Mass = 1f;
        public float Force = 1f;
        public float LinearDrag = 7.0f;
        public float RotationalDrag = 1.0f;
        public float Friction;
        public float Bounce;
        public float Impulse = 1f;
        public float MomentOfInertia = 200;

        public bool IsFixedRotation;


        public bool CustomGravity;
        public Vector2 Gravity;
    }
}
