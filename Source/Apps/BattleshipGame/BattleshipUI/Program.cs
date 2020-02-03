using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleship.Logger;
using Battleship.BattleshipControl;

namespace Battleship.BattleshipUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger.Write(LogLevel.Info, "---------------------------------------------------------------------------------------");
            Log.Logger.Write(LogLevel.Info, "                                                                Starting BattleshipGame");
            Log.Logger.Write(LogLevel.Info, "---------------------------------------------------------------------------------------");

            BattleshipController.Instance.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BattleshipForm());

            Log.Logger.Write(LogLevel.Info, "---------------------------------------------------------------------------------------");
            Log.Logger.Write(LogLevel.Info, "                                                                Stopping BattleshipGame");
            Log.Logger.Write(LogLevel.Info, "---------------------------------------------------------------------------------------");

        }
    }
}
