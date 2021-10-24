// Cyotek ImageBox
// http://cyotek.com/blog/tag/imagebox

// Copyright (c) 2010-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

// This code is derived from http://stackoverflow.com/a/13292894/148962 and http://stackoverflow.com/a/11034674/148962

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// A message filter for WM_MOUSEWHEEL and WM_MOUSEHWHEEL. This class cannot be inherited.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.IMessageFilter"/>
  internal sealed class MouseWheelMessageFilter<T> : IMessageFilter
    where T : Control
  {
    #region Private Fields

    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    private static bool _enabled;

    private static MouseWheelMessageFilter<T> _instance;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Constructor that prevents a default instance of this class from being created.
    /// </summary>
    private MouseWheelMessageFilter()
    {
    }

    #endregion Private Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets a value indicating whether the filter is active
    /// </summary>
    /// <value>
    /// <c>true</c> if the message filter is active, <c>false</c> if not.
    /// </value>
    [SuppressMessage("Design", "RCS1158:Static member in generic type should use a type parameter.", Justification = "<Pending>")]
    public static bool Enabled
    {
      get => _enabled;
      set
      {
        if (_enabled != value)
        {
          _enabled = value;

          if (_enabled)
          {
            Interlocked.CompareExchange(ref _instance, new MouseWheelMessageFilter<T>(), null);

            Application.AddMessageFilter(_instance);
          }
          else if (_instance != null)
          {
            Application.RemoveMessageFilter(_instance);
          }
        }
      }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Filters out a message before it is dispatched.
    /// </summary>
    /// <param name="m">  [in,out] The message to be dispatched. You cannot modify this message. </param>
    /// <returns>
    /// <c>true</c> to filter the message and stop it from being dispatched; <c>false</c> to allow the message to
    /// continue to the next filter or control.
    /// </returns>
    /// <seealso cref="M:System.Windows.Forms.IMessageFilter.PreFilterMessage(Message@)"/>
    bool IMessageFilter.PreFilterMessage(ref Message m)
    {
      bool result;

      if (m.Msg == NativeMethods.WM_MOUSEWHEEL || m.Msg == NativeMethods.WM_MOUSEHWHEEL)
      {
        IntPtr hControlUnderMouse;

        hControlUnderMouse = NativeMethods.WindowFromPoint(new Point((int)m.LParam));

        if (hControlUnderMouse != m.HWnd && Control.FromHandle(hControlUnderMouse) is T)
        {
          // redirect the message to the control under the mouse
          NativeMethods.SendMessage(hControlUnderMouse, m.Msg, m.WParam, m.LParam);

          // eat the message (otherwise it's possible two controls will scroll
          // at the same time, which looks awful... and is probably confusing!)
          result = true;
        }
        else
        {
          // window under the mouse either isn't managed or isn't
          // our custom control so do not try and handle the message
          result = false;
        }
      }
      else
      {
        // not a message we can process, don't try and block it
        result = false;
      }

      return result;
    }

    #endregion Public Methods
  }
}
