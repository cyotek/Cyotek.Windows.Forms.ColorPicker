// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

// Derived from https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-mouse-hook-in-c

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Cyotek.Windows.Forms
{
  internal static class ScreenColorPickerMouseHook
  {
    #region Private Fields

    private static IntPtr _hHook = IntPtr.Zero;

    private static LowLevelMouseProc _hookProc;

    private static ScreenColorPicker _owner;

    #endregion Private Fields

    #region Public Methods

    public static void Capture(ScreenColorPicker owner)
    {
      ScreenColorPickerMouseHook.Release();

      _hookProc = new LowLevelMouseProc(ScreenColorPickerMouseHook.MouseHookProc);

      _hHook = ScreenColorPickerMouseHook.SetHook(_hookProc);

      if (_hHook != IntPtr.Zero)
      {
        _owner = owner;
        _owner.MarkAsCapturing();
      }
    }

    public static void Release()
    {
      _owner?.MarkAsReleased();

      if (_hHook != IntPtr.Zero)
      {
        if (!NativeMethods.UnhookWindowsHookEx(_hHook))
        {
          throw new Win32Exception();
        }

        _hHook = IntPtr.Zero;
      }

      _hookProc = null;
    }

    #endregion Public Methods

    #region Private Methods

    private static IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      IntPtr result;

      if (nCode >= 0)
      {
        int message;

        message = wParam.ToInt32();

        if (message == NativeMethods.WM_MOUSEMOVE)
        {
          _owner.RequestUpdate();
        }

        if (message == NativeMethods.WM_LBUTTONDOWN || message == NativeMethods.WM_NCLBUTTONDOWN)
        {
          // if the user presses a button then update the colour, release,
          // but also eat the message so the click isn't intercepted
          _owner.UpdateColor();
          ScreenColorPickerMouseHook.Release();

          result = new IntPtr(1);
        }
        else
        {
          // do not eat, continue to next hook
          result = NativeMethods.CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
      }
      else
      {
        // do not process, continue to next hook
        result = NativeMethods.CallNextHookEx(_hHook, nCode, wParam, lParam);
      }

      return result;
    }

    private static IntPtr SetHook(LowLevelMouseProc proc)
    {
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        return NativeMethods.SetWindowsHookEx(NativeMethods.WH_MOUSE_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    #endregion Private Methods
  }
}
