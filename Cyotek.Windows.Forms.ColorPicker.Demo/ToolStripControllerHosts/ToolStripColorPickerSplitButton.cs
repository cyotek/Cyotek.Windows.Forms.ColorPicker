using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Cyotek.Windows.Forms.ColorPicker.Demo.ToolStripControllerHosts
{
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
  public class ToolStripColorPickerSplitButton : ToolStripSplitButton
  {
    #region Constructors

    public ToolStripColorPickerSplitButton()
    {
      this.Color = Color.Black;
    }

    #endregion

    #region Public Properties

    [Category("Data")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
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
    public new ToolStripDropDown DropDown
    {
      get { return base.DropDown; }
      set { base.DropDown = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ColorGrid Host
    {
      get
      {
        this.EnsureDropDownIsCreated();

        return _dropDown.Host;
      }
    }

    #endregion

    #region Private Members

    private void DropDownColorChangedHandler(object sender, EventArgs e)
    {
      this.Color = _dropDown.Color;
    }

    private void EnsureDropDownIsCreated()
    {
      if (_dropDown == null)
      {
        _dropDown = new ToolStripColorPickerDropDown();
        _dropDown.ColorChanged += this.DropDownColorChangedHandler;
      }
    }



    #endregion

    #region Protected Members

    protected override ToolStripDropDown CreateDefaultDropDown()
    {
      this.EnsureDropDownIsCreated();

      return _dropDown;
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ToolStripDropDownItem"/> and optionally releases the managed resources. 
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_dropDown != null)
        {
          this.DropDown = null;
          _dropDown.Dispose();
          _dropDown.ColorChanged -= this.DropDownColorChangedHandler;
          _dropDown = null;
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ToolStripSplitButton.ButtonClick"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnButtonClick(EventArgs e)
    {
      base.OnButtonClick(e);

      using (ColorPickerDialog dialog = new ColorPickerDialog())
      {
        dialog.Color = this.Color;

        if (dialog.ShowDialog(this.GetCurrentParent()) == DialogResult.OK)
        {
          this.Color = dialog.Color;
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      if (_dropDown != null)
      {
        _dropDown.Color = this.Color;
      }

      handler = this.ColorChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raised in response to the <see cref="M:System.Windows.Forms.ToolStripDropDownItem.ShowDropDown"/> method.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnDropDownShow(EventArgs e)
    {
      this.EnsureDropDownIsCreated();
      base.OnDropDownShow(e);
    }

    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle underline;

      base.OnPaint(e);

      underline = this.GetUnderlineRectangle(e.Graphics);

      using (Brush brush = new SolidBrush(this.Color))
      {
        e.Graphics.FillRectangle(brush, underline);
      }
    }

    private Rectangle GetUnderlineRectangle(Graphics g)
    {
      int x;
      int y;
      int w;
      int h;

      // TODO: These are approximate values and may not work with different font sizes or image sizes etc

      h = 4; // static height!
      x = this.ContentRectangle.Left;
      y = this.ContentRectangle.Bottom - (h + 1);

      if (this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText && this.Image != null && !string.IsNullOrEmpty(this.Text))
      {
        int innerHeight;

        innerHeight = this.Image.Height - h;

        // got both an image and some text to deal with
        w = this.Image.Width;
        y = this.ButtonBounds.Top + innerHeight + ((this.ButtonBounds.Height - this.Image.Height) / 2);

        switch (this.TextImageRelation)
        {
          case TextImageRelation.TextBeforeImage:
            x = this.ButtonBounds.Right - (w + this.ButtonBounds.Left + 2);
            break;
          case TextImageRelation.ImageAboveText:
            x = this.ButtonBounds.Left + ((this.ButtonBounds.Width - this.Image.Width) / 2);
            y = this.ButtonBounds.Top + innerHeight + 2;
            break;
          case TextImageRelation.TextAboveImage:
            x = this.ButtonBounds.Left + ((this.ButtonBounds.Width - this.Image.Width) / 2);
            y = this.ContentRectangle.Bottom - h;
            break;
          case TextImageRelation.Overlay:
            x = this.ButtonBounds.Left + ((this.ButtonBounds.Width - this.Image.Width) / 2);
            y = this.ButtonBounds.Top + innerHeight + ((this.ButtonBounds.Height - this.Image.Height) / 2);
            break;
        }
      }
      else if (this.DisplayStyle == ToolStripItemDisplayStyle.Image && this.Image != null)
      {
        // just the image
        w = this.Image.Width;
      }
      else if (this.DisplayStyle == ToolStripItemDisplayStyle.Text && !string.IsNullOrEmpty(this.Text))
      {
        // just the text
        w = TextRenderer.MeasureText(g, this.Text, this.Font).Width;
      }
      else
      {
        // who knows, use what we have
        // TODO: ButtonBounds (and SplitterBounds for that matter) seem to return the wrong
        // values when painting first occurs, so the line is too narrow until after you 
        // hover the mouse over the button
        w = this.ButtonBounds.Width - (this.ContentRectangle.Left * 2);
      }

      return new Rectangle(x, y, w, h);
    }

    #endregion

    #region Public Members

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    #endregion

    #region  Fields

    private Color _color;

    private ToolStripColorPickerDropDown _dropDown;

    #endregion
  }
}
