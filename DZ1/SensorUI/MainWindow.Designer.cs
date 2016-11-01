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
            this.CreateSensor = new System.Windows.Forms.Button();
            this.userAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SensorName
            // 
            this.SensorName.AutoSize = true;
            this.SensorName.Location = new System.Drawing.Point(12, 28);
            this.SensorName.Name = "SensorName";
            this.SensorName.Size = new System.Drawing.Size(69, 13);
            this.SensorName.TabIndex = 0;
            this.SensorName.Text = "Sensor name";
            // 
            // SensorNameTextbox
            // 
            this.SensorNameTextbox.Location = new System.Drawing.Point(87, 25);
            this.SensorNameTextbox.Name = "SensorNameTextbox";
            this.SensorNameTextbox.Size = new System.Drawing.Size(161, 20);
            this.SensorNameTextbox.TabIndex = 1;
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(302, 25);
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
            this.PortLabel.Location = new System.Drawing.Point(270, 29);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port";
            // 
            // CreateSensor
            // 
            this.CreateSensor.Location = new System.Drawing.Point(459, 24);
            this.CreateSensor.Name = "CreateSensor";
            this.CreateSensor.Size = new System.Drawing.Size(75, 23);
            this.CreateSensor.TabIndex = 5;
            this.CreateSensor.Text = "Create";
            this.CreateSensor.UseVisualStyleBackColor = true;
            this.CreateSensor.Click += new System.EventHandler(this.CreateSensor_Click);
            // 
            // userAddressBindingSource
            // 
            this.userAddressBindingSource.DataSource = typeof(Sensor.Service.UserAddress);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 61);
            this.Controls.Add(this.CreateSensor);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.SensorNameTextbox);
            this.Controls.Add(this.SensorName);
            this.Name = "MainWindow";
            this.Text = "SensorUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
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
        private System.Windows.Forms.Button CreateSensor;
        private System.Windows.Forms.BindingSource userAddressBindingSource;
    }
}

