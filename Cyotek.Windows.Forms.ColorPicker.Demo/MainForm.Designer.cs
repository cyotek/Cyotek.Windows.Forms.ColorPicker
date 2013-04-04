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
      this.aboutButton = new System.Windows.Forms.Button();
      this.exitButton = new System.Windows.Forms.Button();
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
      // aboutButton
      // 
      this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.aboutButton.Location = new System.Drawing.Point(276, 296);
      this.aboutButton.Name = "aboutButton";
      this.aboutButton.Size = new System.Drawing.Size(87, 27);
      this.aboutButton.TabIndex = 1;
      this.aboutButton.Text = "&About";
      this.aboutButton.UseVisualStyleBackColor = true;
      this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
      // 
      // exitButton
      // 
      this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.exitButton.Location = new System.Drawing.Point(370, 296);
      this.exitButton.Name = "exitButton";
      this.exitButton.Size = new System.Drawing.Size(87, 27);
      this.exitButton.TabIndex = 2;
      this.exitButton.Text = "Close";
      this.exitButton.UseVisualStyleBackColor = true;
      this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
      // 
      // colorGridDemoButton
      // 
      this.colorGridDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorGridDemoButton.Location = new System.Drawing.Point(73, 22);
      this.colorGridDemoButton.Name = "colorGridDemoButton";
      this.colorGridDemoButton.Size = new System.Drawing.Size(364, 27);
      this.colorGridDemoButton.TabIndex = 0;
      this.colorGridDemoButton.Text = "Color&Grid Control Demonstration";
      this.colorGridDemoButton.UseVisualStyleBackColor = true;
      this.colorGridDemoButton.Click += new System.EventHandler(this.colorGridDemoButton_Click);
      // 
      // screenColorPickerDemoButton
      // 
      this.screenColorPickerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.screenColorPickerDemoButton.Location = new System.Drawing.Point(74, 55);
      this.screenColorPickerDemoButton.Name = "screenColorPickerDemoButton";
      this.screenColorPickerDemoButton.Size = new System.Drawing.Size(363, 27);
      this.screenColorPickerDemoButton.TabIndex = 1;
      this.screenColorPickerDemoButton.Text = "&ScreenColorPicker Control Demonstration";
      this.screenColorPickerDemoButton.UseVisualStyleBackColor = true;
      this.screenColorPickerDemoButton.Click += new System.EventHandler(this.screenColorPickerDemoButton_Click);
      // 
      // colorWheelDemoButton
      // 
      this.colorWheelDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorWheelDemoButton.Location = new System.Drawing.Point(74, 89);
      this.colorWheelDemoButton.Name = "colorWheelDemoButton";
      this.colorWheelDemoButton.Size = new System.Drawing.Size(363, 27);
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
      this.groupBox1.Image = global::Cyotek.Windows.Forms.ColorPicker.Demo.Properties.Resources.icon;
      this.groupBox1.Location = new System.Drawing.Point(14, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(444, 275);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Available Demonstrations";
      // 
      // colorPickerFormDemoButton
      // 
      this.colorPickerFormDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorPickerFormDemoButton.Location = new System.Drawing.Point(73, 221);
      this.colorPickerFormDemoButton.Name = "colorPickerFormDemoButton";
      this.colorPickerFormDemoButton.Size = new System.Drawing.Size(363, 27);
      this.colorPickerFormDemoButton.TabIndex = 6;
      this.colorPickerFormDemoButton.Text = "Color&PickerDialog Form Demonstration";
      this.colorPickerFormDemoButton.UseVisualStyleBackColor = true;
      this.colorPickerFormDemoButton.Click += new System.EventHandler(this.colorPickerFormDemoButton_Click);
      // 
      // colorSliderDemoButton
      // 
      this.colorSliderDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorSliderDemoButton.Location = new System.Drawing.Point(73, 188);
      this.colorSliderDemoButton.Name = "colorSliderDemoButton";
      this.colorSliderDemoButton.Size = new System.Drawing.Size(363, 27);
      this.colorSliderDemoButton.TabIndex = 5;
      this.colorSliderDemoButton.Text = "Color&Slider Controls Demonstration";
      this.colorSliderDemoButton.UseVisualStyleBackColor = true;
      this.colorSliderDemoButton.Click += new System.EventHandler(this.colorSliderDemoButton_Click);
      // 
      // colorEditorDemoButton
      // 
      this.colorEditorDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorEditorDemoButton.Location = new System.Drawing.Point(73, 155);
      this.colorEditorDemoButton.Name = "colorEditorDemoButton";
      this.colorEditorDemoButton.Size = new System.Drawing.Size(363, 27);
      this.colorEditorDemoButton.TabIndex = 4;
      this.colorEditorDemoButton.Text = "Color&Editor Control Demonstration";
      this.colorEditorDemoButton.UseVisualStyleBackColor = true;
      this.colorEditorDemoButton.Click += new System.EventHandler(this.colorEditorDemoButton_Click);
      // 
      // colorEditorManagerDemoButton
      // 
      this.colorEditorManagerDemoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.colorEditorManagerDemoButton.Location = new System.Drawing.Point(73, 122);
      this.colorEditorManagerDemoButton.Name = "colorEditorManagerDemoButton";
      this.colorEditorManagerDemoButton.Size = new System.Drawing.Size(363, 27);
      this.colorEditorManagerDemoButton.TabIndex = 3;
      this.colorEditorManagerDemoButton.Text = "ColorEditor&Manager Component Demonstration";
      this.colorEditorManagerDemoButton.UseVisualStyleBackColor = true;
      this.colorEditorManagerDemoButton.Click += new System.EventHandler(this.colorEditorManagerDemoButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.exitButton;
      this.ClientSize = new System.Drawing.Size(472, 336);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.exitButton);
      this.Controls.Add(this.aboutButton);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Cyotek ColorPicker Controls for Windows Forms";
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button aboutButton;
    private System.Windows.Forms.Button exitButton;
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

