using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class BaseForm : Form
  {
    #region Constructors

    public BaseForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Overridden Members

    protected override void OnLoad(EventArgs e)
    {
      this.Font = SystemFonts.MessageBoxFont;

      base.OnLoad(e);
    }

    #endregion
  }
}
