namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorGridEditingDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorGridEditingDemoForm));
            System.Windows.Forms.Label editModeLabel;
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editModeComboBox = new System.Windows.Forms.ComboBox();
            this.eventsListBox = new Cyotek.Windows.Forms.ColorPicker.Demo.EventsListBox();
            demoLabel = new System.Windows.Forms.Label();
            editModeLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoLabel
            // 
            demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            demoLabel.AutoEllipsis = true;
            demoLabel.BackColor = System.Drawing.SystemColors.Info;
            demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            demoLabel.Location = new System.Drawing.Point(444, 27);
            demoLabel.Name = "demoLabel";
            demoLabel.Padding = new System.Windows.Forms.Padding(9);
            demoLabel.Size = new System.Drawing.Size(408, 151);
            demoLabel.TabIndex = 2;
            demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // editModeLabel
            // 
            editModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            editModeLabel.AutoSize = true;
            editModeLabel.Location = new System.Drawing.Point(441, 190);
            editModeLabel.Name = "editModeLabel";
            editModeLabel.Size = new System.Drawing.Size(58, 13);
            editModeLabel.TabIndex = 3;
            editModeLabel.Text = "&Edit Mode:";
            // 
            // colorGrid
            // 
            this.colorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.Location = new System.Drawing.Point(12, 27);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(6);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
            this.colorGrid.Size = new System.Drawing.Size(426, 199);
            this.colorGrid.TabIndex = 1;
            this.colorGrid.ColorChanged += new System.EventHandler(this.ColorGrid_ColorChanged);
            this.colorGrid.ColorIndexChanged += new System.EventHandler(this.ColorGrid_ColorIndexChanged);
            this.colorGrid.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.ColorGrid_EditingColor);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 337);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(864, 22);
            this.statusStrip.TabIndex = 6;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(864, 24);
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
            // editModeComboBox
            // 
            this.editModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editModeComboBox.Items.AddRange(new object[] {
            "None",
            "Custom",
            "Both"});
            this.editModeComboBox.Location = new System.Drawing.Point(444, 206);
            this.editModeComboBox.Name = "editModeComboBox";
            this.editModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.editModeComboBox.TabIndex = 4;
            this.editModeComboBox.SelectedIndexChanged += new System.EventHandler(this.EditModeComboBox_SelectedIndexChanged);
            // 
            // eventsListBox
            // 
            this.eventsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(12, 239);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(840, 95);
            this.eventsListBox.TabIndex = 5;
            // 
            // ColorGridEditingDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 359);
            this.Controls.Add(this.eventsListBox);
            this.Controls.Add(this.editModeComboBox);
            this.Controls.Add(this.colorGrid);
            this.Controls.Add(editModeLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(demoLabel);
            this.Controls.Add(this.statusStrip);
            this.Name = "ColorGridEditingDemoForm";
            this.Text = "External Palette Files Demonstration";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private ColorGrid colorGrid;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private EventsListBox eventsListBox;
    private System.Windows.Forms.ComboBox editModeComboBox;
  }
}
