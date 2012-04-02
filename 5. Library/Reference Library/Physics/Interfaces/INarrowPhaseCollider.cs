#if (XNA)
using Microsoft.Xna.Framework;
#else
using FarseerPhysics.Mathematics;
#endif

using FarseerPhysics.Collisions;

namespace FarseerPhysics.Interfaces
{
    public interface INarrowPhaseCollider
    {
        void Collide(Geom geomA, Geom geomB, ContactList contactList);
        //INarrowPhaseCollider Clone();
        bool Intersect(Geom geom, ref Vector2 point);
    }
}
