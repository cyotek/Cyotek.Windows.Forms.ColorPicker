namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorEditorDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorEditorDemoForm));
            this.propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.colorPreviewBox = new Cyotek.Windows.Forms.ColorPreviewBox();
            this.demoLabel = new System.Windows.Forms.Label();
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
            // propertiesSplitContainer
            // 
            this.propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.propertiesSplitContainer.Size = new System.Drawing.Size(823, 393);
            this.propertiesSplitContainer.SplitterDistance = 271;
            this.propertiesSplitContainer.SplitterWidth = 5;
            this.propertiesSplitContainer.TabIndex = 1;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.colorEditor;
            this.propertyGrid.Size = new System.Drawing.Size(271, 393);
            this.propertyGrid.TabIndex = 0;
            // 
            // colorEditor
            // 
            this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorEditor.Location = new System.Drawing.Point(0, 0);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Padding = new System.Windows.Forms.Padding(9);
            this.colorEditor.Size = new System.Drawing.Size(209, 393);
            this.colorEditor.TabIndex = 0;
            this.colorEditor.ColorChanged += new System.EventHandler(this.ColorEditor_ColorChanged);
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
            this.optionsSplitContainer.Panel1.Controls.Add(this.colorEditor);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(this.colorPreviewBox);
            this.optionsSplitContainer.Panel2.Controls.Add(this.demoLabel);
            this.optionsSplitContainer.Size = new System.Drawing.Size(547, 393);
            this.optionsSplitContainer.SplitterDistance = 209;
            this.optionsSplitContainer.SplitterWidth = 5;
            this.optionsSplitContainer.TabIndex = 0;
            // 
            // colorPreviewBox
            // 
            this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPreviewBox.Color = System.Drawing.Color.Empty;
            this.colorPreviewBox.Location = new System.Drawing.Point(3, 349);
            this.colorPreviewBox.Name = "colorPreviewBox";
            this.colorPreviewBox.Size = new System.Drawing.Size(321, 41);
            this.colorPreviewBox.TabIndex = 0;
            this.colorPreviewBox.TabStop = false;
            // 
            // demoLabel
            // 
            this.demoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.demoLabel.AutoEllipsis = true;
            this.demoLabel.BackColor = System.Drawing.SystemColors.Info;
            this.demoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demoLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.demoLabel.Location = new System.Drawing.Point(3, 0);
            this.demoLabel.Name = "demoLabel";
            this.demoLabel.Padding = new System.Windows.Forms.Padding(9);
            this.demoLabel.Size = new System.Drawing.Size(322, 347);
            this.demoLabel.TabIndex = 0;
            this.demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // ColorEditorDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 455);
            this.Controls.Add(this.propertiesSplitContainer);
            this.Name = "ColorEditorDemoForm";
            this.Text = "ColorEditor Control Demonstration";
            this.Controls.SetChildIndex(this.propertiesSplitContainer, 0);
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
    private ColorEditor colorEditor;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
    private System.Windows.Forms.Label demoLabel;
    private ColorPreviewBox colorPreviewBox;
  }
}
