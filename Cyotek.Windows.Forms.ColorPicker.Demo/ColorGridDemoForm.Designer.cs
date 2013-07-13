namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorGridDemoForm
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
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
      this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
      this.groupBox4 = new Cyotek.Windows.Forms.GroupBox();
      this.paintNetPaletteFileButton = new System.Windows.Forms.Button();
      this.jascPaletteFileButton = new System.Windows.Forms.Button();
      this.groupBox3 = new Cyotek.Windows.Forms.GroupBox();
      this.addCustomColorsButton = new System.Windows.Forms.Button();
      this.resetCustomColorsButton = new System.Windows.Forms.Button();
      this.groupBox2 = new Cyotek.Windows.Forms.GroupBox();
      this.shadesOfGreenButton = new System.Windows.Forms.Button();
      this.shadesOfRedButton = new System.Windows.Forms.Button();
      this.shadesOfBlueButton = new System.Windows.Forms.Button();
      this.grayScaleButton = new System.Windows.Forms.Button();
      this.groupBox1 = new Cyotek.Windows.Forms.GroupBox();
      this.paintNetPaletteButton = new System.Windows.Forms.Button();
      this.hexagonPaletteButton = new System.Windows.Forms.Button();
      this.standardColorsButton = new System.Windows.Forms.Button();
      this.office2010Button = new System.Windows.Forms.Button();
      this.addNewColorButton = new System.Windows.Forms.Button();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.colorToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadGimpPaletteButton = new System.Windows.Forms.Button();
      this.propertiesSplitContainer.Panel1.SuspendLayout();
      this.propertiesSplitContainer.Panel2.SuspendLayout();
      this.propertiesSplitContainer.SuspendLayout();
      this.optionsSplitContainer.Panel1.SuspendLayout();
      this.optionsSplitContainer.Panel2.SuspendLayout();
      this.optionsSplitContainer.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
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
      this.propertiesSplitContainer.Size = new System.Drawing.Size(1006, 428);
      this.propertiesSplitContainer.SplitterDistance = 334;
      this.propertiesSplitContainer.SplitterWidth = 5;
      this.propertiesSplitContainer.TabIndex = 1;
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.SelectedObject = this.colorGrid;
      this.propertyGrid.Size = new System.Drawing.Size(334, 428);
      this.propertyGrid.TabIndex = 0;
      // 
      // colorGrid
      // 
      this.colorGrid.Location = new System.Drawing.Point(3, 3);
      this.colorGrid.Name = "colorGrid";
      this.colorGrid.Padding = new System.Windows.Forms.Padding(6);
      this.colorGrid.Size = new System.Drawing.Size(249, 182);
      this.colorGrid.TabIndex = 0;
      this.colorGrid.ColorChanged += new System.EventHandler(this.colorGrid_ColorChanged);
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
      this.optionsSplitContainer.Panel1.Controls.Add(this.colorGrid);
      // 
      // optionsSplitContainer.Panel2
      // 
      this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox4);
      this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox3);
      this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox2);
      this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox1);
      this.optionsSplitContainer.Panel2.Controls.Add(this.addNewColorButton);
      this.optionsSplitContainer.Size = new System.Drawing.Size(667, 428);
      this.optionsSplitContainer.SplitterDistance = 291;
      this.optionsSplitContainer.SplitterWidth = 5;
      this.optionsSplitContainer.TabIndex = 0;
      // 
      // groupBox4
      // 
      this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox4.Controls.Add(this.loadGimpPaletteButton);
      this.groupBox4.Controls.Add(this.paintNetPaletteFileButton);
      this.groupBox4.Controls.Add(this.jascPaletteFileButton);
      this.groupBox4.Location = new System.Drawing.Point(3, 315);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(365, 94);
      this.groupBox4.TabIndex = 4;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "External Palette Files";
      // 
      // paintNetPaletteFileButton
      // 
      this.paintNetPaletteFileButton.Location = new System.Drawing.Point(6, 22);
      this.paintNetPaletteFileButton.Name = "paintNetPaletteFileButton";
      this.paintNetPaletteFileButton.Size = new System.Drawing.Size(138, 27);
      this.paintNetPaletteFileButton.TabIndex = 0;
      this.paintNetPaletteFileButton.Text = "Paint.NET";
      this.paintNetPaletteFileButton.UseVisualStyleBackColor = true;
      this.paintNetPaletteFileButton.Click += new System.EventHandler(this.paintNetPaletteFileButton_Click);
      // 
      // jascPaletteFileButton
      // 
      this.jascPaletteFileButton.Location = new System.Drawing.Point(151, 22);
      this.jascPaletteFileButton.Name = "jascPaletteFileButton";
      this.jascPaletteFileButton.Size = new System.Drawing.Size(138, 27);
      this.jascPaletteFileButton.TabIndex = 1;
      this.jascPaletteFileButton.Text = "JASC 1.0";
      this.jascPaletteFileButton.UseVisualStyleBackColor = true;
      this.jascPaletteFileButton.Click += new System.EventHandler(this.jascPaletteFileButton_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.addCustomColorsButton);
      this.groupBox3.Controls.Add(this.resetCustomColorsButton);
      this.groupBox3.Location = new System.Drawing.Point(3, 49);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(365, 60);
      this.groupBox3.TabIndex = 1;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Custom Colors";
      // 
      // addCustomColorsButton
      // 
      this.addCustomColorsButton.Location = new System.Drawing.Point(6, 22);
      this.addCustomColorsButton.Name = "addCustomColorsButton";
      this.addCustomColorsButton.Size = new System.Drawing.Size(138, 27);
      this.addCustomColorsButton.TabIndex = 0;
      this.addCustomColorsButton.Text = "Add Custom Colors";
      this.addCustomColorsButton.UseVisualStyleBackColor = true;
      this.addCustomColorsButton.Click += new System.EventHandler(this.addCustomColorsButton_Click);
      // 
      // resetCustomColorsButton
      // 
      this.resetCustomColorsButton.Location = new System.Drawing.Point(150, 22);
      this.resetCustomColorsButton.Name = "resetCustomColorsButton";
      this.resetCustomColorsButton.Size = new System.Drawing.Size(138, 27);
      this.resetCustomColorsButton.TabIndex = 1;
      this.resetCustomColorsButton.Text = "Reset Custom Colors";
      this.resetCustomColorsButton.UseVisualStyleBackColor = true;
      this.resetCustomColorsButton.Click += new System.EventHandler(this.resetCustomColorsButton_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.shadesOfGreenButton);
      this.groupBox2.Controls.Add(this.shadesOfRedButton);
      this.groupBox2.Controls.Add(this.shadesOfBlueButton);
      this.groupBox2.Controls.Add(this.grayScaleButton);
      this.groupBox2.Location = new System.Drawing.Point(3, 215);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(365, 94);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Dynamically Generated Color Palettes";
      // 
      // shadesOfGreenButton
      // 
      this.shadesOfGreenButton.Location = new System.Drawing.Point(6, 22);
      this.shadesOfGreenButton.Name = "shadesOfGreenButton";
      this.shadesOfGreenButton.Size = new System.Drawing.Size(138, 27);
      this.shadesOfGreenButton.TabIndex = 0;
      this.shadesOfGreenButton.Text = "Shades of Green";
      this.shadesOfGreenButton.UseVisualStyleBackColor = true;
      this.shadesOfGreenButton.Click += new System.EventHandler(this.shadesOfGreenButton_Click);
      // 
      // shadesOfRedButton
      // 
      this.shadesOfRedButton.Location = new System.Drawing.Point(151, 22);
      this.shadesOfRedButton.Name = "shadesOfRedButton";
      this.shadesOfRedButton.Size = new System.Drawing.Size(138, 27);
      this.shadesOfRedButton.TabIndex = 1;
      this.shadesOfRedButton.Text = "Shades of Red";
      this.shadesOfRedButton.UseVisualStyleBackColor = true;
      this.shadesOfRedButton.Click += new System.EventHandler(this.shadesOfRedButton_Click);
      // 
      // shadesOfBlueButton
      // 
      this.shadesOfBlueButton.Location = new System.Drawing.Point(6, 55);
      this.shadesOfBlueButton.Name = "shadesOfBlueButton";
      this.shadesOfBlueButton.Size = new System.Drawing.Size(138, 27);
      this.shadesOfBlueButton.TabIndex = 2;
      this.shadesOfBlueButton.Text = "Shades of Blue";
      this.shadesOfBlueButton.UseVisualStyleBackColor = true;
      this.shadesOfBlueButton.Click += new System.EventHandler(this.shadesOfBlueButton_Click);
      // 
      // grayScaleButton
      // 
      this.grayScaleButton.Location = new System.Drawing.Point(151, 55);
      this.grayScaleButton.Name = "grayScaleButton";
      this.grayScaleButton.Size = new System.Drawing.Size(138, 27);
      this.grayScaleButton.TabIndex = 3;
      this.grayScaleButton.Text = "Grayscale";
      this.grayScaleButton.UseVisualStyleBackColor = true;
      this.grayScaleButton.Click += new System.EventHandler(this.grayScaleButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.paintNetPaletteButton);
      this.groupBox1.Controls.Add(this.hexagonPaletteButton);
      this.groupBox1.Controls.Add(this.standardColorsButton);
      this.groupBox1.Controls.Add(this.office2010Button);
      this.groupBox1.Location = new System.Drawing.Point(3, 115);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(365, 94);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Pre-defined Color Palettes";
      // 
      // paintNetPaletteButton
      // 
      this.paintNetPaletteButton.Location = new System.Drawing.Point(151, 55);
      this.paintNetPaletteButton.Name = "paintNetPaletteButton";
      this.paintNetPaletteButton.Size = new System.Drawing.Size(138, 27);
      this.paintNetPaletteButton.TabIndex = 3;
      this.paintNetPaletteButton.Text = "Paint.NET";
      this.paintNetPaletteButton.UseVisualStyleBackColor = true;
      this.paintNetPaletteButton.Click += new System.EventHandler(this.paintNetPaletteButton_Click);
      // 
      // hexagonPaletteButton
      // 
      this.hexagonPaletteButton.Location = new System.Drawing.Point(6, 55);
      this.hexagonPaletteButton.Name = "hexagonPaletteButton";
      this.hexagonPaletteButton.Size = new System.Drawing.Size(138, 27);
      this.hexagonPaletteButton.TabIndex = 2;
      this.hexagonPaletteButton.Text = "Hexagon";
      this.hexagonPaletteButton.UseVisualStyleBackColor = true;
      this.hexagonPaletteButton.Click += new System.EventHandler(this.hexagonPaletteButton_Click);
      // 
      // standardColorsButton
      // 
      this.standardColorsButton.Location = new System.Drawing.Point(6, 22);
      this.standardColorsButton.Name = "standardColorsButton";
      this.standardColorsButton.Size = new System.Drawing.Size(138, 27);
      this.standardColorsButton.TabIndex = 0;
      this.standardColorsButton.Text = "Standard Colors";
      this.standardColorsButton.UseVisualStyleBackColor = true;
      this.standardColorsButton.Click += new System.EventHandler(this.standardColorsButton_Click);
      // 
      // office2010Button
      // 
      this.office2010Button.Location = new System.Drawing.Point(151, 22);
      this.office2010Button.Name = "office2010Button";
      this.office2010Button.Size = new System.Drawing.Size(138, 27);
      this.office2010Button.TabIndex = 1;
      this.office2010Button.Text = "Office 2010";
      this.office2010Button.UseVisualStyleBackColor = true;
      this.office2010Button.Click += new System.EventHandler(this.office2010Button_Click);
      // 
      // addNewColorButton
      // 
      this.addNewColorButton.Location = new System.Drawing.Point(3, 12);
      this.addNewColorButton.Name = "addNewColorButton";
      this.addNewColorButton.Size = new System.Drawing.Size(138, 27);
      this.addNewColorButton.TabIndex = 0;
      this.addNewColorButton.Text = "Random Color";
      this.addNewColorButton.UseVisualStyleBackColor = true;
      this.addNewColorButton.Click += new System.EventHandler(this.addNewColorButton_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripStatusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 452);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
      this.statusStrip1.Size = new System.Drawing.Size(1006, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
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
      this.menuStrip.Size = new System.Drawing.Size(1006, 24);
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
      // loadGimpPaletteButton
      // 
      this.loadGimpPaletteButton.Location = new System.Drawing.Point(6, 55);
      this.loadGimpPaletteButton.Name = "loadGimpPaletteButton";
      this.loadGimpPaletteButton.Size = new System.Drawing.Size(138, 27);
      this.loadGimpPaletteButton.TabIndex = 2;
      this.loadGimpPaletteButton.Text = "Gimp";
      this.loadGimpPaletteButton.UseVisualStyleBackColor = true;
      this.loadGimpPaletteButton.Click += new System.EventHandler(this.loadGimpPaletteButton_Click);
      // 
      // ColorGridDemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1006, 474);
      this.Controls.Add(this.propertiesSplitContainer);
      this.Controls.Add(this.menuStrip);
      this.Controls.Add(this.statusStrip1);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.Name = "ColorGridDemoForm";
      this.Text = "ColorGrid Control Demonstration";
      this.propertiesSplitContainer.Panel1.ResumeLayout(false);
      this.propertiesSplitContainer.Panel2.ResumeLayout(false);
      this.propertiesSplitContainer.ResumeLayout(false);
      this.optionsSplitContainer.Panel1.ResumeLayout(false);
      this.optionsSplitContainer.Panel1.PerformLayout();
      this.optionsSplitContainer.Panel2.ResumeLayout(false);
      this.optionsSplitContainer.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer propertiesSplitContainer;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private ColorGrid colorGrid;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
    private System.Windows.Forms.Button addCustomColorsButton;
    private System.Windows.Forms.Button addNewColorButton;
    private System.Windows.Forms.Button shadesOfGreenButton;
    private System.Windows.Forms.Button grayScaleButton;
    private System.Windows.Forms.Button shadesOfBlueButton;
    private System.Windows.Forms.Button shadesOfRedButton;
    private System.Windows.Forms.Button resetCustomColorsButton;
    private System.Windows.Forms.Button standardColorsButton;
    private System.Windows.Forms.Button office2010Button;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel colorToolStripStatusLabel;
    private System.Windows.Forms.Button hexagonPaletteButton;
    private GroupBox groupBox1;
    private GroupBox groupBox3;
    private GroupBox groupBox2;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.Button paintNetPaletteButton;
    private GroupBox groupBox4;
    private System.Windows.Forms.Button paintNetPaletteFileButton;
    private System.Windows.Forms.Button jascPaletteFileButton;
    private System.Windows.Forms.Button loadGimpPaletteButton;
  }
}