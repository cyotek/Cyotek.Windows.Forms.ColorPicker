// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2021 Cyotek Ltd.

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
  [ToolboxItem(false)]
  internal sealed class ColorComboBox : ComboBox
  {
    #region Public Constructors

    public ColorComboBox()
    {
      base.DrawMode = DrawMode.OwnerDrawFixed;
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DrawMode DrawMode
    {
      get => base.DrawMode;
      set => base.DrawMode = value;
    }

    #endregion Public Properties

    #region Internal Methods

    internal void FillNamedColors()
    {
      this.BeginUpdate();
      this.Items.Clear();
      this.AddColorProperties(typeof(SystemColors));
      this.AddColorProperties(typeof(Color));
      this.SetDropDownWidth();
      this.EndUpdate();
    }

    #endregion Internal Methods

    #region Protected Methods

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
      if (e.Index != -1)
      {
        Rectangle colorBox;
        string name;
        Color color;

        e.DrawBackground();

        name = (string)this.Items[e.Index];
        color = Color.FromName(name);
        colorBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

        using (Brush brush = new SolidBrush(color))
        {
          e.Graphics.FillRectangle(brush, colorBox);
        }
        e.Graphics.DrawRectangle(SystemPens.ControlText, colorBox);

        TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colorBox.Right + 3, colorBox.Top), e.ForeColor);

        e.DrawFocusRectangle();
      }

      base.OnDrawItem(e);
    }

    protected override void OnDropDown(EventArgs e)
    {
      if (this.Items.Count == 0)
      {
        this.FillNamedColors();
      }

      base.OnDropDown(e);
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.SetDropDownWidth();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (ColorComboBox.IsNavigationKey(e.KeyCode) && this.Items.Count == 0)
      {
        this.FillNamedColors();
      }

      base.OnKeyDown(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private static bool IsNavigationKey(Keys keys)
    {
      return keys == Keys.Up || keys == Keys.Down || keys == Keys.PageUp || keys == Keys.PageDown;
    }

    private void AddColorProperties(Type type)
    {
      Type colorType;
      PropertyInfo[] properties;

      colorType = typeof(Color);
      properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);

      for (int i = 0; i < properties.Length; i++)
      {
        PropertyInfo property;

        property = properties[i];

        if (property.PropertyType == colorType)
        {
          Color color;

          color = (Color)property.GetValue(type, null);
          if (!color.IsEmpty)
          {
            this.Items.Add(color.Name);
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

    private void SetDropDownWidth()
    {
      if (this.Items.Count != 0)
      {
        this.DropDownWidth = this.ItemHeight * 2 + this.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
      }
    }

    #endregion Private Methods
  }
}
