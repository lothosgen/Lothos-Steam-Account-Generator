using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator.File.MainUI.HTML.Listeners
{
    class Key_Listener
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        //private static readonly int VK_SNAPSHOT = 0x2C; //This is the print-screen key.

        //Assume the timer is setup with Interval = 16 (corresponds to ~60FPS).
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public static bool Listen(int ListenKey)
        {
            short keyState = GetAsyncKeyState(ListenKey);

            //Check if the MSB is set. If so, then the key is pressed.
            bool prntScrnIsPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            //Check if the LSB is set. If so, then the key was pressed since
            //the last call to GetAsyncKeyState
            bool unprocessedPress = ((keyState >> 0) & 0x0001) == 0x0001;

            if (prntScrnIsPressed)
            {
                //TODO Execute client code...

            }

            if (unprocessedPress)
            {
                //TODO Execute client code...
                return true;
            }
            return false;
        }
    }
}
