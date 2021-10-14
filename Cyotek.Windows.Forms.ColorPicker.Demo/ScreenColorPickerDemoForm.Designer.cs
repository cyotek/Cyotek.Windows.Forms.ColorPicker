namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  partial class ScreenColorPickerDemoForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenColorPickerDemoForm));
      this.propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
      this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
      this.eventsSplitContainer = new System.Windows.Forms.SplitContainer();
      this.demoLabel = new System.Windows.Forms.Label();
      this.captureButton = new System.Windows.Forms.Button();
      this.releaseButton = new System.Windows.Forms.Button();
      this.eventsListBox = new Cyotek.Windows.Forms.ColorPicker.Demo.EventsListBox();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.colorToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.colorPreviewBox = new Cyotek.Windows.Forms.ColorPicker.Demo.ColorPreviewBox();
      ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).BeginInit();
      this.propertiesSplitContainer.Panel1.SuspendLayout();
      this.propertiesSplitContainer.Panel2.SuspendLayout();
      this.propertiesSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).BeginInit();
      this.optionsSplitContainer.Panel1.SuspendLayout();
      this.optionsSplitContainer.Panel2.SuspendLayout();
      this.optionsSplitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).BeginInit();
      this.eventsSplitContainer.Panel1.SuspendLayout();
      this.eventsSplitContainer.Panel2.SuspendLayout();
      this.eventsSplitContainer.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // propertiesSplitContainer
      // 
      this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertiesSplitContainer.Location = new System.Drawing.Point(0, 24);
      this.propertiesSplitContainer.Name = "propertiesSplitContainer";
      // 
      // propertiesSplitContainer.Panel1
      // 
      this.propertiesSplitContainer.Panel1.Controls.Add(this.propertyGrid);
      // 
      // propertiesSplitContainer.Panel2
      // 
      this.propertiesSplitContainer.Panel2.Controls.Add(this.optionsSplitContainer);
      this.propertiesSplitContainer.Size = new System.Drawing.Size(784, 295);
      this.propertiesSplitContainer.SplitterDistance = 259;
      this.propertiesSplitContainer.SplitterWidth = 6;
      this.propertiesSplitContainer.TabIndex = 1;
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.SelectedObject = this.screenColorPicker;
      this.propertyGrid.Size = new System.Drawing.Size(259, 295);
      this.propertyGrid.TabIndex = 0;
      // 
      // screenColorPicker
      // 
      this.screenColorPicker.Color = System.Drawing.Color.Empty;
      this.screenColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
      this.screenColorPicker.Location = new System.Drawing.Point(0, 0);
      this.screenColorPicker.Name = "screenColorPicker";
      this.screenColorPicker.Size = new System.Drawing.Size(70, 295);
      this.screenColorPicker.ColorChanged += new System.EventHandler(this.ScreenColorPicker_ColorChanged);
      this.screenColorPicker.Selected += new System.EventHandler(this.ScreenColorPicker_Selected);
      this.screenColorPicker.Selecting += new System.ComponentModel.CancelEventHandler(this.ScreenColorPicker_Selecting);
      // 
      // optionsSplitContainer
      // 
      this.optionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.optionsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.optionsSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.optionsSplitContainer.Name = "optionsSplitContainer";
      // 
      // optionsSplitContainer.Panel1
      // 
      this.optionsSplitContainer.Panel1.Controls.Add(this.screenColorPicker);
      // 
      // optionsSplitContainer.Panel2
      // 
      this.optionsSplitContainer.Panel2.Controls.Add(this.eventsSplitContainer);
      this.optionsSplitContainer.Size = new System.Drawing.Size(519, 295);
      this.optionsSplitContainer.SplitterDistance = 70;
      this.optionsSplitContainer.SplitterWidth = 6;
      this.optionsSplitContainer.TabIndex = 0;
      // 
      // eventsSplitContainer
      // 
      this.eventsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.eventsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.eventsSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.eventsSplitContainer.Name = "eventsSplitContainer";
      this.eventsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // eventsSplitContainer.Panel1
      // 
      this.eventsSplitContainer.Panel1.Controls.Add(this.colorPreviewBox);
      this.eventsSplitContainer.Panel1.Controls.Add(this.demoLabel);
      this.eventsSplitContainer.Panel1.Controls.Add(this.captureButton);
      this.eventsSplitContainer.Panel1.Controls.Add(this.releaseButton);
      // 
      // eventsSplitContainer.Panel2
      // 
      this.eventsSplitContainer.Panel2.Controls.Add(this.eventsListBox);
      this.eventsSplitContainer.Size = new System.Drawing.Size(443, 295);
      this.eventsSplitContainer.SplitterDistance = 195;
      this.eventsSplitContainer.TabIndex = 0;
      // 
      // demoLabel
      // 
      this.demoLabel.AutoEllipsis = true;
      this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
      this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.demoLabel.Dock = System.Windows.Forms.DockStyle.Right;
      this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
      this.demoLabel.Location = new System.Drawing.Point(84, 0);
      this.demoLabel.Name = "demoLabel";
      this.demoLabel.Padding = new System.Windows.Forms.Padding(10);
      this.demoLabel.Size = new System.Drawing.Size(359, 195);
      this.demoLabel.TabIndex = 2;
      this.demoLabel.Text = resources.GetString("demoLabel.Text");
      // 
      // captureButton
      // 
      this.captureButton.Location = new System.Drawing.Point(3, 3);
      this.captureButton.Name = "captureButton";
      this.captureButton.Size = new System.Drawing.Size(75, 23);
      this.captureButton.TabIndex = 0;
      this.captureButton.Text = "&Capture";
      this.captureButton.UseVisualStyleBackColor = true;
      this.captureButton.Click += new System.EventHandler(this.CaptureButton_Click);
      // 
      // releaseButton
      // 
      this.releaseButton.Location = new System.Drawing.Point(3, 32);
      this.releaseButton.Name = "releaseButton";
      this.releaseButton.Size = new System.Drawing.Size(75, 23);
      this.releaseButton.TabIndex = 1;
      this.releaseButton.Text = "&Release";
      this.releaseButton.UseVisualStyleBackColor = true;
      this.releaseButton.Click += new System.EventHandler(this.ReleaseButton_Click);
      // 
      // eventsListBox
      // 
      this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.eventsListBox.FormattingEnabled = true;
      this.eventsListBox.ItemHeight = 15;
      this.eventsListBox.Location = new System.Drawing.Point(0, 0);
      this.eventsListBox.Name = "eventsListBox";
      this.eventsListBox.Size = new System.Drawing.Size(443, 96);
      this.eventsListBox.TabIndex = 0;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 319);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
      this.statusStrip.Size = new System.Drawing.Size(784, 22);
      this.statusStrip.TabIndex = 2;
      // 
      // colorToolStripStatusLabel
      // 
      this.colorToolStripStatusLabel.Name = "colorToolStripStatusLabel";
      this.colorToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
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
      // colorPreviewBox
      // 
      this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorPreviewBox.Color = System.Drawing.Color.Empty;
      this.colorPreviewBox.Location = new System.Drawing.Point(3, 139);
      this.colorPreviewBox.Name = "colorPreviewBox";
      this.colorPreviewBox.Size = new System.Drawing.Size(75, 53);
      this.colorPreviewBox.TabIndex = 3;
      // 
      // ScreenColorPickerDemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 341);
      this.Controls.Add(this.propertiesSplitContainer);
      this.Controls.Add(this.menuStrip);
      this.Controls.Add(this.statusStrip);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.Name = "ScreenColorPickerDemoForm";
      this.Text = "ScreenColorPicker Control Demonstration";
      this.propertiesSplitContainer.Panel1.ResumeLayout(false);
      this.propertiesSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).EndInit();
      this.propertiesSplitContainer.ResumeLayout(false);
      this.optionsSplitContainer.Panel1.ResumeLayout(false);
      this.optionsSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
      this.optionsSplitContainer.ResumeLayout(false);
      this.eventsSplitContainer.Panel1.ResumeLayout(false);
      this.eventsSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).EndInit();
      this.eventsSplitContainer.ResumeLayout(false);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer propertiesSplitContainer;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel colorToolStripStatusLabel;
    private ScreenColorPicker screenColorPicker;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.Button releaseButton;
    private System.Windows.Forms.Button captureButton;
    private System.Windows.Forms.Label demoLabel;
    private System.Windows.Forms.SplitContainer eventsSplitContainer;
    private EventsListBox eventsListBox;
    private ColorPreviewBox colorPreviewBox;
  }
}
