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
      this.components = new System.ComponentModel.Container();
      this.colorEditor3 = new Cyotek.Windows.Forms.ColorEditor();
      this.colorEditor2 = new Cyotek.Windows.Forms.ColorEditor();
      this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
      this.colorGrid2 = new Cyotek.Windows.Forms.ColorGrid();
      this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // colorEditor3
      // 
      this.colorEditor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.colorEditor3.Location = new System.Drawing.Point(718, 340);
      this.colorEditor3.Name = "colorEditor3";
      this.colorEditor3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.colorEditor3.ShowAlphaChannel = false;
      this.colorEditor3.ShowColorSpaceLabels = false;
      this.colorEditor3.Size = new System.Drawing.Size(219, 87);
      this.colorEditor3.TabIndex = 4;
      // 
      // colorEditor2
      // 
      this.colorEditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.colorEditor2.Location = new System.Drawing.Point(480, 340);
      this.colorEditor2.Name = "colorEditor2";
      this.colorEditor2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.colorEditor2.ShowAlphaChannel = false;
      this.colorEditor2.ShowColorSpaceLabels = false;
      this.colorEditor2.Size = new System.Drawing.Size(163, 111);
      this.colorEditor2.TabIndex = 3;
      // 
      // colorEditor1
      // 
      this.colorEditor1.Location = new System.Drawing.Point(180, 207);
      this.colorEditor1.Name = "colorEditor1";
      this.colorEditor1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.colorEditor1.ShowAlphaChannel = false;
      this.colorEditor1.ShowColorSpaceLabels = false;
      this.colorEditor1.Size = new System.Drawing.Size(396, 134);
      this.colorEditor1.TabIndex = 2;
      // 
      // colorGrid2
      // 
      this.colorGrid2.AutoAddColors = false;
      this.colorGrid2.CellContextMenuStrip = this.contextMenuStrip1;
      this.colorGrid2.CellSize = new System.Drawing.Size(32, 32);
      this.colorGrid2.Columns = 0;
      this.colorGrid2.Location = new System.Drawing.Point(405, 81);
      this.colorGrid2.Name = "colorGrid2";
      this.colorGrid2.Palette = Cyotek.Windows.Forms.ColorPalette.Standard;
      this.colorGrid2.ShowCustomColors = false;
      this.colorGrid2.Size = new System.Drawing.Size(294, 77);
      this.colorGrid2.TabIndex = 1;
      // 
      // colorGrid1
      // 
      this.colorGrid1.AutoAddColors = false;
      this.colorGrid1.CellContextMenuStrip = this.contextMenuStrip1;
      this.colorGrid1.CellSize = new System.Drawing.Size(32, 32);
      this.colorGrid1.Columns = 0;
      this.colorGrid1.Location = new System.Drawing.Point(105, 81);
      this.colorGrid1.Name = "colorGrid1";
      this.colorGrid1.Palette = Cyotek.Windows.Forms.ColorPalette.Standard;
      this.colorGrid1.ShowCustomColors = false;
      this.colorGrid1.Size = new System.Drawing.Size(294, 77);
      this.colorGrid1.TabIndex = 0;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
      // 
      // item1ToolStripMenuItem
      // 
      this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
      this.item1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.item1ToolStripMenuItem.Text = "Item 1";
      // 
      // item2ToolStripMenuItem
      // 
      this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
      this.item2ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.item2ToolStripMenuItem.Text = "Item 2";
      // 
      // ScratchForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(1106, 579);
      this.Controls.Add(this.colorEditor3);
      this.Controls.Add(this.colorEditor2);
      this.Controls.Add(this.colorEditor1);
      this.Controls.Add(this.colorGrid2);
      this.Controls.Add(this.colorGrid1);
      this.Name = "ScratchForm";
      this.Text = "ScratchForm";
      this.Load += new System.EventHandler(this.ScratchForm_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ColorGrid colorGrid1;
    private ColorGrid colorGrid2;
    private ColorEditor colorEditor1;
    private ColorEditor colorEditor2;
    private ColorEditor colorEditor3;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
  }
}
