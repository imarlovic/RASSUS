namespace SensorUI
{
    partial class Dashboard
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
            this.StopButton = new System.Windows.Forms.Button();
            this.MeasureButton = new System.Windows.Forms.Button();
            this.NeighbourLabel = new System.Windows.Forms.Label();
            this.NeighbourInfo = new System.Windows.Forms.Label();
            this.userAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RequestLogLabel = new System.Windows.Forms.Label();
            this.RequestLog = new System.Windows.Forms.Label();
            this.MainLogLabel = new System.Windows.Forms.Label();
            this.MainLog = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.SensorNameLabel = new System.Windows.Forms.Label();
            this.SensorName = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(173, 142);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 17;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MeasureButton
            // 
            this.MeasureButton.Location = new System.Drawing.Point(15, 142);
            this.MeasureButton.Name = "MeasureButton";
            this.MeasureButton.Size = new System.Drawing.Size(75, 23);
            this.MeasureButton.TabIndex = 18;
            this.MeasureButton.Text = "Measure";
            this.MeasureButton.UseVisualStyleBackColor = true;
            this.MeasureButton.Click += new System.EventHandler(this.MeasureButton_Click);
            // 
            // NeighbourLabel
            // 
            this.NeighbourLabel.AutoSize = true;
            this.NeighbourLabel.Location = new System.Drawing.Point(441, 147);
            this.NeighbourLabel.Name = "NeighbourLabel";
            this.NeighbourLabel.Size = new System.Drawing.Size(59, 13);
            this.NeighbourLabel.TabIndex = 10;
            this.NeighbourLabel.Text = "Neighbour:";
            // 
            // NeighbourInfo
            // 
            this.NeighbourInfo.AutoSize = true;
            this.NeighbourInfo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userAddressBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "Not found"));
            this.NeighbourInfo.Location = new System.Drawing.Point(506, 147);
            this.NeighbourInfo.Name = "NeighbourInfo";
            this.NeighbourInfo.Size = new System.Drawing.Size(54, 13);
            this.NeighbourInfo.TabIndex = 11;
            this.NeighbourInfo.Text = "Not found";
            // 
            // userAddressBindingSource
            // 
            this.userAddressBindingSource.DataSource = typeof(Sensor.Service.UserAddress);
            // 
            // RequestLogLabel
            // 
            this.RequestLogLabel.AutoSize = true;
            this.RequestLogLabel.Location = new System.Drawing.Point(12, 74);
            this.RequestLogLabel.Name = "RequestLogLabel";
            this.RequestLogLabel.Size = new System.Drawing.Size(71, 13);
            this.RequestLogLabel.TabIndex = 12;
            this.RequestLogLabel.Text = "Request Log:";
            // 
            // RequestLog
            // 
            this.RequestLog.AutoSize = true;
            this.RequestLog.Location = new System.Drawing.Point(89, 74);
            this.RequestLog.Name = "RequestLog";
            this.RequestLog.Size = new System.Drawing.Size(36, 13);
            this.RequestLog.TabIndex = 13;
            this.RequestLog.Text = "Empty";
            // 
            // MainLogLabel
            // 
            this.MainLogLabel.AutoSize = true;
            this.MainLogLabel.Location = new System.Drawing.Point(12, 40);
            this.MainLogLabel.Name = "MainLogLabel";
            this.MainLogLabel.Size = new System.Drawing.Size(54, 13);
            this.MainLogLabel.TabIndex = 14;
            this.MainLogLabel.Text = "Main Log:";
            // 
            // MainLog
            // 
            this.MainLog.AutoSize = true;
            this.MainLog.Location = new System.Drawing.Point(89, 40);
            this.MainLog.Name = "MainLog";
            this.MainLog.Size = new System.Drawing.Size(36, 13);
            this.MainLog.TabIndex = 15;
            this.MainLog.Text = "Empty";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(233, 9);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(20, 13);
            this.IPLabel.TabIndex = 9;
            this.IPLabel.Text = "IP:";
            // 
            // SensorNameLabel
            // 
            this.SensorNameLabel.AutoSize = true;
            this.SensorNameLabel.Location = new System.Drawing.Point(12, 9);
            this.SensorNameLabel.Name = "SensorNameLabel";
            this.SensorNameLabel.Size = new System.Drawing.Size(72, 13);
            this.SensorNameLabel.TabIndex = 6;
            this.SensorNameLabel.Text = "Sensor name:";
            // 
            // SensorName
            // 
            this.SensorName.AutoSize = true;
            this.SensorName.Location = new System.Drawing.Point(90, 9);
            this.SensorName.Name = "SensorName";
            this.SensorName.Size = new System.Drawing.Size(72, 13);
            this.SensorName.TabIndex = 19;
            this.SensorName.Text = "GenericName";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(259, 9);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(54, 13);
            this.IP.TabIndex = 19;
            this.IP.Text = "GenericIP";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 176);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.SensorName);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.MeasureButton);
            this.Controls.Add(this.NeighbourLabel);
            this.Controls.Add(this.NeighbourInfo);
            this.Controls.Add(this.RequestLogLabel);
            this.Controls.Add(this.RequestLog);
            this.Controls.Add(this.MainLogLabel);
            this.Controls.Add(this.MainLog);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.SensorNameLabel);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userAddressBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button MeasureButton;
        private System.Windows.Forms.Label NeighbourLabel;
        private System.Windows.Forms.Label NeighbourInfo;
        private System.Windows.Forms.BindingSource userAddressBindingSource;
        private System.Windows.Forms.Label RequestLogLabel;
        private System.Windows.Forms.Label RequestLog;
        private System.Windows.Forms.Label MainLogLabel;
        private System.Windows.Forms.Label MainLog;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label SensorNameLabel;
        private System.Windows.Forms.Label SensorName;
        private System.Windows.Forms.Label IP;
    }
}