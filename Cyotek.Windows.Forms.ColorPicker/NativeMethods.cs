// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cyotek.Windows.Forms
{
  internal static class NativeMethods
  {
    #region Public Fields

    /// <summary>
    ///   Logical pixels inch in X
    /// </summary>
    public const int LOGPIXELSX = 88;

    /// <summary>
    ///   Logical pixels inch in Y
    /// </summary>
    public const int LOGPIXELSY = 90;

    public const int R2_NOT = 6;

    public const int WH_KEYBOARD_LL = 13;

    public const int WH_MOUSE_LL = 14;

    public const int WM_KEYDOWN = 0x0100;

    public const int WM_LBUTTONDOWN = 0x0201;

    public const int WM_MOUSEMOVE = 0x0200;

    public const int WM_NCLBUTTONDOWN = 0x00A1;

    #endregion Public Fields

    #region Private Fields

    private const string _gdi32DllName = "gdi32.dll";

    private const string _user32DllName = "user32.dll";

    #endregion Private Fields

    #region Public Methods

    [DllImport(_user32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport(_user32DllName)]
    public static extern bool DrawFocusRect(IntPtr hDC, [In] ref RECT lprc);

    public static void DrawFocusRectangle(Graphics g, Rectangle rectangle)
    {
      NativeMethods.DrawFocusRectangle(g, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
    }

    public static void DrawFocusRectangle(Graphics g, int x, int y, int w, int h)
    {
      NativeMethods.RECT rect;

      rect = new NativeMethods.RECT(x, y, x + w, y + h);

      // The Win32 API DrawFocusRect draws using an inverted brush and so works on black,
      // whereas ControlPaint.DrawFocusRect decidedly does not
      NativeMethods.DrawFocusRect(g.GetHdc(), ref rect);
      g.ReleaseHdc();
    }

    [DllImport(_user32DllName, EntryPoint = "GetDC", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    public static Point GetDesktopDpi()
    {
      IntPtr hWnd;
      IntPtr hDC;
      int dpix;
      int dpiy;

      hWnd = GetDesktopWindow();
      hDC = GetDC(hWnd);

      try
      {
        dpix = GetDeviceCaps(hDC, LOGPIXELSX);
        dpiy = GetDeviceCaps(hDC, LOGPIXELSY);
      }
      finally
      {
        ReleaseDC(hWnd, hDC);
      }

      return new Point(dpix, dpiy);
    }

    [DllImport(_user32DllName)]
    public static extern IntPtr GetDesktopWindow();

    [DllImport(_gdi32DllName)]
    public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport(_gdi32DllName, EntryPoint = "LineTo", CallingConvention = CallingConvention.StdCall)]
    public static extern bool LineTo(IntPtr hdc, int x, int y);

    [DllImport(_gdi32DllName, EntryPoint = "MoveToEx", CallingConvention = CallingConvention.StdCall)]
    public static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);

    [DllImport(_user32DllName, EntryPoint = "ReleaseDC", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport(_gdi32DllName, EntryPoint = "SetROP2", CallingConvention = CallingConvention.StdCall)]
    public static extern int SetROP2(IntPtr hdc, int fnDrawMode);

    [DllImport(_user32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport(_user32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport(_user32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);

    #endregion Public Methods

    #region Public Structs

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int left;

      public int top;

      public int right;

      public int bottom;

      public RECT(int left, int top, int right, int bottom)
      {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
      }
    }

    #endregion Public Structs
  }
}
