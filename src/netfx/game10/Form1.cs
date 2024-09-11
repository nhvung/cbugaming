using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game10
{
    public partial class Form1 : Form

        
    {
        public Form1()
        {
            InitializeComponent();
        }

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
         CharSet = CharSet.Unicode, ExactSpelling = true,
         CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool EnumThreadWindows(int threadId, EnumWindowsProc callback, IntPtr lParam);

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        private extern static int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        enum WindowLongFlags : int
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWL_WNDPROC = -4,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4
        }

        public IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;

            foreach (ProcessThread t in process.Threads)
            {
                windowHandle = FindWindowInThread(t.Id, compareTitle);
                if (windowHandle != IntPtr.Zero)
                {
                    break;
                }
            }

            return windowHandle;
        }

        private IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            EnumThreadWindows(threadId, (hWnd, lParam) =>
            {
                StringBuilder text = new StringBuilder(200);
                GetWindowText(hWnd, text, 200);
                if (compareTitle(text.ToString()))
                {
                    windowHandle = hWnd;
                    return false;
                }
                else
                {
                    windowHandle = FindChildWindow(hWnd, compareTitle);
                    if (windowHandle != IntPtr.Zero)
                    {
                        return false;
                    }
                }
                return true;
            }, IntPtr.Zero);

            return windowHandle;
        }

        private IntPtr FindChildWindow(IntPtr hWnd, Func<string, bool> compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            EnumChildWindows(hWnd, (hChildWnd, lParam) =>
            {
                StringBuilder text = new StringBuilder(200);
                GetWindowText(hChildWnd, text, 200);
                if (compareTitle(text.ToString()))
                {
                    windowHandle = hWnd;
                    return false;
                }
                return true;
            }, IntPtr.Zero);

            return windowHandle;
        }

        private void ts_menu_add_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() {
            Filter = "EXE  Files|*.exe"};
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    String dir = Path.GetDirectoryName(ofd.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = ofd.FileName;
                    process.StartInfo.WorkingDirectory = dir;
                    process.Start();

                    // Wait for process to be created and enter idle condition
                    Thread.Sleep(5000);

                    //IntPtr appWin = FindWindowInProcess(process, s => s.StartsWith("Built on"));
                    IntPtr appWin = process.MainWindowHandle;

                    // Put it into this form
                    SetParent(appWin, this.Handle);

                    // Remove border and whatnot
                    SetWindowLong(appWin, (int)WindowLongFlags.GWL_STYLE, (uint)WindowStyles.WS_VISIBLE);

                    // Move the window to overlay it on this window
                    MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
                }
                catch
                {

                }
            }
        }
    }
}
