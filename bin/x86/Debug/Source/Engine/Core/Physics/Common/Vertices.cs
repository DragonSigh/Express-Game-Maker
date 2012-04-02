using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FarseerPhysics.Collision;
using Microsoft.Xna.Framework;
using EGMGame.Library;

namespace FarseerPhysics.Common
{
#if !(XBOX360)
    [DebuggerDisplay("Count = {Count} Vertices = {ToString()}")]
#endif
    public class Vertices : List<Vector2>
    {
        public Vertices()
        {
        }

        public Vertices(int capacity)
        {
            Capacity = capacity;
        }

        public Vertices(Vector2[] vector2)
        {
            for (int i = 0; i < vector2.Length; i++)
            {
                Add(vector2[i]);
            }
        }

        public Vertices(IList<Vector2> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>
        /// Nexts the index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int NextIndex(int index)
        {
            if (index == Count - 1)
            {
                return 0;
            }
            return index + 1;
        }

        public Vector2 NextVertex(int index)
        {
            return this[NextIndex(index)];
        }

        /// <summary>
        /// Gets the previous index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int PreviousIndex(int index)
        {
            if (index == 0)
            {
                return Count - 1;
            }
            return index - 1;
        }

        public Vector2 PreviousVertex(int index)
        {
            return this[PreviousIndex(index)];
        }

        /// <summary>
        /// Gets the signed area.
        /// </summary>
        /// <returns></returns>
        public float GetSignedArea()
        {
            int i;
            float area = 0;

            for (i = 0; i < Count; i++)
            {
                int j = (i + 1) % Count;
                area += this[i].X * this[j].Y;
                area -= this[i].Y * this[j].X;
            }
            area /= 2.0f;
            return area;
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            int i;
            float area = 0;

            for (i = 0; i < Count; i++)
            {
                int j = (i + 1) % Count;
                area += this[i].X * this[j].Y;
                area -= this[i].Y * this[j].X;
            }
            area /= 2.0f;
            return (area < 0 ? -area : area);
        }

        /// <summary>
        /// Gets the centroid.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetCentroid()
        {
            // Same algorithm is used by Box2D

            Vector2 c = Vector2.Zero;
            float area = 0.0f;

            const float inv3 = 1.0f / 3.0f;
            Vector2 pRef = Vector2.Zero;
            for (int i = 0; i < Count; ++i)
            {
                // Triangle vertices.
                Vector2 p1 = pRef;
                Vector2 p2 = this[i];
                Vector2 p3 = i + 1 < Count ? this[i + 1] : this[0];

                Vector2 e1 = p2 - p1;
                Vector2 e2 = p3 - p1;

                float D = MathUtils.Cross(e1, e2);

                float triangleArea = 0.5f * D;
                area += triangleArea;

                // Area weighted centroid
                c += triangleArea * inv3 * (p1 + p2 + p3);
            }

            // Centroid
            c *= 1.0f / area;
            return c;
        }

        /// <summary>
        /// Gets the radius based on area.
        /// </summary>
        /// <returns></returns>
        public float GetRadius()
        {
            float area = GetSignedArea();

            double radiusSqrd = (double)area / MathHelper.Pi;
            if (radiusSqrd < 0)
            {
                radiusSqrd *= -1;
            }

            return (float)Math.Sqrt(radiusSqrd);
        }

        /// <summary>
        /// Returns an AABB for vertex.
        /// </summary>
        /// <returns></returns>
        public AABB GetCollisionBox()
        {
            AABB aabb;
            Vector2 lowerBound = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 upperBound = new Vector2(float.MinValue, float.MinValue);

            for (int i = 0; i < Count; ++i)
            {
                if (this[i].X < lowerBound.X)
                {
                    lowerBound.X = this[i].X;
                }
                if (this[i].X > upperBound.X)
                {
                    upperBound.X = this[i].X;
                }

                if (this[i].Y < lowerBound.Y)
                {
                    lowerBound.Y = this[i].Y;
                }
                if (this[i].Y > upperBound.Y)
                {
                    upperBound.Y = this[i].Y;
                }
            }

            aabb.LowerBound = lowerBound;
            aabb.UpperBound = upperBound;

            return aabb;
        }

        public void Translate(Vector2 vector)
        {
            Translate(ref vector);
        }

        /// <summary>
        /// Translates the vertices with the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public void Translate(ref Vector2 vector)
        {
            for (int i = 0; i < Count; i++)
                this[i] = Vector2.Add(this[i], vector);
        }

        /// <summary>
        /// Scales the vertices with the specified vector.
        /// </summary>
        /// <param name="value">The Value.</param>
        public void Scale(ref Vector2 value)
        {
            for (int i = 0; i < Count; i++)
                this[i] = Vector2.Multiply(this[i], value);
        }

        /// <summary>
        /// Rotate the vertices with the defined value in radians.
        /// </summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public void Rotate(float value)
        {
            Matrix rotationMatrix;
            Matrix.CreateRotationZ(value, out rotationMatrix);

            for (int i = 0; i < Count; i++)
                this[i] = Vector2.Transform(this[i], rotationMatrix);
        }

        /// <summary>
        /// Assuming the polygon is simple; determines whether the polygon is convex.
        /// NOTE: It will also return false if the input contains colinear edges.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if it is convex; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConvex()
        {
            // Ensure the polygon is convex and the interior
            // is to the left of each edge.
            for (int i = 0; i < Count; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < Count ? i + 1 : 0;
                Vector2 edge = this[i2] - this[i1];

                for (int j = 0; j < Count; ++j)
                {
                    // Don't check vertices on the current edge.
                    if (j == i1 || j == i2)
                    {
                        continue;
                    }

                    Vector2 r = this[j] - this[i1];

                    float s = edge.X * r.Y - edge.Y * r.X;

                    if (s <= 0.0f)
                        return false;
                }
            }
            return true;
        }

        public bool IsCounterClockWise()
        {
            //We just return true for lines
            if (Count < 3)
                return true;

            return (GetSignedArea() > 0.0f);
        }

        /// <summary>
        /// Forces counter clock wise order.
        /// </summary>
        public void ForceCounterClockWise()
        {
            if (!IsCounterClockWise())
            {
                Reverse();
            }
        }

        /// <summary>
        /// Check for edge crossings
        /// </summary>
        /// <returns></returns>
        public bool IsSimple()
        {
            for (int i = 0; i < Count; ++i)
            {
                int iplus = (i + 1 > Count - 1) ? 0 : i + 1;
                Vector2 a1 = new Vector2(this[i].X, this[i].Y);
                Vector2 a2 = new Vector2(this[iplus].X, this[iplus].Y);
                for (int j = i + 1; j < Count; ++j)
                {
                    int jplus = (j + 1 > Count - 1) ? 0 : j + 1;
                    Vector2 b1 = new Vector2(this[j].X, this[j].Y);
                    Vector2 b2 = new Vector2(this[jplus].X, this[jplus].Y);

                    Vector2 temp;

                    if (LineTools.LineIntersect2(a1, a2, b1, b2, out temp))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //TODO: Test
        //Implementation found here: http://www.gamedev.net/community/forums/topic.asp?topic_id=548477
        public bool IsSimple2()
        {
            for (int i = 0; i < Count; ++i)
            {
                if (i < Count - 1)
                {
                    for (int h = i + 1; h < Count; ++h)
                    {
                        // Do two vertices lie on top of one another?
                        if (this[i] == this[h])
                        {
                            return true;
                        }
                    }
                }

                int j = (i + 1) % Count;
                Vector2 iToj = this[j] - this[i];
                Vector2 iTojNormal = new Vector2(iToj.Y, -iToj.X);

                // i is the first vertex and j is the second
                int startK = (j + 1) % Count;
                int endK = (i - 1 + Count) % Count;
                endK += startK < endK ? 0 : startK + 1;
                int k = startK;
                Vector2 iTok = this[k] - this[i];
                bool onLeftSide = Vector2.Dot(iTok, iTojNormal) >= 0;
                Vector2 prevK = this[k];
                ++k;
                for (; k <= endK; ++k)
                {
                    int modK = k % Count;
                    iTok = this[modK] - this[i];
                    if (onLeftSide != Vector2.Dot(iTok, iTojNormal) >= 0)
                    {
                        Vector2 prevKtoK = this[modK] - prevK;
                        Vector2 prevKtoKNormal = new Vector2(prevKtoK.Y, -prevKtoK.X);
                        if ((Vector2.Dot(this[i] - prevK, prevKtoKNormal) >= 0) !=
                            (Vector2.Dot(this[j] - prevK, prevKtoKNormal) >= 0))
                        {
                            return true;
                        }
                    }
                    onLeftSide = Vector2.Dot(iTok, iTojNormal) > 0;
                    prevK = this[modK];
                }
            }
            return false;
        }


        // From Eric Jordan's convex decomposition library

        /// <summary>
        /// Checks if polygon is valid for use in Box2d engine.
        /// Last ditch effort to ensure no invalid polygons are
        /// added to world fixtureetry.
        ///
        /// Performs a full check, for simplicity, convexity,
        /// orientation, minimum angle, and volume.  This won't
        /// be very efficient, and a lot of it is redundant when
        /// other tools in this section are used.
        /// </summary>
        /// <returns></returns>
        public bool CheckPolygon()
        {
            int error = -1;
            if (Count < 3 || Count > Settings.MaxPolygonVertices)
            {
                error = 0;
            }
            if (!IsConvex())
            {
                error = 1;
            }
            if (!IsSimple())
            {
                error = 2;
            }
            if (GetArea() < Settings.Epsilon)
            {
                error = 3;
            }

            //Compute normals
            Vector2[] normals = new Vector2[Count];
            Vertices vertices = new Vertices(Count);
            for (int i = 0; i < Count; ++i)
            {
                vertices.Add(new Vector2(this[i].X, this[i].Y));
                int i1 = i;
                int i2 = i + 1 < Count ? i + 1 : 0;
                Vector2 edge = new Vector2(this[i2].X - this[i1].X, this[i2].Y - this[i1].Y);
                normals[i] = MathUtils.Cross(edge, 1.0f);
                normals[i].Normalize();
            }

            //Required side checks
            for (int i = 0; i < Count; ++i)
            {
                int iminus = (i == 0) ? Count - 1 : i - 1;

                //Parallel sides check
                float cross = MathUtils.Cross(normals[iminus], normals[i]);
                cross = MathUtils.Clamp(cross, -1.0f, 1.0f);
                float angle = (float)Math.Asin(cross);
                if (angle <= Settings.AngularSlop)
                {
                    error = 4;
                    break;
                }

                //Too skinny check
                for (int j = 0; j < Count; ++j)
                {
                    if (j == i || j == (i + 1) % Count)
                    {
                        continue;
                    }
                    float s = Vector2.Dot(normals[i], vertices[j] - vertices[i]);
                    if (s >= -Settings.LinearSlop)
                    {
                        error = 5;
                    }
                }


                Vector2 centroid = vertices.GetCentroid();
                Vector2 n1 = normals[iminus];
                Vector2 n2 = normals[i];
                Vector2 v = vertices[i] - centroid;

                Vector2 d = new Vector2();
                d.X = Vector2.Dot(n1, v); // - toiSlop;
                d.Y = Vector2.Dot(n2, v); // - toiSlop;

                // Shifting the edge inward by toiSlop should
                // not cause the plane to pass the centroid.
                if ((d.X < 0.0f) || (d.Y < 0.0f))
                {
                    error = 6;
                }
            }

            if (error != -1)
            {
                Debug.WriteLine("Found invalid polygon, ");
                switch (error)
                {
                    case 0:
                        Debug.WriteLine(string.Format("must have between 3 and {0} vertices.\n",
                                                      Settings.MaxPolygonVertices));
                        break;
                    case 1:
                        Debug.WriteLine("must be convex.\n");
                        break;
                    case 2:
                        Debug.WriteLine("must be simple (cannot intersect itself).\n");
                        break;
                    case 3:
                        Debug.WriteLine("area is too small.\n");
                        break;
                    case 4:
                        Debug.WriteLine("sides are too close to parallel.\n");
                        break;
                    case 5:
                        Debug.WriteLine("polygon is too thin.\n");
                        break;
                    case 6:
                        Debug.WriteLine("core shape generation would move edge past centroid (too thin).\n");
                        break;
                    default:
                        Debug.WriteLine("don't know why.\n");
                        break;
                }
            }
            return error != -1;
        }

        // From Eric Jordan's convex decomposition library

        /// <summary>
        /// Trace the edge of a non-simple polygon and return a simple polygon.
        /// 
        /// Method:
        /// Start at vertex with minimum y (pick maximum x one if there are two).
        /// We aim our "lastDir" vector at (1.0, 0)
        /// We look at the two rays going off from our start vertex, and follow whichever
        /// has the smallest angle (in -Pi . Pi) wrt lastDir ("rightest" turn)
        /// Loop until we hit starting vertex:
        /// We add our current vertex to the list.
        /// We check the seg from current vertex to next vertex for intersections
        /// - if no intersections, follow to next vertex and continue
        /// - if intersections, pick one with minimum distance
        /// - if more than one, pick one with "rightest" next point (two possibilities for each)
        /// </summary>
        /// <param name="verts">The vertices.</param>
        /// <returns></returns>
        public Vertices TraceEdge(Vertices verts)
        {
            PolyNode[] nodes = new PolyNode[verts.Count * verts.Count];
            //overkill, but sufficient (order of mag. is right)
            int nNodes = 0;

            //Add base nodes (raw outline)
            for (int i = 0; i < verts.Count; ++i)
            {
                Vector2 pos = new Vector2(verts[i].X, verts[i].Y);
                nodes[i].Position = pos;
                ++nNodes;
                int iplus = (i == verts.Count - 1) ? 0 : i + 1;
                int iminus = (i == 0) ? verts.Count - 1 : i - 1;
                nodes[i].AddConnection(nodes[iplus]);
                nodes[i].AddConnection(nodes[iminus]);
            }

            //Process intersection nodes - horribly inefficient
            bool dirty = true;
            int counter = 0;
            while (dirty)
            {
                dirty = false;
                for (int i = 0; i < nNodes; ++i)
                {
                    for (int j = 0; j < nodes[i].NConnected; ++j)
                    {
                        for (int k = 0; k < nNodes; ++k)
                        {
                            if (k == i || nodes[k] == nodes[i].Connected[j]) continue;
                            for (int l = 0; l < nodes[k].NConnected; ++l)
                            {
                                if (nodes[k].Connected[l] == nodes[i].Connected[j] ||
                                    nodes[k].Connected[l] == nodes[i]) continue;

                                //Check intersection
                                Vector2 intersectPt;

                                bool crosses = LineTools.LineIntersect(nodes[i].Position, nodes[i].Connected[j].Position,
                                                                       nodes[k].Position, nodes[k].Connected[l].Position,
                                                                       out intersectPt);
                                if (crosses)
                                {
                                    dirty = true;
                                    //Destroy and re-hook connections at crossing point
                                    PolyNode connj = nodes[i].Connected[j];
                                    PolyNode connl = nodes[k].Connected[l];
                                    nodes[i].Connected[j].RemoveConnection(nodes[i]);
                                    nodes[i].RemoveConnection(connj);
                                    nodes[k].Connected[l].RemoveConnection(nodes[k]);
                                    nodes[k].RemoveConnection(connl);
                                    nodes[nNodes] = new PolyNode(intersectPt);
                                    nodes[nNodes].AddConnection(nodes[i]);
                                    nodes[i].AddConnection(nodes[nNodes]);
                                    nodes[nNodes].AddConnection(nodes[k]);
                                    nodes[k].AddConnection(nodes[nNodes]);
                                    nodes[nNodes].AddConnection(connj);
                                    connj.AddConnection(nodes[nNodes]);
                                    nodes[nNodes].AddConnection(connl);
                                    connl.AddConnection(nodes[nNodes]);
                                    ++nNodes;
                                    goto SkipOut;
                                }
                            }
                        }
                    }
                }
            SkipOut:
                ++counter;
            }

            //Collapse duplicate points
            bool foundDupe = true;
            int nActive = nNodes;
            while (foundDupe)
            {
                foundDupe = false;
                for (int i = 0; i < nNodes; ++i)
                {
                    if (nodes[i].NConnected == 0) continue;
                    for (int j = i + 1; j < nNodes; ++j)
                    {
                        if (nodes[j].NConnected == 0) continue;
                        Vector2 diff = nodes[i].Position - nodes[j].Position;
                        if (diff.LengthSquared() <= Settings.Epsilon * Settings.Epsilon)
                        {
                            if (nActive <= 3)
                                return new Vertices();

                            //printf("Found dupe, %d left\n",nActive);
                            --nActive;
                            foundDupe = true;
                            PolyNode inode = nodes[i];
                            PolyNode jnode = nodes[j];
                            //Move all of j's connections to i, and orphan j
                            int njConn = jnode.NConnected;
                            for (int k = 0; k < njConn; ++k)
                            {
                                PolyNode knode = jnode.Connected[k];
                                Debug.Assert(knode != jnode);
                                if (knode != inode)
                                {
                                    inode.AddConnection(knode);
                                    knode.AddConnection(inode);
                                }
                                knode.RemoveConnection(jnode);
                            }
                            jnode.NConnected = 0;
                        }
                    }
                }
            }

            //Now walk the edge of the list

            //Find node with minimum y value (max x if equal)
            float minY = float.MaxValue;
            float maxX = -float.MaxValue;
            int minYIndex = -1;
            for (int i = 0; i < nNodes; ++i)
            {
                if (nodes[i].Position.Y < minY && nodes[i].NConnected > 1)
                {
                    minY = nodes[i].Position.Y;
                    minYIndex = i;
                    maxX = nodes[i].Position.X;
                }
                else if (nodes[i].Position.Y == minY && nodes[i].Position.X > maxX && nodes[i].NConnected > 1)
                {
                    minYIndex = i;
                    maxX = nodes[i].Position.X;
                }
            }

            Vector2 origDir = new Vector2(1.0f, 0.0f);
            Vector2[] resultVecs = new Vector2[4 * nNodes];
            // nodes may be visited more than once, unfortunately - change to growable array!
            int nResultVecs = 0;
            PolyNode currentNode = nodes[minYIndex];
            PolyNode startNode = currentNode;
            Debug.Assert(currentNode.NConnected > 0);
            PolyNode nextNode = currentNode.GetRightestConnection(origDir);
            if (nextNode == null)
            {
                Vertices vertices = new Vertices(nResultVecs);

                for (int i = 0; i < nResultVecs; ++i)
                {
                    vertices.Add(resultVecs[i]);
                }

                return vertices;
            }

            // Borked, clean up our mess and return
            resultVecs[0] = startNode.Position;
            ++nResultVecs;
            while (nextNode != startNode)
            {
                if (nResultVecs > 4 * nNodes)
                {
                    Debug.Assert(false);
                }
                resultVecs[nResultVecs++] = nextNode.Position;
                PolyNode oldNode = currentNode;
                currentNode = nextNode;
                nextNode = currentNode.GetRightestConnection(oldNode);
                if (nextNode == null)
                {
                    Vertices vertices = new Vertices(nResultVecs);
                    for (int i = 0; i < nResultVecs; ++i)
                    {
                        vertices.Add(resultVecs[i]);
                    }
                    return vertices;
                }
                // There was a problem, so jump out of the loop and use whatever garbage we've generated so far
            }

            return new Vertices();
        }

        private class PolyNode
        {
            private const int MaxConnected = 32;

            /*
             * Given sines and cosines, tells if A's angle is less than B's on -Pi, Pi
             * (in other words, is A "righter" than B)
             */
            public PolyNode[] Connected = new PolyNode[MaxConnected];
            public int NConnected;
            public Vector2 Position;

            public PolyNode(Vector2 pos)
            {
                Position = pos;
                NConnected = 0;
            }

            private bool IsRighter(float sinA, float cosA, float sinB, float cosB)
            {
                if (sinA < 0)
                {
                    if (sinB > 0 || cosA <= cosB) return true;
                    else return false;
                }
                else
                {
                    if (sinB < 0 || cosA <= cosB) return false;
                    else return true;
                }
            }

            public void AddConnection(PolyNode toMe)
            {
                Debug.Assert(NConnected < MaxConnected);

                // Ignore duplicate additions
                for (int i = 0; i < NConnected; ++i)
                {
                    if (Connected[i] == toMe) return;
                }
                Connected[NConnected] = toMe;
                ++NConnected;
            }

            public void RemoveConnection(PolyNode fromMe)
            {
                bool isFound = false;
                int foundIndex = -1;
                for (int i = 0; i < NConnected; ++i)
                {
                    if (fromMe == Connected[i])
                    {
                        //.position == connected[i].position){
                        isFound = true;
                        foundIndex = i;
                        break;
                    }
                }
                Debug.Assert(isFound);
                --NConnected;
                for (int i = foundIndex; i < NConnected; ++i)
                {
                    Connected[i] = Connected[i + 1];
                }
            }

            public PolyNode GetRightestConnection(PolyNode incoming)
            {
                if (NConnected == 0) Debug.Assert(false); // This means the connection graph is inconsistent
                if (NConnected == 1)
                {
                    //b2Assert(false);
                    // Because of the possibility of collapsing nearby points,
                    // we may end up with "spider legs" dangling off of a region.
                    // The correct behavior here is to turn around.
                    return incoming;
                }
                Vector2 inDir = Position - incoming.Position;

                float inLength = inDir.Length();
                inDir.Normalize();

                Debug.Assert(inLength > Settings.Epsilon);

                PolyNode result = null;
                for (int i = 0; i < NConnected; ++i)
                {
                    if (Connected[i] == incoming) continue;
                    Vector2 testDir = Connected[i].Position - Position;
                    float testLengthSqr = testDir.LengthSquared();
                    testDir.Normalize();
                    Debug.Assert(testLengthSqr >= Settings.Epsilon * Settings.Epsilon);
                    float myCos = Vector2.Dot(inDir, testDir);
                    float mySin = MathUtils.Cross(inDir, testDir);
                    if (result != null)
                    {
                        Vector2 resultDir = result.Position - Position;
                        resultDir.Normalize();
                        float resCos = Vector2.Dot(inDir, resultDir);
                        float resSin = MathUtils.Cross(inDir, resultDir);
                        if (IsRighter(mySin, myCos, resSin, resCos))
                        {
                            result = Connected[i];
                        }
                    }
                    else
                    {
                        result = Connected[i];
                    }
                }

                Debug.Assert(result != null);

                return result;
            }

            public PolyNode GetRightestConnection(Vector2 incomingDir)
            {
                Vector2 diff = Position - incomingDir;
                PolyNode temp = new PolyNode(diff);
                PolyNode res = GetRightestConnection(temp);
                Debug.Assert(res != null);
                return res;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(this[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(" ");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Projects to axis.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        public void ProjectToAxis(ref Vector2 axis, out float min, out float max)
        {
            // To project a point on an axis use the dot product
            float dotProduct = Vector2.Dot(axis, this[0]);
            min = dotProduct;
            max = dotProduct;

            for (int i = 0; i < Count; i++)
            {
                dotProduct = Vector2.Dot(this[i], axis);
                if (dotProduct < min)
                {
                    min = dotProduct;
                }
                else
                {
                    if (dotProduct > max)
                    {
                        max = dotProduct;
                    }
                }
            }
        }

        /// <summary>
        /// Winding number test for a point in a polygon.
        /// </summary>
        /// See more info about the algorithm here: http://softsurfer.com/Archive/algorithm_0103/algorithm_0103.htm
        /// <param name="point">The point to be tested.</param>
        /// <returns>-1 if the winding number is zero and the point is outside
        /// the polygon, 1 if the point is inside the polygon, and 0 if the point
        /// is on the polygons edge.</returns>
        public int PointInPolygon(ref Vector2 point)
        {
            // Winding number
            int wn = 0;

            // Iterate through polygon's edges
            for (int i = 0; i < Count; i++)
            {
                // Get points
                Vector2 p1 = this[i];
                Vector2 p2 = this[NextIndex(i)];

                // Test if a point is directly on the edge
                Vector2 edge = p2 - p1;
                float area = MathUtils.Area(ref p1, ref p2, ref point);
                if (area == 0f && Vector2.Dot(point - p1, edge) >= 0f && Vector2.Dot(point - p2, edge) <= 0f)
                {
                    return 0;
                }
                // Test edge for intersection with ray from point
                if (p1.Y <= point.Y)
                {
                    if (p2.Y > point.Y && area > 0f)
                    {
                        ++wn;
                    }
                }
                else
                {
                    if (p2.Y <= point.Y && area < 0f)
                    {
                        --wn;
                    }
                }
            }
            return (wn == 0 ? -1 : 1);
        }

        /// <summary>
        /// Compute the sum of the angles made between the test point and each pair of points making up the polygon. 
        /// If this sum is 2pi then the point is an interior point, if 0 then the point is an exterior point. 
        /// ref: http://ozviz.wasp.uwa.edu.au/~pbourke/fixtureetry/insidepoly/  - Solution 2 
        /// </summary>
        public bool PointInPolygonAngle(ref Vector2 point)
        {
            double angle = 0;

            // Iterate through polygon's edges
            for (int i = 0; i < Count; i++)
            {
                // Get points
                Vector2 p1 = this[i] - point;
                Vector2 p2 = this[NextIndex(i)] - point;

                angle += MathUtils.VectorAngle(ref p1, ref p2);
            }

            if (Math.Abs(angle) < Math.PI)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple polygon simplification.
        /// </summary>
        /// <param name="polygon">The polygon that needs simplification.</param>
        /// <returns>A simplified polygon.</returns>
        public static Vertices Simplify(Vertices polygon)
        {
            return Simplify(polygon, 0);
        }
        /// <summary>
        /// Simple polygon simplification.
        /// </summary>
        /// <param name="polygon">The polygon that needs simplification.</param>
        /// <param name="bias">The distance bias (in pixels) between points. Points closer than this will be 'joined'.</param>
        /// <returns>A simplified polygon.</returns>
        public static Vertices Simplify(Vertices polygon, int bias)
        {
            //We can't simplify polygons under 3 vertices
            if (polygon.Count < 3)
                return polygon;

            Vertices simplified = new Vertices();
            Vertices roundPolygon = Round(polygon);

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
        public static Vertices Round(Vertices polygon)
        {
            Vertices returnPoly = new Vertices();
            for (int i = 0; i < polygon.Count; i++)
                returnPoly.Add(new Vector2((float)Math.Round(polygon[i].X, 0), (float)Math.Round(polygon[i].Y, 0)));

            return returnPoly;
        }
        /// <summary>
        /// Determines if three vertices are collinear (ie. on a straight line)
        /// </summary>
        /// <param name="p1">Vertex 1</param>
        /// <param name="p2">Vertex 2</param>
        /// <param name="p3">Vertex 3</param>
        /// <returns></returns>
        private static bool VerticesAreCollinear(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            double collinearity = (p3.X - p1.X) * (p2.Y - p1.Y) + (p3.Y - p1.Y) * (p1.X - p2.X);
            return (collinearity == 0);
        }


        #region DrDeth's Extension

        private const float _epsilon = .00001f;
        /// <summary>
        /// Prepares the polygons.
        /// </summary>
        /// <param name="polygon1">The polygon1.</param>
        /// <param name="polygon2">The polygon2.</param>
        /// <param name="poly1">The poly1.</param>
        /// <param name="poly2">The poly2.</param>
        /// <param name="intersections">The intersections.</param>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        private static int PreparePolygons(Vertices polygon1, Vertices polygon2, out Vertices poly1, out Vertices poly2,
                                    out List<EdgeIntersectInfo> intersections, out PolyUnionError error)
        {
            error = PolyUnionError.None;

            // Make a copy of the polygons so that we dont modify the originals, and
            // force vertices to integer (pixel) values.
            poly1 = Round(polygon1);

            poly2 = Round(polygon2);

            // Find intersection points
            intersections = new List<EdgeIntersectInfo>();
            if (!VerticesIntersect(poly1, poly2, ref intersections))
            {
                // No intersections found - polygons do not overlap.
                error = PolyUnionError.NoIntersections;
                return -1;
            }

            // Add intersection points to original polygons, ignoring existing points.
            foreach (EdgeIntersectInfo intersect in intersections)
            {
                if (!poly1.Contains(intersect.IntersectionPoint))
                {
                    poly1.Insert(poly1.IndexOf(intersect.EdgeOne.EdgeStart) + 1, intersect.IntersectionPoint);
                }

                if (!poly2.Contains(intersect.IntersectionPoint))
                {
                    poly2.Insert(poly2.IndexOf(intersect.EdgeTwo.EdgeStart) + 1, intersect.IntersectionPoint);
                }
            }

            // Find starting point on the edge of polygon1 
            // that is outside of the intersected area
            // to begin polygon trace.
            int startingIndex = -1;
            int currentIndex = 0;
            do
            {
                if (!PointInPolygonAngle(poly1[currentIndex], poly2))
                {
                    startingIndex = currentIndex;
                    break;
                }
                currentIndex = poly1.NextIndex(currentIndex);
            } while (currentIndex != 0);

            // If we dont find a point on polygon1 thats outside of the
            // intersect area, the polygon1 must be inside of polygon2,
            // in which case, polygon2 IS the union of the two.
            if (startingIndex == -1)
            {
                error = PolyUnionError.Poly1InsidePoly2;
            }

            return startingIndex;
        }

        /// <summary>
        /// Check and return polygon intersections
        /// </summary>
        /// <param name="polygon1"></param>
        /// <param name="polygon2"></param>
        /// <param name="intersections"></param>
        /// <returns></returns>
        private static bool VerticesIntersect(Vertices polygon1, Vertices polygon2,
                                       ref List<EdgeIntersectInfo> intersections)
        {
            // Make sure the output is clear before we start.
            intersections.Clear();

            // Iterate through polygon1's edges
            for (int i = 0; i < polygon1.Count; i++)
            {
                // Get edge vertices
                Vector2 p1 = polygon1[i];
                Vector2 p2 = polygon1[polygon1.NextIndex(i)];

                // Get intersections between this edge and polygon2
                for (int j = 0; j < polygon2.Count; j++)
                {
                    Vector2 point;

                    Vector2 p3 = polygon2[j];
                    Vector2 p4 = polygon2[polygon2.NextIndex(j)];

                    // _defaultFloatTolerance = .00001f (Perhaps this should be made available publically from RayHelper?

                    // Check if the edges intersect 
                    if (LineIntersect(p1, p2, p3, p4, true, true, .00001f, out point))
                    {
                        // Here, we round the returned intersection point to its nearest whole number.
                        // This prevents floating point anomolies where 99.9999-> is returned instead of 100.
                        point = new Vector2((float)Math.Round(point.X, 0), (float)Math.Round(point.Y, 0));
                        // Record the intersection
                        intersections.Add(new EdgeIntersectInfo(new Edge(p1, p2), new Edge(p3, p4), point));
                    }
                }
            }

            // true if any intersections were found.
            return (intersections.Count > 0);
        }

        /// <summary>
        /// * ref: http://ozviz.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/  - Solution 2 
        /// * Compute the sum of the angles made between the test point and each pair of points making up the polygon. 
        /// * If this sum is 2pi then the point is an interior point, if 0 then the point is an exterior point. 
        /// </summary>
        private static bool PointInPolygonAngle(Vector2 point, Vertices polygon)
        {
            double angle = 0;

            // Iterate through polygon's edges
            for (int i = 0; i < polygon.Count; i++)
            {
                /*
                p1.h = polygon[i].h - p.h;
                p1.v = polygon[i].v - p.v;
                p2.h = polygon[(i + 1) % n].h - p.h;
                p2.v = polygon[(i + 1) % n].v - p.v;
                */
                // Get points
                Vector2 p1 = polygon[i] - point;
                Vector2 p2 = polygon[polygon.NextIndex(i)] - point;

                angle += VectorAngle(p1, p2);
            }

            if (Math.Abs(angle) < Math.PI)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Merges two polygons, given that they intersect.
        /// </summary>
        /// <param name="polygon1">The first polygon.</param>
        /// <param name="polygon2">The second polygon.</param>
        /// <param name="error">The error returned from union</param>
        /// <returns>The union of the two polygons, or null if there was an error.</returns>
        public static Vertices Union(Vertices polygon1, Vertices polygon2, out PolyUnionError error)
        {
            Vertices poly1;
            Vertices poly2;
            List<EdgeIntersectInfo> intersections;

            int startingIndex = PreparePolygons(polygon1, polygon2, out poly1, out poly2, out intersections, out error);

            if (startingIndex == -1)
            {
                switch (error)
                {
                    case PolyUnionError.NoIntersections:
                        return null;

                    case PolyUnionError.Poly1InsidePoly2:
                        return polygon2;
                }
            }

            Vertices union = new Vertices();
            Vertices currentPoly = poly1;
            Vertices otherPoly = poly2;

            // Store the starting vertex so we can refer to it later.
            Vector2 startingVertex = poly1[startingIndex];
            int currentIndex = startingIndex;

            do
            {
                // Add the current vertex to the final union
                union.Add(currentPoly[currentIndex]);

                foreach (EdgeIntersectInfo intersect in intersections)
                {
                    // If the current point is an intersection point
                    if (currentPoly[currentIndex] == intersect.IntersectionPoint)
                    {
                        // Make sure we want to swap polygons here.
                        int otherIndex = otherPoly.IndexOf(intersect.IntersectionPoint);

                        // If the next vertex, if we do swap, is not inside the current polygon,
                        // then its safe to swap, otherwise, just carry on with the current poly.
                        if (!PointInPolygonAngle(otherPoly[otherPoly.NextIndex(otherIndex)], currentPoly))
                        {
                            // switch polygons
                            if (currentPoly == poly1)
                            {
                                currentPoly = poly2;
                                otherPoly = poly1;
                            }
                            else
                            {
                                currentPoly = poly1;
                                otherPoly = poly2;
                            }

                            // set currentIndex
                            currentIndex = otherIndex;

                            // Stop checking intersections for this point.
                            break;
                        }
                    }
                }

                // Move to next index
                currentIndex = currentPoly.NextIndex(currentIndex);
            } while ((currentPoly[currentIndex] != startingVertex) && (union.Count <= (poly1.Count + poly2.Count)));


            // If the number of vertices in the union is more than the combined vertices
            // of the input polygons, then something is wrong and the algorithm will
            // loop forever. Luckily, we check for that.
            if (union.Count > (poly1.Count + poly2.Count))
            {
                error = PolyUnionError.InfiniteLoop;
            }

            return union;
        }
        /// <summary>
        /// Return the angle between two vectors on a plane
        /// The angle is from vector 1 to vector 2, positive anticlockwise
        /// The result is between -pi -> pi
        /// </summary>
        private static double VectorAngle(Vector2 p1, Vector2 p2)
        {
            double theta1 = Math.Atan2(p1.Y, p1.X);
            double theta2 = Math.Atan2(p2.Y, p2.X);
            double dtheta = theta2 - theta1;
            while (dtheta > Math.PI)
                dtheta -= (2 * Math.PI);
            while (dtheta < -Math.PI)
                dtheta += (2 * Math.PI);

            return (dtheta);
        }

        /// <summary>
        /// This method detects if two line segments (or lines) intersect,
        /// and, if so, the point of intersection. Use the <paramref name="firstIsSegment"/> and
        /// <paramref name="secondIsSegment"/> parameters to set whether the intersection point
        /// must be on the first and second line segments. Setting these
        /// both to true means you are doing a line-segment to line-segment
        /// intersection. Setting one of them to true means you are doing a
        /// line to line-segment intersection test, and so on.
        /// Note: If two line segments are coincident, then 
        /// no intersection is detected (there are actually
        /// infinite intersection points).
        /// Author: Jeremy Bell
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">This is set to the intersection
        /// point if an intersection is detected.</param>
        /// <param name="firstIsSegment">Set this to true to require that the 
        /// intersection point be on the first line segment.</param>
        /// <param name="secondIsSegment">Set this to true to require that the
        /// intersection point be on the second line segment.</param>
        /// <param name="floatTolerance">Some of the calculations require
        /// checking if a floating point Value equals another. This is
        /// the tolerance that is used to determine this (ie Value +
        /// or - <paramref name="floatTolerance"/>)</param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4, bool firstIsSegment,
                                         bool secondIsSegment, float floatTolerance, out Vector2 intersectionPoint)
        {
            return LineIntersect(ref point1, ref point2, ref point3, ref point4, firstIsSegment, secondIsSegment, floatTolerance,
                                 out intersectionPoint);
        }

        /// <summary>
        /// This method detects if two line segments (or lines) intersect,
        /// and, if so, the point of intersection. Use the <paramref name="firstIsSegment"/> and
        /// <paramref name="secondIsSegment"/> parameters to set whether the intersection point
        /// must be on the first and second line segments. Setting these
        /// both to true means you are doing a line-segment to line-segment
        /// intersection. Setting one of them to true means you are doing a
        /// line to line-segment intersection test, and so on.
        /// Note: If two line segments are coincident, then 
        /// no intersection is detected (there are actually
        /// infinite intersection points).
        /// Author: Jeremy Bell
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="point">This is set to the intersection
        /// point if an intersection is detected.</param>
        /// <param name="firstIsSegment">Set this to true to require that the 
        /// intersection point be on the first line segment.</param>
        /// <param name="secondIsSegment">Set this to true to require that the
        /// intersection point be on the second line segment.</param>
        /// <param name="floatTolerance">Some of the calculations require
        /// checking if a floating point Value equals another. This is
        /// the tolerance that is used to determine this (ie Value +
        /// or - <paramref name="floatTolerance"/>)</param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(ref Vector2 point1, ref Vector2 point2, ref Vector2 point3, ref Vector2 point4,
                                 bool firstIsSegment, bool secondIsSegment, float floatTolerance,
                                 out Vector2 point)
        {
            point = new Vector2();

            // these are reused later.
            // each lettered sub-calculation is used twice, except
            // for b and d, which are used 3 times
            float a = point4.Y - point3.Y;
            float b = point2.X - point1.X;
            float c = point4.X - point3.X;
            float d = point2.Y - point1.Y;

            // denominator to solution of linear system
            float denom = (a * b) - (c * d);

            // if denominator is 0, then lines are parallel
            if (!(denom >= -_epsilon && denom <= _epsilon))
            {
                float e = point1.Y - point3.Y;
                float f = point1.X - point3.X;
                float oneOverDenom = 1.0f / denom;

                // numerator of first equation
                float ua = (c * e) - (a * f);
                ua *= oneOverDenom;

                // check if intersection point of the two lines is on line segment 1
                if (!firstIsSegment || ua >= 0.0f && ua <= 1.0f)
                {
                    // numerator of second equation
                    float ub = (b * e) - (d * f);
                    ub *= oneOverDenom;

                    // check if intersection point of the two lines is on line segment 2
                    // means the line segments intersect, since we know it is on
                    // segment 1 as well.
                    if (!secondIsSegment || ub >= 0.0f && ub <= 1.0f)
                    {
                        // check if they are coincident (no collision in this case)
                        if (ua != 0f && ub != 0f)
                        {
                            //There is an intersection
                            point.X = point1.X + ua * b;
                            point.Y = point1.Y + ua * d;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// This method detects if two line segments intersect,
        /// and, if so, the point of intersection. 
        /// Note: If two line segments are coincident, then 
        /// no intersection is detected (there are actually
        /// infinite intersection points).
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">This is set to the intersection
        /// point if an intersection is detected.</param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(ref Vector2 point1, ref Vector2 point2, ref Vector2 point3, ref Vector2 point4,
                                         out Vector2 intersectionPoint)
        {
            return LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, _epsilon, out intersectionPoint);
        }

        /// <summary>
        /// This method detects if two line segments intersect,
        /// and, if so, the point of intersection. 
        /// Note: If two line segments are coincident, then 
        /// no intersection is detected (there are actually
        /// infinite intersection points).
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">This is set to the intersection
        /// point if an intersection is detected.</param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4, out Vector2 intersectionPoint)
        {
            return LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, _epsilon, out intersectionPoint);
        }

        /// <summary>
        /// Get all intersections between a line segment and a list of vertices
        /// representing a polygon. The vertices reuse adjacent points, so for example
        /// edges one and two are between the first and second vertices and between the
        /// second and third vertices. The last edge is between vertex vertices.Count - 1
        /// and verts0. (ie, vertices from a Geometry or AABB)
        /// </summary>
        /// <param name="point1">The first point of the line segment to test</param>
        /// <param name="point2">The second point of the line segment to test.</param>
        /// <param name="vertices">The vertices, as described above</param>
        /// <param name="intersectionPoints">An list of intersection points. Any intersection points
        /// found will be added to this list.</param>
        public static void LineSegmentVerticesIntersect(ref Vector2 point1, ref Vector2 point2, Vertices vertices,
                                                        ref List<Vector2> intersectionPoints)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector2 point;
                if (LineIntersect(vertices[i], vertices[vertices.NextIndex(i)],
                                  point1, point2, true, true, _epsilon, out point))
                {
                    intersectionPoints.Add(point);
                }
            }
        }

        public bool CheckEquals(Vertices vertices)
        {
            if (this.Count != vertices.Count) return false;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] != vertices[i]) return false;
            }
            return true;
        }
        #endregion

    }

    #region DrDeth's Extension
    /// <summary>
    /// Enumerator to specify errors with Polygon functions.
    /// </summary>
    public enum PolyUnionError
    {
        None,
        NoIntersections,
        Poly1InsidePoly2,
        InfiniteLoop
    }

    public class Edge
    {
        public Edge(Vector2 edgeStart, Vector2 edgeEnd)
        {
            EdgeStart = edgeStart;
            EdgeEnd = edgeEnd;
        }

        public Vector2 EdgeStart { get; private set; }
        public Vector2 EdgeEnd { get; private set; }
    }

    public class EdgeIntersectInfo
    {
        public EdgeIntersectInfo(Edge edgeOne, Edge edgeTwo, Vector2 intersectionPoint)
        {
            EdgeOne = edgeOne;
            EdgeTwo = edgeTwo;
            IntersectionPoint = intersectionPoint;
        }

        public Edge EdgeOne { get; private set; }
        public Edge EdgeTwo { get; private set; }
        public Vector2 IntersectionPoint { get; private set; }
    }
    #endregion
}