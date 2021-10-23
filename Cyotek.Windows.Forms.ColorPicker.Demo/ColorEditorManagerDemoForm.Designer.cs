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
      this.previewPanel = new Cyotek.Windows.Forms.ColorPicker.Demo.ColorPreviewBox();
      this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
      this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
      this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
      this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
      this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
      this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
      this.demoLabel = new System.Windows.Forms.Label();
      this.wheelPanel = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.menuStrip.SuspendLayout();
      this.wheelPanel.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(672, 24);
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
      // previewPanel
      // 
      this.previewPanel.Color = System.Drawing.Color.Empty;
      this.previewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.previewPanel.Location = new System.Drawing.Point(407, 185);
      this.previewPanel.Name = "previewPanel";
      this.previewPanel.Size = new System.Drawing.Size(67, 47);
      this.previewPanel.TabIndex = 2;
      // 
      // lightnessColorSlider
      // 
      this.lightnessColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lightnessColorSlider.Color = System.Drawing.Color.RoyalBlue;
      this.lightnessColorSlider.Location = new System.Drawing.Point(140, 0);
      this.lightnessColorSlider.Name = "lightnessColorSlider";
      this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.lightnessColorSlider.Size = new System.Drawing.Size(28, 139);
      this.lightnessColorSlider.TabIndex = 1;
      this.lightnessColorSlider.Value = 56F;
      // 
      // screenColorPicker
      // 
      this.screenColorPicker.Color = System.Drawing.Color.RoyalBlue;
      this.screenColorPicker.Image = global::Cyotek.Windows.Forms.ColorPicker.Demo.Properties.Resources.eyedropper;
      this.screenColorPicker.Location = new System.Drawing.Point(407, 3);
      this.screenColorPicker.Name = "screenColorPicker";
      this.screenColorPicker.Size = new System.Drawing.Size(67, 85);
      this.screenColorPicker.Zoom = 6;
      // 
      // colorWheel
      // 
      this.colorWheel.Alpha = 1D;
      this.colorWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
      this.colorWheel.Lightness = 0.56862747669219971D;
      this.colorWheel.Location = new System.Drawing.Point(0, 0);
      this.colorWheel.Name = "colorWheel";
      this.colorWheel.Size = new System.Drawing.Size(135, 139);
      this.colorWheel.TabIndex = 0;
      // 
      // colorEditor
      // 
      this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
      this.colorEditor.Location = new System.Drawing.Point(177, 3);
      this.colorEditor.Name = "colorEditor";
      this.tableLayoutPanel1.SetRowSpan(this.colorEditor, 2);
      this.colorEditor.Size = new System.Drawing.Size(224, 229);
      this.colorEditor.TabIndex = 1;
      // 
      // colorGrid
      // 
      this.colorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.colorGrid.AutoAddColors = false;
      this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
      this.colorGrid.Color = System.Drawing.Color.RoyalBlue;
      this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
      this.colorGrid.Location = new System.Drawing.Point(0, 144);
      this.colorGrid.Name = "colorGrid";
      this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
      this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
      this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
      this.colorGrid.ShowCustomColors = false;
      this.colorGrid.Size = new System.Drawing.Size(192, 72);
      this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
      this.colorGrid.TabIndex = 2;
      // 
      // colorEditorManager
      // 
      this.colorEditorManager.Color = System.Drawing.Color.RoyalBlue;
      this.colorEditorManager.ColorEditor = this.colorEditor;
      this.colorEditorManager.ColorGrid = this.colorGrid;
      this.colorEditorManager.ColorWheel = this.colorWheel;
      this.colorEditorManager.LightnessColorSlider = this.lightnessColorSlider;
      this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
      this.colorEditorManager.ColorChanged += new System.EventHandler(this.ColorEditorManager_ColorChanged);
      // 
      // demoLabel
      // 
      this.demoLabel.AutoEllipsis = true;
      this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
      this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.demoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
      this.demoLabel.Location = new System.Drawing.Point(480, 0);
      this.demoLabel.Name = "demoLabel";
      this.demoLabel.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
      this.tableLayoutPanel1.SetRowSpan(this.demoLabel, 2);
      this.demoLabel.Size = new System.Drawing.Size(168, 235);
      this.demoLabel.TabIndex = 3;
      this.demoLabel.Text = resources.GetString("demoLabel.Text");
      // 
      // wheelPanel
      // 
      this.wheelPanel.Controls.Add(this.colorGrid);
      this.wheelPanel.Controls.Add(this.colorWheel);
      this.wheelPanel.Controls.Add(this.lightnessColorSlider);
      this.wheelPanel.Location = new System.Drawing.Point(3, 3);
      this.wheelPanel.Name = "wheelPanel";
      this.tableLayoutPanel1.SetRowSpan(this.wheelPanel, 2);
      this.wheelPanel.Size = new System.Drawing.Size(168, 206);
      this.wheelPanel.TabIndex = 0;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.wheelPanel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.demoLabel, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.colorEditor, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.previewPanel, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.screenColorPicker, 2, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 235);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // ColorEditorManagerDemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(672, 269);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "ColorEditorManagerDemoForm";
      this.Text = "ColorEditorManager Component Demonstration";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.wheelPanel.ResumeLayout(false);
      this.wheelPanel.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
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
    private Cyotek.Windows.Forms.ColorPicker.Demo.ColorPreviewBox previewPanel;
    private LightnessColorSlider lightnessColorSlider;
    private System.Windows.Forms.Label demoLabel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel wheelPanel;
  }
}
