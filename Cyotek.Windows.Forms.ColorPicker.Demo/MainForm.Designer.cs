namespace Cyotek.Windows.Forms.Demo
{
  partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.colorGridDemoButton = new System.Windows.Forms.Button();
            this.screenColorPickerDemoButton = new System.Windows.Forms.Button();
            this.colorWheelDemoButton = new System.Windows.Forms.Button();
            this.demoGroupBox = new Cyotek.Windows.Forms.GroupBox();
            this.colorGridEditingDemoButton = new System.Windows.Forms.Button();
            this.externalPaletteFilesDemoButton = new System.Windows.Forms.Button();
            this.toolstripDemoButton = new System.Windows.Forms.Button();
            this.colorPickerFormDemoButton = new System.Windows.Forms.Button();
            this.colorSliderDemoButton = new System.Windows.Forms.Button();
            this.colorEditorDemoButton = new System.Windows.Forms.Button();
            this.colorEditorManagerDemoButton = new System.Windows.Forms.Button();
            this.demoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorGridDemoButton
            // 
            this.colorGridDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorGridDemoButton.Location = new System.Drawing.Point(6, 22);
            this.colorGridDemoButton.Name = "colorGridDemoButton";
            this.colorGridDemoButton.Size = new System.Drawing.Size(583, 27);
            this.colorGridDemoButton.TabIndex = 0;
            this.colorGridDemoButton.Text = "Color&Grid Control Demonstration";
            this.colorGridDemoButton.UseVisualStyleBackColor = true;
            this.colorGridDemoButton.Click += new System.EventHandler(this.ColorGridDemoButton_Click);
            // 
            // screenColorPickerDemoButton
            // 
            this.screenColorPickerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenColorPickerDemoButton.Location = new System.Drawing.Point(6, 55);
            this.screenColorPickerDemoButton.Name = "screenColorPickerDemoButton";
            this.screenColorPickerDemoButton.Size = new System.Drawing.Size(584, 27);
            this.screenColorPickerDemoButton.TabIndex = 1;
            this.screenColorPickerDemoButton.Text = "&ScreenColorPicker Control Demonstration";
            this.screenColorPickerDemoButton.UseVisualStyleBackColor = true;
            this.screenColorPickerDemoButton.Click += new System.EventHandler(this.ScreenColorPickerDemoButton_Click);
            // 
            // colorWheelDemoButton
            // 
            this.colorWheelDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorWheelDemoButton.Location = new System.Drawing.Point(6, 89);
            this.colorWheelDemoButton.Name = "colorWheelDemoButton";
            this.colorWheelDemoButton.Size = new System.Drawing.Size(584, 27);
            this.colorWheelDemoButton.TabIndex = 2;
            this.colorWheelDemoButton.Text = "Color&Wheel Control Demonstration";
            this.colorWheelDemoButton.UseVisualStyleBackColor = true;
            this.colorWheelDemoButton.Click += new System.EventHandler(this.ColorWheelDemoButton_Click);
            // 
            // demoGroupBox
            // 
            this.demoGroupBox.Controls.Add(this.colorGridEditingDemoButton);
            this.demoGroupBox.Controls.Add(this.externalPaletteFilesDemoButton);
            this.demoGroupBox.Controls.Add(this.toolstripDemoButton);
            this.demoGroupBox.Controls.Add(this.colorPickerFormDemoButton);
            this.demoGroupBox.Controls.Add(this.colorSliderDemoButton);
            this.demoGroupBox.Controls.Add(this.colorEditorDemoButton);
            this.demoGroupBox.Controls.Add(this.colorEditorManagerDemoButton);
            this.demoGroupBox.Controls.Add(this.colorGridDemoButton);
            this.demoGroupBox.Controls.Add(this.colorWheelDemoButton);
            this.demoGroupBox.Controls.Add(this.screenColorPickerDemoButton);
            this.demoGroupBox.Location = new System.Drawing.Point(28, 82);
            this.demoGroupBox.Name = "demoGroupBox";
            this.demoGroupBox.Size = new System.Drawing.Size(596, 397);
            this.demoGroupBox.TabIndex = 0;
            this.demoGroupBox.TabStop = false;
            this.demoGroupBox.Text = "Available Demonstrations";
            // 
            // colorGridEditingDemoButton
            // 
            this.colorGridEditingDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorGridEditingDemoButton.Location = new System.Drawing.Point(6, 320);
            this.colorGridEditingDemoButton.Name = "colorGridEditingDemoButton";
            this.colorGridEditingDemoButton.Size = new System.Drawing.Size(584, 27);
            this.colorGridEditingDemoButton.TabIndex = 9;
            this.colorGridEditingDemoButton.Text = "ColorGrid E&diting Demonstration";
            this.colorGridEditingDemoButton.UseVisualStyleBackColor = true;
            this.colorGridEditingDemoButton.Click += new System.EventHandler(this.colorGridEditingDemoButton_Click);
            // 
            // externalPaletteFilesDemoButton
            // 
            this.externalPaletteFilesDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.externalPaletteFilesDemoButton.Location = new System.Drawing.Point(6, 287);
            this.externalPaletteFilesDemoButton.Name = "externalPaletteFilesDemoButton";
            this.externalPaletteFilesDemoButton.Size = new System.Drawing.Size(583, 27);
            this.externalPaletteFilesDemoButton.TabIndex = 8;
            this.externalPaletteFilesDemoButton.Text = "E&xternal Palette Files Demonstration";
            this.externalPaletteFilesDemoButton.UseVisualStyleBackColor = true;
            this.externalPaletteFilesDemoButton.Click += new System.EventHandler(this.ExternalPaletteFilesDemoButton_Click);
            // 
            // toolstripDemoButton
            // 
            this.toolstripDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolstripDemoButton.Location = new System.Drawing.Point(6, 254);
            this.toolstripDemoButton.Name = "toolstripDemoButton";
            this.toolstripDemoButton.Size = new System.Drawing.Size(583, 27);
            this.toolstripDemoButton.TabIndex = 7;
            this.toolstripDemoButton.Text = "Using the ColorGrid in a &ToolStrip control";
            this.toolstripDemoButton.UseVisualStyleBackColor = true;
            this.toolstripDemoButton.Click += new System.EventHandler(this.ToolstripDemoButton_Click);
            // 
            // colorPickerFormDemoButton
            // 
            this.colorPickerFormDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPickerFormDemoButton.Location = new System.Drawing.Point(6, 221);
            this.colorPickerFormDemoButton.Name = "colorPickerFormDemoButton";
            this.colorPickerFormDemoButton.Size = new System.Drawing.Size(583, 27);
            this.colorPickerFormDemoButton.TabIndex = 6;
            this.colorPickerFormDemoButton.Text = "Color&PickerDialog Form Demonstration";
            this.colorPickerFormDemoButton.UseVisualStyleBackColor = true;
            this.colorPickerFormDemoButton.Click += new System.EventHandler(this.ColorPickerFormDemoButton_Click);
            // 
            // colorSliderDemoButton
            // 
            this.colorSliderDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSliderDemoButton.Location = new System.Drawing.Point(6, 188);
            this.colorSliderDemoButton.Name = "colorSliderDemoButton";
            this.colorSliderDemoButton.Size = new System.Drawing.Size(583, 27);
            this.colorSliderDemoButton.TabIndex = 5;
            this.colorSliderDemoButton.Text = "Color&Slider Controls Demonstration";
            this.colorSliderDemoButton.UseVisualStyleBackColor = true;
            this.colorSliderDemoButton.Click += new System.EventHandler(this.ColorSliderDemoButton_Click);
            // 
            // colorEditorDemoButton
            // 
            this.colorEditorDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditorDemoButton.Location = new System.Drawing.Point(6, 155);
            this.colorEditorDemoButton.Name = "colorEditorDemoButton";
            this.colorEditorDemoButton.Size = new System.Drawing.Size(583, 27);
            this.colorEditorDemoButton.TabIndex = 4;
            this.colorEditorDemoButton.Text = "Color&Editor Control Demonstration";
            this.colorEditorDemoButton.UseVisualStyleBackColor = true;
            this.colorEditorDemoButton.Click += new System.EventHandler(this.ColorEditorDemoButton_Click);
            // 
            // colorEditorManagerDemoButton
            // 
            this.colorEditorManagerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditorManagerDemoButton.Location = new System.Drawing.Point(6, 122);
            this.colorEditorManagerDemoButton.Name = "colorEditorManagerDemoButton";
            this.colorEditorManagerDemoButton.Size = new System.Drawing.Size(583, 27);
            this.colorEditorManagerDemoButton.TabIndex = 3;
            this.colorEditorManagerDemoButton.Text = "ColorEditor&Manager Component Demonstration";
            this.colorEditorManagerDemoButton.UseVisualStyleBackColor = true;
            this.colorEditorManagerDemoButton.Click += new System.EventHandler(this.ColorEditorManagerDemoButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 541);
            this.Controls.Add(this.demoGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Cyotek Color Picker Controls for Windows Forms";
            this.Controls.SetChildIndex(this.demoGroupBox, 0);
            this.demoGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button colorGridDemoButton;
    private System.Windows.Forms.Button screenColorPickerDemoButton;
    private System.Windows.Forms.Button colorWheelDemoButton;
    private GroupBox demoGroupBox;
    private System.Windows.Forms.Button colorEditorManagerDemoButton;
    private System.Windows.Forms.Button colorEditorDemoButton;
    private System.Windows.Forms.Button colorSliderDemoButton;
    private System.Windows.Forms.Button colorPickerFormDemoButton;
    private System.Windows.Forms.Button toolstripDemoButton;
    private System.Windows.Forms.Button externalPaletteFilesDemoButton;
    private System.Windows.Forms.Button colorGridEditingDemoButton;
  }
}

