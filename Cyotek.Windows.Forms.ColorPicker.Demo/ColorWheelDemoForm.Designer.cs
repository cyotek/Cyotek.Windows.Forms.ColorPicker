namespace Cyotek.Windows.Forms.Demo
{
  partial class ColorWheelDemoForm
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
            System.Windows.Forms.Label demoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorWheelDemoForm));
            Cyotek.Windows.Forms.GroupBox customColorsGroupBox;
            System.Windows.Forms.Button tetradicButton;
            System.Windows.Forms.Button randomButton;
            System.Windows.Forms.Button analogousButton;
            System.Windows.Forms.Button noneButton;
            this.automaticSecondaryCheckBox = new System.Windows.Forms.CheckBox();
            this.propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.colorPreviewBox = new Cyotek.Windows.Forms.ColorPreviewBox();
            demoLabel = new System.Windows.Forms.Label();
            customColorsGroupBox = new Cyotek.Windows.Forms.GroupBox();
            tetradicButton = new System.Windows.Forms.Button();
            randomButton = new System.Windows.Forms.Button();
            analogousButton = new System.Windows.Forms.Button();
            noneButton = new System.Windows.Forms.Button();
            customColorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).BeginInit();
            this.propertiesSplitContainer.Panel1.SuspendLayout();
            this.propertiesSplitContainer.Panel2.SuspendLayout();
            this.propertiesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).BeginInit();
            this.optionsSplitContainer.Panel1.SuspendLayout();
            this.optionsSplitContainer.Panel2.SuspendLayout();
            this.optionsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // demoLabel
            // 
            demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            demoLabel.AutoEllipsis = true;
            demoLabel.BackColor = System.Drawing.SystemColors.Info;
            demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            demoLabel.Location = new System.Drawing.Point(3, 0);
            demoLabel.Name = "demoLabel";
            demoLabel.Padding = new System.Windows.Forms.Padding(9);
            demoLabel.Size = new System.Drawing.Size(260, 224);
            demoLabel.TabIndex = 2;
            demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // customColorsGroupBox
            // 
            customColorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            customColorsGroupBox.Controls.Add(this.automaticSecondaryCheckBox);
            customColorsGroupBox.Controls.Add(tetradicButton);
            customColorsGroupBox.Controls.Add(randomButton);
            customColorsGroupBox.Controls.Add(analogousButton);
            customColorsGroupBox.Controls.Add(noneButton);
            customColorsGroupBox.Location = new System.Drawing.Point(3, 227);
            customColorsGroupBox.Name = "customColorsGroupBox";
            customColorsGroupBox.Size = new System.Drawing.Size(260, 63);
            customColorsGroupBox.TabIndex = 4;
            customColorsGroupBox.TabStop = false;
            customColorsGroupBox.Text = "SecondaryColors";
            // 
            // automaticSecondaryCheckBox
            // 
            this.automaticSecondaryCheckBox.AutoSize = true;
            this.automaticSecondaryCheckBox.Location = new System.Drawing.Point(6, 45);
            this.automaticSecondaryCheckBox.Name = "automaticSecondaryCheckBox";
            this.automaticSecondaryCheckBox.Size = new System.Drawing.Size(73, 17);
            this.automaticSecondaryCheckBox.TabIndex = 4;
            this.automaticSecondaryCheckBox.Text = "Automatic";
            this.automaticSecondaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // tetradicButton
            // 
            tetradicButton.Location = new System.Drawing.Point(146, 19);
            tetradicButton.Name = "tetradicButton";
            tetradicButton.Size = new System.Drawing.Size(64, 20);
            tetradicButton.TabIndex = 3;
            tetradicButton.Text = "Tetradic";
            tetradicButton.UseVisualStyleBackColor = true;
            tetradicButton.Click += new System.EventHandler(this.TetradicButton_Click);
            // 
            // randomButton
            // 
            randomButton.Location = new System.Drawing.Point(216, 19);
            randomButton.Name = "randomButton";
            randomButton.Size = new System.Drawing.Size(64, 20);
            randomButton.TabIndex = 2;
            randomButton.Text = "Random";
            randomButton.UseVisualStyleBackColor = true;
            randomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // analogousButton
            // 
            analogousButton.Location = new System.Drawing.Point(76, 19);
            analogousButton.Name = "analogousButton";
            analogousButton.Size = new System.Drawing.Size(64, 20);
            analogousButton.TabIndex = 1;
            analogousButton.Text = "Analogous";
            analogousButton.UseVisualStyleBackColor = true;
            analogousButton.Click += new System.EventHandler(this.AnalogousButton_Click);
            // 
            // noneButton
            // 
            noneButton.Location = new System.Drawing.Point(6, 19);
            noneButton.Name = "noneButton";
            noneButton.Size = new System.Drawing.Size(64, 20);
            noneButton.TabIndex = 0;
            noneButton.Text = "None";
            noneButton.UseVisualStyleBackColor = true;
            noneButton.Click += new System.EventHandler(this.NoneButton_Click);
            // 
            // propertiesSplitContainer
            // 
            this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.propertiesSplitContainer.Size = new System.Drawing.Size(826, 339);
            this.propertiesSplitContainer.SplitterDistance = 248;
            this.propertiesSplitContainer.SplitterWidth = 5;
            this.propertiesSplitContainer.TabIndex = 1;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.colorWheel;
            this.propertyGrid.Size = new System.Drawing.Size(248, 339);
            this.propertyGrid.TabIndex = 0;
            // 
            // colorWheel
            // 
            this.colorWheel.Alpha = 1D;
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(209)))), ((int)(((byte)(202)))));
            this.colorWheel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorWheel.Location = new System.Drawing.Point(0, 0);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(298, 339);
            this.colorWheel.TabIndex = 0;
            this.colorWheel.ColorChanged += new System.EventHandler(this.ColorWheel_ColorChanged);
            // 
            // optionsSplitContainer
            // 
            this.optionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.optionsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.optionsSplitContainer.Name = "optionsSplitContainer";
            // 
            // optionsSplitContainer.Panel1
            // 
            this.optionsSplitContainer.Panel1.Controls.Add(this.colorWheel);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(customColorsGroupBox);
            this.optionsSplitContainer.Panel2.Controls.Add(this.colorPreviewBox);
            this.optionsSplitContainer.Panel2.Controls.Add(demoLabel);
            this.optionsSplitContainer.Size = new System.Drawing.Size(573, 339);
            this.optionsSplitContainer.SplitterDistance = 298;
            this.optionsSplitContainer.SplitterWidth = 5;
            this.optionsSplitContainer.TabIndex = 0;
            // 
            // colorPreviewBox
            // 
            this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPreviewBox.Location = new System.Drawing.Point(3, 295);
            this.colorPreviewBox.Name = "colorPreviewBox";
            this.colorPreviewBox.Size = new System.Drawing.Size(260, 41);
            // 
            // ColorWheelDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 445);
            this.Controls.Add(this.propertiesSplitContainer);
            this.Name = "ColorWheelDemoForm";
            this.Text = "ColorWheel Control Demonstration";
            this.Controls.SetChildIndex(this.propertiesSplitContainer, 0);
            customColorsGroupBox.ResumeLayout(false);
            customColorsGroupBox.PerformLayout();
            this.propertiesSplitContainer.Panel1.ResumeLayout(false);
            this.propertiesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesSplitContainer)).EndInit();
            this.propertiesSplitContainer.ResumeLayout(false);
            this.optionsSplitContainer.Panel1.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
            this.optionsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.SplitContainer propertiesSplitContainer;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private ColorWheel colorWheel;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
    private ColorPreviewBox colorPreviewBox;
    private System.Windows.Forms.CheckBox automaticSecondaryCheckBox;
  }
}
