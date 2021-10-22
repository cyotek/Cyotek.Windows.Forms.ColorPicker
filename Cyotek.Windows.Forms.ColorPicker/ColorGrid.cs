// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Represents a grid control, which displays a collection of colors using different styles.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ColorGrid : Control, IColorEditor
  {
    #region Public Fields

    public const int InvalidIndex = -1;

    #endregion Public Fields

    #region Private Fields

    private static readonly object _eventAutoAddColorsChanged = new object();

    private static readonly object _eventAutoFitChanged = new object();

    private static readonly object _eventCellBorderColorChanged = new object();

    private static readonly object _eventCellBorderStyleChanged = new object();

    private static readonly object _eventCellContextMenuStripChanged = new object();

    private static readonly object _eventCellSizeChanged = new object();

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventColorIndexChanged = new object();

    private static readonly object _eventColorsChanged = new object();

    private static readonly object _eventColumnsChanged = new object();

    private static readonly object _eventCustomColorsChanged = new object();

    private static readonly object _eventEditingColor = new object();

    private static readonly object _eventEditModeChanged = new object();

    private static readonly object _eventHotIndexChanged = new object();

    private static readonly object _eventPaletteChanged = new object();

    private static readonly object _eventSelectedCellStyleChanged = new object();

    private static readonly object _eventShowCustomColorsChanged = new object();

    private static readonly object _eventShowToolTipsChanged = new object();

    private static readonly object _eventSpacingChanged = new object();

    private readonly IDictionary<int, Rectangle> _colorRegions;

    private int _actualColumns;

    private bool _autoAddColors;

    private bool _autoFit;

    private Brush _cellBackgroundBrush;

    private Color _cellBorderColor;

    private ColorCellBorderStyle _cellBorderStyle;

    private ContextMenuStrip _cellContextMenuStrip;

    private Size _cellSize;

    private Color _color;

    private int _colorIndex;

    private ColorCollection _colors;

    private int _columns;

    private ColorCollection _customColors;

    private int _customRows;

    private ColorEditingMode _editMode;

    private int _hotIndex;

    private bool _layoutRequired;

    private ColorPalette _palette;

    private int _previousColorIndex;

    private int _previousHotIndex;

    private int _primaryRows;

    private Size _scaledCellSize;

    private ColorGridSelectedCellStyle _selectedCellStyle;

    private int _separatorHeight;

    private bool _showCustomColors;

    private bool _showToolTips;

    private Size _spacing;

    private ToolTip _toolTip;

    private int _updateCount;

    private bool _wasKeyPressed;

    #endregion Private Fields

    #region Public Constructors

    public ColorGrid()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.SupportsTransparentBackColor, true);
      _previousHotIndex = InvalidIndex;
      _previousColorIndex = InvalidIndex;
      _hotIndex = InvalidIndex;

      _colorRegions = new Dictionary<int, Rectangle>();
      _colors = ColorPalettes.NamedColors;
      _customColors = new ColorCollection(Enumerable.Repeat(Color.White, 16));
      _showCustomColors = true;
      _cellSize = new Size(12, 12);
      _spacing = new Size(3, 3);
      _columns = 16;
      base.AutoSize = true;
      this.Padding = new Padding(5);
      _autoAddColors = true;
      _cellBorderColor = SystemColors.ButtonShadow;
      _showToolTips = true;
      _toolTip = new ToolTip();
      _separatorHeight = 8;
      _editMode = ColorEditingMode.CustomOnly;
      _color = Color.Black;
      _cellBorderStyle = ColorCellBorderStyle.FixedSingle;
      _selectedCellStyle = ColorGridSelectedCellStyle.Zoomed;
      _palette = ColorPalette.Named;

      this.AddEventHandlers(_colors);
      this.AddEventHandlers(_customColors);

      this.SetScaledCellSize();
      this.RefreshColors();
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler AutoAddColorsChanged
    {
      add => this.Events.AddHandler(_eventAutoAddColorsChanged, value);
      remove => this.Events.RemoveHandler(_eventAutoAddColorsChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler AutoFitChanged
    {
      add => this.Events.AddHandler(_eventAutoFitChanged, value);
      remove => this.Events.RemoveHandler(_eventAutoFitChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler CellBorderColorChanged
    {
      add => this.Events.AddHandler(_eventCellBorderColorChanged, value);
      remove => this.Events.RemoveHandler(_eventCellBorderColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler CellBorderStyleChanged
    {
      add => this.Events.AddHandler(_eventCellBorderStyleChanged, value);
      remove => this.Events.RemoveHandler(_eventCellBorderStyleChanged, value);
    }

    /// <summary>
    /// Occurs when the CellContextMenuStrip property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CellContextMenuStripChanged
    {
      add => this.Events.AddHandler(_eventCellContextMenuStripChanged, value);
      remove => this.Events.RemoveHandler(_eventCellContextMenuStripChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler CellSizeChanged
    {
      add => this.Events.AddHandler(_eventCellSizeChanged, value);
      remove => this.Events.RemoveHandler(_eventCellSizeChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add => this.Events.AddHandler(_eventColorChanged, value);
      remove => this.Events.RemoveHandler(_eventColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColorIndexChanged
    {
      add => this.Events.AddHandler(_eventColorIndexChanged, value);
      remove => this.Events.RemoveHandler(_eventColorIndexChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColorsChanged
    {
      add => this.Events.AddHandler(_eventColorsChanged, value);
      remove => this.Events.RemoveHandler(_eventColorsChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColumnsChanged
    {
      add => this.Events.AddHandler(_eventColumnsChanged, value);
      remove => this.Events.RemoveHandler(_eventColumnsChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler CustomColorsChanged
    {
      add => this.Events.AddHandler(_eventCustomColorsChanged, value);
      remove => this.Events.RemoveHandler(_eventCustomColorsChanged, value);
    }

    [Category("Action")]
    public event EventHandler<EditColorCancelEventArgs> EditingColor
    {
      add => this.Events.AddHandler(_eventEditingColor, value);
      remove => this.Events.RemoveHandler(_eventEditingColor, value);
    }

    [Category("Property Changed")]
    public event EventHandler EditModeChanged
    {
      add => this.Events.AddHandler(_eventEditModeChanged, value);
      remove => this.Events.RemoveHandler(_eventEditModeChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler HotIndexChanged
    {
      add => this.Events.AddHandler(_eventHotIndexChanged, value);
      remove => this.Events.RemoveHandler(_eventHotIndexChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler PaletteChanged
    {
      add => this.Events.AddHandler(_eventPaletteChanged, value);
      remove => this.Events.RemoveHandler(_eventPaletteChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler SelectedCellStyleChanged
    {
      add => this.Events.AddHandler(_eventSelectedCellStyleChanged, value);
      remove => this.Events.RemoveHandler(_eventSelectedCellStyleChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ShowCustomColorsChanged
    {
      add => this.Events.AddHandler(_eventShowCustomColorsChanged, value);
      remove => this.Events.RemoveHandler(_eventShowCustomColorsChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ShowToolTipsChanged
    {
      add => this.Events.AddHandler(_eventShowToolTipsChanged, value);
      remove => this.Events.RemoveHandler(_eventShowToolTipsChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler SpacingChanged
    {
      add => this.Events.AddHandler(_eventSpacingChanged, value);
      remove => this.Events.RemoveHandler(_eventSpacingChanged, value);
    }

    #endregion Public Events

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ActualColumns
    {
      get => _actualColumns;
      protected set => _actualColumns = value;
    }

    [Category("Behavior")]
    [DefaultValue(true)]
    public virtual bool AutoAddColors
    {
      get => _autoAddColors;
      set
      {
        if (_autoAddColors != value)
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
      get => _autoFit;
      set
      {
        if (_autoFit != value)
        {
          _autoFit = value;

          this.OnAutoFitChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(true)]
    [DefaultValue(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "ButtonShadow")]
    public virtual Color CellBorderColor
    {
      get => _cellBorderColor;
      set
      {
        if (_cellBorderColor != value)
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
      get => _cellBorderStyle;
      set
      {
        if (_cellBorderStyle != value)
        {
          _cellBorderStyle = value;

          this.OnCellBorderStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ContextMenuStrip), null)]
    public ContextMenuStrip CellContextMenuStrip
    {
      get => _cellContextMenuStrip;
      set
      {
        if (_cellContextMenuStrip != value)
        {
          _cellContextMenuStrip = value;

          this.OnCellContextMenuStripChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Size), "12, 12")]
    public virtual Size CellSize
    {
      get => _cellSize;
      set
      {
        if (_cellSize != value)
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
      get => _color;
      set
      {
        int newIndex;

        _color = value;

        if (!value.IsEmpty)
        {
          // the new color matches the color at the current index, so don't change the index
          // this stops the selection hopping about if you have duplicate colors in a palette
          // otherwise, if the colors don't match, then find the index that does
          newIndex = this.GetColor(_colorIndex) == value
            ? _colorIndex
            : this.GetColorIndex(value);

          if (newIndex == InvalidIndex)
          {
            newIndex = this.AddCustomColor(value);
          }
        }
        else
        {
          newIndex = InvalidIndex;
        }

        this.ColorIndex = newIndex;

        this.OnColorChanged(EventArgs.Empty);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int ColorIndex
    {
      get => _colorIndex;
      set
      {
        if (_colorIndex != value)
        {
          _previousColorIndex = _colorIndex;
          _colorIndex = value;

          if (value != InvalidIndex)
          {
            this.Color = this.GetColor(value);
          }

          this.OnColorIndexChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection Colors
    {
      get => _colors;
      set
      {
        if (value == null)
        {
          throw new ArgumentNullException(nameof(value));
        }

        if (!object.ReferenceEquals(_colors, value))
        {
          this.RemoveEventHandlers(_colors);

          _colors = value;

          this.OnColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(16)]
    public virtual int Columns
    {
      get => _columns;
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(value), value, "Number of columns cannot be less than zero.");
        }

        if (_columns != value)
        {
          _columns = value;
          this.CalculateGridSize();

          this.OnColumnsChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    public Point CurrentCell => this.GetCell(_colorIndex);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection CustomColors
    {
      get => _customColors;
      set
      {
        if (!object.ReferenceEquals(_customColors, value))
        {
          this.RemoveEventHandlers(_customColors);

          _customColors = value;

          this.OnCustomColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(ColorEditingMode), "CustomOnly")]
    public virtual ColorEditingMode EditMode
    {
      get => _editMode;
      set
      {
        if (_editMode != value)
        {
          _editMode = value;

          this.OnEditModeChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int HotIndex
    {
      get => _hotIndex;
      set
      {
        if (_hotIndex != value)
        {
          _previousHotIndex = _hotIndex;
          _hotIndex = value;

          this.OnHotIndexChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorPalette), "Named")]
    public virtual ColorPalette Palette
    {
      get => _palette;
      set
      {
        if (_palette != value)
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
      get => _selectedCellStyle;
      set
      {
        if (_selectedCellStyle != value)
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
      get => _showCustomColors;
      set
      {
        if (_showCustomColors != value)
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
      get => _showToolTips;
      set
      {
        if (_showToolTips != value)
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
      get => _spacing;
      set
      {
        if (_spacing != value)
        {
          _spacing = value;

          this.OnSpacingChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    #endregion Public Properties

    #region Protected Properties

    /// <summary>
    ///   Gets a value indicating whether painting of the control is allowed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool AllowPainting => _updateCount == 0;

    protected IDictionary<int, Rectangle> ColorRegions => _colorRegions;

    protected int CustomRows
    {
      get => _customRows;
      set => _customRows = value;
    }

    protected override Padding DefaultPadding => new Padding(5);

    protected int PrimaryRows
    {
      get => _primaryRows;
      set => _primaryRows = value;
    }

    protected int SeparatorHeight
    {
      get => _separatorHeight;
      set => _separatorHeight = value;
    }

    [Obsolete("This property will be removed in a future version.")]
    protected bool WasKeyPressed
    {
      get => _wasKeyPressed;
      set => _wasKeyPressed = value;
    }

    #endregion Protected Properties

    #region Public Methods

    public virtual int AddCustomColor(Color value)
    {
      int newIndex;

      newIndex = this.GetColorIndex(value);

      if (newIndex == InvalidIndex)
      {
        if (_autoAddColors)
        {
          _customColors.Add(value);
        }
        else
        {
          if (_customColors == null)
          {
            _customColors = new ColorCollection();
            _customColors.Add(value);
          }
          else
          {
            _customColors[0] = value;
          }

          newIndex = this.GetColorIndex(value);
        }

        if (_showCustomColors)
        {
          this.RefreshColors();
        }
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
      {
        _updateCount--;
      }

      if (this.AllowPainting)
      {
        if (_layoutRequired)
        {
          this.RefreshColors();
          _layoutRequired = false;
        }
        else
        {
          this.Invalidate();
        }
      }
    }

    /// <summary>
    /// Returns the <see cref="Rectangle"/> describing the bounds of a single color cell
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more arguments are outside the
    /// required range.</exception>
    /// <param name="index">Zero-based index of the color cell to return.</param>
    /// <returns>
    /// The cell bounds.
    /// </returns>
    public Rectangle GetCellBounds(int index)
    {
      if (index < 0 || index > _colors.Count + _customColors.Count - 1)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      return _colorRegions[index];
    }

    public Color GetColor(int index)
    {
      Color result;
      int colorCount;
      int customColorCount;

      colorCount = _colors != null
        ? _colors.Count
        : 0;
      customColorCount = _customColors != null
        ? _customColors.Count
        : 0;

      if (index < 0 || index > colorCount + customColorCount)
      {
        result = Color.Empty;
      }
      else
      {
        result = index > colorCount - 1
          ? _customColors[index - colorCount]
          : _colors[index];
      }

      return result;
    }

    public ColorSource GetColorSource(int colorIndex)
    {
      ColorSource result;
      int colorCount;
      int customColorCount;

      colorCount = _colors != null
        ? _colors.Count
        : 0;
      customColorCount = _customColors != null
        ? _customColors.Count
        : 0;

      if (colorCount < 0 || colorIndex > colorCount + customColorCount)
      {
        result = ColorSource.None;
      }
      else
      {
        result = colorIndex > colorCount - 1
          ? ColorSource.Custom
          : ColorSource.Standard;
      }

      return result;
    }

    public ColorSource GetColorSource(Color color)
    {
      int index;
      ColorSource result;

      index = _colors.IndexOf(color);

      if (index != InvalidIndex)
      {
        result = ColorSource.Standard;
      }
      else
      {
        index = _customColors.IndexOf(color);
        result = index != InvalidIndex
          ? ColorSource.Custom
          : ColorSource.None;
      }

      return result;
    }

    public override Size GetPreferredSize(Size proposedSize)
    {
      return base.AutoSize
        ? this.GetAutoSize()
        : base.GetPreferredSize(proposedSize);
    }

    public ColorHitTestInfo HitTest(Point point)
    {
      ColorHitTestInfo result;
      int colorIndex;

      result = new ColorHitTestInfo();
      colorIndex = InvalidIndex;

      foreach (KeyValuePair<int, Rectangle> pair in _colorRegions.Where(pair => pair.Value.Contains(point)))
      {
        colorIndex = pair.Key;
        break;
      }

      result.Index = colorIndex;
      if (colorIndex != InvalidIndex)
      {
        result.Color = colorIndex < _colors.Count + _customColors.Count
          ? this.GetColor(colorIndex)
          : Color.White;
        result.Source = this.GetColorSource(colorIndex);
      }
      else
      {
        result.Source = ColorSource.None;
      }

      return result;
    }

    public void Invalidate(int index)
    {
      if (this.AllowPainting && index != InvalidIndex)
      {
        Rectangle bounds;

        if (_colorRegions.TryGetValue(index, out bounds))
        {
          if (_selectedCellStyle == ColorGridSelectedCellStyle.Zoomed)
          {
            bounds.Inflate(this.Padding.Left, this.Padding.Top);
          }

          this.Invalidate(bounds);
        }
      }
    }

    public void Navigate(int offsetX, int offsetY)
    {
      this.Navigate(offsetX, offsetY, NavigationOrigin.Current);
    }

    public virtual void Navigate(int offsetX, int offsetY, NavigationOrigin origin)
    {
      Point cellLocation;
      Point offsetCellLocation;
      int row;
      int column;
      int index;

      switch (origin)
      {
        case NavigationOrigin.Begin:
          cellLocation = Point.Empty;
          break;

        case NavigationOrigin.End:
          cellLocation = new Point(_actualColumns - 1, _primaryRows + _customRows - 1);
          break;

        default:
          cellLocation = this.CurrentCell;
          break;
      }

      if (cellLocation.X == -1 && cellLocation.Y == -1)
      {
        cellLocation = Point.Empty; // If no cell is selected, assume the first one is for the purpose of keyboard navigation
      }

      offsetCellLocation = this.GetCellOffset(cellLocation, offsetX, offsetY);
      row = offsetCellLocation.Y;
      column = offsetCellLocation.X;
      index = this.GetCellIndex(column, row);
      if (index != InvalidIndex)
      {
        this.ColorIndex = index;
      }
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual void CalculateCellSize()
    {
      int w;
      int h;

      w = (this.ClientSize.Width - this.Padding.Horizontal) / _actualColumns - _spacing.Width;
      h = (this.ClientSize.Height - this.Padding.Vertical) / (_primaryRows + _customRows) - _spacing.Height;

      if (w > 0 && h > 0)
      {
        this.CellSize = new Size(w, h);
      }
    }

    protected virtual void CalculateGridSize()
    {
      int primaryRows;
      int customRows;

      _actualColumns = _columns != 0
        ? _columns
        : (this.ClientSize.Width + _spacing.Width - this.Padding.Vertical) / (_scaledCellSize.Width + _spacing.Width);
      if (_actualColumns < 1)
      {
        _actualColumns = 1;
      }

      primaryRows = this.GetRows(_colors != null
        ? _colors.Count
        : 0);
      if (primaryRows == 0)
      {
        primaryRows = 1;
      }

      customRows = _showCustomColors
        ? this.GetRows(_customColors != null
                            ? _customColors.Count
                            : 0)
        : 0;

      _primaryRows = primaryRows;
      _customRows = customRows;
    }

    protected virtual Brush CreateTransparencyBrush()
    {
      return new TextureBrush(ResourceManager.CellBackground, WrapMode.Tile);
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
          for (int column = 0; column < _actualColumns; column++)
          {
            if (index < colors.Count)
            {
              _colorRegions.Add(rangeStart + index, new Rectangle(this.Padding.Left + column * (_scaledCellSize.Width + _spacing.Width), offset + row * (_scaledCellSize.Height + _spacing.Height), _scaledCellSize.Width, _scaledCellSize.Height));
            }

            index++;
          }
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.RemoveEventHandlers(_colors);
        this.RemoveEventHandlers(_customColors);

        _toolTip?.Dispose();

        _cellBackgroundBrush?.Dispose();
      }

      base.Dispose(disposing);
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
      int width;

      offset = _customRows != 0
        ? _separatorHeight
        : 0;

      if (_columns != 0)
      {
        width = (_scaledCellSize.Width + _spacing.Width) * _actualColumns + this.Padding.Horizontal - _spacing.Width;
      }
      else
      {
        width = this.ClientSize.Width;
      }

      return new Size(width, (_scaledCellSize.Height + _spacing.Height) * (_primaryRows + _customRows) + offset + this.Padding.Vertical - _spacing.Height);
    }

    protected int GetCellIndex(Point point)
    {
      return this.GetCellIndex(point.X, point.Y);
    }

    protected virtual int GetCellIndex(int column, int row)
    {
      int result;

      if (column >= 0 && column < _actualColumns && row >= 0 && row < _primaryRows + _customRows)
      {
        int lastStandardRowOffset;

        lastStandardRowOffset = _primaryRows * _actualColumns - _colors.Count;
        result = row * _actualColumns + column;
        if (row == _primaryRows - 1 && column >= _actualColumns - lastStandardRowOffset)
        {
          result -= lastStandardRowOffset;
        }
        if (row >= _primaryRows)
        {
          result -= lastStandardRowOffset;
        }

        if (result > _colors.Count + _customColors.Count - 1)
        {
          result = InvalidIndex;
        }
      }
      else
      {
        result = InvalidIndex;
      }

      return result;
    }

    protected Point GetCellOffset(int columnOffset, int rowOffset)
    {
      return this.GetCellOffset(this.CurrentCell, columnOffset, rowOffset);
    }

    protected Point GetCellOffset(Point cell, int columnOffset, int rowOffset)
    {
      int row;
      int column;
      int lastStandardRowOffset;
      int lastStandardRowLastColumn;

      lastStandardRowOffset = _primaryRows * _actualColumns - _colors.Count;
      lastStandardRowLastColumn = _actualColumns - lastStandardRowOffset;
      column = cell.X + columnOffset;
      row = cell.Y + rowOffset;

      // if the row is the last row, but there aren't enough columns to fill the row - nudge it to the last available
      if (row == _primaryRows - 1 && column >= lastStandardRowLastColumn)
      {
        column = lastStandardRowLastColumn - 1;
      }

      // wrap the column to the end of the previous row
      if (column < 0)
      {
        column = _actualColumns - 1;
        row--;
        if (row == _primaryRows - 1)
        {
          column = _actualColumns - (lastStandardRowOffset + 1);
        }
      }

      // wrap to column to the start of the next row
      if (row == _primaryRows - 1 && column >= _actualColumns - lastStandardRowOffset || column >= _actualColumns)
      {
        column = 0;
        row++;
      }

      return new Point(column, row);
    }

    protected virtual int GetColorIndex(Color value)
    {
      int index;

      index = _colors != null
        ? _colors.IndexOf(value)
        : InvalidIndex;

      if (index == InvalidIndex && _showCustomColors && _customColors != null)
      {
        index = _customColors.IndexOf(value);
        if (index != InvalidIndex)
        {
          index += _colors.Count;
        }
      }

      return index;
    }

    protected virtual ColorCollection GetPredefinedPalette()
    {
      return ColorPalettes.GetPalette(_palette);
    }

    protected int GetRows(int count)
    {
      int rows;

      if (count != 0 && _actualColumns > 0)
      {
        rows = count / _actualColumns;
        if (count % _actualColumns != 0)
        {
          rows++;
        }
      }
      else
      {
        rows = 0;
      }

      return rows;
    }

    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if (keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Enter || keyData == Keys.Home || keyData == Keys.End)
      {
        result = true;
      }
      else
      {
        result = base.IsInputKey(keyData);
      }

      return result;
    }

    /// <summary>
    /// Raises the <see cref="AutoAddColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAutoAddColorsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventAutoAddColorsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="AutoFitChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAutoFitChanged(EventArgs e)
    {
      EventHandler handler;

      if (_autoFit && base.AutoSize)
      {
        base.AutoSize = false;
      }

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventAutoFitChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnAutoSizeChanged(EventArgs e)
    {
      if (base.AutoSize && _autoFit)
      {
        this.AutoFit = false;
      }

      base.OnAutoSizeChanged(e);

      if (base.AutoSize)
      {
        this.SizeToFit();
      }
    }

    /// <summary>
    /// Raises the <see cref="CellBorderColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellBorderColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventCellBorderColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellBorderStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellBorderStyleChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventCellBorderStyleChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellContextMenuStripChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellContextMenuStripChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventCellContextMenuStripChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CellSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellSizeChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetScaledCellSize();

      if (base.AutoSize)
      {
        this.SizeToFit();
      }

      if (this.AllowPainting)
      {
        this.RefreshColors();
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventCellSizeChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorIndexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorIndexChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate(_previousColorIndex);
        this.Invalidate(_colorIndex);
      }

      handler = (EventHandler)this.Events[_eventColorIndexChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.AddEventHandlers(_colors);

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventColorsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColumnsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColumnsChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventColumnsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.AddEventHandlers(_customColors);
      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventCustomColorsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="EditingColor" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EditColorCancelEventArgs" /> instance containing the event data.</param>
    protected virtual void OnEditingColor(EditColorCancelEventArgs e)
    {
      EventHandler<EditColorCancelEventArgs> handler;

      handler = (EventHandler<EditColorCancelEventArgs>)this.Events[_eventEditingColor];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="EditModeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnEditModeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventEditModeChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);

      if (this.AllowPainting)
      {
        this.Invalidate(_colorIndex);
      }
    }

    /// <summary>
    /// Raises the <see cref="HotIndexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnHotIndexChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetToolTip();

      if (this.AllowPainting)
      {
        this.Invalidate(_previousHotIndex);
        this.Invalidate(_hotIndex);
      }

      handler = (EventHandler)this.Events[_eventHotIndexChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      _wasKeyPressed = true;

      switch (e.KeyData)
      {
        case Keys.Down:
          this.Navigate(0, 1);
          e.Handled = true;
          break;

        case Keys.Up:
          this.Navigate(0, -1);
          e.Handled = true;
          break;

        case Keys.Left:
          this.Navigate(-1, 0);
          e.Handled = true;
          break;

        case Keys.Right:
          this.Navigate(1, 0);
          e.Handled = true;
          break;

        case Keys.Home:
          this.Navigate(0, 0, NavigationOrigin.Begin);
          e.Handled = true;
          break;

        case Keys.End:
          this.Navigate(0, 0, NavigationOrigin.End);
          e.Handled = true;
          break;
      }

      base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
      if (_wasKeyPressed && _colorIndex != InvalidIndex)
      {
        switch (e.KeyData)
        {
          case Keys.Enter:
            ColorSource source;

            source = this.GetColorSource(_colorIndex);

            if (source == ColorSource.Custom && _editMode != ColorEditingMode.None || source == ColorSource.Standard && _editMode == ColorEditingMode.Both)
            {
              e.Handled = true;

              this.StartColorEdit(_colorIndex);
            }
            break;

          case Keys.Apps:
          case Keys.F10 | Keys.Shift:
            int x;
            int y;
            Point location;

            location = _colorRegions[_colorIndex].Location;
            x = location.X;
            y = location.Y + _cellSize.Height;

            this.ShowContextMenu(new Point(x, y));
            break;
        }
      }

      _wasKeyPressed = false;

      base.OnKeyUp(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);

      if (this.AllowPainting)
      {
        this.Invalidate(_colorIndex);
      }
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      ColorHitTestInfo hitTest;

      base.OnMouseDoubleClick(e);

      hitTest = this.HitTest(e.Location);

      if (e.Button == MouseButtons.Left && (hitTest.Source == ColorSource.Custom && _editMode != ColorEditingMode.None || hitTest.Source == ColorSource.Standard && _editMode == ColorEditingMode.Both))
      {
        this.StartColorEdit(hitTest.Index);
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (!this.Focused && this.TabStop)
      {
        this.Focus();
      }

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

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      if (e.Button == MouseButtons.Right)
      {
        int index;

        index = this.HitTest(e.Location).Index;

        if (index != InvalidIndex)
        {
          this.Focus();
          this.ColorIndex = index;

          this.ShowContextMenu(e.Location);
        }
      }
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      if (this.AllowPainting)
      {
        this.RefreshColors();
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.AllowPainting)
      {
        int colorCount;

        colorCount = _colors.Count;

        this.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc as the PaintBackground event is no longer being called

        // draw a design time dotted grid
        if (this.DesignMode)
        {
          using (Pen pen = new Pen(SystemColors.ButtonShadow)
          {
            DashStyle = DashStyle.Dot
          })
          {
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
          }
        }

        // draw cells for all current colors
        for (int i = 0; i < colorCount; i++)
        {
          Rectangle bounds;

          bounds = _colorRegions[i];
          if (e.ClipRectangle.IntersectsWith(bounds))
          {
            this.PaintCell(e, i, i, _colors[i], bounds);
          }
        }

        if (_customColors.Count != 0 && _showCustomColors)
        {
          // draw a separator
          this.PaintSeparator(e);

          // and the custom colors
          for (int i = 0; i < _customColors.Count; i++)
          {
            Rectangle bounds;

            if (_colorRegions.TryGetValue(colorCount + i, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
            {
              this.PaintCell(e, i, colorCount + i, _customColors[i], bounds);
            }
          }
        }

        // draw the selected color
        if (_selectedCellStyle != ColorGridSelectedCellStyle.None && _colorIndex >= 0)
        {
          Rectangle bounds;

          if (_colorRegions.TryGetValue(_colorIndex, out bounds) && e.ClipRectangle.IntersectsWith(bounds))
          {
            this.PaintSelectedCell(e, _colorIndex, this.Color, bounds);
          }
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="PaletteChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPaletteChanged(EventArgs e)
    {
      EventHandler handler;

      this.Colors = this.GetPredefinedPalette();

      handler = (EventHandler)this.Events[_eventPaletteChanged];

      handler?.Invoke(this, e);
    }

    protected override void OnResize(EventArgs e)
    {
      this.RefreshColors();

      base.OnResize(e);
    }

    /// <summary>
    /// Raises the <see cref="SelectedCellStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectedCellStyleChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.AllowPainting)
      {
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventSelectedCellStyleChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowCustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshColors();

      handler = (EventHandler)this.Events[_eventShowCustomColorsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowToolTipsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowToolTipsChanged(EventArgs e)
    {
      EventHandler handler;

      if (_showToolTips)
      {
        _toolTip = new ToolTip();
      }
      else if (_toolTip != null)
      {
        _toolTip.Dispose();
        _toolTip = null;
      }

      handler = (EventHandler)this.Events[_eventShowToolTipsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SpacingChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSpacingChanged(EventArgs e)
    {
      EventHandler handler;

      if (base.AutoSize)
      {
        this.SizeToFit();
      }

      if (this.AllowPainting)
      {
        this.RefreshColors();
        this.Invalidate();
      }

      handler = (EventHandler)this.Events[_eventSpacingChanged];

      handler?.Invoke(this, e);
    }

    protected virtual void PaintCell(PaintEventArgs e, int colorIndex, int cellIndex, Color color, Rectangle bounds)
    {
      if (color.A != 255)
      {
        this.PaintTransparentCell(e, bounds);
      }

      using (Brush brush = new SolidBrush(color))
      {
        e.Graphics.FillRectangle(brush, bounds);
      }

      switch (_cellBorderStyle)
      {
        case ColorCellBorderStyle.FixedSingle:
          using (Pen pen = new Pen(_cellBorderColor))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          break;

        case ColorCellBorderStyle.DoubleSoft:
          HslColor shadedOuter;
          HslColor shadedInner;

          shadedOuter = new HslColor(color);
          shadedOuter.L -= 0.50;

          shadedInner = new HslColor(color);
          shadedInner.L -= 0.20;

          using (Pen pen = new Pen(_cellBorderColor))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
          using (Pen pen = new Pen(Color.FromArgb(32, shadedOuter.ToRgbColor())))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, bounds.Width - 5, bounds.Height - 5);
          }
          using (Pen pen = new Pen(Color.FromArgb(32, shadedInner.ToRgbColor())))
          {
            e.Graphics.DrawRectangle(pen, bounds.Left + 3, bounds.Top + 3, bounds.Width - 7, bounds.Height - 7);
          }
          break;
      }

      if (_hotIndex != InvalidIndex && _hotIndex == cellIndex)
      {
        e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
        e.Graphics.DrawRectangle(Pens.White, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3);
      }
    }

    protected virtual void PaintSelectedCell(PaintEventArgs e, int colorIndex, Color color, Rectangle bounds)
    {
      switch (_selectedCellStyle)
      {
        case ColorGridSelectedCellStyle.Standard:
          if (this.Focused)
          {
            ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
          }
          else
          {
            e.Graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
          }
          break;

        case ColorGridSelectedCellStyle.Zoomed:
          // make the cell larger according to the padding
          bounds.Inflate(this.Padding.Left, this.Padding.Top);

          // fill the inner
          e.Graphics.FillRectangle(Brushes.White, bounds);
          bounds.Inflate(-3, -3);

          if (color.A != 255)
          {
            this.PaintTransparentCell(e, bounds);
          }

          using (Brush brush = new SolidBrush(color))
          {
            e.Graphics.FillRectangle(brush, bounds);
          }

          // draw a border
          if (this.Focused)
          {
            bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            ControlPaint.DrawFocusRectangle(e.Graphics, bounds);
          }
          else
          {
            bounds = new Rectangle(bounds.Left - 2, bounds.Top - 2, bounds.Width + 3, bounds.Height + 3);

            using (Pen pen = new Pen(_cellBorderColor))
            {
              e.Graphics.DrawRectangle(pen, bounds);
            }
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
      y1 = _separatorHeight / 2 + this.Padding.Top + _primaryRows * (_scaledCellSize.Height + _spacing.Height) + 1 - _spacing.Height;
      y2 = y1;

      using (Pen pen = new Pen(_cellBorderColor))
      {
        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
      }
    }

    protected virtual void PaintTransparentCell(PaintEventArgs e, Rectangle bounds)
    {
      if (_cellBackgroundBrush == null)
      {
        _cellBackgroundBrush = this.CreateTransparencyBrush();
      }

      e.Graphics.FillRectangle(_cellBackgroundBrush, bounds);
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
        }
      }
    }

    protected virtual void RefreshColors()
    {
      if (this.AllowPainting)
      {
        this.CalculateGridSize();

        if (_autoFit)
        {
          this.CalculateCellSize();
        }
        else if (base.AutoSize)
        {
          this.SizeToFit();
        }

        _colorRegions.Clear();

        if (_colors != null)
        {
          this.DefineColorRegions(_colors, 0, this.Padding.Top);
          if (_showCustomColors)
          {
            this.DefineColorRegions(_customColors, _colors.Count, this.Padding.Top + _separatorHeight + (_scaledCellSize.Height + _spacing.Height) * _primaryRows);
          }

          this.ColorIndex = this.GetColorIndex(this.Color);

          if (!this.Color.IsEmpty && _colorIndex == InvalidIndex && _autoAddColors && _showCustomColors)
          {
            this.AddCustomColor(this.Color);
          }

          this.Invalidate();
        }
      }
      else
      {
        _layoutRequired = true;
      }
    }

    protected virtual void SetColor(int colorIndex, Color color)
    {
      int colorCount;

      colorCount = _colors.Count;

      if (colorIndex < 0 || colorIndex > colorCount + _customColors.Count)
      {
        throw new ArgumentOutOfRangeException(nameof(colorIndex));
      }

      if (colorIndex > colorCount - 1)
      {
        _customColors[colorIndex - colorCount] = color;
      }
      else
      {
        _colors[colorIndex] = color;
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddEventHandlers(ColorCollection value)
    {
      if (value != null)
      {
        value.ItemInserted += this.ColorsCollectionChangedHandler;
        value.ItemRemoved += this.ColorsCollectionChangedHandler;
        value.ItemsCleared += this.ColorsCollectionChangedHandler;
        value.ItemReplaced += this.ColorsCollectionItemReplacedHandler;
      }
    }

    private void ColorsCollectionChangedHandler(object sender, ColorCollectionEventArgs e)
    {
      this.RefreshColors();
    }

    private void ColorsCollectionItemReplacedHandler(object sender, ColorCollectionEventArgs e)
    {
      ColorCollection collection;
      int index;

      collection = (ColorCollection)sender;
      index = _colorIndex;
      if (index != InvalidIndex && ReferenceEquals(collection, _customColors))
      {
        index -= _colors.Count;
      }

      if (index >= 0 && index < collection.Count && collection[index] != this.Color)
      {
        _previousColorIndex = index;
        _colorIndex = -1;
        this.ColorIndex = index;
      }

      this.Invalidate(e.Index);
    }

    private Point GetCell(int index)
    {
      int row;
      int column;

      if (index == InvalidIndex)
      {
        row = -1;
        column = -1;
      }
      else if (index >= _colors.Count)
      {
        // custom color
        index -= _colors.Count;
        row = index / _actualColumns;
        column = index - row * _actualColumns;
        row += _primaryRows;
      }
      else
      {
        // normal row
        row = index / _actualColumns;
        column = index - row * _actualColumns;
      }

      return new Point(column, row);
    }

    private void RemoveEventHandlers(ColorCollection value)
    {
      if (value != null)
      {
        value.ItemInserted -= this.ColorsCollectionChangedHandler;
        value.ItemRemoved -= this.ColorsCollectionChangedHandler;
        value.ItemsCleared -= this.ColorsCollectionChangedHandler;
        value.ItemReplaced -= this.ColorsCollectionItemReplacedHandler;
      }
    }

    private void SetScaledCellSize()
    {
      Point dpi;
      float scaleX;
      float scaleY;

      dpi = NativeMethods.GetDesktopDpi();
      scaleX = dpi.X / 96F;
      scaleY = dpi.Y / 96F;

      if (scaleX > 1 && scaleY > 1)
      {
        _scaledCellSize = new Size((int)(_cellSize.Width * scaleX), (int)(_cellSize.Height * scaleY));
      }
      else
      {
        _scaledCellSize = _cellSize;
      }
    }

    private void SetToolTip()
    {
      if (_showToolTips)
      {
        _toolTip.SetToolTip(this, _hotIndex != InvalidIndex
          ? this.GetColor(_hotIndex).Name
          : null);
      }
    }

    private void ShowContextMenu(Point location)
    {
      _cellContextMenuStrip?.Show(this, location);
    }

    private void SizeToFit()
    {
      this.Size = this.GetAutoSize();
    }

    private void StartColorEdit(int index)
    {
      EditColorCancelEventArgs e;

      e = new EditColorCancelEventArgs(this.GetColor(index), index);
      this.OnEditingColor(e);

      if (!e.Cancel)
      {
        this.EditColor(index);
      }
    }

    #endregion Private Methods
  }
}
