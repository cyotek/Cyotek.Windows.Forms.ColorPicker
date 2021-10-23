// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.Drawing;

namespace Cyotek.Windows.Forms
{
  public class ColorHitTestInfo
  {
    #region Private Fields

    private Color _color;

    private int _index;

    private ColorSource _source;

    #endregion Private Fields

    #region Public Constructors

    public ColorHitTestInfo()
    {
      _color = Color.Empty;
      _index = ColorGrid.InvalidIndex;
      _source = ColorSource.None;
    }

    #endregion Public Constructors

    #region Public Properties

    public Color Color
    {
      get => _color;
      set => _color = value;
    }

    public int Index
    {
      get => _index;
      set => _index = value;
    }

    public ColorSource Source
    {
      get => _source;
      set => _source = value;
    }

    #endregion Public Properties
  }
}
