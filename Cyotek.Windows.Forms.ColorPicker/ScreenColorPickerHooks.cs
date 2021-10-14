// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

// Mouse hook derived from https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-mouse-hook-in-c
// Keyboard hook derived from https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  internal static class ScreenColorPickerHooks
  {
    #region Private Fields

    private static readonly LowLevelKeyboardProc _keyboardHookProc = ScreenColorPickerHooks.KeyboardHookProc;

    private static readonly LowLevelMouseProc _mouseHookProc = ScreenColorPickerHooks.MouseHookProc;

    private static IntPtr _keyboardHooK = IntPtr.Zero;

    private static IntPtr _mouseHook = IntPtr.Zero;

    private static ScreenColorPicker _owner;

    #endregion Private Fields

    #region Public Methods

    public static void Capture(ScreenColorPicker owner)
    {
      ScreenColorPickerHooks.Release();

      if (owner.MarkAsCapturing())
      {
        _mouseHook = ScreenColorPickerHooks.SetHook(_mouseHookProc);
        _keyboardHooK = ScreenColorPickerHooks.SetHook(_keyboardHookProc);

        _owner = owner;
      }
    }

    public static void Release()
    {
      _owner?.MarkAsReleased();
      _owner = null;

      ScreenColorPickerHooks.Release(ref _mouseHook);
      ScreenColorPickerHooks.Release(ref _keyboardHooK);
    }

    #endregion Public Methods

    #region Private Methods

    private static IntPtr KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      IntPtr result;

      if (nCode >= 0 && wParam == (IntPtr)NativeMethods.WM_KEYDOWN)
      {
        if ((Keys)Marshal.ReadInt32(lParam) == Keys.Escape)
        {
          // if the user presses escape, abort the capture
          // but also eat the message so the press isn't intercepted
          ScreenColorPickerHooks.Release();

          result = new IntPtr(1);
        }
        else
        {
          // do not eat, continue to next hook
          result = NativeMethods.CallNextHookEx(_mouseHook, nCode, wParam, lParam);
        }
      }
      else
      {
        // do not process, continue to next hook
        result = NativeMethods.CallNextHookEx(_mouseHook, nCode, wParam, lParam);
      }

      return result;
    }

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
          ScreenColorPickerHooks.Release();

          result = new IntPtr(1);
        }
        else
        {
          // do not eat, continue to next hook
          result = NativeMethods.CallNextHookEx(_mouseHook, nCode, wParam, lParam);
        }
      }
      else
      {
        // do not process, continue to next hook
        result = NativeMethods.CallNextHookEx(_mouseHook, nCode, wParam, lParam);
      }

      return result;
    }

    private static void Release(ref IntPtr handle)
    {
      if (handle != IntPtr.Zero)
      {
        if (!NativeMethods.UnhookWindowsHookEx(handle))
        {
          throw new Win32Exception();
        }

        handle = IntPtr.Zero;
      }
    }

    private static IntPtr SetHook(LowLevelMouseProc proc)
    {
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        return NativeMethods.SetWindowsHookEx(NativeMethods.WH_MOUSE_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        return NativeMethods.SetWindowsHookEx(NativeMethods.WH_KEYBOARD_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    #endregion Private Methods
  }
}
