using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2018 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome
  // https://www.paypal.me/cyotek

  internal partial class BaseForm : Form
  {
    #region Constructors

    public BaseForm()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6F, 13F);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.MinimizeBox = false;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.ResumeLayout(false);
    }

    #endregion

    #region Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      Cursor.Current = Cursors.Default;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      base.Font = SystemFonts.MessageBoxFont;
    }

    #endregion
  }
}
