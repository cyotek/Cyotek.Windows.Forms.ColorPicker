using System;

namespace Cyotek.Windows.Forms
{
  partial class ColorPickerDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.previewPanel = new ColorPreviewBox();
            this.loadPaletteButton = new System.Windows.Forms.Button();
            this.savePaletteButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(453, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(453, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.Location = new System.Drawing.Point(453, 203);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(75, 47);
            // 
            // loadPaletteButton
            // 
            this.loadPaletteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadPaletteButton.Location = new System.Drawing.Point(12, 147);
            this.loadPaletteButton.Name = "loadPaletteButton";
            this.loadPaletteButton.Size = new System.Drawing.Size(23, 23);
            this.loadPaletteButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.loadPaletteButton, "Load Palette");
            this.loadPaletteButton.UseVisualStyleBackColor = false;
            this.loadPaletteButton.Click += new System.EventHandler(this.LoadPaletteButton_Click);
            // 
            // savePaletteButton
            // 
            this.savePaletteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.savePaletteButton.Location = new System.Drawing.Point(34, 147);
            this.savePaletteButton.Name = "savePaletteButton";
            this.savePaletteButton.Size = new System.Drawing.Size(23, 23);
            this.savePaletteButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.savePaletteButton, "Save Palette");
            this.savePaletteButton.UseVisualStyleBackColor = false;
            this.savePaletteButton.Click += new System.EventHandler(this.SavePaletteButton_Click);
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.screenColorPicker.Color = System.Drawing.Color.Black;
            this.screenColorPicker.Location = new System.Drawing.Point(453, 83);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(73, 85);
            this.toolTip.SetToolTip(this.screenColorPicker, "Click and drag to select screen color");
            this.screenColorPicker.Zoom = 6;
            // 
            // colorWheel
            // 
            this.colorWheel.Alpha = 1D;
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Location = new System.Drawing.Point(12, 12);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(192, 147);
            this.colorWheel.TabIndex = 4;
            // 
            // colorEditor
            // 
            this.colorEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor.Location = new System.Drawing.Point(210, 12);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Size = new System.Drawing.Size(230, 238);
            this.colorEditor.TabIndex = 0;
            // 
            // colorGrid
            // 
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
            this.colorGrid.Location = new System.Drawing.Point(12, 176);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
            this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(192, 72);
            this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
            this.colorGrid.TabIndex = 7;
            this.colorGrid.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.ColorGrid_EditingColor);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.Color = System.Drawing.Color.Empty;
            this.colorEditorManager.ColorEditor = this.colorEditor;
            this.colorEditorManager.ColorGrid = this.colorGrid;
            this.colorEditorManager.ColorWheel = this.colorWheel;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            this.colorEditorManager.ColorChanged += new System.EventHandler(this.ColorEditorManager_ColorChanged);
            // 
            // ColorPickerDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(540, 262);
            this.Controls.Add(this.savePaletteButton);
            this.Controls.Add(this.loadPaletteButton);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.screenColorPicker);
            this.Controls.Add(this.colorWheel);
            this.Controls.Add(this.colorEditor);
            this.Controls.Add(this.colorGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Picker";
            this.ResumeLayout(false);

    }

    #endregion

    private ColorGrid colorGrid;
    private ColorEditor colorEditor;
    private ColorWheel colorWheel;
    private ColorEditorManager colorEditorManager;
    private ScreenColorPicker screenColorPicker;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private ColorPreviewBox previewPanel;
    private System.Windows.Forms.Button loadPaletteButton;
    private System.Windows.Forms.Button savePaletteButton;
    private System.Windows.Forms.ToolTip toolTip;
  }
}
