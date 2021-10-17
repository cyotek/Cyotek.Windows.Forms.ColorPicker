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
      demoLabel = new System.Windows.Forms.Label();
      previewGroupBox = new Cyotek.Windows.Forms.GroupBox();
      previewGroupBox.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // demoLabel
      // 
      demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      demoLabel.AutoEllipsis = true;
      demoLabel.BackColor = System.Drawing.SystemColors.Info;
      demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
      demoLabel.Location = new System.Drawing.Point(345, 27);
      demoLabel.Name = "demoLabel";
      demoLabel.Padding = new System.Windows.Forms.Padding(10);
      demoLabel.Size = new System.Drawing.Size(289, 307);
      demoLabel.TabIndex = 6;
      demoLabel.Text = resources.GetString("demoLabel.Text");
      // 
      // previewGroupBox
      // 
      previewGroupBox.Controls.Add(this.dialogColorPreviewPanel);
      previewGroupBox.Location = new System.Drawing.Point(12, 139);
      previewGroupBox.Name = "previewGroupBox";
      previewGroupBox.Size = new System.Drawing.Size(200, 192);
      previewGroupBox.TabIndex = 3;
      previewGroupBox.TabStop = false;
      previewGroupBox.Text = "Preview";
      // 
      // dialogColorPreviewPanel
      // 
      this.dialogColorPreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dialogColorPreviewPanel.Color = System.Drawing.Color.Empty;
      this.dialogColorPreviewPanel.Location = new System.Drawing.Point(6, 22);
      this.dialogColorPreviewPanel.Name = "dialogColorPreviewPanel";
      this.dialogColorPreviewPanel.Size = new System.Drawing.Size(188, 164);
      this.dialogColorPreviewPanel.TabIndex = 1;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
      this.menuStrip.Size = new System.Drawing.Size(646, 24);
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
      this.browseColorButton.Location = new System.Drawing.Point(12, 106);
      this.browseColorButton.Name = "browseColorButton";
      this.browseColorButton.Size = new System.Drawing.Size(121, 27);
      this.browseColorButton.TabIndex = 2;
      this.browseColorButton.Text = "&Choose Color...";
      this.browseColorButton.UseVisualStyleBackColor = true;
      this.browseColorButton.Click += new System.EventHandler(this.BrowseColorButton_Click);
      // 
      // colorPreviewPanel
      // 
      this.colorPreviewPanel.Color = System.Drawing.Color.Empty;
      this.colorPreviewPanel.Location = new System.Drawing.Point(12, 27);
      this.colorPreviewPanel.Name = "colorPreviewPanel";
      this.colorPreviewPanel.Size = new System.Drawing.Size(200, 73);
      this.colorPreviewPanel.TabIndex = 1;
      // 
      // showAlphaChannelCheckBox
      // 
      this.showAlphaChannelCheckBox.Checked = true;
      this.showAlphaChannelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showAlphaChannelCheckBox.Location = new System.Drawing.Point(218, 27);
      this.showAlphaChannelCheckBox.Name = "showAlphaChannelCheckBox";
      this.showAlphaChannelCheckBox.Size = new System.Drawing.Size(121, 36);
      this.showAlphaChannelCheckBox.TabIndex = 4;
      this.showAlphaChannelCheckBox.Text = "Show &Alpha Channel";
      this.showAlphaChannelCheckBox.UseVisualStyleBackColor = true;
      // 
      // preserveAlphaChannelCheckBox
      // 
      this.preserveAlphaChannelCheckBox.Location = new System.Drawing.Point(217, 69);
      this.preserveAlphaChannelCheckBox.Name = "preserveAlphaChannelCheckBox";
      this.preserveAlphaChannelCheckBox.Size = new System.Drawing.Size(122, 36);
      this.preserveAlphaChannelCheckBox.TabIndex = 5;
      this.preserveAlphaChannelCheckBox.Text = "&Preserve Alpha Channel";
      this.preserveAlphaChannelCheckBox.UseVisualStyleBackColor = true;
      // 
      // ColorPickerDialogDemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(646, 343);
      this.Controls.Add(previewGroupBox);
      this.Controls.Add(this.preserveAlphaChannelCheckBox);
      this.Controls.Add(this.showAlphaChannelCheckBox);
      this.Controls.Add(this.colorPreviewPanel);
      this.Controls.Add(demoLabel);
      this.Controls.Add(this.browseColorButton);
      this.Controls.Add(this.menuStrip);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
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
  }
}
