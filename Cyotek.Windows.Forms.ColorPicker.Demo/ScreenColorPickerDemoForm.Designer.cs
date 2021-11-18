namespace Cyotek.Windows.Forms.Demo
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
            this.colorPreviewBox = new Cyotek.Windows.Forms.ColorPreviewBox();
            this.demoLabel = new System.Windows.Forms.Label();
            this.captureButton = new System.Windows.Forms.Button();
            this.releaseButton = new System.Windows.Forms.Button();
            this.eventsListBox = new Cyotek.Windows.Forms.Demo.EventsListBox();
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
            this.SuspendLayout();
            // 
            // propertiesSplitContainer
            // 
            this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesSplitContainer.Location = new System.Drawing.Point(12, 56);
            this.propertiesSplitContainer.Name = "propertiesSplitContainer";
            // 
            // propertiesSplitContainer.Panel1
            // 
            this.propertiesSplitContainer.Panel1.Controls.Add(this.propertyGrid);
            // 
            // propertiesSplitContainer.Panel2
            // 
            this.propertiesSplitContainer.Panel2.Controls.Add(this.optionsSplitContainer);
            this.propertiesSplitContainer.Size = new System.Drawing.Size(660, 335);
            this.propertiesSplitContainer.SplitterDistance = 217;
            this.propertiesSplitContainer.SplitterWidth = 5;
            this.propertiesSplitContainer.TabIndex = 1;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.screenColorPicker;
            this.propertyGrid.Size = new System.Drawing.Size(217, 335);
            this.propertyGrid.TabIndex = 0;
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Color = System.Drawing.Color.Empty;
            this.screenColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenColorPicker.Location = new System.Drawing.Point(0, 0);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(438, 71);
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
            this.optionsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // optionsSplitContainer.Panel1
            // 
            this.optionsSplitContainer.Panel1.Controls.Add(this.screenColorPicker);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(this.eventsSplitContainer);
            this.optionsSplitContainer.Size = new System.Drawing.Size(438, 335);
            this.optionsSplitContainer.SplitterDistance = 71;
            this.optionsSplitContainer.SplitterWidth = 5;
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
            this.eventsSplitContainer.Size = new System.Drawing.Size(438, 259);
            this.eventsSplitContainer.SplitterDistance = 161;
            this.eventsSplitContainer.SplitterWidth = 3;
            this.eventsSplitContainer.TabIndex = 0;
            // 
            // colorPreviewBox
            // 
            this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPreviewBox.Location = new System.Drawing.Point(3, 123);
            this.colorPreviewBox.Name = "colorPreviewBox";
            this.colorPreviewBox.Size = new System.Drawing.Size(87, 35);
            // 
            // demoLabel
            // 
            this.demoLabel.AutoEllipsis = true;
            this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
            this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demoLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.demoLabel.Location = new System.Drawing.Point(96, 0);
            this.demoLabel.Name = "demoLabel";
            this.demoLabel.Padding = new System.Windows.Forms.Padding(9);
            this.demoLabel.Size = new System.Drawing.Size(342, 161);
            this.demoLabel.TabIndex = 2;
            this.demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(3, 3);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(64, 20);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "&Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // releaseButton
            // 
            this.releaseButton.Location = new System.Drawing.Point(3, 28);
            this.releaseButton.Name = "releaseButton";
            this.releaseButton.Size = new System.Drawing.Size(64, 20);
            this.releaseButton.TabIndex = 1;
            this.releaseButton.Text = "&Release";
            this.releaseButton.UseVisualStyleBackColor = true;
            this.releaseButton.Click += new System.EventHandler(this.ReleaseButton_Click);
            // 
            // eventsListBox
            // 
            this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(0, 0);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(438, 95);
            this.eventsListBox.TabIndex = 0;
            // 
            // ScreenColorPickerDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.propertiesSplitContainer);
            this.Name = "ScreenColorPickerDemoForm";
            this.Text = "ScreenColorPicker Control Demonstration";
            this.Controls.SetChildIndex(this.propertiesSplitContainer, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer propertiesSplitContainer;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
    private ScreenColorPicker screenColorPicker;
    private System.Windows.Forms.Button releaseButton;
    private System.Windows.Forms.Button captureButton;
    private System.Windows.Forms.Label demoLabel;
    private System.Windows.Forms.SplitContainer eventsSplitContainer;
    private EventsListBox eventsListBox;
    private ColorPreviewBox colorPreviewBox;
  }
}
