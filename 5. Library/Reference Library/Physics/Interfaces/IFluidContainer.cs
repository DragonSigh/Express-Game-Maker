using FarseerPhysics.Collisions;

#if (XNA)
using Microsoft.Xna.Framework;
#else
using FarseerPhysics.Mathematics;
#endif

namespace FarseerPhysics.Interfaces
{
    public interface IFluidContainer
    {
        bool Intersect(AABB aabb);
        bool Contains(ref Vector2 vector);
    }
}