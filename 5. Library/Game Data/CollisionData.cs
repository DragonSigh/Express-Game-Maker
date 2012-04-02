using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Collisions;
using System.Drawing;

namespace EGMGame.GameLibrary
{
    [Serializable]
    public class CollisionData : Vertices
    {
        public Vector2 Position
        {
            get
            {
                AABB.Update(this);
                return AABB.min;
            }
        }
        public float Mass = 1f;
        public float Friction;
        public float Bounce;
        public bool IsPlatform;
        [NonSerialized]
        private AABB AABB = new AABB();
        
        internal RectangleF GetRectangle()
        {
            RectangleF rect = new RectangleF();
            AABB a = new AABB(this);
            
            rect.X = (int)a.min.X - 12;
            rect.Y = (int)a.min.Y - 12;
            rect.Width = (int)(a.Width) + 24;
            rect.Height = (int)(a.Height) + 24;
            return rect;
        }

        /// <summary>
        /// Simple polygon simplification.
        /// </summary>
        /// <param name="polygon">The polygon that needs simplification.</param>
        /// <param name="bias">The distance bias (in pixels) between points. Points closer than this will be 'joined'.</param>
        /// <returns>A simplified polygon.</returns>
        public static CollisionData Simplify(CollisionData polygon, int bias)
        {
            //We can't simplify polygons under 3 CollisionData
            if (polygon.Count < 3)
                return polygon;

            CollisionData simplified = new CollisionData();
            CollisionData roundPolygon = Round(polygon);

            for (int curr = 0; curr < roundPolygon.Count; curr++)
            {
                int prev = roundPolygon.PreviousIndex(curr);
                int next = roundPolygon.NextIndex(curr);

                if ((roundPolygon[prev] - roundPolygon[curr]).Length() <= bias)
                    continue;

                if (!VerticesAreCollinear(roundPolygon[prev], roundPolygon[curr], roundPolygon[next]))
                    simplified.Add(roundPolygon[curr]);
            }

            return simplified;
        }
        /// <summary>
        /// Rounds vertices X and Y values to whole numbers.
        /// </summary>
        /// <param name="polygon">The polygon whose vertices should be rounded.</param>
        /// <returns>A new polygon with rounded vertices.</returns>
        public static CollisionData Round(CollisionData polygon)
        {
            CollisionData returnPoly = new CollisionData();
            for (int i = 0; i < polygon.Count; i++)
                returnPoly.Add(new Vector2((float)Math.Round(polygon[i].X, 0), (float)Math.Round(polygon[i].Y, 0)));

            return returnPoly;
        }

        /// <summary>
        /// Simple polygon simplification.
        /// </summary>
        /// <param name="polygon">The polygon that needs simplification.</param>
        /// <returns>A simplified polygon.</returns>
        public static CollisionData Simplify(CollisionData polygon)
        {
            return Simplify(polygon, 0);
        }

        internal void SetOffSet(out float mouseOffx, out float mouseOffy, PointF point)
        {
            mouseOffx = point.X - Position.X;
            mouseOffy = point.Y - Position.Y;
        }

        internal void ResetAABB()
        {
            AABB = new AABB();
        }
    }
}
