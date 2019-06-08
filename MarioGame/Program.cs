﻿using System;

namespace Gamespace
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            MarioGame.Instance.Run();
            //To run on mac, a mannul inculsion of Monogame.framwork from nuget is needed
        }
    }
#endif
}
