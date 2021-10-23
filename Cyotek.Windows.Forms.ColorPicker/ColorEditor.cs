// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Represents a control that allows the editing of a color in a variety of ways.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  [ToolboxBitmap(typeof(ColorEditor), "ColorEditorToolboxBitmap.bmp")]
  [ToolboxItem(true)]
  public partial class ColorEditor : UserControl, IColorEditor
  {
    #region Private Fields

    private const int _minimumBarWidth = 30;

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventNubColorChanged = new object();

    private static readonly object _eventNubOutlineColorChanged = new object();

    private static readonly object _eventNubSizeChanged = new object();

    private static readonly object _eventOrientationChanged = new object();

    private static readonly object _eventPreserveAlphaChannelChanged = new object();

    private static readonly object _eventShowAlphaChannelChanged = new object();

    private static readonly object _eventShowColorSpaceLabelsChanged = new object();

    private static readonly object _eventShowHexChanged = new object();

    private static readonly object _eventShowHslChanged = new object();

    private static readonly object _eventShowRgbChanged = new object();

    private Color _color;

    private HslColor _hslColor;

    private bool _lockUpdates;

    private Color _nubColor;

    private Color _nubOutlineColor;

    private Size _nubSize;

    private Orientation _orientation;

    private bool _preserveAlphaChannel;

    private bool _showAlphaChannel;

    private bool _showColorSpaceLabels;

    private bool _showHex;

    private bool _showHsl;

    private bool _showRgb;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorEditor"/> class.
    /// </summary>
    public ColorEditor()
    {
      this.InitializeComponent();

      _color = Color.Black;
      _orientation = Orientation.Vertical;
      _showAlphaChannel = true;
      _showColorSpaceLabels = true;
      _showRgb = true;
      _showHsl = true;
      _showHex = true;
      _nubSize = new Size(8, 8);
      _nubColor = Color.Black;
      _nubOutlineColor = Color.White;

      this.ResizeComponents();
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add => this.Events.AddHandler(_eventColorChanged, value);
      remove => this.Events.RemoveHandler(_eventColorChanged, value);
    }

    /// <summary>
    /// Occurs when the NubColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubColorChanged
    {
      add => this.Events.AddHandler(_eventNubColorChanged, value);
      remove => this.Events.RemoveHandler(_eventNubColorChanged, value);
    }

    /// <summary>
    /// Occurs when the NubOutlineColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubOutlineColorChanged
    {
      add => this.Events.AddHandler(_eventNubOutlineColorChanged, value);
      remove => this.Events.RemoveHandler(_eventNubOutlineColorChanged, value);
    }

    /// <summary>
    /// Occurs when the NubSize property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubSizeChanged
    {
      add => this.Events.AddHandler(_eventNubSizeChanged, value);
      remove => this.Events.RemoveHandler(_eventNubSizeChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler OrientationChanged
    {
      add => this.Events.AddHandler(_eventOrientationChanged, value);
      remove => this.Events.RemoveHandler(_eventOrientationChanged, value);
    }

    /// <summary>
    /// Occurs when the PreserveAlphaChannel property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler PreserveAlphaChannelChanged
    {
      add => this.Events.AddHandler(_eventPreserveAlphaChannelChanged, value);
      remove => this.Events.RemoveHandler(_eventPreserveAlphaChannelChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ShowAlphaChannelChanged
    {
      add => this.Events.AddHandler(_eventShowAlphaChannelChanged, value);
      remove => this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowColorSpaceLabels property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowColorSpaceLabelsChanged
    {
      add => this.Events.AddHandler(_eventShowColorSpaceLabelsChanged, value);
      remove => this.Events.RemoveHandler(_eventShowColorSpaceLabelsChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowHex property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowHexChanged
    {
      add => this.Events.AddHandler(_eventShowHexChanged, value);
      remove => this.Events.RemoveHandler(_eventShowHexChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowHsl property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowHslChanged
    {
      add => this.Events.AddHandler(_eventShowHslChanged, value);
      remove => this.Events.RemoveHandler(_eventShowHslChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowRgb property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowRgbChanged
    {
      add => this.Events.AddHandler(_eventShowRgbChanged, value);
      remove => this.Events.RemoveHandler(_eventShowRgbChanged, value);
    }

    #endregion Public Events

    #region Public Properties

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get => _color;
      set
      {
        if (value.A != 255 && !_showAlphaChannel && !_preserveAlphaChannel)
        {
          value = Color.FromArgb(255, value);
        }

        if (_color != value)
        {
          _color = value;

          if (!_lockUpdates)
          {
            _lockUpdates = true;
            this.HslColor = new HslColor(value);
            _lockUpdates = false;
            this.UpdateFields(false);
          }
          else
          {
            this.OnColorChanged(EventArgs.Empty);
          }
        }
      }
    }

    /// <summary>
    /// Gets or sets the component color as a HSL structure.
    /// </summary>
    /// <value>The component color.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual HslColor HslColor
    {
      get => _hslColor;
      set
      {
        if (_hslColor != value)
        {
          _hslColor = value;

          if (!_lockUpdates)
          {
            _lockUpdates = true;
            this.Color = value.ToRgbColor();
            _lockUpdates = false;
            this.UpdateFields(false);
          }
          else
          {
            this.OnColorChanged(EventArgs.Empty);
          }
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public Color NubColor
    {
      get => _nubColor;
      set
      {
        if (_nubColor != value)
        {
          _nubColor = value;

          this.OnNubColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "White")]
    public Color NubOutlineColor
    {
      get => _nubOutlineColor;
      set
      {
        if (_nubOutlineColor != value)
        {
          _nubOutlineColor = value;

          this.OnNubOutlineColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Size), "8, 8")]
    public Size NubSize
    {
      get => _nubSize;
      set
      {
        if (_nubSize != value)
        {
          _nubSize = value;

          this.OnNubSizeChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the orientation of the editor.
    /// </summary>
    /// <value>The orientation.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Orientation), "Vertical")]
    public virtual Orientation Orientation
    {
      get => _orientation;
      set
      {
        if (_orientation != value)
        {
          _orientation = value;

          this.OnOrientationChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool PreserveAlphaChannel
    {
      get => _preserveAlphaChannel;
      set
      {
        if (_preserveAlphaChannel != value)
        {
          _preserveAlphaChannel = value;

          this.OnPreserveAlphaChannelChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public virtual bool ShowAlphaChannel
    {
      get => _showAlphaChannel;
      set
      {
        if (_showAlphaChannel != value)
        {
          _showAlphaChannel = value;

          this.OnShowAlphaChannelChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowColorSpaceLabels
    {
      get => _showColorSpaceLabels;
      set
      {
        if (_showColorSpaceLabels != value)
        {
          _showColorSpaceLabels = value;

          this.OnShowColorSpaceLabelsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowHex
    {
      get => _showHex;
      set
      {
        if (_showHex != value)
        {
          _showHex = value;

          this.OnShowHexChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowHsl
    {
      get => _showHsl;
      set
      {
        if (_showHsl != value)
        {
          _showHsl = value;

          this.OnShowHslChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowRgb
    {
      get => _showRgb;
      set
      {
        if (_showRgb != value)
        {
          _showRgb = value;

          this.OnShowRgbChanged(EventArgs.Empty);
        }
      }
    }

    #endregion Public Properties

    #region Protected Properties

    protected override Size DefaultSize => new Size(200, 260);

    /// <summary>
    /// Gets or sets a value indicating whether input changes should be processed.
    /// </summary>
    /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
    protected bool LockUpdates
    {
      get => _lockUpdates;
      set => _lockUpdates = value;
    }

    #endregion Protected Properties

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnDockChanged(EventArgs e)
    {
      base.OnDockChanged(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="NubColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateSliderNubs();

      handler = (EventHandler)this.Events[_eventNubColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NubOutlineColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubOutlineColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateSliderNubs();

      handler = (EventHandler)this.Events[_eventNubOutlineColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NubSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubSizeChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateSliderNubs();

      handler = (EventHandler)this.Events[_eventNubSizeChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="OrientationChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnOrientationChanged(EventArgs e)
    {
      EventHandler handler;

      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventOrientationChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="PreserveAlphaChannelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPreserveAlphaChannelChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventPreserveAlphaChannelChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Resize" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowAlphaChannelChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowColorSpaceLabelsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowColorSpaceLabelsChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowColorSpaceLabelsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowHexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowHexChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);
      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowHexChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowHslChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowHslChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);
      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowHslChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowRgbChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowRgbChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);
      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowRgbChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Updates the editing field values.
    /// </summary>
    /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
    protected virtual void UpdateFields(bool userAction)
    {
      if (!_lockUpdates)
      {
        try
        {
          _lockUpdates = true;

          // RGB
          if (_showRgb)
          {
            if (!(userAction && rNumericUpDown.Focused))
            {
              rNumericUpDown.Value = _color.R;
            }

            if (!(userAction && gNumericUpDown.Focused))
            {
              gNumericUpDown.Value = _color.G;
            }

            if (!(userAction && bNumericUpDown.Focused))
            {
              bNumericUpDown.Value = _color.B;
            }

            rColorBar.Value = _color.R;
            rColorBar.Color = _color;
            gColorBar.Value = _color.G;
            gColorBar.Color = _color;
            bColorBar.Value = _color.B;
            bColorBar.Color = _color;
          }

          if (_showHex)
          {
            // HTML
            if (!(userAction && hexTextBox.Focused))
            {
              hexTextBox.Text = _color.IsNamedColor
                ? _color.Name
                : string.Format("{0:X2}{1:X2}{2:X2}", _color.R, _color.G, _color.B);
            }
          }

          if (_showHsl)
          {
            // HSL
            if (!(userAction && hNumericUpDown.Focused))
            {
              hNumericUpDown.Value = (int)_hslColor.H;
            }

            if (!(userAction && sNumericUpDown.Focused))
            {
              sNumericUpDown.Value = (int)(_hslColor.S * 100);
            }

            if (!(userAction && lNumericUpDown.Focused))
            {
              lNumericUpDown.Value = (int)(_hslColor.L * 100);
            }

            hColorBar.Value = (int)_hslColor.H;
            sColorBar.Color = _color;
            sColorBar.Value = (int)(_hslColor.S * 100);
            lColorBar.Color = _color;
            lColorBar.Value = (int)(_hslColor.L * 100);
          }

          // Alpha
          if (!(userAction && aNumericUpDown.Focused))
          {
            aNumericUpDown.Value = _color.A;
          }
          aColorBar.Color = _color;
          aColorBar.Value = _color.A;
        }
        finally
        {
          _lockUpdates = false;
        }
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void hexTextBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (hexTextBox.SelectedIndex != -1)
      {
        _lockUpdates = true;
        this.Color = Color.FromName((string)hexTextBox.SelectedItem);
        _lockUpdates = false;
      }
    }

    private void ProcessHexStringUpdate(ref bool useRgb, ref bool useNamed)
    {
      string text;

      text = hexTextBox.Text;

      if (!string.IsNullOrEmpty(text))
      {
        int namedIndex;

        if (text[0] == '#')
        {
          text = text.Substring(1);
        }

        if (hexTextBox.Items.Count == 0)
        {
          hexTextBox.FillNamedColors();
        }

        namedIndex = hexTextBox.FindStringExact(text);

        if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
        {
          try
          {
            Color color;

            color = namedIndex != -1
              ? Color.FromName(text)
              : ColorTranslator.FromHtml("#" + text);
            aNumericUpDown.Value = color.A;
            rNumericUpDown.Value = color.R;
            bNumericUpDown.Value = color.B;
            gNumericUpDown.Value = color.G;

            useRgb = true;
          }
          // ReSharper disable EmptyGeneralCatchClause
          catch
          {
          }
          // ReSharper restore EmptyGeneralCatchClause
        }
        else
        {
          useNamed = true;
        }
      }
    }

    private void ProcessHslSliderUpdate()
    {
      hNumericUpDown.Value = (int)hColorBar.Value;
      sNumericUpDown.Value = (int)sColorBar.Value;
      lNumericUpDown.Value = (int)lColorBar.Value;
    }

    private void ProcessRgbSliderUpdate()
    {
      aNumericUpDown.Value = (int)aColorBar.Value;
      rNumericUpDown.Value = (int)rColorBar.Value;
      gNumericUpDown.Value = (int)gColorBar.Value;
      bNumericUpDown.Value = (int)bColorBar.Value;
    }

    /// <summary>
    /// Resizes the editing components.
    /// </summary>
    private void ResizeComponents()
    {
      try
      {
        Size size;
        Padding padding;
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
        int barHorizontalOffset;
        int nubOffset;

        size = this.ClientSize;
        padding = this.Padding;
        top = padding.Top;
        innerMargin = 3;
        editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
        rowHeight = Math.Max(Math.Max(rLabel.Height, rColorBar.Height), rNumericUpDown.Height);
        labelOffset = (rowHeight - rLabel.Height) >> 1;
        colorBarOffset = (rowHeight - rColorBar.Height) >> 1;
        editOffset = (rowHeight - rNumericUpDown.Height) >> 1;
        barHorizontalOffset = innerMargin + (_showAlphaChannel
          ? aLabel.Width
          : hLabel.Width);
        nubOffset = (rColorBar.NubSize.Width >> 1) + 1;

        columnWidth = _orientation == Orientation.Horizontal && (!_showHsl || _showRgb)
          ? (size.Width - (padding.Horizontal + innerMargin)) >> 1
          : size.Width - padding.Horizontal;

        group1HeaderLeft = padding.Left;
        group1EditLeft = columnWidth - editWidth;
        group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

        if (_orientation == Orientation.Horizontal && _showRgb)
        {
          group2HeaderLeft = padding.Left + columnWidth + innerMargin;
          group2EditLeft = size.Width - (padding.Right + editWidth);
          group2BarLeft = group2HeaderLeft + barHorizontalOffset + innerMargin;
        }
        else
        {
          group2HeaderLeft = group1HeaderLeft;
          group2EditLeft = group1EditLeft;
          group2BarLeft = group1BarLeft;
        }

        barWidth = group1EditLeft - (group1BarLeft + innerMargin);

        this.SetBarStates(barWidth >= _minimumBarWidth);

        // RGB header
        if ((_showHex || _showRgb) && _showColorSpaceLabels)
        {
          rgbHeaderLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          top += rowHeight + innerMargin;
        }

        if (_showRgb)
        {
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
        }

        if (_showHex)
        {
          // Hex row
          hexLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          hexTextBox.SetBounds(group1BarLeft + nubOffset, top + colorBarOffset, barWidth + innerMargin + editWidth - nubOffset, 0, BoundsSpecified.Location | BoundsSpecified.Width);
          top += rowHeight + innerMargin;
        }

        if (_showHsl)
        {
          // reset top
          if (_orientation == Orientation.Horizontal)
          {
            top = padding.Top;
          }

          // HSL header
          if (_showColorSpaceLabels)
          {
            hslLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
            top += rowHeight + innerMargin;
          }

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
        }

        if (_showAlphaChannel)
        {
          // A row
          aLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          aColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
          aNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        }
      }
      catch
      {
        // ignore errors
      }
    }

    private void SetBarStates(bool visible)
    {
      rColorBar.Visible = visible && _showRgb;
      gColorBar.Visible = visible && _showRgb;
      bColorBar.Visible = visible && _showRgb;

      hColorBar.Visible = visible && _showHsl;
      sColorBar.Visible = visible && _showHsl;
      lColorBar.Visible = visible && _showHsl;

      aColorBar.Visible = _showAlphaChannel && visible;
    }

    private void SetControlStates()
    {
      aLabel.Visible = _showAlphaChannel;
      aColorBar.Visible = _showAlphaChannel;
      aNumericUpDown.Visible = _showAlphaChannel;

      rgbHeaderLabel.Visible = (_showHex || _showRgb) && _showColorSpaceLabels;
      rLabel.Visible = _showRgb;
      rColorBar.Visible = _showRgb;
      rNumericUpDown.Visible = _showRgb;
      gLabel.Visible = _showRgb;
      gColorBar.Visible = _showRgb;
      gNumericUpDown.Visible = _showRgb;
      bLabel.Visible = _showRgb;
      bColorBar.Visible = _showRgb;
      bNumericUpDown.Visible = _showRgb;

      hexLabel.Visible = _showHex;
      hexTextBox.Visible = _showHex;

      hslLabel.Visible = _showHsl && _showColorSpaceLabels;
      hLabel.Visible = _showHsl;
      hColorBar.Visible = _showHsl;
      hNumericUpDown.Visible = _showHsl;
      sLabel.Visible = _showHsl;
      sColorBar.Visible = _showHsl;
      sNumericUpDown.Visible = _showHsl;
      lLabel.Visible = _showHsl;
      lColorBar.Visible = _showHsl;
      lNumericUpDown.Visible = _showHsl;
    }

    private void UpdateSliderNub(ColorSlider control)
    {
      control.NubSize = _nubSize;
      control.NubColor = _nubColor;
      control.NubOutlineColor = _nubOutlineColor;
    }

    private void UpdateSliderNubs()
    {
      this.UpdateSliderNub(rColorBar);
      this.UpdateSliderNub(gColorBar);
      this.UpdateSliderNub(bColorBar);
      this.UpdateSliderNub(hColorBar);
      this.UpdateSliderNub(sColorBar);
      this.UpdateSliderNub(lColorBar);
      this.UpdateSliderNub(aColorBar);
    }

    /// <summary>
    /// Change handler for editing components.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void ValueChangedHandler(object sender, EventArgs e)
    {
      if (!_lockUpdates)
      {
        bool useHsl;
        bool useRgb;
        bool useNamed;

        useHsl = false;
        useRgb = false;
        useNamed = false;

        _lockUpdates = true;

        if (sender == hexTextBox)
        {
          this.ProcessHexStringUpdate(ref useRgb, ref useNamed);
        }
        else if (sender == aColorBar || sender == rColorBar || sender == gColorBar || sender == bColorBar)
        {
          this.ProcessRgbSliderUpdate();
          useRgb = true;
        }
        else if (sender == aNumericUpDown || sender == rNumericUpDown || sender == gNumericUpDown || sender == bNumericUpDown)
        {
          useRgb = true;
        }
        else if (sender == hColorBar || sender == lColorBar || sender == sColorBar)
        {
          this.ProcessHslSliderUpdate();
          useHsl = true;
        }
        else if (sender == hNumericUpDown || sender == sNumericUpDown || sender == lNumericUpDown)
        {
          useHsl = true;
        }

        if (useRgb || useNamed)
        {
          Color color;

          color = useNamed
            ? Color.FromName(hexTextBox.Text)
            : Color.FromArgb((int)aNumericUpDown.Value, (int)rNumericUpDown.Value, (int)gNumericUpDown.Value, (int)bNumericUpDown.Value);

          this.Color = color;
          this.HslColor = new HslColor(color);
        }
        else if (useHsl)
        {
          HslColor color;

          color = new HslColor((int)aNumericUpDown.Value, (double)hNumericUpDown.Value, (double)sNumericUpDown.Value / 100, (double)lNumericUpDown.Value / 100);
          this.HslColor = color;
          this.Color = color.ToRgbColor();
        }

        _lockUpdates = false;

        this.UpdateFields(true);
      }
    }

    #endregion Private Methods
  }
}
