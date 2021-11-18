// Cyotek Color Picker controls library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.Drawing;

namespace Cyotek.Windows.Forms
{
  internal static class ResourceManager
  {
    #region Public Methods

    /// <summary>
    ///   Creates a bitmap image containing a 2x2 grid using the specified cell size and colors.
    /// </summary>
    /// <param name="cellSize">Size of the cell.</param>
    /// <param name="cellColor">Cell color.</param>
    /// <param name="alternateCellColor">Alternate cell color.</param>
    /// <returns></returns>
    public static Bitmap CreateCheckerBoxTile(int cellSize, Color cellColor, Color alternateCellColor)
    {
      Bitmap result;
      int width;
      int height;

      // draw the tile
      width = cellSize * 2;
      height = cellSize * 2;
      result = new Bitmap(width, height);

      using (Graphics g = Graphics.FromImage(result))
      {
        using (Brush brush = new SolidBrush(cellColor))
        {
          g.FillRectangle(brush, new Rectangle(cellSize, 0, cellSize, cellSize));
          g.FillRectangle(brush, new Rectangle(0, cellSize, cellSize, cellSize));
        }

        using (Brush brush = new SolidBrush(alternateCellColor))
        {
          g.FillRectangle(brush, new Rectangle(0, 0, cellSize, cellSize));
          g.FillRectangle(brush, new Rectangle(cellSize, cellSize, cellSize, cellSize));
        }
      }

      return result;
    }

    #endregion Public Methods
  }
}
;
