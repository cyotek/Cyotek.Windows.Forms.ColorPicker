using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  public partial class ColorPickerDialog : Form
  {
    #region Constructors

    public ColorPickerDialog()
    {
      this.InitializeComponent();
      this.Font = SystemFonts.DialogFont;
    }

    #endregion

    #region Properties

    public Color Color
    {
      get { return colorEditorManager.Color; }
      set { colorEditorManager.Color = value; }
    }

    #endregion

    #region Members

    private string GetPaletteFilter(bool includeCombined)
    {
      StringBuilder filter;

      // TODO: Should really try and query available serializers and build up a format string automatically

      filter = new StringBuilder();
      if (includeCombined)
        filter.Append("Palette Files (*.pal;*.gpl;*.txt)|*.pal;*.gpl;*.txt|");
      filter.Append("JASC Palette Files (*.pal)|*.pal|");
      filter.Append("GIMP Palette Files (*.glp)|*.gpl|");
      filter.Append("Paint.NET Palette Files (*.txt)|*.txt");

      return filter.ToString();
    }

    private IPaletteSerializer GetSerializer(string fileName)
    {
      IPaletteSerializer result;

      // TODO: Work this out via reflection

      switch (Path.GetExtension(fileName).ToLowerInvariant())
      {
        case ".txt":
          result = new PaintNetPaletteSerializer();
          break;
        case ".pal":
          result = new JascPaletteSerializer();
          break;
        case ".gpl":
          result = new GimpPaletteSerializer();
          break;
        default:
          result = null;
          break;
      }

      return result;
    }

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

    private void loadPaletteButton_Click(object sender, EventArgs e)
    {
      using (FileDialog dialog = new OpenFileDialog
      {
        Filter = this.GetPaletteFilter(true),
        DefaultExt = "pal",
        Title = "Open Palette File"
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          IPaletteSerializer serializer;

          serializer = this.GetSerializer(dialog.FileName);
          if (serializer != null)
          {
            try
            {
              ColorCollection palette;

              using (FileStream file = File.OpenRead(dialog.FileName))
                palette = serializer.Deserialize(file);

              if (palette != null)
              {
                // we can only display 96 colors in the color grid due to it's size, so if there's more, bin them
                while (palette.Count > 96)
                  palette.RemoveAt(palette.Count - 1);

                // or if we have less, fill in the blanks
                while (palette.Count < 96)
                  palette.Add(Color.White);

                colorGrid.Colors = palette;
              }
            }
            catch (Exception ex)
            {
              MessageBox.Show(string.Format("Sorry, unable to open palette. {0}", ex.GetBaseException().Message), "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
          else
            MessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        Filter = this.GetPaletteFilter(true),
        DefaultExt = "pal",
        Title = "Save Palette File As"
      })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          IPaletteSerializer serializer;

          serializer = this.GetSerializer(dialog.FileName);
          if (serializer != null)
          {
            try
            {
              using (FileStream file = File.OpenWrite(dialog.FileName))
                serializer.Serialize(file, colorGrid.Colors);
            }
            catch (Exception ex)
            {
              MessageBox.Show(string.Format("Sorry, unable to open palette. {0}", ex.GetBaseException().Message), "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
          else
            MessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }

    #endregion
  }
}
