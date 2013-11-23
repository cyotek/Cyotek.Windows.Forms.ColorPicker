namespace Cyotek.Windows.Forms.ColorPicker.Demo
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
      this.groupBox1 = new Cyotek.Windows.Forms.GroupBox();
      this.colorPickerFormDemoButton = new System.Windows.Forms.Button();
      this.colorSliderDemoButton = new System.Windows.Forms.Button();
      this.colorEditorDemoButton = new System.Windows.Forms.Button();
      this.colorEditorManagerDemoButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // colorGridDemoButton
      // 
      this.colorGridDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorGridDemoButton.Location = new System.Drawing.Point(6, 22);
      this.colorGridDemoButton.Name = "colorGridDemoButton";
      this.colorGridDemoButton.Size = new System.Drawing.Size(574, 27);
      this.colorGridDemoButton.TabIndex = 0;
      this.colorGridDemoButton.Text = "Color&Grid Control Demonstration";
      this.colorGridDemoButton.UseVisualStyleBackColor = true;
      this.colorGridDemoButton.Click += new System.EventHandler(this.colorGridDemoButton_Click);
      // 
      // screenColorPickerDemoButton
      // 
      this.screenColorPickerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.screenColorPickerDemoButton.Location = new System.Drawing.Point(7, 55);
      this.screenColorPickerDemoButton.Name = "screenColorPickerDemoButton";
      this.screenColorPickerDemoButton.Size = new System.Drawing.Size(573, 27);
      this.screenColorPickerDemoButton.TabIndex = 1;
      this.screenColorPickerDemoButton.Text = "&ScreenColorPicker Control Demonstration";
      this.screenColorPickerDemoButton.UseVisualStyleBackColor = true;
      this.screenColorPickerDemoButton.Click += new System.EventHandler(this.screenColorPickerDemoButton_Click);
      // 
      // colorWheelDemoButton
      // 
      this.colorWheelDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorWheelDemoButton.Location = new System.Drawing.Point(7, 89);
      this.colorWheelDemoButton.Name = "colorWheelDemoButton";
      this.colorWheelDemoButton.Size = new System.Drawing.Size(573, 27);
      this.colorWheelDemoButton.TabIndex = 2;
      this.colorWheelDemoButton.Text = "Color&Wheel Control Demonstration";
      this.colorWheelDemoButton.UseVisualStyleBackColor = true;
      this.colorWheelDemoButton.Click += new System.EventHandler(this.colorWheelDemoButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.colorPickerFormDemoButton);
      this.groupBox1.Controls.Add(this.colorSliderDemoButton);
      this.groupBox1.Controls.Add(this.colorEditorDemoButton);
      this.groupBox1.Controls.Add(this.colorEditorManagerDemoButton);
      this.groupBox1.Controls.Add(this.colorGridDemoButton);
      this.groupBox1.Controls.Add(this.colorWheelDemoButton);
      this.groupBox1.Controls.Add(this.screenColorPickerDemoButton);
      this.groupBox1.Location = new System.Drawing.Point(0, 41);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(587, 326);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Available Demonstrations";
      // 
      // colorPickerFormDemoButton
      // 
      this.colorPickerFormDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorPickerFormDemoButton.Location = new System.Drawing.Point(6, 221);
      this.colorPickerFormDemoButton.Name = "colorPickerFormDemoButton";
      this.colorPickerFormDemoButton.Size = new System.Drawing.Size(573, 27);
      this.colorPickerFormDemoButton.TabIndex = 6;
      this.colorPickerFormDemoButton.Text = "Color&PickerDialog Form Demonstration";
      this.colorPickerFormDemoButton.UseVisualStyleBackColor = true;
      this.colorPickerFormDemoButton.Click += new System.EventHandler(this.colorPickerFormDemoButton_Click);
      // 
      // colorSliderDemoButton
      // 
      this.colorSliderDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorSliderDemoButton.Location = new System.Drawing.Point(6, 188);
      this.colorSliderDemoButton.Name = "colorSliderDemoButton";
      this.colorSliderDemoButton.Size = new System.Drawing.Size(573, 27);
      this.colorSliderDemoButton.TabIndex = 5;
      this.colorSliderDemoButton.Text = "Color&Slider Controls Demonstration";
      this.colorSliderDemoButton.UseVisualStyleBackColor = true;
      this.colorSliderDemoButton.Click += new System.EventHandler(this.colorSliderDemoButton_Click);
      // 
      // colorEditorDemoButton
      // 
      this.colorEditorDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorEditorDemoButton.Location = new System.Drawing.Point(6, 155);
      this.colorEditorDemoButton.Name = "colorEditorDemoButton";
      this.colorEditorDemoButton.Size = new System.Drawing.Size(573, 27);
      this.colorEditorDemoButton.TabIndex = 4;
      this.colorEditorDemoButton.Text = "Color&Editor Control Demonstration";
      this.colorEditorDemoButton.UseVisualStyleBackColor = true;
      this.colorEditorDemoButton.Click += new System.EventHandler(this.colorEditorDemoButton_Click);
      // 
      // colorEditorManagerDemoButton
      // 
      this.colorEditorManagerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorEditorManagerDemoButton.Location = new System.Drawing.Point(6, 122);
      this.colorEditorManagerDemoButton.Name = "colorEditorManagerDemoButton";
      this.colorEditorManagerDemoButton.Size = new System.Drawing.Size(573, 27);
      this.colorEditorManagerDemoButton.TabIndex = 3;
      this.colorEditorManagerDemoButton.Text = "ColorEditor&Manager Component Demonstration";
      this.colorEditorManagerDemoButton.UseVisualStyleBackColor = true;
      this.colorEditorManagerDemoButton.Click += new System.EventHandler(this.colorEditorManagerDemoButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = null;
      this.ClientSize = new System.Drawing.Size(615, 495);
      this.Controls.Add(this.groupBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.Text = "Cyotek ColorPicker Controls for Windows Forms";
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button colorGridDemoButton;
    private System.Windows.Forms.Button screenColorPickerDemoButton;
    private System.Windows.Forms.Button colorWheelDemoButton;
    private GroupBox groupBox1;
    private System.Windows.Forms.Button colorEditorManagerDemoButton;
    private System.Windows.Forms.Button colorEditorDemoButton;
    private System.Windows.Forms.Button colorSliderDemoButton;
    private System.Windows.Forms.Button colorPickerFormDemoButton;



  }
}

