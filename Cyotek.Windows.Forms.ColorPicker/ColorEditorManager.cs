using System;
using System.ComponentModel;
using System.Drawing;

#if USEEXTERNALCYOTEKLIBS
using Cyotek.Drawing;
#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public class ColorEditorManager : Component, IColorEditor
  {
    #region Instance Fields

    private ColorEditor _colorEditor;

    private ColorGrid _grid;

    private HslColor _hslColor;

    private LightnessColorSlider _lightnessColorSlider;

    private ScreenColorPicker _screenColorPicker;

    private ColorWheel _wheel;

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    /// <summary>
    /// Occurs when the ColorEditor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorEditorChanged;

    /// <summary>
    /// Occurs when the Grid property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorGridChanged;

    /// <summary>
    /// Occurs when the Wheel property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorWheelChanged;

    /// <summary>
    /// Occurs when the LightnessColorSlider property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler LightnessColorSliderChanged;

    /// <summary>
    /// Occurs when the ScreenColorPicker property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ScreenColorPickerChanged;

    #endregion

    #region Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Color Color
    {
      get { return this.HslColor.ToRgbColor(); }
      set { this.HslColor = new HslColor(value); }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorGrid), null)]
    public virtual ColorEditor ColorEditor
    {
      get { return _colorEditor; }
      set
      {
        if (this.ColorEditor != value)
        {
          _colorEditor = value;

          this.OnColorEditorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorGrid), null)]
    public virtual ColorGrid ColorGrid
    {
      get { return _grid; }
      set
      {
        if (this.ColorGrid != value)
        {
          _grid = value;

          this.OnColorGridChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorWheel), null)]
    public virtual ColorWheel ColorWheel
    {
      get { return _wheel; }
      set
      {
        if (this.ColorWheel != value)
        {
          _wheel = value;

          this.OnColorWheelChanged(EventArgs.Empty);
        }
      }
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

    [Category("Behavior")]
    [DefaultValue(typeof(LightnessColorSlider), null)]
    public virtual LightnessColorSlider LightnessColorSlider
    {
      get { return _lightnessColorSlider; }
      set
      {
        if (this.LightnessColorSlider != value)
        {
          _lightnessColorSlider = value;

          this.OnLightnessColorSliderChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ScreenColorPicker), null)]
    public virtual ScreenColorPicker ScreenColorPicker
    {
      get { return _screenColorPicker; }
      set
      {
        if (this.ScreenColorPicker != value)
        {
          _screenColorPicker = value;

          this.OnScreenColorPickerChanged(EventArgs.Empty);
        }
      }
    }

    protected bool LockUpdates { get; set; }

    #endregion

    #region Members

    protected virtual void BindEvents(IColorEditor control)
    {
      control.ColorChanged += this.ColorChangedHandler;
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Synchronize(this);

      handler = this.ColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorEditorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorEditorChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.ColorEditor != null)
        this.BindEvents(this.ColorEditor);

      handler = this.ColorEditorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorGridChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorGridChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.ColorGrid != null)
        this.BindEvents(this.ColorGrid);

      handler = this.ColorGridChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorWheelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorWheelChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.ColorWheel != null)
        this.BindEvents(this.ColorWheel);

      handler = this.ColorWheelChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="LightnessColorSliderChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLightnessColorSliderChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.LightnessColorSlider != null)
        this.BindEvents(this.LightnessColorSlider);

      handler = this.LightnessColorSliderChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ScreenColorPickerChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnScreenColorPickerChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.ScreenColorPicker != null)
        this.BindEvents(this.ScreenColorPicker);

      handler = this.ScreenColorPickerChanged;

      if (handler != null)
        handler(this, e);
    }

    protected virtual void SetColor(IColorEditor control, IColorEditor sender)
    {
      if (control != null && control != sender)
        control.Color = sender.Color;
    }

    protected virtual void Synchronize(IColorEditor sender)
    {
      if (!this.LockUpdates)
      {
        try
        {
          this.LockUpdates = true;
          this.SetColor(this.ColorGrid, sender);
          this.SetColor(this.ColorWheel, sender);
          this.SetColor(this.ScreenColorPicker, sender);
          this.SetColor(this.ColorEditor, sender);
          this.SetColor(this.LightnessColorSlider, sender);
        }
        finally
        {
          this.LockUpdates = false;
        }
      }
    }

    #endregion

    #region Event Handlers

    private void ColorChangedHandler(object sender, EventArgs e)
    {
      if (!this.LockUpdates)
      {
        IColorEditor source;

        source = (IColorEditor)sender;

        this.LockUpdates = true;
        this.Color = source.Color;
        this.LockUpdates = false;
        this.Synchronize(source);
      }
    }

    #endregion
  }
}
