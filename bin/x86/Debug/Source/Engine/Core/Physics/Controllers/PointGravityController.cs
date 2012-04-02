using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using EGMGame.Library;

namespace FarseerPhysics.Controllers
{

    public class PointGravityController : Controller
    {
        public Vector2 Point;

        public PointGravityController(float strength)
            : base(ControllerType.GravityController)
        {
            Strength = strength;
            MaxRadius = float.MaxValue;
        }

        public PointGravityController(float strength, float maxRadius, float minRadius)
            : base(ControllerType.GravityController)
        {
            MinRadius = minRadius;
            MaxRadius = maxRadius;
            Strength = strength;
        }

        public PointGravityController(World world, Vector2 point, float strength, float maxRadius)
            : base(ControllerType.GravityController)
        {
            Point = point;
            MaxRadius = maxRadius;
            Strength = strength;

            Global.World.AddController(this);
        }

        public float MinRadius { get; set; }
        public float MaxRadius { get; set; }
        public float Strength { get; set; }
        public GravityType GravityType { get; set; }

        public override void Update(float dt)
        {
            Vector2 f = Vector2.Zero;
            foreach (Body body in World.BodyList)
            {
                if (!IsActiveOn(body))
                    continue;;

                Vector2 d = Point - body.Position;
                float r2 = d.LengthSquared();

                if (r2 < Settings.Epsilon)
                    continue;;

                float r = d.Length();

                if (r >= MaxRadius || r <= MinRadius)
                    continue;;

                switch (GravityType)
                {
                    case GravityType.DistanceSquared:
                        f = Strength / r2 / (float)Math.Sqrt(r2) * body.Mass * d;
                        break;
                    case GravityType.Linear:
                        f = Strength / r2 * body.Mass * d;
                        break;
                }

                body.ApplyForce(ref f);
            }
        }
    }
}