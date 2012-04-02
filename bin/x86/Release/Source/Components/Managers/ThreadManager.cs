//* Copyright (c) 2008, Charles Humphrey http://xna-uk.net/blogs/randomchaos/default.aspx
//* All rights reserved.
//*
//* Redistribution and use in source and binary forms, with or without
//* modification, are permitted provided that the following conditions are met:
//*     * Redistributions of source code must retain the above copyright
//*       notice, this list of conditions and the following disclaimer.
//*     * Redistributions in binary form must reproduce the above copyright
//*       notice, this list of conditions and the following disclaimer in the
//*       documentation and/or other materials provided with the distribution.
//*     * Neither the name of the RandomChaos nor the
//*       names of its contributors may be used to endorse or promote products
//*       derived from this software without specific prior written permission.
//*
//* THIS SOFTWARE IS PROVIDED BY CHARLES HUMPHREY ``AS IS'' AND ANY
//* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//* DISCLAIMED. IN NO EVENT SHALL CHARLES HUMPHREY BE LIABLE FOR ANY
//* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Threading;

namespace EGMGame
{

#if XBOX
    ///
    /// Processor affinity map.
    /// Index CPU CORE Comment
    /// -----------------------------------------------------------------------
    ///   0    1    1  Please avoid using. (used by 360)
    ///   1    1    2  Game runs here by default, so avoid this one too.
    ///   2    2    1  Please avoid using. (used by 360)
    ///   3    2    2  Part of Guide and Dashboard live here so usable in game.
    ///   4    3    1  Live market place downloads use this so usable in game.
    ///   5    3    2  Part of Guide and Dashboard live here so usable in game.
    /// -----------------------------------------------------------------------  
    ///
#endif

    /// <summary>
    /// This is the Thread manager.
    /// </summary>
    public class ThreadManager : GameComponent
    {

        /// <summary>
        /// List of ThreadStart used to start the treads.
        /// </summary>
        private Dictionary<int, ThreadStart> threadStarters = new Dictionary<int, ThreadStart>();
        private Dictionary<int, ThreadCodeObj> threadedCodeList = new Dictionary<int, ThreadCodeObj>();
        /// <summary>
        /// List of runnign threads.
        /// </summary>
        private Dictionary<int, Thread> threads = new Dictionary<int, Thread>();

        /// <summary>
        /// Managers GameTime to be passed onto the threads.
        /// </summary>
        static GameTime gameTime;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="game">Calling game class</param>
        public ThreadManager(Game game)
            : base(game)
        { }

        /// <summary>
        /// Overiden Update call, loads manager gameTime varaible.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            ThreadManager.gameTime = gameTime;

            for (int t = 0; t < threadedCodeList.Count; t++)
                threadedCodeList[t].Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Method to add a thread to the maanger.
        /// </summary>
        /// <param name="threadCode">Code to be executed in the thread.</param>
        /// <param name="threadInterval">Time period between each call in miliseconds</param>
        /// <returns>Index of thread, first one added will be 0 next 1 etc..</returns>
#if XBOX
        public int AddThread(ThreadCode threadCode, int threadInterval, int affinityIndex)
#else
        public int AddThread(ThreadCode threadCode, int threadInterval)
#endif
        {
            int retVal = threads.Count;

#if XBOX
            ThreadCodeObj thisThread = new ThreadCodeObj(threadCode, threadInterval, affinityIndex);
#else
            ThreadCodeObj thisThread = new ThreadCodeObj(threadCode, threadInterval);
#endif

            threadedCodeList.Add(threadedCodeList.Count, thisThread);
            threadStarters.Add(threadStarters.Count, new ThreadStart(thisThread.Worker));
            threads.Add(threads.Count, new Thread(threadStarters[threads.Count]));

            threads[threads.Count - 1].Start();

            return retVal;
        }
        /// <summary>
        /// Method to kill a single thread.
        /// </summary>
        /// <param name="index"></param>
        public void KillThread(int index)
        {
            threadedCodeList[index].KillThread(threads[index]);
        }

        /// <summary>
        /// Method to start a thread
        /// </summary>
        /// <param name="threadCode"></param>
        /// <param name="threadInterval"></param>
        /// <param name="index"></param>
#if WINDOWS
        public void StartThread(ThreadCode threadCode, int threadInterval, int index)
        {
            if (index < threadedCodeList.Count)
            {
                if (threadedCodeList[index].stopThread)
                {
                    threads[index] = new Thread(threadStarters[index]);
                    threadedCodeList[index].stopThread = false;
                    threads[index].Start();
                }
            }
            else
            {
                AddThread(threadCode, threadInterval);
            }
        }
#endif

#if XBOX
        /// <summary>
        /// Method to start a thread
        /// </summary>
        /// <param name="threadCode"></param>
        /// <param name="threadInterval"></param>
        /// <param name="index"></param>
        public void StartThread(ThreadCode threadCode, int threadInterval, int affinityIndex, int index)
        {
            if (index < threadedCodeList.Count)
            {
                if (threadedCodeList[index].stopThread)
                {
                    threads[index] = new Thread(threadStarters[index]);
                    threadedCodeList[index].stopThread = false;
                    threads[index].Start();
                }
            }
            else
            {
                AddThread(threadCode, threadInterval, affinityIndex);
            }
        }
#endif
        /// <summary>
        /// Method to tidy up unfinished threads.
        /// </summary>
        /// <param name="disposing"></param>
#if !SILVERLIGHT
        protected override void Dispose(bool disposing)
        {
            for (int t = 0; t < threads.Count; t++)
                KillThread(t);

            base.Dispose(disposing);
        }
#elif SILVERLIGHT
        public void Dispose(bool disposing)
        {
            for (int t = 0; t < threads.Count; t++)
                KillThread(t);
        }
#endif
        /// <summary>
        /// Is Thread Running
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsThreadRunning(int index)
        {
            if (index < threadedCodeList.Count)
            {
                return threads[index].IsAlive;
            }
            return false;
        }
    }

    /// <summary>
    /// This is the delegate to be used for passing the code to be called in the tread.
    /// </summary>
    /// <param name="gameTime">GameTime</param>
    public delegate void ThreadCode(GameTime gameTime);

    /// <summary>
    /// This class holds the required data for the code to be called in the thread.
    /// </summary>
    internal class ThreadCodeObj
    {
        public ThreadCode CodeToCall = null;

        /// <summary>
        /// Used to make the thread wait.
        /// </summary>
        private ManualResetEvent threadStopEvent = new ManualResetEvent(false);
        /// <summary>
        /// Bool to control imediate stopping of thread loop.
        /// </summary>        
        public bool stopThread = false;
        /// <summary>
        /// Interval thread will wait befoer next cycle.
        /// </summary>        
        private int threadIntervals = 1;

#if XBOX 
        int processorAffinity;
#endif

        public GameTime gameTime;

#if XBOX
        public ThreadCodeObj(ThreadCode code,int interval,int affinity)
        {
            CodeToCall = code;
            threadIntervals = interval;
            processorAffinity = affinity;
        }
#else
        public ThreadCodeObj(ThreadCode code, int interval)
        {
            CodeToCall = code;
            threadIntervals = interval;
        }
#endif
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
        public void Worker()
        {
#if XBOX
            Thread.CurrentThread.SetProcessorAffinity(new int[] { processorAffinity });
#endif
            do
            {
                using (new LockWrapper(gameTime))
                {
                    if (gameTime != null)
                        CodeToCall(gameTime);
                }
            }

            while (!threadStopEvent.WaitOne(threadIntervals) && !stopThread);

        }
        public void KillThread(Thread thread)
        {
            if (!stopThread)
            {
                using (new LockWrapper(stopThread))
                {
                    stopThread = true;
                    thread.Join(0);
                }
            }
        }
    }

    public struct LockWrapper : IDisposable
    {
        public LockWrapper(object lockingObject)
        {
            // acquire the lock 
        }

        public void Dispose()
        {
            // release the lock 
        }
    }


    //#if XBOX
    //    ///
    //    /// Processor affinity map.
    //    /// Index CPU CORE Comment
    //    /// -----------------------------------------------------------------------
    //    ///   0    1    1  Please avoid using. (used by 360)
    //    ///   1    1    2  Game runs here by default, so avoid this one too.
    //    ///   2    2    1  Please avoid using. (used by 360)
    //    ///   3    2    2  Part of Guide and Dashbaord live here so usable in game.
    //    ///   4    3    1  Live market place downloads use this so usable in game.
    //    ///   5    3    2  Part of Guide and Dashbaord live here so usable in game.
    //    /// -----------------------------------------------------------------------  
    //    ///
    //#endif
    //    /// <summary>
    //    /// This is the delegate to be used for passing the code to be called in the tread.
    //    /// </summary>
    //    /// <param name="gameTime">GameTime</param>
    //    public delegate void ThreadCode(GameTime gameTime);

    //    /// <summary>
    //    /// This class holds the required data for the code to be called in the thread.
    //    /// </summary>
    //    internal class ThreadCodeObj
    //    {
    //        public ThreadCode CodeToCall = null;

    //        /// <summary>
    //        /// Mutex to stop thread clashes.
    //        /// </summary>
    //#if !SILVERLIGHT
    //        private static Mutex mutex = new Mutex();
    //#endif
    //        /// <summary>
    //        /// Used to make the thread wait.
    //        /// </summary>
    //        private ManualResetEvent threadStopEvent = new ManualResetEvent(false);
    //        /// <summary>
    //        /// Bool to control imediate stopping of thread loop.
    //        /// </summary>        
    //        public bool stopThread = false;
    //        /// <summary>
    //        /// Interval thread will wait befoer next cycle.
    //        /// </summary>        
    //        private int threadIntervals = 1;

    //#if XBOX 
    //        int processorAffinity;
    //#endif

    //        public GameTime gameTime;

    //#if XBOX
    //        public ThreadCodeObj(ThreadCode code,int interval,int affinity)
    //        {
    //            CodeToCall = code;
    //            threadIntervals = interval;
    //            processorAffinity = affinity;
    //        }
    //#else
    //        public ThreadCodeObj(ThreadCode code, int interval)
    //        {
    //            CodeToCall = code;
    //            threadIntervals = interval;
    //        }
    //#endif
    //        public void Update(GameTime gameTime)
    //        {
    //            this.gameTime = gameTime;
    //        }
    //        public void Worker()
    //        {
    //#if XBOX
    //            Thread.CurrentThread.SetProcessorAffinity(new int[] { processorAffinity });
    //#endif
    //            do
    //            {
    //                try
    //                {
    //#if !SILVERLIGHT
    //                    mutex.WaitOne();
    //#endif
    //                    if (gameTime != null)
    //                        CodeToCall(gameTime);

    //                }
    //                finally
    //                {
    //#if !SILVERLIGHT
    //                    mutex.ReleaseMutex();
    //#endif
    //                }
    //            }
    //#if !SILVERLIGHT
    //            while (!threadStopEvent.WaitOne(threadIntervals, false) && !stopThread);
    //#else

    //            while (!threadStopEvent.WaitOne(threadIntervals) && !stopThread);
    //#endif
    //        }
    //        public void KillThread(Thread thread)
    //        {
    //            if (!stopThread)
    //            {
    //#if !SILVERLIGHT
    //                mutex.WaitOne();
    //#endif
    //                stopThread = true;
    //#if !XBOX
    //                if (thread.IsAlive)
    //#endif
    //                    thread.Join(0);
    //#if !SILVERLIGHT
    //                mutex.ReleaseMutex();
    //#endif
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// This is the Thread manager.
    //    /// </summary>
    //    public class ThreadManager : GameComponent
    //    {

    //        /// <summary>
    //        /// List of ThreadStart used to start the treads.
    //        /// </summary>
    //        private Dictionary<int, ThreadStart> threadStarters = new Dictionary<int, ThreadStart>();
    //        private Dictionary<int, ThreadCodeObj> threadedCodeList = new Dictionary<int, ThreadCodeObj>();
    //        /// <summary>
    //        /// List of runnign threads.
    //        /// </summary>
    //        private Dictionary<int, Thread> threads = new Dictionary<int, Thread>();

    //        /// <summary>
    //        /// Managers GameTime to be passed onto the threads.
    //        /// </summary>
    //        static GameTime gameTime;
    //        /// <summary>
    //        /// ctor
    //        /// </summary>
    //        /// <param name="game">Calling game class</param>
    //        public ThreadManager(Game game)
    //            : base(game)
    //        { }

    //        /// <summary>
    //        /// Overiden Update call, loads manager gameTime varaible.
    //        /// </summary>
    //        /// <param name="gameTime"></param>
    //        public override void Update(GameTime gameTime)
    //        {
    //            ThreadManager.gameTime = gameTime;

    //            for (int t = 0; t < threadedCodeList.Count; t++)
    //                threadedCodeList[t].Update(gameTime);

    //            base.Update(gameTime);
    //        }

    //        /// <summary>
    //        /// Method to add a thread to the maanger.
    //        /// </summary>
    //        /// <param name="threadCode">Code to be executed in the thread.</param>
    //        /// <param name="threadInterval">Time period between each call in miliseconds</param>
    //        /// <returns>Index of thread, first one added will be 0 next 1 etc..</returns>
    //#if XBOX
    //        public int AddThread(ThreadCode threadCode, int threadInterval,int affinityIndex)
    //#else
    //        public int AddThread(ThreadCode threadCode, int threadInterval)
    //#endif
    //        {
    //            int retVal = threads.Count;

    //#if XBOX
    //            ThreadCodeObj thisThread = new ThreadCodeObj(threadCode, threadInterval,affinityIndex);
    //#else
    //            ThreadCodeObj thisThread = new ThreadCodeObj(threadCode, threadInterval);
    //#endif

    //            threadedCodeList.Add(threadedCodeList.Count, thisThread);
    //            threadStarters.Add(threadStarters.Count, new ThreadStart(thisThread.Worker));
    //            threads.Add(threads.Count, new Thread(threadStarters[threads.Count]));

    //            return retVal;
    //        }

    //        /// <summary>
    //        /// Method to kill a single thread.
    //        /// </summary>
    //        /// <param name="index"></param>
    //        public void KillThread(int index)
    //        {
    //            threadedCodeList[index].KillThread(threads[index]);
    //        }

    //        /// <summary>
    //        /// Method to start a thread
    //        /// </summary>
    //        /// <param name="threadCode"></param>
    //        /// <param name="threadInterval"></param>
    //        /// <param name="index"></param>
    //        public void StartThread(int index)
    //        {
    //            threads[index] = new Thread(threadStarters[index]);
    //            threadedCodeList[index].stopThread = false;
    //            threads[index].Start();
    //        }

    //        /// <summary>
    //        /// Method to tidy up unfinished threads.
    //        /// </summary>
    //        /// <param name="disposing"></param>
    //#if !SILVERLIGHT
    //        protected override void Dispose(bool disposing)
    //        {
    //            for (int t = 0; t < threads.Count; t++)
    //                KillThread(t);

    //            base.Dispose(disposing);
    //        }
    //#elif SILVERLIGHT
    //        public void Dispose(bool disposing)
    //        {
    //            for (int t = 0; t < threads.Count; t++)
    //                KillThread(t);
    //        }
    //#endif
    //    }
}
