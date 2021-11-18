namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorGridEditingDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorGridEditingDemoForm));
            System.Windows.Forms.Label editModeLabel;
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.editModeComboBox = new System.Windows.Forms.ComboBox();
            this.eventsListBox = new Cyotek.Windows.Forms.Demo.EventsListBox();
            this.eventsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.optionsSplitContainer = new System.Windows.Forms.SplitContainer();
            demoLabel = new System.Windows.Forms.Label();
            editModeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).BeginInit();
            this.eventsSplitContainer.Panel1.SuspendLayout();
            this.eventsSplitContainer.Panel2.SuspendLayout();
            this.eventsSplitContainer.SuspendLayout();
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
            demoLabel.Location = new System.Drawing.Point(2, 0);
            demoLabel.Name = "demoLabel";
            demoLabel.Padding = new System.Windows.Forms.Padding(9);
            demoLabel.Size = new System.Drawing.Size(391, 168);
            demoLabel.TabIndex = 0;
            demoLabel.Text = resources.GetString("demoLabel.Text");
            // 
            // editModeLabel
            // 
            editModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            editModeLabel.AutoSize = true;
            editModeLabel.Location = new System.Drawing.Point(0, 178);
            editModeLabel.Name = "editModeLabel";
            editModeLabel.Size = new System.Drawing.Size(58, 13);
            editModeLabel.TabIndex = 1;
            editModeLabel.Text = "&Edit Mode:";
            // 
            // colorGrid
            // 
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGrid.Location = new System.Drawing.Point(0, 0);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(6);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
            this.colorGrid.Size = new System.Drawing.Size(361, 218);
            this.colorGrid.TabIndex = 0;
            this.colorGrid.ColorChanged += new System.EventHandler(this.ColorGrid_ColorChanged);
            this.colorGrid.ColorIndexChanged += new System.EventHandler(this.ColorGrid_ColorIndexChanged);
            this.colorGrid.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.ColorGrid_EditingColor);
            // 
            // editModeComboBox
            // 
            this.editModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editModeComboBox.Items.AddRange(new object[] {
            "None",
            "Custom",
            "Both"});
            this.editModeComboBox.Location = new System.Drawing.Point(3, 194);
            this.editModeComboBox.Name = "editModeComboBox";
            this.editModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.editModeComboBox.TabIndex = 2;
            this.editModeComboBox.SelectedIndexChanged += new System.EventHandler(this.EditModeComboBox_SelectedIndexChanged);
            // 
            // eventsListBox
            // 
            this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(0, 0);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(761, 96);
            this.eventsListBox.TabIndex = 0;
            // 
            // eventsSplitContainer
            // 
            this.eventsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.eventsSplitContainer.Location = new System.Drawing.Point(12, 12);
            this.eventsSplitContainer.Name = "eventsSplitContainer";
            this.eventsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // eventsSplitContainer.Panel1
            // 
            this.eventsSplitContainer.Panel1.Controls.Add(this.optionsSplitContainer);
            // 
            // eventsSplitContainer.Panel2
            // 
            this.eventsSplitContainer.Panel2.Controls.Add(this.eventsListBox);
            this.eventsSplitContainer.Size = new System.Drawing.Size(761, 318);
            this.eventsSplitContainer.SplitterDistance = 218;
            this.eventsSplitContainer.TabIndex = 0;
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
            this.optionsSplitContainer.Panel1.Controls.Add(this.colorGrid);
            // 
            // optionsSplitContainer.Panel2
            // 
            this.optionsSplitContainer.Panel2.Controls.Add(demoLabel);
            this.optionsSplitContainer.Panel2.Controls.Add(this.editModeComboBox);
            this.optionsSplitContainer.Panel2.Controls.Add(editModeLabel);
            this.optionsSplitContainer.Size = new System.Drawing.Size(761, 218);
            this.optionsSplitContainer.SplitterDistance = 361;
            this.optionsSplitContainer.TabIndex = 0;
            // 
            // ColorGridEditingDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 380);
            this.Controls.Add(this.eventsSplitContainer);
            this.Name = "ColorGridEditingDemoForm";
            this.Text = "External Palette Files Demonstration";
            this.Controls.SetChildIndex(this.eventsSplitContainer, 0);
            this.eventsSplitContainer.Panel1.ResumeLayout(false);
            this.eventsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).EndInit();
            this.eventsSplitContainer.ResumeLayout(false);
            this.optionsSplitContainer.Panel1.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.ResumeLayout(false);
            this.optionsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsSplitContainer)).EndInit();
            this.optionsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private ColorGrid colorGrid;
    private EventsListBox eventsListBox;
    private System.Windows.Forms.ComboBox editModeComboBox;
    private System.Windows.Forms.SplitContainer eventsSplitContainer;
    private System.Windows.Forms.SplitContainer optionsSplitContainer;
  }
}
