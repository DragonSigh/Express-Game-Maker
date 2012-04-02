//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EGMGame
{
    public class ExMath
    {
        /// <summary>
        /// Rotates a given point
        /// </summary>
        /// <param name="basePoint"></param>
        /// <param name="sourcePoint"></param>
        /// <param name="rotationAngle"></param>
        /// <returns></returns>
        public static Vector2 rotatePoint(Vector2 basePoint, Vector2 sourcePoint, float rotationAngle)
        {
            double r;
            double theta;
            double offsetX;
            double offsetY;
            double offsetTheta;
            double rotateX;
            double rotateY;
            double rotationRadians;
            Vector2 retPoint;
            try
            {
                //shift x and y relative to 0,0 origin  
                offsetX = (sourcePoint.X + (basePoint.X * -1));
                offsetY = (sourcePoint.Y + (basePoint.Y * -1));
                //convert to radians. take absolute value (necessary for x coord only).  
                offsetX = Math.Abs(offsetX * (Math.PI / 180));
                offsetY = offsetY * (Math.PI / 180);
                rotationRadians = rotationAngle * (Math.PI / 180);
                //get distance from origin to source point  
                r = Math.Sqrt(Math.Pow(offsetX, 2) + Math.Pow(offsetY, 2));
                //get current angle of orientation  
                theta = Math.Atan(offsetY / offsetX);
                // add rotation value to theta to get new angle of orientation  
                offsetTheta = theta + rotationRadians;
                //calculate new x coord  
                rotateX = r * Math.Cos(offsetTheta);
                //calculate new y coord  
                rotateY = r * Math.Sin(offsetTheta);
                //convert new x and y back to decimal degrees  
                rotateX = rotateX * (180 / Math.PI);
                rotateY = rotateY * (180 / Math.PI);
                //shift new x and y relative to base point  
                rotateX = (rotateX + basePoint.X);
                rotateY = (rotateY + basePoint.Y);
                //return new point  
                retPoint = new Vector2();
                retPoint.X = (float)rotateX;
                retPoint.Y = (float)rotateY;
                return retPoint;
            }
            catch
            {
                return sourcePoint;
            }
        }
        /// <summary>
        /// Returns whether the number is between two numbers
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p1">A number less then p</param>
        /// <param name="p2">A number greater then p</param>
        /// <returns></returns>
        internal static bool Between(int p, int p1, int p2)
        {
            return (p > p1 && p < p2);
        }
    }
}
