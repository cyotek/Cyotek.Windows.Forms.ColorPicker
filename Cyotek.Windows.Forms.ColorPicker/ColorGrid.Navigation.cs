// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  partial class ColorGrid
  {
    #region Private Properties

    private int CustomRowOffset => _customRows * _actualColumns - _customColors.Count;

    private int PrimaryRowOffset => _primaryRows * _actualColumns - _colors.Count;

    #endregion Private Properties

    #region Public Methods

    public void EnsureVisible(int index)
    {
      if (_rows > _visibleRows)
      {
        this.ValidateIndex(index, false);

        this.GetCellCoordinates(index, out int r, out int _);

        if (r < _scrollBar.Value)
        {
          _scrollBar.Value = r;
        }
        else
        {
          while (r >= _scrollBar.Value + _scrollBar.LargeChange)
          {
            this.ScrollControl(1);
          }
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
          cellLocation = new Point(_actualColumns - 1, _rows - 1);
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

      if (index == ColorGrid.InvalidIndex && origin != NavigationOrigin.Current)
      {
        // wrap to the start or the end
        index = origin == NavigationOrigin.Begin
          ? 0
          : this.ItemCount - 1;
      }

      if (this.IsValidIndex(index))
      {
        this.ColorIndex = index;
        this.EnsureVisible(index);
      }
    }

    public void Navigate(ColorGridNavigationMode mode)
    {
      //NavigationOption option;
      int index;

      //option = this.GetNavigationOption(false);
      index = this.GetNavigationDestination(mode);

      if (this.IsValidIndex(index))
      {
        this.ColorIndex = index;
      }
      //this.SetFocused(index);
      //this.UpdateSelection(index, option);
    }

    #endregion Public Methods

    #region Protected Methods

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

      lastStandardRowOffset = this.PrimaryRowOffset;
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

    /// <summary> Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel" /> event. </summary>
    /// <param name="e"> A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the
    ///  event data. </param>
    /// <seealso cref="System.Windows.Forms.Control.OnMouseWheel(MouseEventArgs)"/>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);

      if (_fullyVisibleRows > 0)
      {
        this.ScrollControl(WheelHelper.WheelScrollLines(this.Handle, e.Delta, _fullyVisibleRows, true));
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private int AdjustNavigationIncrement(int increment)
    {
      this.GetCellCoordinates(_colorIndex, out int r, out int c);

      if (increment == _actualColumns)
      {
        if (r == _primaryRows - 1)
        {
          // the current row is the end of the
          // primary colours and may be partial
          increment -= this.PrimaryRowOffset;
        }
        else if (r + 1 == _primaryRows - 1 && c >= _actualColumns - this.PrimaryRowOffset)
        {
          // the next row is partial AND the current
          // column is beyond the length of the new row
          increment -= this.PrimaryRowOffset;
        }
        else if (r == _primaryRows + _customRows - 1)
        {
          // the current row is the end of the
          // custom colours and may be partial
          increment -= this.CustomRowOffset;
        }
        else if (r + 1 == _primaryRows + _customRows - 1 && c >= _actualColumns - this.CustomRowOffset)
        {
          // the next row is partial AND the current
          // column is beyond the length of the new row
          increment -= this.CustomRowOffset;
        }
      }
      else if (increment == -_actualColumns && r - 1 == _primaryRows - 1 && c < _actualColumns - this.PrimaryRowOffset)
      {
        // the previous row is partial AND the current
        // column is within the length of the new row
        increment += this.PrimaryRowOffset;
      }

      return increment;
    }

    private int GetNavigationDestination(ColorGridNavigationMode mode)
    {
      int index;

      switch (mode)
      {
        case ColorGridNavigationMode.Previous:
          index = this.GetNavigationDestination(-1, true);
          break;

        case ColorGridNavigationMode.Next:
          index = this.GetNavigationDestination(1, true);
          break;

        case ColorGridNavigationMode.PreviousRow:
          index = this.GetNavigationDestination(-_actualColumns, true);
          break;

        case ColorGridNavigationMode.NextRow:
          index = this.GetNavigationDestination(_actualColumns, true);
          break;

        case ColorGridNavigationMode.PreviousPage:
          index = this.GetNavigationDestination(-(_fullyVisibleRows * _actualColumns), false);
          break;

        case ColorGridNavigationMode.NextPage:
          index = this.GetNavigationDestination(_fullyVisibleRows * _actualColumns, false);
          break;

        case ColorGridNavigationMode.Start:
          index = this.GetNavigationDestination(-this.ItemCount, false);
          break;

        case ColorGridNavigationMode.End:
          index = this.GetNavigationDestination(this.ItemCount, false);
          break;

        default:
          index = ColorGrid.InvalidIndex;
          break;
      }

      return index;
    }

    private int GetNavigationDestination(int increment, bool keepToGrid)
    {
      int newIndex;

      increment = this.AdjustNavigationIncrement(increment);
      newIndex = _colorIndex + increment;

      if (!keepToGrid)
      {
        if (newIndex < 0)
        {
          newIndex = 0;
        }
        else if (newIndex >= this.ItemCount)
        {
          newIndex = this.ItemCount - 1;
        }
      }

      return newIndex;
    }

    private bool IsNavigationKey(Keys keyData)
    {
      return keyData == Keys.Left
             || keyData == Keys.Right
             || keyData == Keys.Up
             || keyData == Keys.Down
             || keyData == Keys.Home
             || keyData == Keys.End
             || keyData == Keys.PageUp
             || keyData == Keys.PageDown
        ;
    }

    /// <summary> Handler, called when the scrollbar value changed. </summary>
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e">  Event information. </param>
    private void ScrollbarValueChangedHandler(object sender, EventArgs e)
    {
      this.TopItem = _scrollBar.Value * _actualColumns;
    }

    /// <summary> Scrolls the list by the specified number of lines. </summary>
    /// <param name="lines">  The number lines to scroll by. </param>
    private void ScrollControl(int lines)
    {
      int value;

      try
      {
        value = checked(_scrollBar.Value + lines);
      }
      catch (OverflowException)
      {
        value = lines < 0
          ? 0
          : this.ItemCount;
      }

      this.SetScrollValue(value);
    }

    /// <summary> Sets the scrollbar value. </summary>
    /// <param name="value">  The value to apply. </param>
    private void SetScrollValue(int value)
    {
      value = Math.Min(value, _scrollBar.Maximum - (_scrollBar.LargeChange - 1));

      if (value < 0)
      {
        value = 0;
      }

      _scrollBar.Value = value;
    }

    private void Update(KeyEventArgs e)
    {
      if (_colorIndex == ColorGrid.InvalidIndex && this.IsNavigationKey(e.KeyData))
      {
        _colorIndex = 0;
        e.Handled = true;
      }
      else
      {
        e.Handled = true;

        switch (e.KeyCode)
        {
          case Keys.Left:
            this.Navigate(ColorGridNavigationMode.Previous);
            break;

          case Keys.Right:
            this.Navigate(ColorGridNavigationMode.Next);
            break;

          case Keys.Up:
            this.Navigate(ColorGridNavigationMode.PreviousRow);
            break;

          case Keys.Down:
            this.Navigate(ColorGridNavigationMode.NextRow);
            break;

          case Keys.PageUp:
            this.Navigate(ColorGridNavigationMode.PreviousPage);
            break;

          case Keys.PageDown:
            this.Navigate(ColorGridNavigationMode.NextPage);
            break;

          case Keys.Home:
            this.Navigate(ColorGridNavigationMode.Start);
            break;

          case Keys.End:
            this.Navigate(ColorGridNavigationMode.End);
            break;

          default:
            e.Handled = false;
            break;
        }
      }
    }

    #endregion Private Methods
  }
}
