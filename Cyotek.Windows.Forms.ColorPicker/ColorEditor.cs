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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Represents a control that allows the editing of a color in a variety of ways.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public partial class ColorEditor : UserControl, IColorEditor
  {
    #region Private Fields

    private const int _minimumBarWidth = 30;

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventOrientationChanged = new object();

    private static readonly object _eventPreserveAlphaChannelChanged = new object();

    private static readonly object _eventShowAlphaChannelChanged = new object();

    private static readonly object _eventShowColorSpaceLabelsChanged = new object();

    private Color _color;

    private HslColor _hslColor;

    private bool _lockUpdates;

    private Orientation _orientation;

    private bool _preserveAlphaChannel;

    private bool _showAlphaChannel;

    private bool _showColorSpaceLabels;

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

    #endregion Public Events

    #region Public Properties

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "0, 0, 0")]
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

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.SetDropDownWidth();
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

          // HTML
          if (!(userAction && hexTextBox.Focused))
          {
            hexTextBox.Text = _color.IsNamedColor
              ? _color.Name
              : string.Format("{0:X2}{1:X2}{2:X2}", _color.R, _color.G, _color.B);
          }

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

    private void AddColorProperties(Type type)
    {
      Type colorType;

      colorType = typeof(Color);

      // ReSharper disable once LoopCanBePartlyConvertedToQuery
      foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
      {
        if (property.PropertyType == colorType)
        {
          Color color;

          color = (Color)property.GetValue(type, null);
          if (!color.IsEmpty)
          {
            hexTextBox.Items.Add(color.Name);
          }
        }
      }
    }

    private string AddSpaces(string text)
    {
      string result;

      //http://stackoverflow.com/a/272929/148962

      if (!string.IsNullOrEmpty(text))
      {
        StringBuilder newText;

        newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
          if (char.IsUpper(text[i]) && text[i - 1] != ' ')
          {
            newText.Append(' ');
          }
          newText.Append(text[i]);
        }

        result = newText.ToString();
      }
      else
      {
        result = null;
      }

      return result;
    }

    private void FillNamedColors()
    {
      this.AddColorProperties(typeof(SystemColors));
      this.AddColorProperties(typeof(Color));
      this.SetDropDownWidth();
    }

    private void hexTextBox_DrawItem(object sender, DrawItemEventArgs e)
    {
      // TODO: Really, this should be another control - ColorComboBox or ColorListBox etc.

      if (e.Index != -1)
      {
        Rectangle colorBox;
        string name;
        Color color;

        e.DrawBackground();

        name = (string)hexTextBox.Items[e.Index];
        color = Color.FromName(name);
        colorBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

        using (Brush brush = new SolidBrush(color))
        {
          e.Graphics.FillRectangle(brush, colorBox);
        }
        e.Graphics.DrawRectangle(SystemPens.ControlText, colorBox);

        TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colorBox.Right + 3, colorBox.Top), e.ForeColor);

        //if (color == Color.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
        //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

        e.DrawFocusRectangle();
      }
    }

    private void hexTextBox_DropDown(object sender, EventArgs e)
    {
      if (hexTextBox.Items.Count == 0)
      {
        this.FillNamedColors();
      }
    }

    private void hexTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Up:
        case Keys.Down:
        case Keys.PageUp:
        case Keys.PageDown:
          if (hexTextBox.Items.Count == 0)
          {
            this.FillNamedColors();
          }
          break;
      }
    }

    private void hexTextBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (hexTextBox.SelectedIndex != -1)
      {
        _lockUpdates = true;
        this.Color = Color.FromName((string)hexTextBox.SelectedItem);
        _lockUpdates = false;
      }
    }

    /// <summary>
    /// Resizes the editing components.
    /// </summary>
    private void ResizeComponents()
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
        int barHorizontalOffset;

        top = this.Padding.Top;
        innerMargin = 3;
        editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
        rowHeight = Math.Max(Math.Max(rLabel.Height, rColorBar.Height), rNumericUpDown.Height);
        labelOffset = (rowHeight - rLabel.Height) >> 1;
        colorBarOffset = (rowHeight - rColorBar.Height) >> 1;
        editOffset = (rowHeight - rNumericUpDown.Height) >> 1;
        barHorizontalOffset = _showAlphaChannel ? aLabel.Width : hLabel.Width;

        columnWidth = _orientation == Orientation.Horizontal
          ? (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) >> 1
          : this.ClientSize.Width - this.Padding.Horizontal;

        group1HeaderLeft = this.Padding.Left;
        group1EditLeft = columnWidth - editWidth;
        group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

        if (_orientation == Orientation.Horizontal)
        {
          group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
          group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
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
        if (_showColorSpaceLabels)
        {
          rgbHeaderLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          top += rowHeight + innerMargin;
        }

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
        hexTextBox.SetBounds(group1BarLeft, top + colorBarOffset, barWidth + innerMargin + editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // reset top
        if (_orientation == Orientation.Horizontal)
        {
          top = this.Padding.Top;
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

    private void SetBarStates(bool visible)
    {
      rColorBar.Visible = visible;
      gColorBar.Visible = visible;
      bColorBar.Visible = visible;
      hColorBar.Visible = visible;
      sColorBar.Visible = visible;
      lColorBar.Visible = visible;
      aColorBar.Visible = _showAlphaChannel && visible;
    }

    private void SetControlStates()
    {
      aLabel.Visible = _showAlphaChannel;
      aColorBar.Visible = _showAlphaChannel;
      aNumericUpDown.Visible = _showAlphaChannel;

      rgbHeaderLabel.Visible = _showColorSpaceLabels;
      hslLabel.Visible = _showColorSpaceLabels;
    }

    private void SetDropDownWidth()
    {
      if (hexTextBox.Items.Count != 0)
      {
        hexTextBox.DropDownWidth = hexTextBox.ItemHeight * 2 + hexTextBox.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
      }
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
          string text;
          int namedIndex;

          text = hexTextBox.Text;
          if (text.StartsWith("#"))
          {
            text = text.Substring(1);
          }

          if (hexTextBox.Items.Count == 0)
          {
            this.FillNamedColors();
          }

          namedIndex = hexTextBox.FindStringExact(text);

          if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
          {
            try
            {
              Color color;

              color = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
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
          else
          {
            useNamed = true;
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
        {
          useRgb = true;
        }
        else if (sender == hColorBar || sender == lColorBar || sender == sColorBar)
        {
          hNumericUpDown.Value = (int)hColorBar.Value;
          sNumericUpDown.Value = (int)sColorBar.Value;
          lNumericUpDown.Value = (int)lColorBar.Value;

          useHsl = true;
        }
        else if (sender == hNumericUpDown || sender == sNumericUpDown || sender == lNumericUpDown)
        {
          useHsl = true;
        }

        if (useRgb || useNamed)
        {
          Color color;

          color = useNamed ? Color.FromName(hexTextBox.Text) : Color.FromArgb((int)aNumericUpDown.Value, (int)rNumericUpDown.Value, (int)gNumericUpDown.Value, (int)bNumericUpDown.Value);

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
