// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;
using System.Text;

namespace Cyotek.Windows.Forms
{
  // http://en.wikipedia.org/wiki/HSL_color_space

  [Serializable]
  public struct HslColor
  {
    #region Public Fields

    public static readonly HslColor Empty;

    #endregion Public Fields

    #region Private Fields

    private int _alpha;

    private double _hue;

    private bool _isEmpty;

    private double _lightness;

    private double _saturation;

    #endregion Private Fields

    #region Public Constructors

    static HslColor()
    {
      Empty = new HslColor
      {
        IsEmpty = true
      };
    }

    public HslColor(double hue, double saturation, double lightness)
      : this(255, hue, saturation, lightness)
    { }

    public HslColor(int alpha, double hue, double saturation, double lightness)
    {
      _hue = Math.Min(359, hue);
      _saturation = Math.Min(1, saturation);
      _lightness = Math.Min(1, lightness);
      _alpha = alpha;
      _isEmpty = false;
    }

    public HslColor(Color color)
    {
      _alpha = color.A;
      _hue = color.GetHue();
      _saturation = color.GetSaturation();
      _lightness = color.GetBrightness();
      _isEmpty = false;
    }

    #endregion Public Constructors

    #region Public Properties

    public int A
    {
      get { return _alpha; }
      set { _alpha = Math.Min(0, Math.Max(255, value)); }
    }

    public double H
    {
      get { return _hue; }
      set
      {
        _hue = value;

        if (_hue > 359)
        {
          _hue = 0;
        }
        if (_hue < 0)
        {
          _hue = 359;
        }
      }
    }

    public bool IsEmpty
    {
      get { return _isEmpty; }
      internal set { _isEmpty = value; }
    }

    public double L
    {
      get { return _lightness; }
      set { _lightness = Math.Min(1, Math.Max(0, value)); }
    }

    public double S
    {
      get { return _saturation; }
      set { _saturation = Math.Min(1, Math.Max(0, value)); }
    }

    #endregion Public Properties

    #region Public Methods

    public static implicit operator Color(HslColor color)
    {
      return color.ToRgbColor();
    }

    public static implicit operator HslColor(Color color)
    {
      return new HslColor(color);
    }

    public static bool operator !=(HslColor a, HslColor b)
    {
      return !(a == b);
    }

    public static bool operator ==(HslColor a, HslColor b)
    {
      // ReSharper disable CompareOfFloatsByEqualityOperator
      return a.H == b.H && a.L == b.L && a.S == b.S && a.A == b.A;
      // ReSharper restore CompareOfFloatsByEqualityOperator
    }

    public override bool Equals(object obj)
    {
      bool result;

      if (obj is HslColor)
      {
        HslColor color;

        color = (HslColor)obj;
        result = this == color;
      }
      else
      {
        result = false;
      }

      return result;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public Color ToRgbColor()
    {
      return this.ToRgbColor(this.A);
    }

    public Color ToRgbColor(int alpha)
    {
      byte r;
      byte g;
      byte b;

      // https://www.programmingalgorithms.com/algorithm/hsl-to-rgb

      if (Math.Abs(_saturation) < double.Epsilon)
      {
        r = g = b = Convert.ToByte(_lightness * 255F);
      }
      else
      {
        double v1;
        double v2;
        double hue;

        hue = _hue / 360;

        v2 = _lightness < 0.5
          ? _lightness * (1 + _saturation)
          : _lightness + _saturation - _lightness * _saturation;
        v1 = 2 * _lightness - v2;

        r = HslColor.Clamp(255 * HslColor.HueToRgb(v1, v2, hue + 1.0f / 3));
        g = HslColor.Clamp(255 * HslColor.HueToRgb(v1, v2, hue));
        b = HslColor.Clamp(255 * HslColor.HueToRgb(v1, v2, hue - 1.0f / 3));
      }

      return Color.FromArgb(alpha, r, g, b);
    }

    public override string ToString()
    {
      StringBuilder builder;

      builder = new StringBuilder();
      builder.Append(this.GetType().Name);
      builder.Append(" [");
      builder.Append("H=");
      builder.Append(this.H);
      builder.Append(", S=");
      builder.Append(this.S);
      builder.Append(", L=");
      builder.Append(this.L);
      builder.Append("]");

      return builder.ToString();
    }

    #endregion Public Methods

    #region Private Methods

    private static byte Clamp(double v)
    {
      if (v < 0)
      {
        v = 0;
      }

      if (v > 255)
      {
        v = 255;
      }

      return (byte)v;
    }

    private static double HueToRgb(double v1, double v2, double vH)
    {
      double result;

      if (vH < 0)
      {
        vH++;
      }

      if (vH > 1)
      {
        vH--;
      }

      if (6 * vH < 1)
      {
        result = v1 + (v2 - v1) * 6 * vH;
      }
      else if (2 * vH < 1)
      {
        result = v2;
      }
      else if (3 * vH < 2)
      {
        result = v1 + (v2 - v1) * (2.0f / 3 - vH) * 6;
      }
      else
      {
        result = v1;
      }

      return result;
    }

    #endregion Private Methods
  }
}
