namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorPickerDialogDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPickerDialogDemoForm));
            Cyotek.Windows.Forms.GroupBox previewGroupBox;
            this.dialogColorPreviewPanel = new Cyotek.Windows.Forms.ColorPreviewBox();
            this.browseColorButton = new System.Windows.Forms.Button();
            this.colorPreviewPanel = new Cyotek.Windows.Forms.ColorPreviewBox();
            this.showAlphaChannelCheckBox = new System.Windows.Forms.CheckBox();
            this.preserveAlphaChannelCheckBox = new System.Windows.Forms.CheckBox();
            this.showLoadCheckBox = new System.Windows.Forms.CheckBox();
            this.showSaveCheckBox = new System.Windows.Forms.CheckBox();
            demoLabel = new System.Windows.Forms.Label();
            previewGroupBox = new Cyotek.Windows.Forms.GroupBox();
            previewGroupBox.SuspendLayout();
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
            demoLabel.Location = new System.Drawing.Point(311, 21);
            demoLabel.Name = "demoLabel";
            demoLabel.Padding = new System.Windows.Forms.Padding(9);
            demoLabel.Size = new System.Drawing.Size(364, 259);
            demoLabel.TabIndex = 6;
            demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // previewGroupBox
            // 
            previewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            previewGroupBox.Controls.Add(this.dialogColorPreviewPanel);
            previewGroupBox.Location = new System.Drawing.Point(24, 122);
            previewGroupBox.Name = "previewGroupBox";
            previewGroupBox.Size = new System.Drawing.Size(171, 155);
            previewGroupBox.TabIndex = 3;
            previewGroupBox.TabStop = false;
            previewGroupBox.Text = "Preview";
            // 
            // dialogColorPreviewPanel
            // 
            this.dialogColorPreviewPanel.Color = System.Drawing.Color.Empty;
            this.dialogColorPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogColorPreviewPanel.Location = new System.Drawing.Point(3, 16);
            this.dialogColorPreviewPanel.Name = "dialogColorPreviewPanel";
            this.dialogColorPreviewPanel.Size = new System.Drawing.Size(165, 136);
            this.dialogColorPreviewPanel.TabIndex = 0;
            this.dialogColorPreviewPanel.TabStop = false;
            // 
            // browseColorButton
            // 
            this.browseColorButton.Location = new System.Drawing.Point(24, 93);
            this.browseColorButton.Name = "browseColorButton";
            this.browseColorButton.Size = new System.Drawing.Size(104, 23);
            this.browseColorButton.TabIndex = 2;
            this.browseColorButton.Text = "&Choose Color...";
            this.browseColorButton.UseVisualStyleBackColor = true;
            this.browseColorButton.Click += new System.EventHandler(this.BrowseColorButton_Click);
            // 
            // colorPreviewPanel
            // 
            this.colorPreviewPanel.Color = System.Drawing.Color.Empty;
            this.colorPreviewPanel.Location = new System.Drawing.Point(24, 24);
            this.colorPreviewPanel.Name = "colorPreviewPanel";
            this.colorPreviewPanel.Size = new System.Drawing.Size(171, 63);
            this.colorPreviewPanel.TabIndex = 10;
            this.colorPreviewPanel.TabStop = false;
            // 
            // showAlphaChannelCheckBox
            // 
            this.showAlphaChannelCheckBox.Checked = true;
            this.showAlphaChannelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAlphaChannelCheckBox.Location = new System.Drawing.Point(201, 24);
            this.showAlphaChannelCheckBox.Name = "showAlphaChannelCheckBox";
            this.showAlphaChannelCheckBox.Size = new System.Drawing.Size(104, 31);
            this.showAlphaChannelCheckBox.TabIndex = 4;
            this.showAlphaChannelCheckBox.Text = "Show &Alpha Channel";
            this.showAlphaChannelCheckBox.UseVisualStyleBackColor = true;
            // 
            // preserveAlphaChannelCheckBox
            // 
            this.preserveAlphaChannelCheckBox.Location = new System.Drawing.Point(201, 61);
            this.preserveAlphaChannelCheckBox.Name = "preserveAlphaChannelCheckBox";
            this.preserveAlphaChannelCheckBox.Size = new System.Drawing.Size(105, 31);
            this.preserveAlphaChannelCheckBox.TabIndex = 5;
            this.preserveAlphaChannelCheckBox.Text = "&Preserve Alpha Channel";
            this.preserveAlphaChannelCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLoadCheckBox
            // 
            this.showLoadCheckBox.AutoSize = true;
            this.showLoadCheckBox.Checked = true;
            this.showLoadCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLoadCheckBox.Location = new System.Drawing.Point(201, 97);
            this.showLoadCheckBox.Name = "showLoadCheckBox";
            this.showLoadCheckBox.Size = new System.Drawing.Size(80, 17);
            this.showLoadCheckBox.TabIndex = 7;
            this.showLoadCheckBox.Text = "Show &Load";
            this.showLoadCheckBox.UseVisualStyleBackColor = true;
            // 
            // showSaveCheckBox
            // 
            this.showSaveCheckBox.AutoSize = true;
            this.showSaveCheckBox.Checked = true;
            this.showSaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSaveCheckBox.Location = new System.Drawing.Point(201, 119);
            this.showSaveCheckBox.Name = "showSaveCheckBox";
            this.showSaveCheckBox.Size = new System.Drawing.Size(81, 17);
            this.showSaveCheckBox.TabIndex = 8;
            this.showSaveCheckBox.Text = "Show &Save";
            this.showSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ColorPickerDialogDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 339);
            this.Controls.Add(this.showSaveCheckBox);
            this.Controls.Add(this.showLoadCheckBox);
            this.Controls.Add(previewGroupBox);
            this.Controls.Add(this.preserveAlphaChannelCheckBox);
            this.Controls.Add(this.showAlphaChannelCheckBox);
            this.Controls.Add(this.colorPreviewPanel);
            this.Controls.Add(demoLabel);
            this.Controls.Add(this.browseColorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ColorPickerDialogDemoForm";
            this.Text = "ColorPickerDialog Form Demonstration";
            this.Controls.SetChildIndex(this.browseColorButton, 0);
            this.Controls.SetChildIndex(demoLabel, 0);
            this.Controls.SetChildIndex(this.colorPreviewPanel, 0);
            this.Controls.SetChildIndex(this.showAlphaChannelCheckBox, 0);
            this.Controls.SetChildIndex(this.preserveAlphaChannelCheckBox, 0);
            this.Controls.SetChildIndex(previewGroupBox, 0);
            this.Controls.SetChildIndex(this.showLoadCheckBox, 0);
            this.Controls.SetChildIndex(this.showSaveCheckBox, 0);
            previewGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button browseColorButton;
    private ColorPreviewBox dialogColorPreviewPanel;
    private ColorPreviewBox colorPreviewPanel;
    private System.Windows.Forms.CheckBox showAlphaChannelCheckBox;
    private System.Windows.Forms.CheckBox preserveAlphaChannelCheckBox;
    private System.Windows.Forms.CheckBox showLoadCheckBox;
    private System.Windows.Forms.CheckBox showSaveCheckBox;
  }
}
