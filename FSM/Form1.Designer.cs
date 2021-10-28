
namespace FSM
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.switchOnBtn = new System.Windows.Forms.Button();
            this.enableSwitchOnBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.motorVelocityLbl = new System.Windows.Forms.Label();
            this.desiredMotorVelocityInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.enableOperationBtn = new System.Windows.Forms.Button();
            this.quickstopBtn = new System.Windows.Forms.Button();
            this.faultResetBtn = new System.Windows.Forms.Button();
            this.simulateFaultBtn = new System.Windows.Forms.Button();
            this.disableSwitchOnBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.desiredMotorVelocityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current State: ";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(185, 9);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(69, 17);
            this.stateLabel.TabIndex = 1;
            this.stateLabel.Text = "Initialising";
            // 
            // switchOnBtn
            // 
            this.switchOnBtn.Location = new System.Drawing.Point(233, 49);
            this.switchOnBtn.Name = "switchOnBtn";
            this.switchOnBtn.Size = new System.Drawing.Size(160, 25);
            this.switchOnBtn.TabIndex = 2;
            this.switchOnBtn.Text = "Switch ON";
            this.switchOnBtn.UseVisualStyleBackColor = true;
            this.switchOnBtn.Click += new System.EventHandler(this.switchOnBtn_Click);
            // 
            // enableSwitchOnBtn
            // 
            this.enableSwitchOnBtn.Location = new System.Drawing.Point(38, 49);
            this.enableSwitchOnBtn.Name = "enableSwitchOnBtn";
            this.enableSwitchOnBtn.Size = new System.Drawing.Size(160, 25);
            this.enableSwitchOnBtn.TabIndex = 3;
            this.enableSwitchOnBtn.Text = "Enable Switch ON\r\n";
            this.enableSwitchOnBtn.UseVisualStyleBackColor = true;
            this.enableSwitchOnBtn.Click += new System.EventHandler(this.enableSwitchOnBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Motor Velocity (rpm): ";
            // 
            // motorVelocityLbl
            // 
            this.motorVelocityLbl.AutoSize = true;
            this.motorVelocityLbl.Location = new System.Drawing.Point(649, 9);
            this.motorVelocityLbl.Name = "motorVelocityLbl";
            this.motorVelocityLbl.Size = new System.Drawing.Size(16, 17);
            this.motorVelocityLbl.TabIndex = 5;
            this.motorVelocityLbl.Text = "0";
            // 
            // desiredMotorVelocityInput
            // 
            this.desiredMotorVelocityInput.Location = new System.Drawing.Point(704, 49);
            this.desiredMotorVelocityInput.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.desiredMotorVelocityInput.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.desiredMotorVelocityInput.Name = "desiredMotorVelocityInput";
            this.desiredMotorVelocityInput.Size = new System.Drawing.Size(120, 22);
            this.desiredMotorVelocityInput.TabIndex = 6;
            this.desiredMotorVelocityInput.ValueChanged += new System.EventHandler(this.desiredMotorVelocityInput_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Target Motor Velocity (rpm): ";
            // 
            // enableOperationBtn
            // 
            this.enableOperationBtn.Location = new System.Drawing.Point(38, 98);
            this.enableOperationBtn.Name = "enableOperationBtn";
            this.enableOperationBtn.Size = new System.Drawing.Size(160, 25);
            this.enableOperationBtn.TabIndex = 8;
            this.enableOperationBtn.Text = "Enable Operation";
            this.enableOperationBtn.UseVisualStyleBackColor = true;
            this.enableOperationBtn.Click += new System.EventHandler(this.enableOperationBtn_Click);
            // 
            // quickstopBtn
            // 
            this.quickstopBtn.Location = new System.Drawing.Point(233, 98);
            this.quickstopBtn.Name = "quickstopBtn";
            this.quickstopBtn.Size = new System.Drawing.Size(160, 25);
            this.quickstopBtn.TabIndex = 9;
            this.quickstopBtn.Text = "Quickstop";
            this.quickstopBtn.UseVisualStyleBackColor = true;
            this.quickstopBtn.Click += new System.EventHandler(this.quickstopBtn_Click);
            // 
            // faultResetBtn
            // 
            this.faultResetBtn.Location = new System.Drawing.Point(38, 274);
            this.faultResetBtn.Name = "faultResetBtn";
            this.faultResetBtn.Size = new System.Drawing.Size(160, 25);
            this.faultResetBtn.TabIndex = 10;
            this.faultResetBtn.Text = "Fault Reset";
            this.faultResetBtn.UseVisualStyleBackColor = true;
            this.faultResetBtn.Click += new System.EventHandler(this.faultResetBtn_Click);
            // 
            // simulateFaultBtn
            // 
            this.simulateFaultBtn.Location = new System.Drawing.Point(652, 274);
            this.simulateFaultBtn.Name = "simulateFaultBtn";
            this.simulateFaultBtn.Size = new System.Drawing.Size(160, 25);
            this.simulateFaultBtn.TabIndex = 11;
            this.simulateFaultBtn.Text = "Simulate Fault";
            this.simulateFaultBtn.UseVisualStyleBackColor = true;
            this.simulateFaultBtn.Click += new System.EventHandler(this.simulateFaultBtn_Click);
            // 
            // disableSwitchOnBtn
            // 
            this.disableSwitchOnBtn.Location = new System.Drawing.Point(136, 147);
            this.disableSwitchOnBtn.Name = "disableSwitchOnBtn";
            this.disableSwitchOnBtn.Size = new System.Drawing.Size(160, 25);
            this.disableSwitchOnBtn.TabIndex = 12;
            this.disableSwitchOnBtn.Text = "Disable Switch On";
            this.disableSwitchOnBtn.UseVisualStyleBackColor = true;
            this.disableSwitchOnBtn.Click += new System.EventHandler(this.disableSwitchOnBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 329);
            this.Controls.Add(this.disableSwitchOnBtn);
            this.Controls.Add(this.simulateFaultBtn);
            this.Controls.Add(this.faultResetBtn);
            this.Controls.Add(this.quickstopBtn);
            this.Controls.Add(this.enableOperationBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.desiredMotorVelocityInput);
            this.Controls.Add(this.motorVelocityLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enableSwitchOnBtn);
            this.Controls.Add(this.switchOnBtn);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FSM";
            ((System.ComponentModel.ISupportInitialize)(this.desiredMotorVelocityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button switchOnBtn;
        private System.Windows.Forms.Button enableSwitchOnBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label motorVelocityLbl;
        private System.Windows.Forms.NumericUpDown desiredMotorVelocityInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button enableOperationBtn;
        private System.Windows.Forms.Button quickstopBtn;
        private System.Windows.Forms.Button faultResetBtn;
        private System.Windows.Forms.Button simulateFaultBtn;
        private System.Windows.Forms.Button disableSwitchOnBtn;
    }
}

