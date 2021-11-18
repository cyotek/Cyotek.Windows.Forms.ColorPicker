namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorSliderDemonstrationForm
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
            Cyotek.Windows.Forms.GroupBox saturationSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox hueSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox alphaSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox blueSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox greenSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox redSliderGroupBox;
            Cyotek.Windows.Forms.GroupBox nubStylesGroupBox;
            System.Windows.Forms.SplitContainer propertiesSplitContainer;
            System.Windows.Forms.SplitContainer eventsSplitContainer;
            Cyotek.Windows.Forms.GroupBox lightnessSliderGroupBox;
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.ToolStripLabel toolStripLabel4;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripLabel toolStripLabel3;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.Windows.Forms.ToolStripLabel toolStripLabel2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            this.saturationColorSlider = new Cyotek.Windows.Forms.SaturationColorSlider();
            this.hueColorSlider = new Cyotek.Windows.Forms.HueColorSlider();
            this.alphaColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.blueRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.greenRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.redRgbColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.orientationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.verticalLeftColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.verticalRightColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.verticalColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.horizontalColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.horizontalBottomColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.horizontalTopColorSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.eventsListBox = new Cyotek.Windows.Forms.Demo.EventsListBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.backgroundToolStripColorPickerSplitButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.nubColorToolStripColorPickerSplitButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.nubOutlineColorToolStripColorPickerSplitButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            this.nubWidthToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.nubHeightToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.showValueDividerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.backgroundFillToolStripColorPickerSplitButton = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripColorPickerSplitButton();
            saturationSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            hueSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            alphaSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            blueSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            greenSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            redSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            nubStylesGroupBox = new Cyotek.Windows.Forms.GroupBox();
            propertiesSplitContainer = new System.Windows.Forms.SplitContainer();
            eventsSplitContainer = new System.Windows.Forms.SplitContainer();
            lightnessSliderGroupBox = new Cyotek.Windows.Forms.GroupBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            saturationSliderGroupBox.SuspendLayout();
            hueSliderGroupBox.SuspendLayout();
            alphaSliderGroupBox.SuspendLayout();
            blueSliderGroupBox.SuspendLayout();
            greenSliderGroupBox.SuspendLayout();
            redSliderGroupBox.SuspendLayout();
            nubStylesGroupBox.SuspendLayout();
            this.orientationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(propertiesSplitContainer)).BeginInit();
            propertiesSplitContainer.Panel1.SuspendLayout();
            propertiesSplitContainer.Panel2.SuspendLayout();
            propertiesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(eventsSplitContainer)).BeginInit();
            eventsSplitContainer.Panel1.SuspendLayout();
            eventsSplitContainer.Panel2.SuspendLayout();
            eventsSplitContainer.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            lightnessSliderGroupBox.SuspendLayout();
            toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saturationSliderGroupBox
            // 
            saturationSliderGroupBox.Controls.Add(this.saturationColorSlider);
            saturationSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            saturationSliderGroupBox.Location = new System.Drawing.Point(113, 148);
            saturationSliderGroupBox.Name = "saturationSliderGroupBox";
            saturationSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            saturationSliderGroupBox.TabIndex = 5;
            saturationSliderGroupBox.TabStop = false;
            saturationSliderGroupBox.Text = "SaturationColorSlider";
            // 
            // saturationColorSlider
            // 
            this.saturationColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saturationColorSlider.Location = new System.Drawing.Point(3, 16);
            this.saturationColorSlider.Name = "saturationColorSlider";
            this.saturationColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.saturationColorSlider.Size = new System.Drawing.Size(98, 120);
            this.saturationColorSlider.TabIndex = 0;
            this.saturationColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.saturationColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // hueSliderGroupBox
            // 
            hueSliderGroupBox.Controls.Add(this.hueColorSlider);
            hueSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            hueSliderGroupBox.Location = new System.Drawing.Point(3, 148);
            hueSliderGroupBox.Name = "hueSliderGroupBox";
            hueSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            hueSliderGroupBox.TabIndex = 4;
            hueSliderGroupBox.TabStop = false;
            hueSliderGroupBox.Text = "HueColorSlider";
            // 
            // hueColorSlider
            // 
            this.hueColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hueColorSlider.Location = new System.Drawing.Point(3, 16);
            this.hueColorSlider.Name = "hueColorSlider";
            this.hueColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hueColorSlider.Size = new System.Drawing.Size(98, 120);
            this.hueColorSlider.TabIndex = 0;
            this.hueColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.hueColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // alphaSliderGroupBox
            // 
            alphaSliderGroupBox.Controls.Add(this.alphaColorSlider);
            alphaSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            alphaSliderGroupBox.Location = new System.Drawing.Point(333, 3);
            alphaSliderGroupBox.Name = "alphaSliderGroupBox";
            alphaSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            alphaSliderGroupBox.TabIndex = 3;
            alphaSliderGroupBox.TabStop = false;
            alphaSliderGroupBox.Text = "RgbColorSlider (Alpha Channel)";
            // 
            // alphaColorSlider
            // 
            this.alphaColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Alpha;
            this.alphaColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alphaColorSlider.Location = new System.Drawing.Point(3, 16);
            this.alphaColorSlider.Name = "alphaColorSlider";
            this.alphaColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.alphaColorSlider.Size = new System.Drawing.Size(98, 120);
            this.alphaColorSlider.TabIndex = 0;
            this.alphaColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.alphaColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // blueSliderGroupBox
            // 
            blueSliderGroupBox.Controls.Add(this.blueRgbColorSlider);
            blueSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            blueSliderGroupBox.Location = new System.Drawing.Point(223, 3);
            blueSliderGroupBox.Name = "blueSliderGroupBox";
            blueSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            blueSliderGroupBox.TabIndex = 2;
            blueSliderGroupBox.TabStop = false;
            blueSliderGroupBox.Text = "RgbColorSlider (Blue Channel)";
            // 
            // blueRgbColorSlider
            // 
            this.blueRgbColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
            this.blueRgbColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueRgbColorSlider.Location = new System.Drawing.Point(3, 16);
            this.blueRgbColorSlider.Name = "blueRgbColorSlider";
            this.blueRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.blueRgbColorSlider.Size = new System.Drawing.Size(98, 120);
            this.blueRgbColorSlider.TabIndex = 0;
            this.blueRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.blueRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // greenSliderGroupBox
            // 
            greenSliderGroupBox.Controls.Add(this.greenRgbColorSlider);
            greenSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            greenSliderGroupBox.Location = new System.Drawing.Point(113, 3);
            greenSliderGroupBox.Name = "greenSliderGroupBox";
            greenSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            greenSliderGroupBox.TabIndex = 1;
            greenSliderGroupBox.TabStop = false;
            greenSliderGroupBox.Text = "RgbColorSlider (Green Channel)";
            // 
            // greenRgbColorSlider
            // 
            this.greenRgbColorSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
            this.greenRgbColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenRgbColorSlider.Location = new System.Drawing.Point(3, 16);
            this.greenRgbColorSlider.Name = "greenRgbColorSlider";
            this.greenRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.greenRgbColorSlider.Size = new System.Drawing.Size(98, 120);
            this.greenRgbColorSlider.TabIndex = 0;
            this.greenRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.greenRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // redSliderGroupBox
            // 
            redSliderGroupBox.Controls.Add(this.redRgbColorSlider);
            redSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            redSliderGroupBox.Location = new System.Drawing.Point(3, 3);
            redSliderGroupBox.Name = "redSliderGroupBox";
            redSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            redSliderGroupBox.TabIndex = 0;
            redSliderGroupBox.TabStop = false;
            redSliderGroupBox.Text = "RgbColorSlider (Red Channel)";
            // 
            // redRgbColorSlider
            // 
            this.redRgbColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redRgbColorSlider.Location = new System.Drawing.Point(3, 16);
            this.redRgbColorSlider.Name = "redRgbColorSlider";
            this.redRgbColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.redRgbColorSlider.Size = new System.Drawing.Size(98, 120);
            this.redRgbColorSlider.TabIndex = 0;
            this.redRgbColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.redRgbColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // nubStylesGroupBox
            // 
            nubStylesGroupBox.Controls.Add(this.orientationTableLayoutPanel);
            nubStylesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            nubStylesGroupBox.Location = new System.Drawing.Point(333, 148);
            nubStylesGroupBox.Name = "nubStylesGroupBox";
            nubStylesGroupBox.Size = new System.Drawing.Size(104, 139);
            nubStylesGroupBox.TabIndex = 7;
            nubStylesGroupBox.TabStop = false;
            nubStylesGroupBox.Text = "Orientation Styles";
            // 
            // orientationTableLayoutPanel
            // 
            this.orientationTableLayoutPanel.ColumnCount = 3;
            this.orientationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.orientationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.orientationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.orientationTableLayoutPanel.Controls.Add(this.verticalLeftColorSlider, 2, 0);
            this.orientationTableLayoutPanel.Controls.Add(this.verticalRightColorSlider, 1, 0);
            this.orientationTableLayoutPanel.Controls.Add(this.verticalColorSlider, 0, 0);
            this.orientationTableLayoutPanel.Controls.Add(this.horizontalColorSlider, 0, 1);
            this.orientationTableLayoutPanel.Controls.Add(this.horizontalBottomColorSlider, 0, 2);
            this.orientationTableLayoutPanel.Controls.Add(this.horizontalTopColorSlider, 0, 3);
            this.orientationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orientationTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.orientationTableLayoutPanel.Name = "orientationTableLayoutPanel";
            this.orientationTableLayoutPanel.RowCount = 4;
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.01001F));
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.orientationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.orientationTableLayoutPanel.Size = new System.Drawing.Size(98, 120);
            this.orientationTableLayoutPanel.TabIndex = 3;
            // 
            // verticalLeftColorSlider
            // 
            this.verticalLeftColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.verticalLeftColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalLeftColorSlider.Location = new System.Drawing.Point(67, 3);
            this.verticalLeftColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.verticalLeftColorSlider.Name = "verticalLeftColorSlider";
            this.verticalLeftColorSlider.NubStyle = Cyotek.Windows.Forms.ColorSliderNubStyle.TopLeft;
            this.verticalLeftColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.verticalLeftColorSlider.ShowValueDivider = true;
            this.verticalLeftColorSlider.Size = new System.Drawing.Size(25, 51);
            this.verticalLeftColorSlider.TabIndex = 2;
            // 
            // verticalRightColorSlider
            // 
            this.verticalRightColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.verticalRightColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalRightColorSlider.Location = new System.Drawing.Point(35, 3);
            this.verticalRightColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.verticalRightColorSlider.Name = "verticalRightColorSlider";
            this.verticalRightColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.verticalRightColorSlider.ShowValueDivider = true;
            this.verticalRightColorSlider.Size = new System.Drawing.Size(23, 51);
            this.verticalRightColorSlider.TabIndex = 1;
            // 
            // verticalColorSlider
            // 
            this.verticalColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.verticalColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalColorSlider.Location = new System.Drawing.Point(3, 3);
            this.verticalColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.verticalColorSlider.Name = "verticalColorSlider";
            this.verticalColorSlider.NubStyle = Cyotek.Windows.Forms.ColorSliderNubStyle.None;
            this.verticalColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.verticalColorSlider.ShowValueDivider = true;
            this.verticalColorSlider.Size = new System.Drawing.Size(23, 51);
            this.verticalColorSlider.TabIndex = 0;
            // 
            // horizontalColorSlider
            // 
            this.horizontalColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.orientationTableLayoutPanel.SetColumnSpan(this.horizontalColorSlider, 3);
            this.horizontalColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalColorSlider.Location = new System.Drawing.Point(3, 63);
            this.horizontalColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.horizontalColorSlider.Name = "horizontalColorSlider";
            this.horizontalColorSlider.NubStyle = Cyotek.Windows.Forms.ColorSliderNubStyle.None;
            this.horizontalColorSlider.ShowValueDivider = true;
            this.horizontalColorSlider.Size = new System.Drawing.Size(89, 10);
            this.horizontalColorSlider.TabIndex = 3;
            // 
            // horizontalBottomColorSlider
            // 
            this.horizontalBottomColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.orientationTableLayoutPanel.SetColumnSpan(this.horizontalBottomColorSlider, 3);
            this.horizontalBottomColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalBottomColorSlider.Location = new System.Drawing.Point(3, 82);
            this.horizontalBottomColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.horizontalBottomColorSlider.Name = "horizontalBottomColorSlider";
            this.horizontalBottomColorSlider.ShowValueDivider = true;
            this.horizontalBottomColorSlider.Size = new System.Drawing.Size(89, 10);
            this.horizontalBottomColorSlider.TabIndex = 4;
            // 
            // horizontalTopColorSlider
            // 
            this.horizontalTopColorSlider.Color = System.Drawing.Color.SeaGreen;
            this.orientationTableLayoutPanel.SetColumnSpan(this.horizontalTopColorSlider, 3);
            this.horizontalTopColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTopColorSlider.Location = new System.Drawing.Point(3, 101);
            this.horizontalTopColorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.horizontalTopColorSlider.Name = "horizontalTopColorSlider";
            this.horizontalTopColorSlider.NubStyle = Cyotek.Windows.Forms.ColorSliderNubStyle.TopLeft;
            this.horizontalTopColorSlider.ShowValueDivider = true;
            this.horizontalTopColorSlider.Size = new System.Drawing.Size(89, 13);
            this.horizontalTopColorSlider.TabIndex = 5;
            // 
            // propertiesSplitContainer
            // 
            propertiesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            propertiesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            propertiesSplitContainer.Location = new System.Drawing.Point(12, 81);
            propertiesSplitContainer.Name = "propertiesSplitContainer";
            // 
            // propertiesSplitContainer.Panel1
            // 
            propertiesSplitContainer.Panel1.Controls.Add(eventsSplitContainer);
            // 
            // propertiesSplitContainer.Panel2
            // 
            propertiesSplitContainer.Panel2.Controls.Add(this.propertyGrid);
            propertiesSplitContainer.Size = new System.Drawing.Size(760, 430);
            propertiesSplitContainer.SplitterDistance = 440;
            propertiesSplitContainer.SplitterWidth = 5;
            propertiesSplitContainer.TabIndex = 2;
            // 
            // eventsSplitContainer
            // 
            eventsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            eventsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            eventsSplitContainer.Location = new System.Drawing.Point(0, 0);
            eventsSplitContainer.Name = "eventsSplitContainer";
            eventsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // eventsSplitContainer.Panel1
            // 
            eventsSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel);
            // 
            // eventsSplitContainer.Panel2
            // 
            eventsSplitContainer.Panel2.Controls.Add(this.eventsListBox);
            eventsSplitContainer.Size = new System.Drawing.Size(440, 430);
            eventsSplitContainer.SplitterDistance = 290;
            eventsSplitContainer.SplitterWidth = 5;
            eventsSplitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(alphaSliderGroupBox, 3, 0);
            this.tableLayoutPanel.Controls.Add(blueSliderGroupBox, 2, 0);
            this.tableLayoutPanel.Controls.Add(greenSliderGroupBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(redSliderGroupBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(hueSliderGroupBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(saturationSliderGroupBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(lightnessSliderGroupBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(nubStylesGroupBox, 3, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(440, 290);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lightnessSliderGroupBox
            // 
            lightnessSliderGroupBox.Controls.Add(this.lightnessColorSlider);
            lightnessSliderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            lightnessSliderGroupBox.Location = new System.Drawing.Point(223, 148);
            lightnessSliderGroupBox.Name = "lightnessSliderGroupBox";
            lightnessSliderGroupBox.Size = new System.Drawing.Size(104, 139);
            lightnessSliderGroupBox.TabIndex = 6;
            lightnessSliderGroupBox.TabStop = false;
            lightnessSliderGroupBox.Text = "LightnessColorSlider";
            // 
            // lightnessColorSlider
            // 
            this.lightnessColorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightnessColorSlider.Location = new System.Drawing.Point(3, 16);
            this.lightnessColorSlider.Name = "lightnessColorSlider";
            this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lightnessColorSlider.Size = new System.Drawing.Size(98, 120);
            this.lightnessColorSlider.TabIndex = 0;
            this.lightnessColorSlider.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            this.lightnessColorSlider.Enter += new System.EventHandler(this.GotFocusHandler);
            // 
            // eventsListBox
            // 
            this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.IntegralHeight = false;
            this.eventsListBox.Location = new System.Drawing.Point(0, 0);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(440, 135);
            this.eventsListBox.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.alphaColorSlider;
            this.propertyGrid.Size = new System.Drawing.Size(315, 430);
            this.propertyGrid.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel4,
            this.backgroundToolStripColorPickerSplitButton,
            toolStripSeparator1,
            toolStripLabel3,
            this.nubColorToolStripColorPickerSplitButton,
            this.nubOutlineColorToolStripColorPickerSplitButton,
            toolStripLabel1,
            this.nubWidthToolStripTextBox,
            toolStripLabel2,
            this.nubHeightToolStripTextBox,
            toolStripSeparator2,
            this.showValueDividerToolStripButton,
            toolStripSeparator3,
            this.backgroundFillToolStripColorPickerSplitButton});
            toolStrip1.Location = new System.Drawing.Point(12, 56);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(760, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new System.Drawing.Size(66, 22);
            toolStripLabel4.Text = "Base Color:";
            // 
            // backgroundToolStripColorPickerSplitButton
            // 
            this.backgroundToolStripColorPickerSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backgroundToolStripColorPickerSplitButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.backgroundToolStripColorPickerSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundToolStripColorPickerSplitButton.Name = "backgroundToolStripColorPickerSplitButton";
            this.backgroundToolStripColorPickerSplitButton.Size = new System.Drawing.Size(32, 22);
            this.backgroundToolStripColorPickerSplitButton.Text = "Base Color";
            this.backgroundToolStripColorPickerSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.backgroundToolStripColorPickerSplitButton.ColorChanged += new System.EventHandler(this.BackgroundToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new System.Drawing.Size(61, 22);
            toolStripLabel3.Text = "Nub Style:";
            // 
            // nubColorToolStripColorPickerSplitButton
            // 
            this.nubColorToolStripColorPickerSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nubColorToolStripColorPickerSplitButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.NubColor;
            this.nubColorToolStripColorPickerSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nubColorToolStripColorPickerSplitButton.Name = "nubColorToolStripColorPickerSplitButton";
            this.nubColorToolStripColorPickerSplitButton.Size = new System.Drawing.Size(32, 22);
            this.nubColorToolStripColorPickerSplitButton.Text = "Nub Color";
            this.nubColorToolStripColorPickerSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.nubColorToolStripColorPickerSplitButton.ColorChanged += new System.EventHandler(this.NubColorToolStripColorPickerSplitButton_ColorChanged);
            // 
            // nubOutlineColorToolStripColorPickerSplitButton
            // 
            this.nubOutlineColorToolStripColorPickerSplitButton.Color = System.Drawing.Color.White;
            this.nubOutlineColorToolStripColorPickerSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nubOutlineColorToolStripColorPickerSplitButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.NubOutlineColor;
            this.nubOutlineColorToolStripColorPickerSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nubOutlineColorToolStripColorPickerSplitButton.Name = "nubOutlineColorToolStripColorPickerSplitButton";
            this.nubOutlineColorToolStripColorPickerSplitButton.Size = new System.Drawing.Size(32, 22);
            this.nubOutlineColorToolStripColorPickerSplitButton.Text = "Nub Outline Color";
            this.nubOutlineColorToolStripColorPickerSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.nubOutlineColorToolStripColorPickerSplitButton.ColorChanged += new System.EventHandler(this.NubOutlineColorToolStripColorPickerSplitButton_ColorChanged);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(21, 22);
            toolStripLabel1.Text = "W:";
            // 
            // nubWidthToolStripTextBox
            // 
            this.nubWidthToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nubWidthToolStripTextBox.Name = "nubWidthToolStripTextBox";
            this.nubWidthToolStripTextBox.Size = new System.Drawing.Size(24, 25);
            this.nubWidthToolStripTextBox.Text = "8";
            this.nubWidthToolStripTextBox.TextChanged += new System.EventHandler(this.NubWidthToolStripTextBox_TextChanged);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(19, 22);
            toolStripLabel2.Text = "H:";
            // 
            // nubHeightToolStripTextBox
            // 
            this.nubHeightToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nubHeightToolStripTextBox.Name = "nubHeightToolStripTextBox";
            this.nubHeightToolStripTextBox.Size = new System.Drawing.Size(24, 25);
            this.nubHeightToolStripTextBox.Text = "8";
            this.nubHeightToolStripTextBox.TextChanged += new System.EventHandler(this.NubWidthToolStripTextBox_TextChanged);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // showValueDividerToolStripButton
            // 
            this.showValueDividerToolStripButton.CheckOnClick = true;
            this.showValueDividerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showValueDividerToolStripButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.DividerToggle;
            this.showValueDividerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showValueDividerToolStripButton.Name = "showValueDividerToolStripButton";
            this.showValueDividerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.showValueDividerToolStripButton.Text = "Show Value Divider";
            this.showValueDividerToolStripButton.CheckedChanged += new System.EventHandler(this.ShowValueDividerToolStripButton_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // backgroundFillToolStripColorPickerSplitButton
            // 
            this.backgroundFillToolStripColorPickerSplitButton.Color = System.Drawing.SystemColors.Control;
            this.backgroundFillToolStripColorPickerSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backgroundFillToolStripColorPickerSplitButton.Image = global::Cyotek.Windows.Forms.Demo.Properties.Resources.FillColor;
            this.backgroundFillToolStripColorPickerSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundFillToolStripColorPickerSplitButton.Name = "backgroundFillToolStripColorPickerSplitButton";
            this.backgroundFillToolStripColorPickerSplitButton.Size = new System.Drawing.Size(32, 22);
            this.backgroundFillToolStripColorPickerSplitButton.Text = "Background Fill";
            this.backgroundFillToolStripColorPickerSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.backgroundFillToolStripColorPickerSplitButton.ColorChanged += new System.EventHandler(this.BackgroundFillToolStripColorPickerSplitButton_ColorChanged);
            // 
            // ColorSliderDemonstrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(propertiesSplitContainer);
            this.Controls.Add(toolStrip1);
            this.Name = "ColorSliderDemonstrationForm";
            this.Text = "ColorSlider Controls Demonstration";
            this.Controls.SetChildIndex(toolStrip1, 0);
            this.Controls.SetChildIndex(propertiesSplitContainer, 0);
            saturationSliderGroupBox.ResumeLayout(false);
            hueSliderGroupBox.ResumeLayout(false);
            alphaSliderGroupBox.ResumeLayout(false);
            blueSliderGroupBox.ResumeLayout(false);
            greenSliderGroupBox.ResumeLayout(false);
            redSliderGroupBox.ResumeLayout(false);
            nubStylesGroupBox.ResumeLayout(false);
            this.orientationTableLayoutPanel.ResumeLayout(false);
            propertiesSplitContainer.Panel1.ResumeLayout(false);
            propertiesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(propertiesSplitContainer)).EndInit();
            propertiesSplitContainer.ResumeLayout(false);
            eventsSplitContainer.Panel1.ResumeLayout(false);
            eventsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(eventsSplitContainer)).EndInit();
            eventsSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            lightnessSliderGroupBox.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private RgbaColorSlider redRgbColorSlider;
    private HueColorSlider hueColorSlider;
    private RgbaColorSlider alphaColorSlider;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private SaturationColorSlider saturationColorSlider;
    private LightnessColorSlider lightnessColorSlider;
    private RgbaColorSlider blueRgbColorSlider;
    private RgbaColorSlider greenRgbColorSlider;
    private EventsListBox eventsListBox;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton backgroundToolStripColorPickerSplitButton;
    private RgbaColorSlider verticalColorSlider;
    private RgbaColorSlider horizontalColorSlider;
    private RgbaColorSlider horizontalTopColorSlider;
    private RgbaColorSlider horizontalBottomColorSlider;
    private RgbaColorSlider verticalLeftColorSlider;
    private RgbaColorSlider verticalRightColorSlider;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton nubOutlineColorToolStripColorPickerSplitButton;
    private System.Windows.Forms.ToolStripButton showValueDividerToolStripButton;
    private System.Windows.Forms.ToolStripTextBox nubWidthToolStripTextBox;
    private System.Windows.Forms.ToolStripTextBox nubHeightToolStripTextBox;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton nubColorToolStripColorPickerSplitButton;
    private ToolStripControllerHosts.ToolStripColorPickerSplitButton backgroundFillToolStripColorPickerSplitButton;
    private System.Windows.Forms.TableLayoutPanel orientationTableLayoutPanel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
  }
}
