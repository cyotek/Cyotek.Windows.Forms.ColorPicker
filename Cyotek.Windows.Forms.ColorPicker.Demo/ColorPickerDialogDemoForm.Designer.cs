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
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panel = new System.Windows.Forms.Panel();
      this.browseColorButton = new System.Windows.Forms.Button();
      this.demoLabel = new System.Windows.Forms.Label();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(554, 24);
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
      // panel
      // 
      this.panel.BackgroundImage = global::Cyotek.Windows.Forms.ColorPicker.Demo.Properties.Resources.cellbackground;
      this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel.Location = new System.Drawing.Point(12, 27);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(256, 256);
      this.panel.TabIndex = 1;
      this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // browseColorButton
      // 
      this.browseColorButton.Location = new System.Drawing.Point(274, 260);
      this.browseColorButton.Name = "browseColorButton";
      this.browseColorButton.Size = new System.Drawing.Size(103, 23);
      this.browseColorButton.TabIndex = 2;
      this.browseColorButton.Text = "&Choose Color...";
      this.browseColorButton.UseVisualStyleBackColor = true;
      this.browseColorButton.Click += new System.EventHandler(this.browseColorButton_Click);
      // 
      // demoLabel
      // 
      this.demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.demoLabel.AutoEllipsis = true;
      this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
      this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
      this.demoLabel.Location = new System.Drawing.Point(383, 27);
      this.demoLabel.Name = "demoLabel";
      this.demoLabel.Padding = new System.Windows.Forms.Padding(9);
      this.demoLabel.Size = new System.Drawing.Size(159, 256);
      this.demoLabel.TabIndex = 3;
      this.demoLabel.Text = "The ColorPickerDialog form is a pre-built dialog that you can quickly call in ord" +
    "er to choose colors from within your application.";
      // 
      // ColorPickerDialogDemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(554, 297);
      this.Controls.Add(this.demoLabel);
      this.Controls.Add(this.browseColorButton);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.menuStrip);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ColorPickerDialogDemoForm";
      this.Text = "ColorPickerDialog Form Demonstration";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.Button browseColorButton;
    private System.Windows.Forms.Label demoLabel;
  }
}