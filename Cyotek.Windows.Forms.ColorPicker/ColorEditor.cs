using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#if USEEXTERNALCYOTEKLIBS
using HslColor = Cyotek.Drawing.HslColor;
#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public partial class ColorEditor : UserControl, IColorEditor
  {
    #region Instance Fields

    private HslColor _hslColor;

    private Orientation _orientation;

    #endregion

    #region Constructors

    public ColorEditor()
    {
      this.InitializeComponent();

      this.Color = Color.Black;
      this.Orientation = Orientation.Vertical;
      this.Size = new Size(200, 260);
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    /// <summary>
    /// Occurs when the Orientation property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler OrientationChanged;

    #endregion

    #region Overridden Members

    protected override void OnDockChanged(EventArgs e)
    {
      base.OnDockChanged(e);

      this.ResizeComponents();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.ResizeComponents();
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.ResizeComponents();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.ResizeComponents();
    }

    #endregion

    #region Properties

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "0, 0, 0")]
    public virtual Color Color
    {
      get { return this.HslColor.ToRgbColor(); }
      set { this.HslColor = new HslColor(value); }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual HslColor HslColor
    {
      get { return _hslColor; }
      set
      {
        if (this.HslColor != value)
        {
          _hslColor = value;

          this.OnColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Orientation), "Vertical")]
    public virtual Orientation Orientation
    {
      get { return _orientation; }
      set
      {
        if (this.Orientation != value)
        {
          _orientation = value;

          this.OnOrientationChanged(EventArgs.Empty);
        }
      }
    }

    protected bool LockUpdates { get; set; }

    #endregion

    #region Members

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);

      handler = this.ColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="OrientationChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnOrientationChanged(EventArgs e)
    {
      EventHandler handler;

      this.ResizeComponents();

      handler = this.OrientationChanged;

      if (handler != null)
        handler(this, e);
    }

    protected virtual void ResizeComponents()
    {
      try
      {
        int group1HeaderLeft;
        int group1BarLeft;
        int group1EditLeft;
        int group2HeaderLeft;
        int group2BarLeft;
        int group2EditLeft;
        int barWidth;
        int editWidth;
        int top;
        int innerMargin;
        int columnWidth;
        int rowHeight;
        int labelOffset;
        int colorBarOffset;
        int editOffset;

        top = this.Padding.Top;
        innerMargin = 3;
        editWidth = TextRenderer.MeasureText(new string('W', 5), this.Font).Width;
        rowHeight = Math.Max(Math.Max(rLabel.Height, rColorBar.Height), rNumericUpDown.Height);
        labelOffset = (rowHeight - rLabel.Height) / 2;
        colorBarOffset = (rowHeight - rColorBar.Height) / 2;
        editOffset = (rowHeight - rNumericUpDown.Height) / 2;

        switch (this.Orientation)
        {
          case Orientation.Horizontal:
            columnWidth = (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) / 2;
            break;
          default:
            columnWidth = this.ClientSize.Width - this.Padding.Horizontal;
            break;
        }

        group1HeaderLeft = this.Padding.Left;
        group1EditLeft = columnWidth - editWidth;
        group1BarLeft = group1HeaderLeft + aLabel.Width + innerMargin;

        if (this.Orientation == Orientation.Horizontal)
        {
          group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
          group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
          group2BarLeft = group2HeaderLeft + aLabel.Width + innerMargin;
        }
        else
        {
          group2HeaderLeft = group1HeaderLeft;
          group2EditLeft = group1EditLeft;
          group2BarLeft = group1BarLeft;
        }

        barWidth = group1EditLeft - (group1BarLeft + innerMargin);

        // RGB header
        rgbHeaderLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        top += rowHeight + innerMargin;

        // R row
        rLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        rColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        rNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // G row
        gLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        gColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        gNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // B row
        bLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        bColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        bNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // Hex row
        hexLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        hexTextBox.SetBounds(group1EditLeft, top + colorBarOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // reset top
        if (this.Orientation == Orientation.Horizontal)
          top = this.Padding.Top;

        // HSL header
        hslLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        top += rowHeight + innerMargin;

        // H row
        hLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        hColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        hNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // S row
        sLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        sColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        sNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // L row
        lLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        lColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        lNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // A row
        aLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        aColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        aNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
      }
        // ReSharper disable EmptyGeneralCatchClause
      catch
        // ReSharper restore EmptyGeneralCatchClause
      {
        // ignore errors
      }
    }

    protected virtual void UpdateFields(bool userAction)
    {
      if (!this.LockUpdates)
      {
        try
        {
          this.LockUpdates = true;

          // RGB
          if (!(userAction && rNumericUpDown.Focused))
            rNumericUpDown.Value = this.Color.R;
          if (!(userAction && gNumericUpDown.Focused))
            gNumericUpDown.Value = this.Color.G;
          if (!(userAction && bNumericUpDown.Focused))
            bNumericUpDown.Value = this.Color.B;
          rColorBar.Value = this.Color.R;
          rColorBar.Color = this.Color;
          gColorBar.Value = this.Color.G;
          gColorBar.Color = this.Color;
          bColorBar.Value = this.Color.B;
          bColorBar.Color = this.Color;

          // HTML
          if (!(userAction && hexTextBox.Focused))
            hexTextBox.Text = string.Format("{0:X2}{1:X2}{2:X2}", this.Color.R, this.Color.G, this.Color.B);

          // HSL
          if (!(userAction && hNumericUpDown.Focused))
            hNumericUpDown.Value = (int)this.HslColor.H;
          if (!(userAction && sNumericUpDown.Focused))
            sNumericUpDown.Value = (int)(this.HslColor.S * 100);
          if (!(userAction && lNumericUpDown.Focused))
            lNumericUpDown.Value = (int)(this.HslColor.L * 100);
          hColorBar.Value = (int)this.HslColor.H;
          sColorBar.Color = this.Color;
          sColorBar.Value = (int)(this.HslColor.S * 100);
          lColorBar.Color = this.Color;
          lColorBar.Value = (int)(this.HslColor.L * 100);

          // Alpha
          if (!(userAction && aNumericUpDown.Focused))
            aNumericUpDown.Value = this.Color.A;
          aColorBar.Color = this.Color;
          aColorBar.Value = this.Color.A;
        }
        finally
        {
          this.LockUpdates = false;
        }
      }
    }

    #endregion

    #region Event Handlers

    private void ValueChangedHandler(object sender, EventArgs e)
    {
      if (!this.LockUpdates)
      {
        bool useHsl;
        bool useRgb;

        useHsl = false;
        useRgb = false;

        this.LockUpdates = true;

        if (sender == hexTextBox)
        {
          string text;

          text = hexTextBox.Text;
          if (text.StartsWith("#"))
            text = text.Substring(1);

          if (text.Length == 6 || text.Length == 8)
          {
            try
            {
              Color color;

              color = ColorTranslator.FromHtml("#" + text);
              aNumericUpDown.Value = color.A;
              rNumericUpDown.Value = color.R;
              bNumericUpDown.Value = color.B;
              gNumericUpDown.Value = color.G;

              useRgb = true;
            }
              // ReSharper disable EmptyGeneralCatchClause
            catch
            { }
            // ReSharper restore EmptyGeneralCatchClause
          }
        }
        else if (sender == aColorBar || sender == rColorBar || sender == gColorBar || sender == bColorBar)
        {
          aNumericUpDown.Value = (int)aColorBar.Value;
          rNumericUpDown.Value = (int)rColorBar.Value;
          gNumericUpDown.Value = (int)gColorBar.Value;
          bNumericUpDown.Value = (int)bColorBar.Value;

          useRgb = true;
        }
        else if (sender == aNumericUpDown || sender == rNumericUpDown || sender == gNumericUpDown || sender == bNumericUpDown)
          useRgb = true;
        else if (sender == hColorBar || sender == lColorBar || sender == sColorBar)
        {
          hNumericUpDown.Value = (int)hColorBar.Value;
          sNumericUpDown.Value = (int)sColorBar.Value;
          lNumericUpDown.Value = (int)lColorBar.Value;

          useHsl = true;
        }
        else if (sender == hNumericUpDown || sender == sNumericUpDown || sender == lNumericUpDown)
          useHsl = true;

        if (useRgb)
        {
          Color color;

          color = Color.FromArgb((int)aNumericUpDown.Value, (int)rNumericUpDown.Value, (int)gNumericUpDown.Value, (int)bNumericUpDown.Value);
          this.HslColor = new HslColor(color);
        }
        else if (useHsl)
        {
          HslColor color;

          color = new HslColor((int)aNumericUpDown.Value, (double)hNumericUpDown.Value, (double)sNumericUpDown.Value / 100, (double)lNumericUpDown.Value / 100);
          this.HslColor = color;
        }

        this.LockUpdates = false;
        this.UpdateFields(true);
      }
    }

    #endregion
  }
}
