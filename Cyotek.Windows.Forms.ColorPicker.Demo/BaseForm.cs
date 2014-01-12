﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class BaseForm : Form
  {
    #region Public Constructors

    public BaseForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      this.Font = SystemFonts.MessageBoxFont;

      base.OnLoad(e);
    }

    #endregion
  }
}
