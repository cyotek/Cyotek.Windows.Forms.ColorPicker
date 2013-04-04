using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  internal partial class ColorSliderDemonstrationForm : BaseForm
  {
    #region Constructors

    public ColorSliderDemonstrationForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Event Handlers

    private void GotFocusHandler(object sender, EventArgs e)
    {
      propertyGrid.SelectedObject = sender;
    }

    private void ValueChangedHandler(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, "ValueChanged", new Dictionary<string, object>
      {
        {
          "Value", ((ColorSlider)sender).Value
        }
      });
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion
  }
}
