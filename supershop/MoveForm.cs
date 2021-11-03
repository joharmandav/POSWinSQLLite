using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//for DLL's
using System.Runtime.InteropServices;

namespace supershop
{
    class MoveForm
    {
        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

          ////if (e.Button == MouseButtons.Left)
          ////  {
          ////      MoveForm.ReleaseCapture();
          ////      MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
          ////  }

      
    }
}
