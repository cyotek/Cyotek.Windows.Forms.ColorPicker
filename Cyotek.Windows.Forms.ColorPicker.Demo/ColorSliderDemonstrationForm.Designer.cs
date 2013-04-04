namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorSliderDemonstrationForm
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
      this.propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
      this.eventsSplitContainer = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.groupBox7 = new Cyotek.Windows.Forms.GroupBox();
      this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
      this.groupBox6 = new Cyotek.Windows.Forms.GroupBox();
      this.saturationColorSlider = new Cyotek.Windows.Forms.SaturationColorSlider();
      this.groupBox5 = new Cyotek.Windows.Forms.GroupBox();
      this.hueColorSlider = new Cyotek.Windows.Forms.HueColorSlider();
      this.groupBox4 = new Cyotek.Windows.Forms.GroupBox();
      this.alphaColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.groupBox3 = new Cyotek.Windows.Forms.GroupBox();
      this.blueRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.groupBox2 = new Cyotek.Windows.Forms.GroupBox();
      this.greenRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.groupBox1 = new Cyotek.Windows.Forms.GroupBox();
      this.redRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.eventsListBox = new Cyotek.Windows.Forms.ColorPicker.Demo.EventsListBox();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.propertiesSplitContainer.Panel1.SuspendLayout();
      this.propertiesSplitContainer.Panel2.SuspendLayout();
      this.propertiesSplitContainer.SuspendLayout();
      this.eventsSplitContainer.Panel1.SuspendLayout();
      this.eventsSplitContainer.Panel2.SuspendLayout();
      this.eventsSplitContainer.SuspendLayout();
      this.tableLayoutPanel.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // propertiesSplitContainer
      // 
      this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertiesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.propertiesSplitContainer.Location = new System.Drawing.Point(0, 24);
      this.propertiesSplitContainer.Name = "propertiesSplitContainer";
      // 
      // propertiesSplitContainer.Panel1
      // 
      this.propertiesSplitContainer.Panel1.Controls.Add(this.eventsSplitContainer);
      // 
      // propertiesSplitContainer.Panel2
      // 
      this.propertiesSplitContainer.Panel2.Controls.Add(this.propertyGrid);
      this.propertiesSplitContainer.Size = new System.Drawing.Size(847, 349);
      this.propertiesSplitContainer.SplitterDistance = 547;
      this.propertiesSplitContainer.TabIndex = 1;
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
      this.eventsSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel);
      // 
      // eventsSplitContainer.Panel2
      // 
      this.eventsSplitContainer.Panel2.Controls.Add(this.eventsListBox);
      this.eventsSplitContainer.Size = new System.Drawing.Size(547, 349);
      this.eventsSplitContainer.SplitterDistance = 229;
      this.eventsSplitContainer.TabIndex = 0;
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 7;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
      this.tableLayoutPanel.Controls.Add(this.groupBox7, 6, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox6, 5, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox5, 4, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox4, 3, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox3, 2, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox2, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 1;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 229F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(547, 229);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // groupBox7
      // 
      this.groupBox7.Controls.Add(this.lightnessColorSlider);
      this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox7.Location = new System.Drawing.Point(471, 3);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(73, 223);
      this.groupBox7.TabIndex = 6;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "LightnessColorSlider";
      // 
      // lightnessColorSlider
      // 
      this.lightnessColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lightnessColorSlider.Location = new System.Drawing.Point(6, 22);
      this.lightnessColorSlider.Name = "lightnessColorSlider";
      this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.lightnessColorSlider.Size = new System.Drawing.Size(61, 195);
      this.lightnessColorSlider.TabIndex = 0;
      this.lightnessColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.lightnessColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.saturationColorSlider);
      this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox6.Location = new System.Drawing.Point(393, 3);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(72, 223);
      this.groupBox6.TabIndex = 5;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "SaturationColorSlider";
      // 
      // saturationColorSlider
      // 
      this.saturationColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.saturationColorSlider.Location = new System.Drawing.Point(6, 22);
      this.saturationColorSlider.Name = "saturationColorSlider";
      this.saturationColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.saturationColorSlider.Size = new System.Drawing.Size(60, 195);
      this.saturationColorSlider.TabIndex = 0;
      this.saturationColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.saturationColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.hueColorSlider);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(315, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(72, 223);
      this.groupBox5.TabIndex = 4;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "HueColorSlider";
      // 
      // hueColorSlider
      // 
      this.hueColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hueColorSlider.Location = new System.Drawing.Point(6, 22);
      this.hueColorSlider.Name = "hueColorSlider";
      this.hueColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.hueColorSlider.Size = new System.Drawing.Size(60, 195);
      this.hueColorSlider.TabIndex = 0;
      this.hueColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.hueColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.alphaColorSlider);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox4.Location = new System.Drawing.Point(237, 3);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(72, 223);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "RgbColorSlider (Alpha Channel)";
      // 
      // alphaColorSlider
      // 
      this.alphaColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.alphaColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Alpha;
      this.alphaColorSlider.Location = new System.Drawing.Point(6, 22);
      this.alphaColorSlider.Name = "alphaColorSlider";
      this.alphaColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.alphaColorSlider.Size = new System.Drawing.Size(60, 195);
      this.alphaColorSlider.TabIndex = 0;
      this.alphaColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.alphaColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.blueRgbColorSlider);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox3.Location = new System.Drawing.Point(159, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(72, 223);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "RgbColorSlider (Blue Channel)";
      // 
      // blueRgbColorSlider
      // 
      this.blueRgbColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.blueRgbColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
      this.blueRgbColorSlider.Location = new System.Drawing.Point(6, 22);
      this.blueRgbColorSlider.Name = "blueRgbColorSlider";
      this.blueRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.blueRgbColorSlider.Size = new System.Drawing.Size(60, 195);
      this.blueRgbColorSlider.TabIndex = 0;
      this.blueRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.blueRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.greenRgbColorSlider);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(81, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(72, 223);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "RgbColorSlider (Green Channel)";
      // 
      // greenRgbColorSlider
      // 
      this.greenRgbColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.greenRgbColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
      this.greenRgbColorSlider.Location = new System.Drawing.Point(6, 22);
      this.greenRgbColorSlider.Name = "greenRgbColorSlider";
      this.greenRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.greenRgbColorSlider.Size = new System.Drawing.Size(60, 195);
      this.greenRgbColorSlider.TabIndex = 0;
      this.greenRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.greenRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.redRgbColorSlider);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(72, 223);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "RgbColorSlider (Red Channel)";
      // 
      // redRgbColorSlider
      // 
      this.redRgbColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.redRgbColorSlider.Location = new System.Drawing.Point(6, 22);
      this.redRgbColorSlider.Name = "redRgbColorSlider";
      this.redRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.redRgbColorSlider.Size = new System.Drawing.Size(60, 195);
      this.redRgbColorSlider.TabIndex = 0;
      this.redRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      this.redRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
      // 
      // eventsListBox
      // 
      this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.eventsListBox.FormattingEnabled = true;
      this.eventsListBox.IntegralHeight = false;
      this.eventsListBox.ItemHeight = 15;
      this.eventsListBox.Location = new System.Drawing.Point(0, 0);
      this.eventsListBox.Name = "eventsListBox";
      this.eventsListBox.Size = new System.Drawing.Size(547, 116);
      this.eventsListBox.TabIndex = 0;
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.SelectedObject = this.alphaColorSlider;
      this.propertyGrid.Size = new System.Drawing.Size(296, 349);
      this.propertyGrid.TabIndex = 0;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(847, 24);
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
      // ColorSliderDemonstrationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(847, 373);
      this.Controls.Add(this.propertiesSplitContainer);
      this.Controls.Add(this.menuStrip);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.Name = "ColorSliderDemonstrationForm";
      this.Text = "ColorSlider Controls Demonstration";
      this.propertiesSplitContainer.Panel1.ResumeLayout(false);
      this.propertiesSplitContainer.Panel2.ResumeLayout(false);
      this.propertiesSplitContainer.ResumeLayout(false);
      this.eventsSplitContainer.Panel1.ResumeLayout(false);
      this.eventsSplitContainer.Panel2.ResumeLayout(false);
      this.eventsSplitContainer.ResumeLayout(false);
      this.tableLayoutPanel.ResumeLayout(false);
      this.groupBox7.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer propertiesSplitContainer;
    private RgbaColorSlider redRgbColorSlider;
    private HueColorSlider hueColorSlider;
    private RgbaColorSlider alphaColorSlider;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private GroupBox groupBox1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private GroupBox groupBox7;
    private GroupBox groupBox6;
    private GroupBox groupBox5;
    private GroupBox groupBox4;
    private GroupBox groupBox3;
    private GroupBox groupBox2;
    private SaturationColorSlider saturationColorSlider;
    private LightnessColorSlider lightnessColorSlider;
    private RgbaColorSlider blueRgbColorSlider;
    private RgbaColorSlider greenRgbColorSlider;
    private System.Windows.Forms.SplitContainer eventsSplitContainer;
    private EventsListBox eventsListBox;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;


  }
}