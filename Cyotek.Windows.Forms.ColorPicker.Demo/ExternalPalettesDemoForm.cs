// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ExternalPalettesDemoForm : BaseForm
  {
    #region Public Constructors

    public ExternalPalettesDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Properties

    private string PalettePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palettes");

    #endregion Private Properties

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.LoadPaletteFileNames();

      if (palettesListBox.Items.Count > 0)
      {
        palettesListBox.SelectedIndex = 0;
      }

      palettesListBox.Focus();
    }

    #endregion Protected Methods

    #region Private Methods

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void LoadPaletteFileNames()
    {
      palettesListBox.BeginUpdate();

      foreach (string fileName in Directory.GetFiles(this.PalettePath))
      {
        palettesListBox.Items.Add(Path.GetFileName(fileName));
      }

      palettesListBox.EndUpdate();
    }

    private void PalettesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (palettesListBox.SelectedIndex != -1)
      {
        colorGrid.Colors = ColorCollection.LoadPalette(Path.Combine(this.PalettePath, palettesListBox.SelectedItem.ToString()));
      }
    }

    private void SavePaletteButton_Click(object sender, EventArgs e)
    {
      using (FileDialog dialog = new SaveFileDialog
      {
        Filter = PaletteSerializer.DefaultSaveFilter,
        Title = "Save Palette As"
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          IPaletteSerializer serializer;

          serializer = PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(dialog.FilterIndex - 1);

          using (Stream stream = File.Create(dialog.FileName))
          {
            serializer.Serialize(stream, colorGrid.Colors);
          }
        }
      }
    }

    #endregion Private Methods
  }
}
