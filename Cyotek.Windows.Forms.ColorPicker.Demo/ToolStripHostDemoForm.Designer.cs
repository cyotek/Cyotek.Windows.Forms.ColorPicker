using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Demo
{
  partial class ToolStripHostDemoForm
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
            System.Windows.Forms.LinkLabel blogLinkLabel;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textToolStripColorPickerButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.backgroundToolStripColorPickerSplitButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.previewLabel = new System.Windows.Forms.Label();
            this.propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripColorPickerSplitButton1 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton2 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripColorPickerSplitButton3 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton4 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton6 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton7 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton5 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.toolStripColorPickerSplitButton8 = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            blogLinkLabel = new System.Windows.Forms.LinkLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).BeginInit();
            this.propertiesSplitContainer.Panel1.SuspendLayout();
            this.propertiesSplitContainer.Panel2.SuspendLayout();
            this.propertiesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).BeginInit();
            this.optionsSplitContainer.Panel1.SuspendLayout();
            this.optionsSplitContainer.Panel2.SuspendLayout();
            this.optionsSplitContainer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // blogLinkLabel
            // 
            blogLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            blogLinkLabel.AutoSize = true;
            blogLinkLabel.Location = new System.Drawing.Point(3, 160);
            blogLinkLabel.Name = "blogLinkLabel";
            blogLinkLabel.Size = new System.Drawing.Size(407, 13);
            blogLinkLabel.TabIndex = 1;
            blogLinkLabel.TabStop = true;
            blogLinkLabel.Text = "Read the associated blog post describing how to create custom ToolStrip dropdowns" +
    "";
            blogLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BlogLinkLabel_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripColorPickerButton,
            this.backgroundToolStripColorPickerSplitButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(12, 12);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textToolStripColorPickerButton
            // 
            this.textToolStripColorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textToolStripColorPickerButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.TextColor;
            this.textToolStripColorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textToolStripColorPickerButton.Name = "textToolStripColorPickerButton";
            this.textToolStripColorPickerButton.Size = new System.Drawing.Size(32, 22);
            this.textToolStripColorPickerButton.Text = "Text";
            this.textToolStripColorPickerButton.ColorChanged += new System.EventHandler(this.TextToolStripColorPickerButton_ColorChanged);
            // 
            // backgroundToolStripColorPickerSplitButton
            // 
            this.backgroundToolStripColorPickerSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backgroundToolStripColorPickerSplitButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.backgroundToolStripColorPickerSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundToolStripColorPickerSplitButton.Name = "backgroundToolStripColorPickerSplitButton";
            this.backgroundToolStripColorPickerSplitButton.Size = new System.Drawing.Size(32, 22);
            this.backgroundToolStripColorPickerSplitButton.Text = "Fill";
            this.backgroundToolStripColorPickerSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.backgroundToolStripColorPickerSplitButton.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // previewLabel
            // 
            this.previewLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.previewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.previewLabel.Location = new System.Drawing.Point(0, 0);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(437, 164);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "Use the controls in the tool bar to change my colours";
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propertiesSplitContainer
            // 
            this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesSplitContainer.Location = new System.Drawing.Point(12, 37);
            this.propertiesSplitContainer.Name = "propertiesSplitContainer";
            // 
            // propertiesSplitContainer.Panel1
            // 
            this.propertiesSplitContainer.Panel1.Controls.Add(this.propertyGrid);
            // 
            // propertiesSplitContainer.Panel2
            // 
            this.propertiesSplitContainer.Panel2.Controls.Add(this.optionsSplitContainer);
            this.propertiesSplitContainer.Size = new System.Drawing.Size(660, 354);
            this.propertiesSplitContainer.SplitterDistance = 217;
            this.propertiesSplitContainer.SplitterWidth = 6;
            this.propertiesSplitContainer.TabIndex = 1;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(217, 354);
            this.propertyGrid.TabIndex = 0;
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
            this.optionsSplitContainer.Panel1.Controls.Add(this.previewLabel);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(blogLinkLabel);
            this.optionsSplitContainer.Panel2.Controls.Add(this.toolStrip2);
            this.optionsSplitContainer.Size = new System.Drawing.Size(437, 354);
            this.optionsSplitContainer.SplitterDistance = 164;
            this.optionsSplitContainer.SplitterWidth = 6;
            this.optionsSplitContainer.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripColorPickerSplitButton1,
            this.toolStripColorPickerSplitButton2,
            this.toolStripSeparator2,
            this.toolStripColorPickerSplitButton3,
            this.toolStripColorPickerSplitButton4,
            this.toolStripColorPickerSplitButton6,
            this.toolStripColorPickerSplitButton7,
            this.toolStripColorPickerSplitButton5,
            this.toolStripColorPickerSplitButton8});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(437, 38);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripColorPickerSplitButton1
            // 
            this.toolStripColorPickerSplitButton1.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton1.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.TextColor;
            this.toolStripColorPickerSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton1.Name = "toolStripColorPickerSplitButton1";
            this.toolStripColorPickerSplitButton1.Size = new System.Drawing.Size(60, 35);
            this.toolStripColorPickerSplitButton1.Text = "Text";
            this.toolStripColorPickerSplitButton1.ColorChanged += new System.EventHandler(this.TextToolStripColorPickerButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton2
            // 
            this.toolStripColorPickerSplitButton2.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton2.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.toolStripColorPickerSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton2.Name = "toolStripColorPickerSplitButton2";
            this.toolStripColorPickerSplitButton2.Size = new System.Drawing.Size(54, 35);
            this.toolStripColorPickerSplitButton2.Text = "Fill";
            this.toolStripColorPickerSplitButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripColorPickerSplitButton2.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripColorPickerSplitButton3
            // 
            this.toolStripColorPickerSplitButton3.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton3.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.TextColor;
            this.toolStripColorPickerSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton3.Name = "toolStripColorPickerSplitButton3";
            this.toolStripColorPickerSplitButton3.Size = new System.Drawing.Size(44, 35);
            this.toolStripColorPickerSplitButton3.Text = "Text";
            this.toolStripColorPickerSplitButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripColorPickerSplitButton3.ColorChanged += new System.EventHandler(this.TextToolStripColorPickerButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton4
            // 
            this.toolStripColorPickerSplitButton4.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton4.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.toolStripColorPickerSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton4.Name = "toolStripColorPickerSplitButton4";
            this.toolStripColorPickerSplitButton4.Size = new System.Drawing.Size(38, 35);
            this.toolStripColorPickerSplitButton4.Text = "Fill";
            this.toolStripColorPickerSplitButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripColorPickerSplitButton4.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton6
            // 
            this.toolStripColorPickerSplitButton6.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton6.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.TextColor;
            this.toolStripColorPickerSplitButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton6.Name = "toolStripColorPickerSplitButton6";
            this.toolStripColorPickerSplitButton6.Size = new System.Drawing.Size(60, 35);
            this.toolStripColorPickerSplitButton6.Text = "Text";
            this.toolStripColorPickerSplitButton6.ColorChanged += new System.EventHandler(this.TextToolStripColorPickerButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton7
            // 
            this.toolStripColorPickerSplitButton7.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton7.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.toolStripColorPickerSplitButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton7.Name = "toolStripColorPickerSplitButton7";
            this.toolStripColorPickerSplitButton7.Size = new System.Drawing.Size(54, 35);
            this.toolStripColorPickerSplitButton7.Text = "Fill";
            this.toolStripColorPickerSplitButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripColorPickerSplitButton7.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton5
            // 
            this.toolStripColorPickerSplitButton5.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton5.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.TextColor;
            this.toolStripColorPickerSplitButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton5.Name = "toolStripColorPickerSplitButton5";
            this.toolStripColorPickerSplitButton5.Size = new System.Drawing.Size(44, 35);
            this.toolStripColorPickerSplitButton5.Text = "Text";
            this.toolStripColorPickerSplitButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripColorPickerSplitButton5.ColorChanged += new System.EventHandler(this.TextToolStripColorPickerButton_ColorChanged);
            // 
            // toolStripColorPickerSplitButton8
            // 
            this.toolStripColorPickerSplitButton8.Color = System.Drawing.Color.Red;
            this.toolStripColorPickerSplitButton8.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.toolStripColorPickerSplitButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorPickerSplitButton8.Name = "toolStripColorPickerSplitButton8";
            this.toolStripColorPickerSplitButton8.Size = new System.Drawing.Size(38, 35);
            this.toolStripColorPickerSplitButton8.Text = "Fill";
            this.toolStripColorPickerSplitButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripColorPickerSplitButton8.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // ToolStripHostDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.propertiesSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ToolStripHostDemoForm";
            this.Text = "Using ColorGrid in ToolStrips Demonstration";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.propertiesSplitContainer, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.propertiesSplitContainer.Panel1.ResumeLayout(false);
            this.propertiesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).EndInit();
            this.propertiesSplitContainer.ResumeLayout(false);
            this.optionsSplitContainer.Panel1.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
            this.optionsSplitContainer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolStrip toolStrip1;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton textToolStripColorPickerButton;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton backgroundToolStripColorPickerSplitButton;
    private Label previewLabel;
    private SplitContainer propertiesSplitContainer;
    private PropertyGrid propertyGrid;
    private SplitContainer optionsSplitContainer;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStrip toolStrip2;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton1;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton2;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton3;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton4;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton5;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton6;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton7;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton toolStripColorPickerSplitButton8;
  }
}
