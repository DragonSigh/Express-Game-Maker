using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using EGMGame.Processors;

namespace FarseerPhysics.Controllers
{
    public class EventGravityController : Controller
    {
        public EventProcessor Event;

        public EventGravityController(float strength)
            : base(ControllerType.GravityController)
        {
            Strength = strength;
            MaxRadius = float.MaxValue;
        }

        public EventGravityController(float strength, float maxRadius, float minRadius)
            : base(ControllerType.GravityController)
        {
            MinRadius = minRadius;
            MaxRadius = maxRadius;
            Strength = strength;
        }

        public EventGravityController(World world, EventProcessor e, float strength, float maxRadius)
            : base(ControllerType.GravityController)
        {
            Event = e;
            MaxRadius = maxRadius;
            Strength = strength;

           world.AddController(this);
        }

        public float MinRadius { get; set; }
        public float MaxRadius { get; set; }
        public float Strength { get; set; }
        public GravityType GravityType { get; set; }

        public override void Update(float dt)
        {
            if (Event.Body == null)
                return;
            foreach (Body body in World.BodyList)
            {

                Vector2 f = Vector2.Zero;

                if (!IsActiveOn(body))
                    continue;;

                if (body == Event.Body || (body.IsStatic && Event.Body.IsStatic) || !Event.Body.Enabled)
                    continue;;

                Vector2 d = Event.Body.WorldCenter - body.WorldCenter;
                float r2 = d.LengthSquared();

                if (r2 < Settings.Epsilon)
                    continue;;

                float r = d.Length();

                if (r >= MaxRadius || r <= MinRadius)
                    continue;;

                switch (GravityType)
                {
                    case GravityType.DistanceSquared:
                        f = Strength / r2 / (float)Math.Sqrt(r2) * body.Mass * Event.Body.Mass * d;
                        break;
                    case GravityType.Linear:
                        f = Strength / r2 * body.Mass * Event.Body.Mass * d;
                        break;
                }

                body.ApplyForce(ref f);
                Vector2.Negate(ref f, out f);
                Event.Body.ApplyForce(ref f);
            }
        }
    }
}