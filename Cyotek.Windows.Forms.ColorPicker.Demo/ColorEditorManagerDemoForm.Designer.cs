namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorEditorManagerDemoForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorEditorManagerDemoForm));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.previewPanel = new System.Windows.Forms.Panel();
      this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
      this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
      this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
      this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
      this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
      this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
      this.demoLabel = new System.Windows.Forms.Label();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(909, 24);
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
      this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
      // 
      // previewPanel
      // 
      this.previewPanel.Location = new System.Drawing.Point(536, 138);
      this.previewPanel.Name = "previewPanel";
      this.previewPanel.Size = new System.Drawing.Size(75, 47);
      this.previewPanel.TabIndex = 12;
      // 
      // lightnessColorSlider
      // 
      this.lightnessColorSlider.Location = new System.Drawing.Point(176, 27);
      this.lightnessColorSlider.Name = "lightnessColorSlider";
      this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.lightnessColorSlider.Size = new System.Drawing.Size(28, 158);
      this.lightnessColorSlider.TabIndex = 21;
      // 
      // screenColorPicker
      // 
      this.screenColorPicker.Color = System.Drawing.Color.Black;
      this.screenColorPicker.Image = global::Cyotek.Windows.Forms.ColorPicker.Demo.Properties.Resources.eyedropper;
      this.screenColorPicker.Location = new System.Drawing.Point(536, 27);
      this.screenColorPicker.Name = "screenColorPicker";
      this.screenColorPicker.Size = new System.Drawing.Size(73, 85);
      this.screenColorPicker.Zoom = 6;
      // 
      // colorWheel
      // 
      this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.colorWheel.Location = new System.Drawing.Point(12, 27);
      this.colorWheel.Name = "colorWheel";
      this.colorWheel.Size = new System.Drawing.Size(158, 158);
      this.colorWheel.TabIndex = 10;
      // 
      // colorEditor
      // 
      this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.colorEditor.Location = new System.Drawing.Point(275, 27);
      this.colorEditor.Name = "colorEditor";
      this.colorEditor.Size = new System.Drawing.Size(224, 272);
      this.colorEditor.TabIndex = 7;
      // 
      // colorGrid
      // 
      this.colorGrid.AutoAddColors = false;
      this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
      this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
      this.colorGrid.Location = new System.Drawing.Point(12, 191);
      this.colorGrid.Name = "colorGrid";
      this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
      this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
      this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
      this.colorGrid.ShowCustomColors = false;
      this.colorGrid.Size = new System.Drawing.Size(192, 72);
      this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
      this.colorGrid.TabIndex = 11;
      // 
      // colorEditorManager
      // 
      this.colorEditorManager.ColorEditor = this.colorEditor;
      this.colorEditorManager.ColorGrid = this.colorGrid;
      this.colorEditorManager.ColorWheel = this.colorWheel;
      this.colorEditorManager.LightnessColorSlider = this.lightnessColorSlider;
      this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
      this.colorEditorManager.ColorChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
      // 
      // demoLabel
      // 
      this.demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.demoLabel.AutoEllipsis = true;
      this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
      this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
      this.demoLabel.Location = new System.Drawing.Point(617, 9);
      this.demoLabel.Name = "demoLabel";
      this.demoLabel.Padding = new System.Windows.Forms.Padding(9);
      this.demoLabel.Size = new System.Drawing.Size(280, 176);
      this.demoLabel.TabIndex = 22;
      this.demoLabel.Text = resources.GetString("demoLabel.Text");
      // 
      // ColorEditorManagerDemoForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(909, 331);
      this.Controls.Add(this.demoLabel);
      this.Controls.Add(this.lightnessColorSlider);
      this.Controls.Add(this.screenColorPicker);
      this.Controls.Add(this.colorWheel);
      this.Controls.Add(this.colorEditor);
      this.Controls.Add(this.colorGrid);
      this.Controls.Add(this.previewPanel);
      this.Controls.Add(this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "ColorEditorManagerDemoForm";
      this.Text = "ColorEditorManager Component Demonstration";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private ScreenColorPicker screenColorPicker;
    private ColorWheel colorWheel;
    private ColorEditor colorEditor;
    private ColorGrid colorGrid;
    private ColorEditorManager colorEditorManager;
    private System.Windows.Forms.Panel previewPanel;
    private LightnessColorSlider lightnessColorSlider;
    private System.Windows.Forms.Label demoLabel;
  }
}
