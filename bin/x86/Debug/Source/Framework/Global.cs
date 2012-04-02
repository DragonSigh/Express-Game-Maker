using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using EGMGame.Components;

namespace EGMGame.Library
{
    /// <summary>
    /// Helper class.
    /// Create animations, access variables, ....
    /// </summary>
    partial class Global
    {
        #region Animation
        /// <summary>
        /// Creates an animation and add its to the current map.
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionIndex"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="layerIndex"></param>
        /// <returns>Returns the created animation.</returns>
        public static AnimationProcessor CreateAnimation(int animationID, int actionIndex, int direction, Vector2 position, int layerIndex)
        {
            AnimationProcessor animation = new AnimationProcessor();
            animation.Setup(animationID, actionIndex, direction, position, layerIndex);
            Global.Instance.CurrentMap.AddProcessor(animation);
            return animation;
        }
        /// <summary>
        /// Creates an animation and add its to the current map.
        /// </summary>
        /// <param name="animationName"></param>
        /// <param name="actionIndex"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="layerIndex"></param>
        /// <returns>Returns the created animation.</returns>
        public static AnimationProcessor CreateAnimation(string animationName, int actionIndex, int direction, Vector2 position, int layerIndex)
        {
            AnimationProcessor animation = new AnimationProcessor();
            animation.Setup(animationName, actionIndex, direction, position, layerIndex);
            Global.Instance.CurrentMap.AddProcessor(animation);
            return animation;
        }
        #endregion

    }
}
