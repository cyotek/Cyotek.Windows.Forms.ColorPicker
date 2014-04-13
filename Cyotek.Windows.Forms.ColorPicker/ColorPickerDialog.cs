using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  public partial class ColorPickerDialog : Form
  {
    #region Public Constructors

    public ColorPickerDialog()
    {
      this.InitializeComponent();
      this.ShowAlphaChannel = true;
      this.Font = SystemFonts.DialogFont;
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditor.ShowAlphaChannel = this.ShowAlphaChannel;
    }

    #endregion

    #region Public Properties

    public Color Color
    {
      get { return colorEditorManager.Color; }
      set { colorEditorManager.Color = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowAlphaChannel { get; set; }

    #endregion

    #region Event Handlers

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void colorEditorManager_ColorChanged(object sender, EventArgs e)
    {
      previewPanel.BackColor = colorEditorManager.Color;
    }

    private void colorGrid_EditingColor(object sender, EditColorCancelEventArgs e)
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

    private void loadPaletteButton_Click(object sender, EventArgs e)
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

    private void okButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void savePaletteButton_Click(object sender, EventArgs e)
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

    #endregion
  }
}
