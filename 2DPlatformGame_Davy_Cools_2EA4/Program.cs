using System;

namespace _2DPlatformGame_Davy_Cools_2EA4
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
            using (var game = new GameMenuScreen())
                game.Run();
        }
    }
#endif
}
