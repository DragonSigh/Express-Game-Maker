//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Collision;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using EGMGame.Processors;
using EGMGame.Library;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;

namespace EGMGame.Components
{
    public class Pathfinder
    {
        // Collision Box of the agent (the thing you are path finding)
        static Body agentBox;
        /// <summary>
        /// Find path
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="endPoint"></param>
        /// <param name="directions"></param>
        /// <param name="turn"></param>
        /// <param name="precision">The precision of the grid, 1 is bad and quick, 10+ is good and slow</param>
        internal static List<Vector2> FindPath(EventProcessor obj, Vector2 endPos, List<int> directions, int precision)
        {

            // Set the agentBox.
            if (obj.Body != null)
            {
                agentBox = obj.Body.DeepClone();
            }
            else
                return null;

            // ----- Calculate the map collision map -----

            // The current map so we can get tile size info etc.            
            MapProcessor map = Global.Instance.CurrentMap;
            // Get the box surrounding the agentBox
            // We need to work out the optimal grid size to work out
            // the preciseness of the path finding, big = slow & precise
            // small = quick & imprecise. We need a balance.
            Vector2 GridSize = ConvertUnits.ToDisplayUnits(new Vector2(agentBox.Width, agentBox.Height)) / precision;

            // Define the start and end point
            Vector2 startNodePos = GetRoundedNodePosition(obj.Position, GridSize);
            AStarNode startNode = new AStarNode(false, obj.Position, GridSize, (int)(startNodePos.X / GridSize.X), (int)(startNodePos.Y / GridSize.Y));

            Vector2 endNodePos = GetRoundedNodePosition(endPos, GridSize);
            AStarNode endNode = new AStarNode(false, endNodePos, GridSize, (int)(endNodePos.X / GridSize.X), (int)(endNodePos.Y / GridSize.Y));

            if (startNodePos == endNodePos || (startNodePos - endNodePos).Length() < GridSize.Length())
            {
                return null;
            }
            // Now we generate the array for the path finding.
            // For whether or not the grid square is occupied.
            // Note: because this needs to be quick, and imprecise, the conversion from float
            // to int here means that the grid will not fully cover the entire map, but a small 
            // amount, but this is just a small price to pay for the system we have in place.
            AStarNode[,] NodeGrid =
              new AStarNode[(int)(map.Data.Size.X / GridSize.X) + 1,
                    (int)(map.Data.Size.Y / GridSize.Y) + 1];

            List<Body> CollisionGrid = map.MapBodies;

            // Now we need to fill this grid to find out what it occupied
            // or not.
            for (int i = 0; i < NodeGrid.GetLength(0); i++)
            {
                for (int z = 0; z < NodeGrid.GetLength(1); z++)
                {
                    // Create the node
                    NodeGrid[i, z] = new AStarNode(false, new Vector2(i * GridSize.X, z * GridSize.Y), GridSize, i, z);

                    // Assign data
                    if (startNode.Position != NodeGrid[i, z].Position
                        && endNode.Position != NodeGrid[i, z].Position)
                    {
                        NodeGrid[i, z].Occupied = IsOccupied(NodeGrid[i, z], CollisionGrid);
                    }
                }
            }

            // Begin A* Algorythm!
            // Stores all the nodes that require visiting.
            List<AStarNode> openList = new List<AStarNode>(); ;

            // Stores all visited nodes.
            List<AStarNode> closedList = new List<AStarNode>(); ;

            // Fill the list 
            openList = GetAdjacentNodes(startNode, directions, NodeGrid, GridSize);

            AStarNode finalNode = null;

            // Begin the A* algorythm!
            AStarNode node = openList[0];
            int nodeCount = 0;
            while (node != null)
            {
                if (openList.Count > nodeCount)
                {
                    node = openList[nodeCount];
                }
                else
                {
                    break;
                }

                if (node != null)
                {
                    // If node hasn't been visited.
                    if (!node.Visited)
                    {
                        // Mark the node as visited and add it to the closed list.
                        node.Visited = true;

                        closedList.Add(node);

                        // Checks if the current node is the end node.
                        if (node.Position == endNode.Position)
                        {
                            // The position is found! break and process final node.
                            finalNode = node;
                            break;
                        }
                        else
                        {
                            // Adds the adjacent nodes.
                            List<AStarNode> adjNodes = GetAdjacentNodes(node, directions, NodeGrid, GridSize);

                            // Adds them to the open list.
                            foreach (AStarNode m in adjNodes)
                            {
                                AddNodeToList(openList, endNode, node, node, m);
                            }
                            nodeCount++;
                        }
                    }
                    else
                        nodeCount++;
                }
                else
                {
                    finalNode = null;
                    break;
                }
            }

            List<Vector2> finalPath = new List<Vector2>();

            if (finalNode == null)
            {
                // No search found! Just stay still
                finalPath.Add(ConvertUnits.ToSimUnits(startNode.Position));
            }
            else
            {
                AStarNode processingNode = finalNode;

                while (processingNode.ParentNode != null)
                {
                    if (processingNode.ParentNode.Position != startNodePos)
                    {
                        finalPath.Add(ConvertUnits.ToSimUnits(processingNode.Position));
                        processingNode = processingNode.ParentNode;
                    }
                }
                finalPath.Reverse();
            }

            return finalPath;
        }

        internal static bool IsOccupied(AStarNode node, List<Body> fixtures)
        {
            agentBox.Position = ConvertUnits.ToSimUnits(node.Position);

            foreach (Body body in fixtures)
            {
                if (body.Collide(agentBox))
                    return true;
            }
            return false;
        }

        internal static AStarNode GetNextNode(List<AStarNode> openList)
        {
            AStarNode node;
            if (openList.Count > 0)
            {
                node = GetBestNode(openList);
                openList.Remove(node);
            }
            else
            {
                node = null;
            }

            return node;
        }

        internal static AStarNode GetBestNode(List<AStarNode> openList)
        {
            AStarNode node;

            int index = -1;
            int minCost = int.MaxValue;
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].TotalCost < minCost)
                {
                    minCost = openList[i].TotalCost;
                    index = i;
                }
            }

            if (index != -1)
            {
                node = openList[index];
            }
            else
            {
                node = null;
            }

            return node;
        }

        internal static Vector2 GetRoundedNodePosition(Vector2 position, Vector2 gridSize)
        {
            // Find the top left position of the grid square that contains the position
            Vector2 dividedPos = position / gridSize;
            // This will round the axis' to solid positions, now we can find the displacement between
            // the top left of the square and the end position.
            int roundedX = (int)Math.Round(dividedPos.X, 0);
            int roundedY = (int)Math.Round(dividedPos.Y, 0);
            roundedX = roundedX * (int)gridSize.X;
            roundedY = roundedY * (int)gridSize.Y;

            return new Vector2(roundedX, roundedY);
        }

        internal static void AddNodeToList(List<AStarNode> openList, AStarNode endNode, AStarNode parentNode, AStarNode currentNode, AStarNode node)
        {
            if (node != null)
            {
                if (!node.Occupied && !node.Visited)
                {
                    if (!openList.Contains(node))
                    {
                        node.ParentNode = parentNode;
                        // Find the node heuristic
                        Vector2 end = new Vector2(endNode.Position.X, endNode.Position.Y);
                        Vector2 v = new Vector2(node.Position.X, node.Position.Y);
                        float distance = Math.Abs(Vector2.Distance(v, end));
                        node.HeuristicCost = (int)distance;

                        // Add the parent cost is necessary
                        if (parentNode != null)
                        {
                            node.TotalCost = node.HeuristicCost + node.NodeCost + node.ParentNode.TotalCost;
                        }
                        else
                        {
                            node.TotalCost = node.HeuristicCost + node.NodeCost;
                        }

                        // Add the node to the open list.
                        openList.Add(node);
                    }
                    else
                    {
                        // Back checking to see if there is a better path
                        if (currentNode.TotalCost < node.TotalCost)
                        {
                            node.ParentNode = currentNode;
                            node.TotalCost = node.HeuristicCost + node.NodeCost + currentNode.TotalCost;
                        }
                    }
                }
            }
        }

        internal static List<AStarNode> GetAdjacentNodes(AStarNode node, List<int> directions, AStarNode[,] nodeList, Vector2 gridSize)
        {
            List<AStarNode> list = new List<AStarNode>();
            Vector2 currentPos = new Vector2(node.XID, node.YID);

            // Up
            if (currentPos.Y > 0 && directions.Contains(0))
            {
                list.Add(nodeList[(int)currentPos.X, (int)currentPos.Y - 1]);
            }
            // Up Right
            if (currentPos.Y > 0 && currentPos.X < nodeList.GetLength(0) - 1 && directions.Contains(5))
            {
                list.Add(nodeList[(int)currentPos.X + 1, (int)currentPos.Y - 1]);
            }
            // Right
            if (currentPos.X < nodeList.GetLength(0) - 1 && directions.Contains(3))
            {
                list.Add(nodeList[(int)currentPos.X + 1, (int)currentPos.Y]);
            }
            // Right Down
            if (currentPos.X < nodeList.GetLength(0) - 1 && currentPos.Y < nodeList.GetLength(1) - 1 && directions.Contains(7))
            {
                list.Add(nodeList[(int)currentPos.X + 1, (int)currentPos.Y + 1]);
            }
            // Down
            if (currentPos.Y < nodeList.GetLength(1) - 1 && directions.Contains(1))
            {
                list.Add(nodeList[(int)currentPos.X, (int)currentPos.Y + 1]);
            }
            // Down Left
            if (currentPos.Y < nodeList.GetLength(1) - 1 && currentPos.X > 0 && directions.Contains(6))
            {
                list.Add(nodeList[(int)currentPos.X - 1, (int)currentPos.Y + 1]);
            }
            // Left
            if (currentPos.X > 0 && directions.Contains(2))
            {
                list.Add(nodeList[(int)currentPos.X - 1, (int)currentPos.Y]);
            }
            // Left Up
            if (currentPos.Y > 0 && currentPos.X > 0 && directions.Contains(4))
            {
                list.Add(nodeList[(int)currentPos.X - 1, (int)currentPos.Y - 1]);
            }

            return list;
        }
    }

    public class AStarNode
    {
        public AStarNode(bool occupied, Vector2 position, Vector2 size, int xid, int yid)
        {
            XID = xid;
            YID = yid;
            Visited = false;
            Added = false;
            ParentNode = null;
            Occupied = occupied;
            Position = position;
            Size = size;
            TotalCost = 0;
            HeuristicCost = 0;
            NodeCost = 0;
        }

        public int XID;
        public int YID;
        public Vector2 Position;
        public Vector2 Size;
        public bool Occupied;
        public bool Visited;
        public bool Added;
        public AStarNode ParentNode;
        public int TotalCost;
        public int HeuristicCost;
        public int NodeCost;
    }

    public class PathfindingPath
    {
        public bool IsUsingPath = false;
        public bool Turn = true;
        public bool UseImpulse = false;
        public List<Vector2> VectorList = new List<Vector2>();

        public Vector2 CurrentVector
        {
            get { if (VectorList.Count > 0) return VectorList[0]; else return Vector2.Zero; }
        }

        public bool Done
        {
            get { return (VectorList.Count == 0); }
        }

        public void Progress()
        {
            if (VectorList[0] != null)
                VectorList.RemoveAt(0);
        }
        public void AddVector(Vector2 vector)
        {
            VectorList.Add(vector);
        }
        public void AddVector(List<Vector2> vectors, bool overwrite)
        {
            if (!overwrite)
            {
                foreach (Vector2 v in vectors)
                    VectorList.Add(v);
            }
            else
                VectorList = vectors;
        }

        public void Clear()
        {
            VectorList.Clear();
        }
    }
}