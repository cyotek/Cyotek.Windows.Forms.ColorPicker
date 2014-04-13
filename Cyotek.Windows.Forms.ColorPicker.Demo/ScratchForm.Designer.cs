namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  partial class ScratchForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
      this.colorGrid2 = new Cyotek.Windows.Forms.ColorGrid();
      this.SuspendLayout();
      // 
      // colorGrid1
      // 
      this.colorGrid1.AutoAddColors = false;
      this.colorGrid1.CellSize = new System.Drawing.Size(32, 32);
      this.colorGrid1.Columns = 0;
      this.colorGrid1.Location = new System.Drawing.Point(105, 81);
      this.colorGrid1.Name = "colorGrid1";
      this.colorGrid1.Palette = Cyotek.Windows.Forms.ColorPalette.Standard;
      this.colorGrid1.ShowCustomColors = false;
      this.colorGrid1.Size = new System.Drawing.Size(294, 77);
      this.colorGrid1.TabIndex = 0;
      // 
      // colorGrid2
      // 
      this.colorGrid2.AutoAddColors = false;
      this.colorGrid2.CellSize = new System.Drawing.Size(32, 32);
      this.colorGrid2.Columns = 0;
      this.colorGrid2.Location = new System.Drawing.Point(405, 81);
      this.colorGrid2.Name = "colorGrid2";
      this.colorGrid2.Palette = Cyotek.Windows.Forms.ColorPalette.Standard;
      this.colorGrid2.ShowCustomColors = false;
      this.colorGrid2.Size = new System.Drawing.Size(294, 77);
      this.colorGrid2.TabIndex = 1;
      // 
      // ScratchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1106, 579);
      this.Controls.Add(this.colorGrid2);
      this.Controls.Add(this.colorGrid1);
      this.Name = "ScratchForm";
      this.Text = "ScratchForm";
      this.Load += new System.EventHandler(this.ScratchForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ColorGrid colorGrid1;
    private ColorGrid colorGrid2;



  }
}