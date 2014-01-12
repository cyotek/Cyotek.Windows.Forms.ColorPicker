using System;
using System.Drawing;
using System.Windows.Forms;

// Cyotek Color Picker controls library
// Copyright © 2013-2014 Cyotek.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See colorpicker-license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  public partial class ScratchForm : Form
  {
    #region Public Constructors

    public ScratchForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Event Handlers

    private void ScratchForm_Load(object sender, EventArgs e)
    {
      colorEditor1.Color = SystemColors.Highlight;
    }

    private void colorEditor1_ColorChanged(object sender, EventArgs e)
    {
      label1.BackColor = colorEditor1.Color;
      label1.Text = colorEditor1.Color.Name;
    }

    #endregion
  }
}
