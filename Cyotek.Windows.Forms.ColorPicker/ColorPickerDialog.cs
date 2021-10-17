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
    private static readonly object _eventCustomColorsLoading = new object();

    private static readonly object _eventCustomColorsSaving = new object();

    private static readonly object _eventPreviewColorChanged = new object();

    private Color _color;

    private ColorCollection _customColors;

    private bool _preserveAlphaChannel;

    private bool _showAlphaChannel;

    private bool _showLoad;

    private bool _showSave;

    private Brush _textureBrush;

    public ColorPickerDialog()
    {
      this.InitializeComponent();

      _showAlphaChannel = true;
      _showLoad = true;
      _showSave = true;
      _customColors = new ColorCollection();

      base.Font = SystemFonts.DialogFont;
    }

    [Category("Action")]
    public event CancelEventHandler CustomColorsLoading
    {
      add => this.Events.AddHandler(_eventCustomColorsLoading, value);
      remove => this.Events.RemoveHandler(_eventCustomColorsLoading, value);
    }

    [Category("Action")]
    public event EventHandler CustomColorsSaving
    {
      add => this.Events.AddHandler(_eventCustomColorsSaving, value);
      remove => this.Events.RemoveHandler(_eventCustomColorsSaving, value);
    }

    [Category("Property Changed")]
    public event EventHandler PreviewColorChanged
    {
      add => this.Events.AddHandler(_eventPreviewColorChanged, value);
      remove => this.Events.RemoveHandler(_eventPreviewColorChanged, value);
    }

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

    public ColorCollection CustomColors
    {
      get => _customColors;
      set => _customColors = value;
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

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowLoad
    {
      get => _showLoad;
      set => _showLoad = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowSave
    {
      get => _showSave;
      set => _showSave = value;
    }

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
    /// Raises the <see cref="CustomColorsLoading" /> event.
    /// </summary>
    /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsLoading(CancelEventArgs e)
    {
      CancelEventHandler handler;

      handler = (CancelEventHandler)this.Events[_eventCustomColorsLoading];

      if (handler != null)
      {
        handler.Invoke(this, e);
      }
      else
      {
        // if no handler is explicitly bound, then
        // fall back to the built-in behaviour
        this.LoadCustomColors();
      }
    }

    /// <summary>
    /// Raises the <see cref="CustomColorsSaving" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsSaving(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventCustomColorsSaving];

      if (handler != null)
      {
        handler.Invoke(this, e);
      }
      else
      {
        // if no handler is explicitly bound, then
        // fall back to the built-in behaviour
        this.SaveCustomColors();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.UpdateButtonStates();

      screenColorPicker.Image = ResourceManager.ScreenPicker;

      colorEditor.ShowAlphaChannel = _showAlphaChannel;
      colorEditor.PreserveAlphaChannel = _preserveAlphaChannel;

      this.CopyCustomColors();
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

    private void CopyCustomColors()
    {
      colorGrid.Palette = ColorPalette.None;

      if (_customColors == null)
      {
        _customColors = new ColorCollection();
      }

      if (_customColors.Count == 0)
      {
        _customColors.AddRange(ColorPalettes.PaintPalette);
      }

      colorGrid.BeginUpdate();

      colorGrid.Colors.Clear();

      // copy a maximum of 96 colours from the custom plaette
      for (int i = 0; i < Math.Min(96, _customColors.Count); i++)
      {
        Color color;

        color = _customColors[i];

        if (color.A != 255 && !_showAlphaChannel && !_preserveAlphaChannel)
        {
          color = Color.FromArgb(255, color);
        }

        colorGrid.Colors.Add(color);
      }

      // or if we have less, fill in the blanks
      while (colorGrid.Colors.Count < 96)
      {
        colorGrid.Colors.Add(Color.White);
      }

      colorGrid.EndUpdate();
    }

    private void LoadCustomColors()
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
                _customColors.Clear();
                _customColors.AddRange(palette);
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

    private void LoadPaletteButton_Click(object sender, EventArgs e)
    {
      CancelEventArgs args;

      args = new CancelEventArgs();

      this.OnCustomColorsLoading(args);

      if (!args.Cancel)
      {
        this.CopyCustomColors();
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

    private void SaveCustomColors()
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

    private void SavePaletteButton_Click(object sender, EventArgs e)
    {
      if (_customColors == null)
      {
        _customColors = new ColorCollection();
      }

      _customColors.Clear();
      _customColors.AddRange(colorGrid.Colors);

      this.OnCustomColorsSaving(e);
    }

    private void UpdateButtonStates()
    {
      loadPaletteButton.Enabled = _showLoad;
      savePaletteButton.Enabled = _showSave;

      if (_showLoad || _showSave)
      {
        loadPaletteButton.Image = ResourceManager.LoadPalette;
        loadPaletteButton.Visible = true;

        savePaletteButton.Image = ResourceManager.SavePalette;
        savePaletteButton.Visible = true;
      }
      else
      {
        loadPaletteButton.Visible = false;
        savePaletteButton.Visible = false;
      }
    }
  }
}
