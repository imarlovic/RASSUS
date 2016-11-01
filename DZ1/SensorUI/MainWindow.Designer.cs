namespace SensorUI
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.SensorName = new System.Windows.Forms.Label();
            this.SensorNameTextbox = new System.Windows.Forms.TextBox();
            this.PortInput = new System.Windows.Forms.NumericUpDown();
            this.PortLabel = new System.Windows.Forms.Label();
            this.MainLog = new System.Windows.Forms.Label();
            this.MeasureButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.CreateSensor = new System.Windows.Forms.Button();
            this.NeighbourInfo = new System.Windows.Forms.Label();
            this.userAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NeighbourLabel = new System.Windows.Forms.Label();
            this.MainLogLabel = new System.Windows.Forms.Label();
            this.RequestLog = new System.Windows.Forms.Label();
            this.RequestLogLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SensorName
            // 
            this.SensorName.AutoSize = true;
            this.SensorName.Location = new System.Drawing.Point(12, 9);
            this.SensorName.Name = "SensorName";
            this.SensorName.Size = new System.Drawing.Size(69, 13);
            this.SensorName.TabIndex = 0;
            this.SensorName.Text = "Sensor name";
            // 
            // SensorNameTextbox
            // 
            this.SensorNameTextbox.Location = new System.Drawing.Point(87, 6);
            this.SensorNameTextbox.Name = "SensorNameTextbox";
            this.SensorNameTextbox.Size = new System.Drawing.Size(161, 20);
            this.SensorNameTextbox.TabIndex = 1;
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(380, 5);
            this.PortInput.Maximum = new decimal(new int[] {
            55599,
            0,
            0,
            0});
            this.PortInput.Minimum = new decimal(new int[] {
            55500,
            0,
            0,
            0});
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(120, 20);
            this.PortInput.TabIndex = 2;
            this.PortInput.Value = new decimal(new int[] {
            55501,
            0,
            0,
            0});
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(348, 9);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port";
            // 
            // MainLog
            // 
            this.MainLog.AutoSize = true;
            this.MainLog.Location = new System.Drawing.Point(89, 44);
            this.MainLog.Name = "MainLog";
            this.MainLog.Size = new System.Drawing.Size(36, 13);
            this.MainLog.TabIndex = 4;
            this.MainLog.Text = "Empty";
            // 
            // MeasureButton
            // 
            this.MeasureButton.Enabled = false;
            this.MeasureButton.Location = new System.Drawing.Point(15, 146);
            this.MeasureButton.Name = "MeasureButton";
            this.MeasureButton.Size = new System.Drawing.Size(75, 23);
            this.MeasureButton.TabIndex = 5;
            this.MeasureButton.Text = "Measure";
            this.MeasureButton.UseVisualStyleBackColor = true;
            this.MeasureButton.Click += new System.EventHandler(this.MeasureButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(173, 146);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // CreateSensor
            // 
            this.CreateSensor.Location = new System.Drawing.Point(563, 3);
            this.CreateSensor.Name = "CreateSensor";
            this.CreateSensor.Size = new System.Drawing.Size(75, 23);
            this.CreateSensor.TabIndex = 5;
            this.CreateSensor.Text = "Create";
            this.CreateSensor.UseVisualStyleBackColor = true;
            this.CreateSensor.Click += new System.EventHandler(this.CreateSensor_Click);
            // 
            // NeighbourInfo
            // 
            this.NeighbourInfo.AutoSize = true;
            this.NeighbourInfo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userAddressBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "Not found"));
            this.NeighbourInfo.Location = new System.Drawing.Point(506, 151);
            this.NeighbourInfo.Name = "NeighbourInfo";
            this.NeighbourInfo.Size = new System.Drawing.Size(0, 13);
            this.NeighbourInfo.TabIndex = 4;
            // 
            // userAddressBindingSource
            // 
            this.userAddressBindingSource.DataSource = typeof(Sensor.Service.UserAddress);
            // 
            // NeighbourLabel
            // 
            this.NeighbourLabel.AutoSize = true;
            this.NeighbourLabel.Location = new System.Drawing.Point(441, 151);
            this.NeighbourLabel.Name = "NeighbourLabel";
            this.NeighbourLabel.Size = new System.Drawing.Size(59, 13);
            this.NeighbourLabel.TabIndex = 4;
            this.NeighbourLabel.Text = "Neighbour:";
            // 
            // MainLogLabel
            // 
            this.MainLogLabel.AutoSize = true;
            this.MainLogLabel.Location = new System.Drawing.Point(12, 44);
            this.MainLogLabel.Name = "MainLogLabel";
            this.MainLogLabel.Size = new System.Drawing.Size(54, 13);
            this.MainLogLabel.TabIndex = 4;
            this.MainLogLabel.Text = "Main Log:";
            // 
            // RequestLog
            // 
            this.RequestLog.AutoSize = true;
            this.RequestLog.Location = new System.Drawing.Point(89, 78);
            this.RequestLog.Name = "RequestLog";
            this.RequestLog.Size = new System.Drawing.Size(36, 13);
            this.RequestLog.TabIndex = 4;
            this.RequestLog.Text = "Empty";
            // 
            // RequestLogLabel
            // 
            this.RequestLogLabel.AutoSize = true;
            this.RequestLogLabel.Location = new System.Drawing.Point(12, 78);
            this.RequestLogLabel.Name = "RequestLogLabel";
            this.RequestLogLabel.Size = new System.Drawing.Size(71, 13);
            this.RequestLogLabel.TabIndex = 4;
            this.RequestLogLabel.Text = "Request Log:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 181);
            this.Controls.Add(this.CreateSensor);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.MeasureButton);
            this.Controls.Add(this.NeighbourLabel);
            this.Controls.Add(this.NeighbourInfo);
            this.Controls.Add(this.RequestLogLabel);
            this.Controls.Add(this.RequestLog);
            this.Controls.Add(this.MainLogLabel);
            this.Controls.Add(this.MainLog);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.SensorNameTextbox);
            this.Controls.Add(this.SensorName);
            this.Name = "MainWindow";
            this.Text = "SensorUI";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAddressBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SensorName;
        private System.Windows.Forms.TextBox SensorNameTextbox;
        private System.Windows.Forms.NumericUpDown PortInput;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label MainLog;
        private System.Windows.Forms.Button MeasureButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button CreateSensor;
        private System.Windows.Forms.Label NeighbourInfo;
        private System.Windows.Forms.BindingSource userAddressBindingSource;
        private System.Windows.Forms.Label NeighbourLabel;
        private System.Windows.Forms.Label MainLogLabel;
        private System.Windows.Forms.Label RequestLog;
        private System.Windows.Forms.Label RequestLogLabel;
    }
}

