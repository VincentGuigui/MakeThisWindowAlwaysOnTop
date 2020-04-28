using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeThisWindowAlwaysOnTop
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, uint windowStyle);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public enum GWL
        {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }
        const UInt32 WS_EX_TOPMOST = 0x0008;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd,
            StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        // Define the callback delegate's type.
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        public Windows ListWindows = new Windows();

        // Return a list of the desktop windows' handles and titles.
        private void GetDesktopWindowHandlesAndTitles()
        {
            ListWindows.Clear();
            EnumDesktopWindows(IntPtr.Zero, FilterCallback, IntPtr.Zero);
        }

        // We use this function to filter windows.
        // This version selects visible windows that have titles.
        private bool FilterCallback(IntPtr hWnd, int lParam)
        {
            // Get the window's title.
            StringBuilder sb_title = new StringBuilder(1024);
            int length = GetWindowText(hWnd, sb_title, sb_title.Capacity);
            string title = sb_title.ToString();

            // If the window is visible and has a title, save it.
            if (IsWindowVisible(hWnd) &&
                string.IsNullOrEmpty(title) == false)
            {
                int dwExStyle = GetWindowLongPtr(hWnd, (int)GWL.GWL_EXSTYLE);
                ListWindows.Add(new Window { Handle = hWnd, Title = title, TopMost = (dwExStyle & WS_EX_TOPMOST) != 0 });
            }

            // Return true to indicate that we
            // should continue enumerating windows.
            return true;
        }

        public MainForm()
        {
            InitializeComponent();
            GetDesktopWindowHandlesAndTitles();
            lstWindows.DataSource = ListWindows;
        }

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTTOPMOST = new IntPtr(-2);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        private void lstWindows_DoubleClick(object sender, EventArgs e)
        {
            var selectedWindow = lstWindows.SelectedItem as Window;
            var idx = ListWindows.IndexOf(selectedWindow);

            Boolean result = SetWindowPos(selectedWindow.Handle, selectedWindow.TopMost ? HWND_NOTTOPMOST : HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            int dwExStyle = GetWindowLongPtr(selectedWindow.Handle, (int)GWL.GWL_EXSTYLE);
            selectedWindow.TopMost = (dwExStyle & WS_EX_TOPMOST) != 0;
            ListWindows.ResetItem(idx);
        }

        private void lstWindows_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GetDesktopWindowHandlesAndTitles();
                ListWindows.ResetBindings(false);
            }
        }
    }
}
