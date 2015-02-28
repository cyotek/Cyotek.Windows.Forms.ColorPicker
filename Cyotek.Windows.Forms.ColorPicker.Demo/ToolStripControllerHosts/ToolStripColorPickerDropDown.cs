using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Cyotek Color Picker controls library
// Copyright © 2013-2015 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Demo.ToolStripControllerHosts
{
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  internal class ToolStripColorPickerDropDown : ToolStripDropDown
  {
    #region  Fields

    private Color _color;

    #endregion

    #region Constructors

    public ToolStripColorPickerDropDown()
    {
      this.Host = new ColorGrid
                  {
                    AutoSize = true,
                    Columns = 10,
                    Palette = ColorPalette.Office2010
                  };

      this.Host.MouseClick += this.HostMouseClickHandler;
      this.Host.KeyDown += this.HostKeyDownHandler;

      this.Items.Add(new ToolStripControlHost(this.Host));
    }

    #endregion

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color Color
    {
      get { return _color; }
      set
      {
        if (this.Color != value)
        {
          _color = value;

          this.OnColorChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ColorGrid Host { get; private set; }

    #endregion

    #region Private Members

    private void HostKeyDownHandler(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          this.Close(ToolStripDropDownCloseReason.Keyboard);
          this.Color = this.Host.Color;
          break;
        case Keys.Escape:
          this.Close(ToolStripDropDownCloseReason.Keyboard);
          break;
      }
    }

    private void HostMouseClickHandler(object sender, MouseEventArgs e)
    {
      ColorHitTestInfo info;

      info = this.Host.HitTest(e.Location);

      if (info.Index != ColorGrid.InvalidIndex)
      {
        this.Close(ToolStripDropDownCloseReason.ItemClicked);

        this.Color = info.Color;
      }
    }

    #endregion

    #region Protected Members

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ToolStripDropDown"/> and optionally releases the managed resources. 
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.Items.Clear();
        this.Host.MouseClick -= this.HostMouseClickHandler;
        this.Host.KeyDown -= this.HostKeyDownHandler;
        this.Host.Dispose();
        this.Host = null;
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Host.Color = this.Color;

      handler = this.ColorChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

protected override void OnOpened(EventArgs e)
{
  base.OnOpened(e);

  this.Host.Focus();
}

    protected override void OnOpening(CancelEventArgs e)
    {
      ToolStripProfessionalRenderer renderer;

      base.OnOpening(e);

      renderer = this.Renderer as ToolStripProfessionalRenderer;

      if (renderer != null)
      {
        this.Host.BackColor = renderer.ColorTable.ToolStripDropDownBackground;
      }

      this.Host.Color = this.Color;
    }

    #endregion

    #region Public Members

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    #endregion
  }
}
