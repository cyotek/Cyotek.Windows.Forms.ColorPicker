namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  partial class ScratchForm
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
      this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // colorEditor1
      // 
      this.colorEditor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.colorEditor1.Location = new System.Drawing.Point(162, 95);
      this.colorEditor1.Name = "colorEditor1";
      this.colorEditor1.Size = new System.Drawing.Size(200, 260);
      this.colorEditor1.TabIndex = 0;
      this.colorEditor1.ColorChanged += new System.EventHandler(this.colorEditor1_ColorChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(487, 134);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      // 
      // ScratchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1106, 579);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.colorEditor1);
      this.Name = "ScratchForm";
      this.Text = "ScratchForm";
      this.Load += new System.EventHandler(this.ScratchForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ColorEditor colorEditor1;
    private System.Windows.Forms.Label label1;


  }
}