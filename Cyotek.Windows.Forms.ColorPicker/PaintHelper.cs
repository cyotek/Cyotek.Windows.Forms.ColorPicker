// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;

namespace Cyotek.Windows.Forms
{
  internal static class PaintHelper
  {
    #region Public Methods

    public static void DrawInvertedLine(Graphics g, Point start, Point end)
    {
      PaintHelper.DrawInvertedLine(g, start.X, start.Y, end.X, end.Y);
    }

    public static void DrawInvertedLine(Graphics g, int x1, int y1, int x2, int y2)
    {
      IntPtr hdc;

      hdc = g.GetHdc();
      NativeMethods.SetROP2(hdc, NativeMethods.R2_NOT);
      NativeMethods.MoveToEx(hdc, x1, y1, IntPtr.Zero);
      NativeMethods.LineTo(hdc, x2, y2);
      g.ReleaseHdc(hdc);
    }

    public static void DrawInvertedRect(Graphics g, int x, int y, int w, int h)
    {
      IntPtr hdc;

      hdc = g.GetHdc();
      NativeMethods.SetROP2(hdc, NativeMethods.R2_NOT);
      NativeMethods.MoveToEx(hdc, x, y, IntPtr.Zero);
      NativeMethods.LineTo(hdc, x + w - 1, y);
      NativeMethods.LineTo(hdc, x + w - 1, y + h - 1);
      NativeMethods.LineTo(hdc, x, y + h - 1);
      NativeMethods.LineTo(hdc, x, y);
      g.ReleaseHdc(hdc);
    }

    #endregion Public Methods
  }
}
