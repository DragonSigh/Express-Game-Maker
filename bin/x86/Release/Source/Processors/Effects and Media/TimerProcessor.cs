//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework;
namespace EGMGame.Components
{
    public class Timer
    {
        // The id of the variable assigned
        public int variableID;
        public int startTime;
        public int incrementType; // 0 - Increase 1 - Decrease
        public bool working = true;
        VariableData variable;

        #region Constructor And Setup
        public Timer() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="varID"></param>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <param name="second"></param>
        /// <param name="incrementType"></param>
        public Timer(int varID, int h, int m, int s, int type)
        {
            variableID = varID;
            startTime = h * 60 * 60 * 60;
            startTime += m * 60 * 60;
            startTime += s * 60;
            incrementType = type;
            // Get variable
            if (Global.Instance.Variables.TryGetValue(varID, out variable))
            {
                variable.Value = startTime;
            }
        }
        #endregion
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (working && Global.Instance.AutorunID == -1 && Global.Instance.GlobalAutorunID == -1 && !MenuScreen.DeactivateScene)
            {
                if (Global.Instance.Variables.TryGetValue(variableID, out variable))
                {
                    if (incrementType == 0) // Increase
                        variable.Value += 1;
                    else // Decrease
                        variable.Value -= 1;
                }
            }
        }
        /// <summary>
        /// Get the hours
        /// </summary>
        /// <returns></returns>
        public int GetHours()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60 / 60 / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Get the  minutes
        /// </summary>
        /// <returns></returns>
        public int GetMinutes()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60 / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Get the seconds
        /// </summary>
        /// <returns></returns>
        public int GetSeconds()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Get the total hours
        /// </summary>
        /// <returns></returns>
        public int GetTotalHours()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60 / 60 / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Get the total minutes
        /// </summary>
        /// <returns></returns>
        public int GetTotalMinutes()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60 / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Get the total Seconds
        /// </summary>
        /// <returns></returns>
        public int GetTotalSeconds()
        {
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                return (int)variable.Value / 60;
            }
            else
                return 0;
        }
        /// <summary>
        /// Start timer
        /// </summary>
        public void Start()
        {
            working = true;
        }
        /// <summary>
        /// Stop timer
        /// </summary>
        public void Stop()
        {
            working = false;
        }
        /// <summary>
        /// Reset timer
        /// </summary>
        public void Reset()
        {
            // Get variable
            if (Global.Instance.Variables.TryGetValue(variableID, out variable))
            {
                variable.Value = startTime;
            }
        }
    }
}
