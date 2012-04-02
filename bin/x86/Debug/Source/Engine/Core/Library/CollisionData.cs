using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Collision;

namespace EGMGame.GameLibrary
{
    public class CollisionData : Vertices
    {
        public float Mass;
        public float Friction;
        public float Bounce;
        public bool IsPlatform;
    }
}
