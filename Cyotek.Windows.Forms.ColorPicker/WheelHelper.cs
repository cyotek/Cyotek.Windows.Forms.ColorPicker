// Creating a custom single-axis scrolling control in WinForms
// https://www.cyotek.com/blog/creating-a-custom-single-axis-scrolling-control-in-winforms

// Derived from https://www.codeproject.com/articles/1042516/custom-controls-in-win-api-scrolling

using System;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  internal static class WheelHelper
  {
    #region Private Fields

    private static readonly int[] _accumulator = new int[2];

    private static readonly uint[] _lastActivity = new uint[2];

    private static readonly object _lock = new object();

    private static IntPtr _hwndCurrent = IntPtr.Zero;

    #endregion Private Fields

    #region Public Methods

    public static int WheelScrollLines(IntPtr hwnd, int delta, int pageSize, bool isVertical)
    {
      // We accumulate the wheel_delta until there is enough to scroll for
      // at least a single line. This improves the feel for strange values
      // of SPI_GETWHEELSCROLLLINES and for some mouses.

      uint now;
      int scrollSysParam;
      int linesPerWheelDelta;   // Scrolling speed (how much to scroll per WHEEL_DELTA).
      int dirIndex = isVertical ? 0 : 1;  // The index into iAccumulator[].
      int lines;                 // How much to scroll for currently accumulated value.

      now = NativeMethods.GetTickCount();

      // Even when nPage is below one line, we still want to scroll at least a little.
      if (pageSize < 1)
      {
        pageSize = 1;
      }

      // Ask the system for scrolling speed.
      scrollSysParam = isVertical
        ? NativeMethods.SPI_GETWHEELSCROLLLINES
        : NativeMethods.SPI_GETWHEELSCROLLCHARS;

      linesPerWheelDelta = 0;

      if (!NativeMethods.SystemParametersInfo(scrollSysParam, 0, ref linesPerWheelDelta, 0))
      {
        linesPerWheelDelta = 3;  // default when SystemParametersInfo() fails.
      }

      if (linesPerWheelDelta == NativeMethods.WHEEL_PAGESCROLL)
      {
        // System tells to scroll over whole pages.
        linesPerWheelDelta = pageSize;
      }

      if (linesPerWheelDelta > pageSize)
      {
        // Slow down if page is too small. We don't want to scroll over multiple
        // pages at once.
        linesPerWheelDelta = pageSize;
      }

      lock (_lock)
      {
        // In some cases, we do want to reset the accumulated value(s).
        if (hwnd != _hwndCurrent)
        {
          // Do not carry accumulated values between different HWNDs.
          _hwndCurrent = hwnd;
          _accumulator[0] = 0;
          _accumulator[1] = 0;
        }
        else if (now - _lastActivity[dirIndex] > SystemInformation.DoubleClickTime * 2)
        {
          // Reset the accumulator if there was a long time of wheel inactivity.
          _accumulator[dirIndex] = 0;
        }
        else if ((_accumulator[dirIndex] > 0) == (delta < 0))
        {
          // Reset the accumulator if scrolling direction has been reversed.
          _accumulator[dirIndex] = 0;
        }

        if (linesPerWheelDelta > 0)
        {
          // Accumulate the delta.
          _accumulator[dirIndex] += delta;

          // Compute the lines to scroll.
          lines = _accumulator[dirIndex] * linesPerWheelDelta / NativeMethods.WHEEL_DELTA;

          // Decrease the accumulator for the consumed amount.
          // (Corresponds to the remainder of the integer divide above.)
          _accumulator[dirIndex] -= lines * NativeMethods.WHEEL_DELTA / linesPerWheelDelta;
        }
        else
        {
          // uLinesPerWHEELDELTA == 0, i.e. likely configured to no scrolling
          // with mouse wheel.
          lines = 0;
          _accumulator[dirIndex] = 0;
        }

        _lastActivity[dirIndex] = now;
      }

      // Note that for vertical wheel, Windows provides the delta with opposite
      // sign. Hence the minus.
      return isVertical ? -lines : lines;
    }

    #endregion Public Methods
  }
}
