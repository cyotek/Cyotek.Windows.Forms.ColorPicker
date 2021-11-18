namespace Cyotek.Windows.Forms.Demo
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
            this.colorPreviewBox = new Cyotek.Windows.Forms.ColorPreviewBox();
            this.groupBox3 = new Cyotek.Windows.Forms.GroupBox();
            this.addCustomColorsButton = new System.Windows.Forms.Button();
            this.resetCustomColorsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new Cyotek.Windows.Forms.GroupBox();
            this.alphaRangeButton = new System.Windows.Forms.Button();
            this.shadesOfGreenButton = new System.Windows.Forms.Button();
            this.shadesOfRedButton = new System.Windows.Forms.Button();
            this.shadesOfBlueButton = new System.Windows.Forms.Button();
            this.grayScaleButton = new System.Windows.Forms.Button();
            this.groupBox1 = new Cyotek.Windows.Forms.GroupBox();
            this.namedColorsButton = new System.Windows.Forms.Button();
            this.webSafeColorsButton = new System.Windows.Forms.Button();
            this.vga256ColorsButton = new System.Windows.Forms.Button();
            this.paintNetPaletteButton = new System.Windows.Forms.Button();
            this.hexagonPaletteButton = new System.Windows.Forms.Button();
            this.standardColorsButton = new System.Windows.Forms.Button();
            this.office2010Button = new System.Windows.Forms.Button();
            this.addNewColorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).BeginInit();
            this.propertiesSplitContainer.Panel1.SuspendLayout();
            this.propertiesSplitContainer.Panel2.SuspendLayout();
            this.propertiesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).BeginInit();
            this.optionsSplitContainer.Panel1.SuspendLayout();
            this.optionsSplitContainer.Panel2.SuspendLayout();
            this.optionsSplitContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertiesSplitContainer
            // 
            this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.propertiesSplitContainer.Location = new System.Drawing.Point(12, 12);
            this.propertiesSplitContainer.Name = "propertiesSplitContainer";
            // 
            // propertiesSplitContainer.Panel1
            // 
            this.propertiesSplitContainer.Panel1.Controls.Add(this.propertyGrid);
            // 
            // propertiesSplitContainer.Panel2
            // 
            this.propertiesSplitContainer.Panel2.Controls.Add(this.optionsSplitContainer);
            this.propertiesSplitContainer.Size = new System.Drawing.Size(982, 412);
            this.propertiesSplitContainer.SplitterDistance = 300;
            this.propertiesSplitContainer.SplitterWidth = 5;
            this.propertiesSplitContainer.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.colorGrid;
            this.propertyGrid.Size = new System.Drawing.Size(300, 412);
            this.propertyGrid.TabIndex = 0;
            // 
            // colorGrid
            // 
            this.colorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGrid.Location = new System.Drawing.Point(0, 0);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(6);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Standard256;
            this.colorGrid.Size = new System.Drawing.Size(374, 412);
            this.colorGrid.TabIndex = 0;
            this.colorGrid.ColorChanged += new System.EventHandler(this.ColorGrid_ColorChanged);
            this.colorGrid.ColorIndexChanged += new System.EventHandler(this.ColorGrid_ColorIndexChanged);
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
            this.optionsSplitContainer.Panel2.Controls.Add(this.colorPreviewBox);
            this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox3);
            this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox2);
            this.optionsSplitContainer.Panel2.Controls.Add(this.groupBox1);
            this.optionsSplitContainer.Panel2.Controls.Add(this.addNewColorButton);
            this.optionsSplitContainer.Size = new System.Drawing.Size(677, 412);
            this.optionsSplitContainer.SplitterDistance = 374;
            this.optionsSplitContainer.SplitterWidth = 5;
            this.optionsSplitContainer.TabIndex = 0;
            // 
            // colorPreviewBox
            // 
            this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPreviewBox.Color = System.Drawing.Color.Empty;
            this.colorPreviewBox.Location = new System.Drawing.Point(6, 368);
            this.colorPreviewBox.Name = "colorPreviewBox";
            this.colorPreviewBox.Size = new System.Drawing.Size(286, 41);
            this.colorPreviewBox.TabIndex = 4;
            this.colorPreviewBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.addCustomColorsButton);
            this.groupBox3.Controls.Add(this.resetCustomColorsButton);
            this.groupBox3.Location = new System.Drawing.Point(3, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 55);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom Colors";
            // 
            // addCustomColorsButton
            // 
            this.addCustomColorsButton.Location = new System.Drawing.Point(6, 22);
            this.addCustomColorsButton.Name = "addCustomColorsButton";
            this.addCustomColorsButton.Size = new System.Drawing.Size(75, 23);
            this.addCustomColorsButton.TabIndex = 0;
            this.addCustomColorsButton.Text = "Add Custom Colors";
            this.addCustomColorsButton.UseVisualStyleBackColor = true;
            this.addCustomColorsButton.Click += new System.EventHandler(this.AddCustomColorsButton_Click);
            // 
            // resetCustomColorsButton
            // 
            this.resetCustomColorsButton.Location = new System.Drawing.Point(87, 22);
            this.resetCustomColorsButton.Name = "resetCustomColorsButton";
            this.resetCustomColorsButton.Size = new System.Drawing.Size(75, 23);
            this.resetCustomColorsButton.TabIndex = 1;
            this.resetCustomColorsButton.Text = "Clear";
            this.resetCustomColorsButton.UseVisualStyleBackColor = true;
            this.resetCustomColorsButton.Click += new System.EventHandler(this.ResetCustomColorsButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.alphaRangeButton);
            this.groupBox2.Controls.Add(this.shadesOfGreenButton);
            this.groupBox2.Controls.Add(this.shadesOfRedButton);
            this.groupBox2.Controls.Add(this.shadesOfBlueButton);
            this.groupBox2.Controls.Add(this.grayScaleButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 82);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dynamically Generated Color Palettes";
            // 
            // alphaRangeButton
            // 
            this.alphaRangeButton.Location = new System.Drawing.Point(87, 48);
            this.alphaRangeButton.Name = "alphaRangeButton";
            this.alphaRangeButton.Size = new System.Drawing.Size(75, 23);
            this.alphaRangeButton.TabIndex = 4;
            this.alphaRangeButton.Text = "Alpha";
            this.alphaRangeButton.UseVisualStyleBackColor = true;
            this.alphaRangeButton.Click += new System.EventHandler(this.AlphaRangeButton_Click);
            // 
            // shadesOfGreenButton
            // 
            this.shadesOfGreenButton.Location = new System.Drawing.Point(87, 19);
            this.shadesOfGreenButton.Name = "shadesOfGreenButton";
            this.shadesOfGreenButton.Size = new System.Drawing.Size(75, 23);
            this.shadesOfGreenButton.TabIndex = 1;
            this.shadesOfGreenButton.Text = "Green";
            this.shadesOfGreenButton.UseVisualStyleBackColor = true;
            this.shadesOfGreenButton.Click += new System.EventHandler(this.ShadesOfGreenButton_Click);
            // 
            // shadesOfRedButton
            // 
            this.shadesOfRedButton.Location = new System.Drawing.Point(6, 19);
            this.shadesOfRedButton.Name = "shadesOfRedButton";
            this.shadesOfRedButton.Size = new System.Drawing.Size(75, 23);
            this.shadesOfRedButton.TabIndex = 0;
            this.shadesOfRedButton.Text = "Red";
            this.shadesOfRedButton.UseVisualStyleBackColor = true;
            this.shadesOfRedButton.Click += new System.EventHandler(this.ShadesOfRedButton_Click);
            // 
            // shadesOfBlueButton
            // 
            this.shadesOfBlueButton.Location = new System.Drawing.Point(168, 19);
            this.shadesOfBlueButton.Name = "shadesOfBlueButton";
            this.shadesOfBlueButton.Size = new System.Drawing.Size(75, 23);
            this.shadesOfBlueButton.TabIndex = 2;
            this.shadesOfBlueButton.Text = "Blue";
            this.shadesOfBlueButton.UseVisualStyleBackColor = true;
            this.shadesOfBlueButton.Click += new System.EventHandler(this.ShadesOfBlueButton_Click);
            // 
            // grayScaleButton
            // 
            this.grayScaleButton.Location = new System.Drawing.Point(6, 48);
            this.grayScaleButton.Name = "grayScaleButton";
            this.grayScaleButton.Size = new System.Drawing.Size(75, 23);
            this.grayScaleButton.TabIndex = 3;
            this.grayScaleButton.Text = "Grayscale";
            this.grayScaleButton.UseVisualStyleBackColor = true;
            this.grayScaleButton.Click += new System.EventHandler(this.GrayScaleButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.namedColorsButton);
            this.groupBox1.Controls.Add(this.webSafeColorsButton);
            this.groupBox1.Controls.Add(this.vga256ColorsButton);
            this.groupBox1.Controls.Add(this.paintNetPaletteButton);
            this.groupBox1.Controls.Add(this.hexagonPaletteButton);
            this.groupBox1.Controls.Add(this.standardColorsButton);
            this.groupBox1.Controls.Add(this.office2010Button);
            this.groupBox1.Location = new System.Drawing.Point(3, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pre-defined Color Palettes";
            // 
            // namedColorsButton
            // 
            this.namedColorsButton.Location = new System.Drawing.Point(6, 77);
            this.namedColorsButton.Name = "namedColorsButton";
            this.namedColorsButton.Size = new System.Drawing.Size(75, 23);
            this.namedColorsButton.TabIndex = 6;
            this.namedColorsButton.Text = ".NET";
            this.namedColorsButton.UseVisualStyleBackColor = true;
            this.namedColorsButton.Click += new System.EventHandler(this.NamedColorsButton_Click);
            // 
            // webSafeColorsButton
            // 
            this.webSafeColorsButton.Location = new System.Drawing.Point(87, 48);
            this.webSafeColorsButton.Name = "webSafeColorsButton";
            this.webSafeColorsButton.Size = new System.Drawing.Size(75, 23);
            this.webSafeColorsButton.TabIndex = 4;
            this.webSafeColorsButton.Text = "Web Safe";
            this.webSafeColorsButton.UseVisualStyleBackColor = true;
            this.webSafeColorsButton.Click += new System.EventHandler(this.WebSafeColorsButton_Click);
            // 
            // vga256ColorsButton
            // 
            this.vga256ColorsButton.Location = new System.Drawing.Point(87, 19);
            this.vga256ColorsButton.Name = "vga256ColorsButton";
            this.vga256ColorsButton.Size = new System.Drawing.Size(75, 23);
            this.vga256ColorsButton.TabIndex = 1;
            this.vga256ColorsButton.Text = "Windows";
            this.vga256ColorsButton.UseVisualStyleBackColor = true;
            this.vga256ColorsButton.Click += new System.EventHandler(this.Vga256ColorsButton_Click);
            // 
            // paintNetPaletteButton
            // 
            this.paintNetPaletteButton.Location = new System.Drawing.Point(6, 48);
            this.paintNetPaletteButton.Name = "paintNetPaletteButton";
            this.paintNetPaletteButton.Size = new System.Drawing.Size(75, 23);
            this.paintNetPaletteButton.TabIndex = 3;
            this.paintNetPaletteButton.Text = "Paint.NET";
            this.paintNetPaletteButton.UseVisualStyleBackColor = true;
            this.paintNetPaletteButton.Click += new System.EventHandler(this.PaintNetPaletteButton_Click);
            // 
            // hexagonPaletteButton
            // 
            this.hexagonPaletteButton.Location = new System.Drawing.Point(168, 19);
            this.hexagonPaletteButton.Name = "hexagonPaletteButton";
            this.hexagonPaletteButton.Size = new System.Drawing.Size(75, 23);
            this.hexagonPaletteButton.TabIndex = 2;
            this.hexagonPaletteButton.Text = "Hexagon";
            this.hexagonPaletteButton.UseVisualStyleBackColor = true;
            this.hexagonPaletteButton.Click += new System.EventHandler(this.HexagonPaletteButton_Click);
            // 
            // standardColorsButton
            // 
            this.standardColorsButton.Location = new System.Drawing.Point(6, 19);
            this.standardColorsButton.Name = "standardColorsButton";
            this.standardColorsButton.Size = new System.Drawing.Size(75, 23);
            this.standardColorsButton.TabIndex = 0;
            this.standardColorsButton.Text = "QB Colors";
            this.standardColorsButton.UseVisualStyleBackColor = true;
            this.standardColorsButton.Click += new System.EventHandler(this.StandardColorsButton_Click);
            // 
            // office2010Button
            // 
            this.office2010Button.Location = new System.Drawing.Point(168, 48);
            this.office2010Button.Name = "office2010Button";
            this.office2010Button.Size = new System.Drawing.Size(75, 23);
            this.office2010Button.TabIndex = 5;
            this.office2010Button.Text = "Office 2010";
            this.office2010Button.UseVisualStyleBackColor = true;
            this.office2010Button.Click += new System.EventHandler(this.Office2010Button_Click);
            // 
            // addNewColorButton
            // 
            this.addNewColorButton.Location = new System.Drawing.Point(3, 3);
            this.addNewColorButton.Name = "addNewColorButton";
            this.addNewColorButton.Size = new System.Drawing.Size(75, 23);
            this.addNewColorButton.TabIndex = 0;
            this.addNewColorButton.Text = "Random Color";
            this.addNewColorButton.UseVisualStyleBackColor = true;
            this.addNewColorButton.Click += new System.EventHandler(this.AddNewColorButton_Click);
            // 
            // ColorGridDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 474);
            this.Controls.Add(this.propertiesSplitContainer);
            this.Name = "ColorGridDemoForm";
            this.Text = "ColorGrid Control Demonstration";
            this.Controls.SetChildIndex(this.propertiesSplitContainer, 0);
            this.propertiesSplitContainer.Panel1.ResumeLayout(false);
            this.propertiesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).EndInit();
            this.propertiesSplitContainer.ResumeLayout(false);
            this.optionsSplitContainer.Panel1.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
            this.optionsSplitContainer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
    private System.Windows.Forms.Button hexagonPaletteButton;
    private GroupBox groupBox1;
    private GroupBox groupBox3;
    private GroupBox groupBox2;
    private System.Windows.Forms.Button paintNetPaletteButton;
    private System.Windows.Forms.Button vga256ColorsButton;
    private System.Windows.Forms.Button webSafeColorsButton;
    private System.Windows.Forms.Button alphaRangeButton;
    private ColorPreviewBox colorPreviewBox;
    private System.Windows.Forms.Button namedColorsButton;
  }
}
