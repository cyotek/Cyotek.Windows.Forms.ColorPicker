using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

#if USEEXTERNALCYOTEKLIBS
using Cyotek.Drawing;

#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Represents a grid control, which displays a collection of colors using different styles.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ColorGrid : Control, IColorEditor
  {
    #region Constants

    public const int InvalidIndex = -1;

    #endregion

    #region Instance Fields

    private readonly Image _cellBackground;

    private readonly TextureBrush _cellBackgroundBrush;

    private bool _autoAddColors;

    private bool _autoFit;

    private Color _cellBorderColor;

    private ColorCellBorderStyle _cellBorderStyle;

    private Size _cellSize;

    private Color _color;

    private ColorCollection _colors;

    private int _columns;

    private ColorCollection _customColors;

    private ColorEditingMode _editMode;

    private int _hotIndex;

    private ColorPalette _palette;

    private ColorGridSelectedCellStyle _selectedCellStyle;

    private bool _showCustomColors;

    private bool _showToolTips;

    private Size _spacing;

    private ToolTip _toolTip;

    private int _updateCount;

    #endregion

    #region Public Constructors

    public ColorGrid(IEnumerable<Color> colors)
      : this(new ColorCollection(colors))
    { }

    public ColorGrid(ColorCollection colors)
      : this(colors, new ColorCollection(Enumerable.Repeat(Color.White, 32)))
    { }

    public ColorGrid(ColorPalette palette)
      : this(null, new ColorCollection(Enumerable.Repeat(Color.White, 32)), palette)
    { }

    public ColorGrid(ColorCollection colors, ColorCollection customColors)
      : this(colors, customColors, ColorPalette.None)
    { }

    public ColorGrid()
      : this(ColorPalette.Named)
    { }

    #endregion

    #region Protected Constructors

    protected ColorGrid(ColorCollection colors, ColorCollection customColors, ColorPalette palette)
    {
      _cellBackground = new Bitmap(this.GetType().Assembly.GetManifestResourceStream(string.Concat(this.GetType().Namespace, ".Resources.cellbackground.png")));
      _cellBackgroundBrush = new TextureBrush(_cellBackground, WrapMode.Tile);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);
      this.HotIndex = InvalidIndex;
      this.ColorRegions = new Dictionary<int, Rectangle>();
      if (this.Palette != ColorPalette.None)
        this.Colors = colors;
      else
        this.Palette = palette;
      this.CustomColors = customColors;
      this.ShowCustomColors = true;
      this.CellSize = new Size(12, 12);
      this.Spacing = new Size(3, 3);
      this.Columns = 16;
      this.AutoSize = true;
      this.Padding = new Padding(5);
      this.AutoAddColors = true;
      this.CellBorderColor = SystemColors.ButtonShadow;
      this.ShowToolTips = true;
      this.SeparatorHeight = 8;
      this.EditMode = ColorEditingMode.CustomOnly;
      this.Color = Color.Black;
      this.CellBorderStyle = ColorCellBorderStyle.FixedSingle;
      this.SelectedCellStyle = ColorGridSelectedCellStyle.Zoomed;
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the AutoAddColors property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AutoAddColorsChanged;

    /// <summary>
    /// Occurs when the AutoFit property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AutoFitChanged;

    /// <summary>
    /// Occurs when the CellBorderColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CellBorderColorChanged;

    /// <summary>
    /// Occurs when the CellBorderStyle property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CellBorderStyleChanged;

    /// <summary>
    /// Occurs when the CellSize property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CellSizeChanged;

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    /// <summary>
    /// Occurs when the Colors property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorsChanged;

    /// <summary>
    /// Occurs when the Columns property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColumnsChanged;

    /// <summary>
    /// Occurs when the CustomColors property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CustomColorsChanged;

    /// <summary>
    /// Occurs when the EditMode property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler EditModeChanged;

    /// <summary>
    /// Occurs when the HotIndex property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler HotIndexChanged;

    /// <summary>
    /// Occurs when the Palette property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler PaletteChanged;

    /// <summary>
    /// Occurs when the SelectedCellStyle property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SelectedCellStyleChanged;

    /// <summary>
    /// Occurs when the ShowCustomColors property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowCustomColorsChanged;

    /// <summary>
    /// Occurs when the ShowToolTips property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowToolTipsChanged;

    /// <summary>
    /// Occurs when the Spacing property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SpacingChanged;

    #endregion

    #region Overridden Properties

    [Browsable(true)]
    [DefaultValue(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override bool AutoSize
    {
      get { return base.AutoSize; }
      set { base.AutoSize = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get { return base.Font; }
      set { base.Font = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    #endregion

    #region Overridden Methods

    public override Size GetPreferredSize(Size proposedSize)
    {
      return this.AutoSize ? this.GetAutoSize() : base.GetPreferredSize(proposedSize);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_toolTip != null)
          _toolTip.Dispose();

        if (_cellBackground != null)
          _cellBackground.Dispose();

        if (_cellBackgroundBrush != null)
          _cellBackgroundBrush.Dispose();
      }

      base.Dispose(disposing);
    }

    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if (keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Enter || keyData == Keys.Home || keyData == Keys.End)
        result = true;
      else
        result = base.IsInputKey(keyData);

      return result;
    }

    protected override void OnAutoSizeChanged(EventArgs e)
    {
      if (this.AutoSize && this.AutoFit)
        this.AutoFit = false;

      base.OnAutoSizeChanged(e);

      if (this.AutoSize)
        this.SizeToFit();
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);

      this.Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      Point cellLocation;
      bool processed;
      int row;
      int column;
      int lastStandardRowOffset;
      int lastStandardRowLastColumn;

      this.WasKeyPressed = true;

      lastStandardRowOffset = (this.PrimaryRows * this.Columns) - this.Colors.Count;
      lastStandardRowLastColumn = this.Columns - lastStandardRowOffset;
      cellLocation = this.GetCell(this.ColorIndex);
      column = cellLocation.X;
      row = cellLocation.Y;

      switch (e.KeyData)
      {
        case Keys.Down:
          row++;
          if (row == this.PrimaryRows - 1 && column >= lastStandardRowLastColumn)
            column = lastStandardRowLastColumn - 1;
          processed = true;
          break;
        case Keys.Up:
          row--;
          if (row == this.PrimaryRows - 1 && column > lastStandardRowLastColumn)
            column = lastStandardRowLastColumn - 1;
          processed = true;
          break;
        case Keys.Left:
          column--;
          if (column < 0)
          {
            column = this.Columns - 1;
            row--;
            if (row == this.PrimaryRows - 1)
              column = this.Columns - (lastStandardRowOffset + 1);
          }
          processed = true;
          break;
        case Keys.Right:
          column++;
          if (row == this.PrimaryRows - 1 && column >= this.Columns - lastStandardRowOffset || column >= this.Columns)
          {
            column = 0;
            row++;
          }
          processed = true;
          break;
        case Keys.Home:
          column = 0;
          row = 0;
          processed = true;
          break;
        case Keys.End:
          column = this.Columns - 1;
          row = this.PrimaryRows + this.CustomRows - 1;
          processed = true;
          break;
        default:
          processed = false;
          break;
      }

      if (processed)
      {
        int index;

        index = this.GetCellIndex(column, row);
        if (index != InvalidIndex)
        {
          // setting the Color property will automatically set the ColorIndex to the index of the first match
          // which is not exactly what you want when navigating the grid with the keyboard! Disable painting
          // so that no flicker is displayed if the index flicks between two values with a forced repaint inbetween
          this.BeginUpdate();
          this.Color = this.GetColor(index);
          this.ColorIndex = index;
          this.EndUpdate();
        }

        e.Handled = true;
      }

      base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
      if (this.WasKeyPressed && e.KeyData == Keys.Enter && this.ColorIndex != InvalidIndex)
      {
        ColorSource source;

        source = this.GetColorSource(this.ColorIndex);
        if (source == ColorSource.Custom && this.EditMode != ColorEditingMode.None || source == ColorSource.Standard && this.EditMode == ColorEditingMode.Both)
        {
          e.Handled = true;
          this.EditColor(this.ColorIndex);
        }
      }

      this.WasKeyPressed = false;

      base.OnKeyUp(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);

      this.Invalidate();
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      ColorHitTestInfo hitTest;

      base.OnMouseDoubleClick(e);

      hitTest = this.HitTest(e.Location);

      if (hitTest.Source == ColorSource.Custom && this.EditMode != ColorEditingMode.None || hitTest.Source == ColorSource.Standard && this.EditMode == ColorEditingMode.Both)
        this.EditColor(hitTest.Index);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (!this.Focused && this.TabStop)
        this.Focus();

      this.ProcessMouseClick(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);

      this.HotIndex = InvalidIndex;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      this.HotIndex = this.HitTest(e.Location).Index;

      this.ProcessMouseClick(e);
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.RefreshColors();
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.AllowPainting)
      {
        base.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc as the PaintBackground event is no longer being called

        // draw a design time dotted grid
        if (this.DesignMode)
        {
          using (Pen pen = new Pen(SystemColors.ButtonShadow)
          {
            DashStyle = DashStyle.Dot
          })
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        // draw cells for all current colors
        for (int i = 0; i < this.Colors.Count; i++)
          this.PaintCell(e, i, i, this.Colors[i], this.ColorRegions[i]);

        if (this.CustomColors.Count != 0 && this.ShowCustomColors)
        {
          // draw a separator
          this.PaintSeparator(e);

          // and the custom colors
          for (int i = 0; i < this.CustomColors.Count; i++)
            this.PaintCell(e, i, this.Colors.Count + i, this.CustomColors[i], this.ColorRegions[this.Colors.Count + i]);
        }

        // draw the selected color
        if (this.SelectedCellStyle != ColorGridSelectedCellStyle.None && this.ColorIndex >= 0)
          this.PaintSelectedCell(e, this.ColorIndex, this.Color, this.ColorRegions[this.ColorIndex]);
      }
    }

    protected override void OnResize(EventArgs e)
    {
      this.RefreshColors();

      base.OnResize(e);
    }

    #endregion

    #region Public Properties

    [Category("Behavior")]
    [DefaultValue(true)]
    public virtual bool AutoAddColors
    {
      get { return _autoAddColors; }
      set
      {
        if (this.AutoAddColors != value)
        {
          _autoAddColors = value;

          this.OnAutoAddColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public virtual bool AutoFit
    {
      get { return _autoFit; }
      set
      {
        if (this.AutoFit != value)
        {
          _autoFit = value;

          this.OnAutoFitChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "ButtonShadow")]
    public virtual Color CellBorderColor
    {
      get { return _cellBorderColor; }
      set
      {
        if (this.CellBorderColor != value)
        {
          _cellBorderColor = value;

          this.OnCellBorderColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorCellBorderStyle), "FixedSingle")]
    public virtual ColorCellBorderStyle CellBorderStyle
    {
      get { return _cellBorderStyle; }
      set
      {
        if (this.CellBorderStyle != value)
        {
          _cellBorderStyle = value;

          this.OnCellBorderStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Size), "12, 12")]
    public virtual Size CellSize
    {
      get { return _cellSize; }
      set
      {
        if (this.CellSize != value)
        {
          _cellSize = value;

          this.OnCellSizeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        int newIndex;

        _color = value;

        newIndex = this.GetColorIndex(value);

        if (newIndex == InvalidIndex)
          newIndex = this.AddCustomColor(value);

        this.ColorIndex = newIndex;

        this.OnColorChanged(EventArgs.Empty);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection Colors
    {
      get { return _colors; }
      set
      {
        if (this.Colors != value)
        {
          _colors = value;

          this.OnColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(16)]
    public virtual int Columns
    {
      get { return _columns; }
      set
      {
        if (this.Columns != value)
        {
          _columns = value;
          this.CalculateRows();

          this.OnColumnsChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection CustomColors
    {
      get { return _customColors; }
      set
      {
        if (this.CustomColors != value)
        {
          _customColors = value;

          this.OnCustomColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorEditingMode), "CustomOnly")]
    public virtual ColorEditingMode EditMode
    {
      get { return _editMode; }
      set
      {
        if (this.EditMode != value)
        {
          _editMode = value;

          this.OnEditModeChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int HotIndex
    {
      get { return _hotIndex; }
      set
      {
        if (this.HotIndex != value)
        {
          _hotIndex = value;

          this.OnHotIndexChanged(EventArgs.Empty);
        }
      }
    }

    [DefaultValue(typeof(Padding), "5, 5, 5, 5")]
    public new Padding Padding
    {
      get { return base.Padding; }
      set { base.Padding = value; }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorPalette), "Named")]
    public virtual ColorPalette Palette
    {
      get { return _palette; }
      set
      {
        if (this.Palette != value)
        {
          _palette = value;

          this.OnPaletteChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorGridSelectedCellStyle), "Zoomed")]
    public virtual ColorGridSelectedCellStyle SelectedCellStyle
    {
      get { return _selectedCellStyle; }
      set
      {
        if (this.SelectedCellStyle != value)
        {
          _selectedCellStyle = value;

          this.OnSelectedCellStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public virtual bool ShowCustomColors
    {
      get { return _showCustomColors; }
      set
      {
        if (this.ShowCustomColors != value)
        {
          _showCustomColors = value;

          this.OnShowCustomColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(true)]
    public virtual bool ShowToolTips
    {
      get { return _showToolTips; }
      set
      {
        if (this.ShowToolTips != value)
        {
          _showToolTips = value;

          this.OnShowToolTipsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Size), "3, 3")]
    public virtual Size Spacing
    {
      get { return _spacing; }
      set
      {
        if (this.Spacing != value)
        {
          _spacing = value;

          this.OnSpacingChanged(EventArgs.Empty);
        }
      }
    }

    #endregion

    #region Protected Properties

    /// <summary>
    ///   Gets a value indicating whether painting of the control is allowed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool AllowPainting
    {
      get { return _updateCount == 0; }
    }

    protected int ColorIndex { get; set; }

    protected IDictionary<int, Rectangle> ColorRegions { get; set; }

    protected int CustomRows { get; set; }

    protected bool LockUpdates { get; set; }

    protected int PrimaryRows { get; set; }

    protected int SeparatorHeight { get; set; }

    protected bool WasKeyPressed { get; set; }

    #endregion

    #region Public Members

    public virtual int AddCustomColor(Color value)
    {
      int newIndex;

      newIndex = this.GetColorIndex(value);

      if (newIndex == InvalidIndex)
      {
        if (this.AutoAddColors)
          this.CustomColors.Add(value);
        else
        {
          if (this.CustomColors == null)
          {
            this.CustomColors = new ColorCollection();
            this.CustomColors.Add(value);
          }
          else
            this.CustomColors[0] = value;

          newIndex = this.GetColorIndex(value);
        }

        this.RefreshColors();
      }

      return newIndex;
    }

    /// <summary>
    ///   Disables any redrawing of the image box
    /// </summary>
    public virtual void BeginUpdate()
    {
      _updateCount++;
    }

    /// <summary>
    ///   Enables the redrawing of the image box
    /// </summary>
    public virtual void EndUpdate()
    {
      if (_updateCount > 0)
        _updateCount--;

      if (this.AllowPainting)
        this.Invalidate();
    }

    public Color GetColor(int index)
    {
      Color result;
      int colorCount;
      int customColorCount;

      colorCount = this.Colors != null ? this.Colors.Count : 0;
      customColorCount = this.CustomColors != null ? this.CustomColors.Count : 0;

      if (index < 0 || index > (colorCount + customColorCount))
        result = Color.Empty;
      else
        result = index > colorCount - 1 ? this.CustomColors[index - colorCount] : this.Colors[index];

      return result;
    }

    public ColorSource GetColorSource(int colorIndex)
    {
      ColorSource result;
      int colorCount;
      int customColorCount;

      colorCount = this.Colors != null ? this.Colors.Count : 0;
      customColorCount = this.CustomColors != null ? this.CustomColors.Count : 0;

      if (colorCount < 0 || colorIndex > (colorCount + customColorCount))
        result = ColorSource.None;
      else
        result = colorIndex > colorCount - 1 ? ColorSource.Custom : ColorSource.Standard;

      return result;
    }

    public ColorSource GetColorSource(Color color)
    {
      int index;
      ColorSource result;

      index = this.Colors.IndexOf(color);
      if (index != InvalidIndex)
        result = ColorSource.Standard;
      else
      {
        index = this.CustomColors.IndexOf(color);
        result = index != InvalidIndex ? ColorSource.Custom : ColorSource.None;
      }

      return result;
    }

    public ColorHitTestInfo HitTest(Point point)
    {
      ColorHitTestInfo result;
      int colorIndex;

      result = new ColorHitTestInfo();
      colorIndex = InvalidIndex;

      foreach (KeyValuePair<int, Rectangle> pair in this.ColorRegions.Where(pair => pair.Value.Contains(point)))
      {
        colorIndex = pair.Key;
        break;
      }

      result.Index = colorIndex;
      if (colorIndex != InvalidIndex)
      {
        result.Color = colorIndex < (this.Colors.Count + this.CustomColors.Count) ? this.GetColor(colorIndex) : Color.White;
        result.Source = this.GetColorSource(colorIndex);
      }
      else
        result.Source = ColorSource.None;

      return result;
    }

    #endregion

    #region Protected Members

    protected virtual void CalculateCellSize()
    {
      int w;
      int h;

      w = ((this.ClientSize.Width - this.Padding.Horizontal) / this.Columns) - this.Spacing.Width;
      h = ((this.ClientSize.Height - this.Padding.Vertical) / (this.PrimaryRows + this.CustomRows)) - this.Spacing.Height;

      if (w > 0 && h > 0)
        this.CellSize = new Size(w, h);
    }

    protected virtual void CalculateRows()
    {
      int primaryRows;
      int customRows;

      primaryRows = this.GetRows(this.Colors != null ? this.Colors.Count : 0);
      if (primaryRows == 0)
        primaryRows = 1;

      customRows = this.ShowCustomColors ? this.GetRows(this.CustomColors != null ? this.CustomColors.Count : 0) : 0;

      this.PrimaryRows = primaryRows;
      this.CustomRows = customRows;
    }

    protected void DefineColorRegions(ColorCollection colors, int rangeStart, int offset)
    {
      if (colors != null)
      {
        int rows;
        int index;

        rows = this.GetRows(colors.Count);
        index = 0;

        for (int row = 0; row < rows; row++)
        {
          for (int column = 0; column < this.Columns; column++)
          {
            if (index < colors.Count)
              this.ColorRegions.Add(rangeStart + index, new Rectangle(this.Padding.Left + (column * (this.CellSize.Width + this.Spacing.Width)), offset + (row * (this.CellSize.Height + this.Spacing.Height)), this.CellSize.Width, this.CellSize.Height));

            index++;
          }
        }
      }
    }

    protected virtual void EditColor(int colorIndex)
    {
      using (ColorPickerDialog dialog = new ColorPickerDialog())
      {
        dialog.Color = this.GetColor(colorIndex);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.BeginUpdate();
          this.SetColor(colorIndex, dialog.Color);
          this.Color = dialog.Color;
          this.EndUpdate();
        }
      }
    }

    protected Size GetAutoSize()
    {
      int offset;

      offset = this.CustomRows != 0 ? this.SeparatorHeight : 0;

      return new Size(((this.CellSize.Width + this.Spacing.Width) * this.Columns) + this.Padding.Horizontal - this.Spacing.Width, ((this.CellSize.Height + this.Spacing.Height) * (this.PrimaryRows + this.CustomRows)) + offset + this.Padding.Vertical - this.Spacing.Height);
    }

    protected virtual int GetCellIndex(int column, int row)
    {
      int result;

      if (column >= 0 && column < this.Columns && row >= 0 && row < (this.PrimaryRows + this.CustomRows))
      {
        int lastStandardRowOffset;

        lastStandardRowOffset = (this.PrimaryRows * this.Columns) - this.Colors.Count;
        result = row * this.Columns + column;
        if (row == this.PrimaryRows - 1 && column >= (this.Columns - lastStandardRowOffset))
          result -= lastStandardRowOffset;
        if (row >= this.PrimaryRows)
          result -= lastStandardRowOffset;

        if (result > (this.Colors.Count + this.CustomColors.Count) - 1)
          result = InvalidIndex;
      }
      else
        result = InvalidIndex;

      return result;
    }

    protected virtual int GetColorIndex(Color value)
    {
      int index;

      index = this.Colors != null ? this.Colors.IndexOf(value) : InvalidIndex;
      if (index == InvalidIndex && this.CustomColors != null)
      {
        index = this.CustomColors.IndexOf(value);
        if (index != InvalidIndex)
          index += this.Colors.Count;
      }

      return index;
    }

    protected virtual ColorCollection GetPredefinedPalette()
    {
      return ColorPalettes.GetPalette(this.Palette);
    }

    protected int GetRows(int count)
    {
      int rows;

      if (count != 0 && this.Columns > 0)
      {
        rows = count / this.Columns;
        if ((count % Columns) != 0)
          rows++;
      }
      else
        rows = 0;

      return rows;
    }

    /// <summary>
    /// Raises the <see cref="AutoAddColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAutoAddColorsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.AutoAddColorsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="AutoFitChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAutoFitChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AutoFit && this.AutoSize)
        this.AutoSize = false;

      this.RefreshColors();

      handler = this.AutoFitChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellBorderColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellBorderColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.CellBorderColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellBorderStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellBorderStyleChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.CellBorderStyleChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellSizeChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AutoSize)
        this.SizeToFit();
      this.RefreshColors();
      this.Invalidate();

      handler = this.CellSizeChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
        this.Refresh();

      handler = this.ColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorsChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.Colors != null)
        this.Colors.CollectionChanged += this.ColorsCollectionChangedHandler;
      this.RefreshColors();

      handler = this.ColorsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColumnsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColumnsChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshColors();

      handler = this.ColumnsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.CustomColors != null)
        this.CustomColors.CollectionChanged += this.ColorsCollectionChangedHandler;
      this.RefreshColors();

      handler = this.CustomColorsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="EditModeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnEditModeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.EditModeChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="HotIndexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnHotIndexChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetToolTip();
      this.Refresh();

      handler = this.HotIndexChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="PaletteChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPaletteChanged(EventArgs e)
    {
      EventHandler handler;

      this.Colors = this.GetPredefinedPalette();

      handler = this.PaletteChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SelectedCellStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectedCellStyleChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.SelectedCellStyleChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowCustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshColors();

      handler = this.ShowCustomColorsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowToolTipsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowToolTipsChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.ShowToolTips)
        _toolTip = new ToolTip();
      else if (_toolTip != null)
      {
        _toolTip.Dispose();
        _toolTip = null;
      }

      handler = this.ShowToolTipsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SpacingChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSpacingChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AutoSize)
        this.SizeToFit();
      this.RefreshColors();
      this.Invalidate();

      handler = this.SpacingChanged;

      if (handler != null)
        handler(this, e);
    }

    protected virtual void PaintCell(PaintEventArgs e, int colorIndex, int cellIndex, Color color, Rectangle bounds)
    {
      if (color.A != 255)
        e.Graphics.FillRectangle(_cellBackgroundBrush, bounds);

      using (Brush brush = new SolidBrush(color))
        e.Graphics.FillRectangle(brush, bounds);

      switch (this.CellBorderStyle)
      {
        case ColorCellBorderStyle.FixedSingle:
          using (Pen pen = new Pen(this.CellBorderColor))
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          break;
        case ColorCellBorderStyle.DoubleSoft:
          HslColor shadedOuter;
          HslColor shadedInner;

          shadedOuter = new HslColor(color);
          shadedOuter.L -= 0.50;

          shadedInner = new HslColor(color);
          shadedInner.L -= 0.20;

          using (Pen pen = new Pen(this.CellBorderColor))
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
          using (Pen pen = new Pen(Color.FromArgb(32, shadedOuter.ToRgbColor())))
            e.Graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, bounds.Width - 5, bounds.Height - 5);
          using (Pen pen = new Pen(Color.FromArgb(32, shadedInner.ToRgbColor())))
            e.Graphics.DrawRectangle(pen, bounds.Left + 3, bounds.Top + 3, bounds.Width - 7, bounds.Height - 7);
          break;
      }

      if (this.HotIndex != InvalidIndex && this.HotIndex == cellIndex)
      {
        e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
        e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
      }
    }

    protected virtual void PaintSelectedCell(PaintEventArgs e, int colorIndex, Color color, Rectangle bounds)
    {
      switch (this.SelectedCellStyle)
      {
        case ColorGridSelectedCellStyle.Standard:
          if (this.Focused)
            ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
          else
            e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          break;
        case ColorGridSelectedCellStyle.Zoomed:
          // make the cell larger by half
          if (this.SelectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
            bounds.Inflate((this.CellSize.Width / 2) - 1, (this.CellSize.Height / 2) - 1);

          // fill the inner
          e.Graphics.FillRectangle(Brushes.White, bounds);
          if (this.SelectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
            bounds.Inflate(-3, -3);
          if (color.A != 255)
            e.Graphics.FillRectangle(_cellBackgroundBrush, bounds);

          using (Brush brush = new SolidBrush(color))
            e.Graphics.FillRectangle(brush, bounds);
          // draw a border
          if (this.Focused)
          {
            bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
          }
          else
          {
            bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 3, bounds.Height + 3);

            using (Pen pen = new Pen(this.CellBorderColor))
              e.Graphics.DrawRectangle(pen, bounds);
          }
          break;
      }
    }

    protected virtual void PaintSeparator(PaintEventArgs e)
    {
      int x1;
      int y1;
      int x2;
      int y2;

      x1 = this.Padding.Left;
      x2 = this.ClientSize.Width - this.Padding.Right;
      y1 = (this.SeparatorHeight / 2) + this.Padding.Top + (this.PrimaryRows * (this.CellSize.Height + this.Spacing.Height)) + 1 - this.Spacing.Height;
      y2 = y1;

      using (Pen pen = new Pen(this.CellBorderColor))
        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
    }

    protected virtual void ProcessMouseClick(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ColorHitTestInfo hitTest;

        hitTest = this.HitTest(e.Location);

        if (hitTest.Source != ColorSource.None)
        {
          this.Color = hitTest.Color;
          this.ColorIndex = hitTest.Index;
          this.Invalidate();
        }
      }
    }

    protected virtual void RefreshColors()
    {
      if (this.AllowPainting)
      {
        this.CalculateRows();
        if (this.AutoFit)
          this.CalculateCellSize();
        else if (this.AutoSize)
          this.SizeToFit();

        this.ColorRegions.Clear();

        if (this.Colors != null)
        {
          this.DefineColorRegions(this.Colors, 0, this.Padding.Top);
          this.DefineColorRegions(this.CustomColors, this.Colors.Count, this.Padding.Top + this.SeparatorHeight + ((this.CellSize.Height + this.Spacing.Height) * this.PrimaryRows));

          this.ColorIndex = this.GetColorIndex(this.Color);

          if (!this.Color.IsEmpty && this.ColorIndex == InvalidIndex)
            this.AddCustomColor(this.Color);

          this.Invalidate();
        }
      }
    }

    protected virtual void SetColor(int colorIndex, Color color)
    {
      int colorCount;

      colorCount = this.Colors.Count;
      if (colorIndex < 0 || colorIndex > (colorCount + this.CustomColors.Count))
        throw new ArgumentOutOfRangeException("colorIndex");

      if (colorIndex > colorCount - 1)
        this.CustomColors[colorIndex - colorCount] = color;
      else
        this.Colors[colorIndex] = color;
    }

    protected virtual void SetToolTip()
    {
      if (this.ShowToolTips)
        _toolTip.SetToolTip(this, this.HotIndex != InvalidIndex ? this.GetColor(this.HotIndex).Name : null);
    }

    #endregion

    #region Private Members

    private Point GetCell(int index)
    {
      int row;
      int column;

      if (index >= this.Colors.Count)
      {
        // custom color
        index -= this.Colors.Count;
        row = index / this.Columns;
        column = index - (row * this.Columns);
        row += this.PrimaryRows;
      }
      else
      {
        // normal row
        row = index / this.Columns;
        column = index - (row * this.Columns);
      }

      return new Point(column, row);
    }

    private void SizeToFit()
    {
      this.Size = this.GetAutoSize();
    }

    #endregion

    #region Event Handlers

    private void ColorsCollectionChangedHandler(object sender, ColorCollectionEventArgs e)
    {
      this.RefreshColors();
    }

    #endregion
  }
}
