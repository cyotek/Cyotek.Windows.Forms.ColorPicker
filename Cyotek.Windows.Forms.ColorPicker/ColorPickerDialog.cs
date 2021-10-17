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
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  [DefaultEvent("PreviewColorChanged")]
  [DefaultProperty("Color")]
  public partial class ColorPickerDialog : Form
  {
    #region Private Fields

    private static readonly object _eventPreviewColorChanged = new object();

    private Color _color;

    private bool _preserveAlphaChannel;

    private bool _showAlphaChannel;

    private Brush _textureBrush;

    #endregion Private Fields

    #region Public Constructors

    public ColorPickerDialog()
    {
      this.InitializeComponent();

      _showAlphaChannel = true;
      base.Font = SystemFonts.DialogFont;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler PreviewColorChanged
    {
      add => this.Events.AddHandler(_eventPreviewColorChanged, value);
      remove => this.Events.RemoveHandler(_eventPreviewColorChanged, value);
    }

    #endregion Public Events

    #region Public Properties

    public Color Color
    {
      get => _color;
      set
      {
        if (_color != value)
        {
          colorEditorManager.Color = value;

          _color = value;
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool PreserveAlphaChannel
    {
      get => _preserveAlphaChannel;
      set => _preserveAlphaChannel = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowAlphaChannel
    {
      get => _showAlphaChannel;
      set => _showAlphaChannel = value;
    }

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();

        if (_textureBrush != null)
        {
          _textureBrush.Dispose();
          _textureBrush = null;
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      loadPaletteButton.Image = ResourceManager.LoadPalette;
      savePaletteButton.Image = ResourceManager.SavePalette;
      screenColorPicker.Image = ResourceManager.ScreenPicker;

      colorEditor.ShowAlphaChannel = _showAlphaChannel;
      colorEditor.PreserveAlphaChannel = _preserveAlphaChannel;

      if (!_showAlphaChannel && !_preserveAlphaChannel)
      {
        this.RemoveAlphaChannel();
      }
    }

    /// <summary>
    /// Raises the <see cref="PreviewColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPreviewColorChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventPreviewColorChanged];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void ColorEditorManager_ColorChanged(object sender, EventArgs e)
    {
      _color = colorEditorManager.Color;

      previewPanel.Invalidate();

      this.OnPreviewColorChanged(e);
    }

    private void ColorGrid_EditingColor(object sender, EditColorCancelEventArgs e)
    {
      e.Cancel = true;

      using (ColorDialog dialog = new ColorDialog
      {
        FullOpen = true,
        Color = e.Color
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          colorGrid.Colors[e.ColorIndex] = dialog.Color;
        }
      }
    }

    private void LoadPaletteButton_Click(object sender, EventArgs e)
    {
      using (FileDialog dialog = new OpenFileDialog
      {
        Filter = PaletteSerializer.DefaultOpenFilter,
        DefaultExt = "pal",
        Title = "Open Palette File"
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            IPaletteSerializer serializer;

            serializer = PaletteSerializer.GetSerializer(dialog.FileName);
            if (serializer != null)
            {
              ColorCollection palette;

              if (!serializer.CanRead)
              {
                throw new InvalidOperationException("Serializer does not support reading palettes.");
              }

              using (FileStream file = File.OpenRead(dialog.FileName))
              {
                palette = serializer.Deserialize(file);
              }

              if (palette != null)
              {
                // we can only display 96 colors in the color grid due to it's size, so if there's more, bin them
                while (palette.Count > 96)
                {
                  palette.RemoveAt(palette.Count - 1);
                }

                // or if we have less, fill in the blanks
                while (palette.Count < 96)
                {
                  palette.Add(Color.White);
                }

                colorGrid.Colors = palette;
              }
            }
            else
            {
              MessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show(string.Format("Sorry, unable to open palette. {0}", ex.GetBaseException().Message), "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void PreviewPanel_Paint(object sender, PaintEventArgs e)
    {
      Rectangle region;

      region = previewPanel.ClientRectangle;

      if (this.Color.A != 255)
      {
        if (_textureBrush == null)
        {
          _textureBrush = new TextureBrush(ResourceManager.CellBackground, WrapMode.Tile);
        }

        e.Graphics.FillRectangle(_textureBrush, region);
      }

      using (Brush brush = new SolidBrush(this.Color))
      {
        e.Graphics.FillRectangle(brush, region);
      }

      e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
    }

    private void RemoveAlphaChannel()
    {
      for (int i = 0; i < colorGrid.Colors.Count; i++)
      {
        Color color;

        color = colorGrid.Colors[i];

        if (color.A != 255)
        {
          colorGrid.Colors[i] = Color.FromArgb(255, color);
        }
      }
    }

    private void SavePaletteButton_Click(object sender, EventArgs e)
    {
      using (FileDialog dialog = new SaveFileDialog
      {
        Filter = PaletteSerializer.DefaultSaveFilter,
        DefaultExt = "pal",
        Title = "Save Palette File As"
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          IPaletteSerializer serializer;

          serializer = PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(dialog.FilterIndex - 1);

          if (serializer != null)
          {
            if (!serializer.CanWrite)
            {
              throw new InvalidOperationException("Serializer does not support writing palettes.");
            }

            try
            {
              using (FileStream file = File.OpenWrite(dialog.FileName))
              {
                serializer.Serialize(file, colorGrid.Colors);
              }
            }
            catch (Exception ex)
            {
              MessageBox.Show(string.Format("Sorry, unable to save palette. {0}", ex.GetBaseException().Message), "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
          else
          {
            MessageBox.Show("Sorry, unable to save palette, the file format is not supported or is not recognized.", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
      }
    }

    #endregion Private Methods
  }
}
