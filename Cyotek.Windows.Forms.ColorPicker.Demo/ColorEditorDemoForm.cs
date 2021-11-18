using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorEditorDemoForm : DemonstrationBaseForm
  {
    #region Constructors

    public ColorEditorDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditor.Color = Color.SeaGreen;
    }

    private void ColorEditor_ColorChanged(object sender, EventArgs e)
    {
      colorPreviewBox.Color = colorEditor.Color;

      propertyGrid.Refresh();
    }

    #endregion
  }
}
