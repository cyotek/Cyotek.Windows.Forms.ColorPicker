// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.ComponentModel;
using System.Drawing;

namespace Cyotek.Windows.Forms
{
  public class LightnessColorSlider : ColorSlider, IColorEditor
  {
    #region Constants

    private static readonly object _eventColorChanged = new object();

    #endregion

    #region Fields

    private Color _color;

    #endregion

    #region Constructors

    public LightnessColorSlider()
    {
      base.BarStyle = ColorBarStyle.Custom;
      _color = Color.Black;
      this.CreateScale();
    }

    #endregion

    #region Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ColorBarStyle BarStyle
    {
      get { return base.BarStyle; }
      set { base.BarStyle = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color1
    {
      get { return base.Color1; }
      set { base.Color1 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color2
    {
      get { return base.Color2; }
      set { base.Color2 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color3
    {
      get { return base.Color3; }
      set { base.Color3 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override float Maximum
    {
      get { return base.Maximum; }
      set { base.Maximum = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override float Minimum
    {
      get { return base.Minimum; }
      set { base.Minimum = value; }
    }

    public override float Value
    {
      get { return base.Value; }
      set { base.Value = (int)value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether input changes should be processed.
    /// </summary>
    /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
    protected bool LockUpdates { get; set; }

    #endregion

    #region Methods

    protected virtual void CreateScale()
    {
      ColorCollection custom;
      HslColor color;

      custom = new ColorCollection();
      color = new HslColor(_color);
      
      for (int i = 0; i < 100; i++)
      {
        color.L = i / 100D;

        custom.Add(color.ToRgbColor(_color.A));
      }

      this.CustomColors = custom;
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.CreateScale();
      this.Invalidate();

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    #endregion

    #region IColorEditor Interface

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        if (_color != value)
        {
          _color = value;

          if (!this.LockUpdates)
          {
            this.LockUpdates = true;
            this.Value = (float)new HslColor(value).L * 100;
            this.OnColorChanged(EventArgs.Empty);
            this.LockUpdates = false;
          }
        }
      }
    }

    #endregion
  }
}
