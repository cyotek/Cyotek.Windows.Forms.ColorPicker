namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ExternalPalettesDemoForm
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
            System.Windows.Forms.Label demoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalPalettesDemoForm));
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.palettesListBox = new System.Windows.Forms.ListBox();
            this.savePaletteButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
            demoLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).BeginInit();
            this.optionsSplitContainer.Panel1.SuspendLayout();
            this.optionsSplitContainer.Panel2.SuspendLayout();
            this.optionsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoLabel
            // 
            demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            demoLabel.AutoEllipsis = true;
            demoLabel.BackColor = System.Drawing.SystemColors.Info;
            demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            demoLabel.Location = new System.Drawing.Point(3, 0);
            demoLabel.Name = "demoLabel";
            demoLabel.Padding = new System.Windows.Forms.Padding(9);
            demoLabel.Size = new System.Drawing.Size(525, 132);
            demoLabel.TabIndex = 0;
            demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // colorGrid
            // 
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.Columns = 8;
            this.colorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGrid.Location = new System.Drawing.Point(0, 0);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(6);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.None;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(220, 509);
            this.colorGrid.TabIndex = 0;
            // 
            // palettesListBox
            // 
            this.palettesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.palettesListBox.FormattingEnabled = true;
            this.palettesListBox.IntegralHeight = false;
            this.palettesListBox.Location = new System.Drawing.Point(3, 135);
            this.palettesListBox.Name = "palettesListBox";
            this.palettesListBox.Size = new System.Drawing.Size(449, 374);
            this.palettesListBox.TabIndex = 1;
            this.palettesListBox.SelectedIndexChanged += new System.EventHandler(this.PalettesListBox_SelectedIndexChanged);
            // 
            // savePaletteButton
            // 
            this.savePaletteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePaletteButton.Location = new System.Drawing.Point(458, 486);
            this.savePaletteButton.Name = "savePaletteButton";
            this.savePaletteButton.Size = new System.Drawing.Size(75, 23);
            this.savePaletteButton.TabIndex = 2;
            this.savePaletteButton.Text = "Save As";
            this.savePaletteButton.UseVisualStyleBackColor = true;
            this.savePaletteButton.Click += new System.EventHandler(this.SavePaletteButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // optionsSplitContainer
            // 
            this.optionsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.optionsSplitContainer.Location = new System.Drawing.Point(12, 27);
            this.optionsSplitContainer.Name = "optionsSplitContainer";
            // 
            // optionsSplitContainer.Panel1
            // 
            this.optionsSplitContainer.Panel1.Controls.Add(this.colorGrid);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(this.savePaletteButton);
            this.optionsSplitContainer.Panel2.Controls.Add(this.palettesListBox);
            this.optionsSplitContainer.Panel2.Controls.Add(demoLabel);
            this.optionsSplitContainer.Size = new System.Drawing.Size(760, 509);
            this.optionsSplitContainer.SplitterDistance = 220;
            this.optionsSplitContainer.SplitterWidth = 5;
            this.optionsSplitContainer.TabIndex = 1;
            // 
            // ExternalPalettesDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.optionsSplitContainer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Name = "ExternalPalettesDemoForm";
            this.Text = "External Palette Files Demonstration";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.optionsSplitContainer.Panel1.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
            this.optionsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private ColorGrid colorGrid;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.Button savePaletteButton;
    private System.Windows.Forms.ListBox palettesListBox;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
  }
}
