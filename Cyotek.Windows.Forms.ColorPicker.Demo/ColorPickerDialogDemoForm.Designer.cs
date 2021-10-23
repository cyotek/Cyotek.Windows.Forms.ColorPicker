namespace Cyotek.Windows.Forms.ColorPicker.Demo
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
      this.dialogColorPreviewPanel = new Cyotek.Windows.Forms.ColorPicker.Demo.ColorPreviewBox();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.browseColorButton = new System.Windows.Forms.Button();
      this.colorPreviewPanel = new Cyotek.Windows.Forms.ColorPicker.Demo.ColorPreviewBox();
      this.showAlphaChannelCheckBox = new System.Windows.Forms.CheckBox();
      this.preserveAlphaChannelCheckBox = new System.Windows.Forms.CheckBox();
      this.showLoadCheckBox = new System.Windows.Forms.CheckBox();
      this.showSaveCheckBox = new System.Windows.Forms.CheckBox();
      demoLabel = new System.Windows.Forms.Label();
      previewGroupBox = new Cyotek.Windows.Forms.GroupBox();
      previewGroupBox.SuspendLayout();
      this.menuStrip.SuspendLayout();
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
      demoLabel.Location = new System.Drawing.Point(296, 23);
      demoLabel.Name = "demoLabel";
      demoLabel.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
      demoLabel.Size = new System.Drawing.Size(353, 269);
      demoLabel.TabIndex = 6;
      demoLabel.Text = resources.GetString("demoLabel.Text");
      // 
      // previewGroupBox
      // 
      previewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      previewGroupBox.Controls.Add(this.dialogColorPreviewPanel);
      previewGroupBox.Location = new System.Drawing.Point(10, 120);
      previewGroupBox.Name = "previewGroupBox";
      previewGroupBox.Size = new System.Drawing.Size(171, 169);
      previewGroupBox.TabIndex = 3;
      previewGroupBox.TabStop = false;
      previewGroupBox.Text = "Preview";
      // 
      // dialogColorPreviewPanel
      // 
      this.dialogColorPreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dialogColorPreviewPanel.Color = System.Drawing.Color.Empty;
      this.dialogColorPreviewPanel.Location = new System.Drawing.Point(5, 22);
      this.dialogColorPreviewPanel.Name = "dialogColorPreviewPanel";
      this.dialogColorPreviewPanel.Size = new System.Drawing.Size(161, 142);
      this.dialogColorPreviewPanel.TabIndex = 1;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(659, 24);
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
      this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
      // 
      // browseColorButton
      // 
      this.browseColorButton.Location = new System.Drawing.Point(10, 92);
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
      this.colorPreviewPanel.Location = new System.Drawing.Point(10, 23);
      this.colorPreviewPanel.Name = "colorPreviewPanel";
      this.colorPreviewPanel.Size = new System.Drawing.Size(171, 63);
      this.colorPreviewPanel.TabIndex = 1;
      // 
      // showAlphaChannelCheckBox
      // 
      this.showAlphaChannelCheckBox.Checked = true;
      this.showAlphaChannelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showAlphaChannelCheckBox.Location = new System.Drawing.Point(187, 23);
      this.showAlphaChannelCheckBox.Name = "showAlphaChannelCheckBox";
      this.showAlphaChannelCheckBox.Size = new System.Drawing.Size(104, 31);
      this.showAlphaChannelCheckBox.TabIndex = 4;
      this.showAlphaChannelCheckBox.Text = "Show &Alpha Channel";
      this.showAlphaChannelCheckBox.UseVisualStyleBackColor = true;
      // 
      // preserveAlphaChannelCheckBox
      // 
      this.preserveAlphaChannelCheckBox.Location = new System.Drawing.Point(186, 60);
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
      this.showLoadCheckBox.Location = new System.Drawing.Point(187, 96);
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
      this.showSaveCheckBox.Location = new System.Drawing.Point(187, 118);
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
      this.ClientSize = new System.Drawing.Size(659, 300);
      this.Controls.Add(this.showSaveCheckBox);
      this.Controls.Add(this.showLoadCheckBox);
      this.Controls.Add(previewGroupBox);
      this.Controls.Add(this.preserveAlphaChannelCheckBox);
      this.Controls.Add(this.showAlphaChannelCheckBox);
      this.Controls.Add(this.colorPreviewPanel);
      this.Controls.Add(demoLabel);
      this.Controls.Add(this.browseColorButton);
      this.Controls.Add(this.menuStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ColorPickerDialogDemoForm";
      this.Text = "ColorPickerDialog Form Demonstration";
      previewGroupBox.ResumeLayout(false);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.Button browseColorButton;
    private ColorPreviewBox dialogColorPreviewPanel;
    private ColorPreviewBox colorPreviewPanel;
    private System.Windows.Forms.CheckBox showAlphaChannelCheckBox;
    private System.Windows.Forms.CheckBox preserveAlphaChannelCheckBox;
    private System.Windows.Forms.CheckBox showLoadCheckBox;
    private System.Windows.Forms.CheckBox showSaveCheckBox;
  }
}
