using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

public class Program {

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);

    const short SWP_NOMOVE = 0X2;
    const short SWP_NOSIZE = 1;
    const short SWP_NOZORDER = 0X4;
    const int SWP_SHOWWINDOW = 0x0040;

    public static void Main(string[] args) {

        while (true) {
            var hwnd = FindWindow("Windows.UI.Core.CoreWindow", "New notification");

            //Hides the notification
            //ShowWindow(hwnd, 0);

            if (System.AppDomain.CurrentDomain.FriendlyName == "topleft.exe"){
                //Sets to top left (easy peasy)
                //50PX Y offset to make the spacing even
                SetWindowPos(hwnd, 0, 0, -37, 0, 0, SWP_NOSIZE | SWP_NOZORDER | SWP_SHOWWINDOW);
            }
            else if (System.AppDomain.CurrentDomain.FriendlyName == "topright.exe"){
                //Sets to top left (not as easy)

                //Get the current position of the notification window
                Rectangle NotifyRect = new Rectangle();
                GetWindowRect(hwnd, ref NotifyRect);
                
                NotifyRect.Width = NotifyRect.Width - NotifyRect.X;
			    NotifyRect.Height = NotifyRect.Height - NotifyRect.Y;

                //50PX Y offset to make the spacing even
                SetWindowPos(hwnd, 0, Screen.PrimaryScreen.Bounds.Width - NotifyRect.Width, -37, 0, 0, SWP_NOSIZE | SWP_NOZORDER | SWP_SHOWWINDOW);
            }

            Thread.Sleep(10);
        }

        
        Console.ReadLine();

    }
}
