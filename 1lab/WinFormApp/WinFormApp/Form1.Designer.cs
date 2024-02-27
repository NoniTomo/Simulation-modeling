namespace WinFormApp
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edEndV = new System.Windows.Forms.NumericUpDown();
            this.edMaxY = new System.Windows.Forms.NumericUpDown();
            this.edMaxX = new System.Windows.Forms.NumericUpDown();
            this.btStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edStep = new System.Windows.Forms.NumericUpDown();
            this.edSize = new System.Windows.Forms.NumericUpDown();
            this.edWeight = new System.Windows.Forms.NumericUpDown();
            this.laStep = new System.Windows.Forms.Label();
            this.laSize = new System.Windows.Forms.Label();
            this.laWeight = new System.Windows.Forms.Label();
            this.edSpeed = new System.Windows.Forms.NumericUpDown();
            this.edAngle = new System.Windows.Forms.NumericUpDown();
            this.edHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edEndV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edEndV);
            this.panel1.Controls.Add(this.edMaxY);
            this.panel1.Controls.Add(this.edMaxX);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.edStep);
            this.panel1.Controls.Add(this.edSize);
            this.panel1.Controls.Add(this.edWeight);
            this.panel1.Controls.Add(this.laStep);
            this.panel1.Controls.Add(this.laSize);
            this.panel1.Controls.Add(this.laWeight);
            this.panel1.Controls.Add(this.edSpeed);
            this.panel1.Controls.Add(this.edAngle);
            this.panel1.Controls.Add(this.edHeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 106);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // edEndV
            // 
            this.edEndV.DecimalPlaces = 3;
            this.edEndV.Enabled = false;
            this.edEndV.Location = new System.Drawing.Point(542, 67);
            this.edEndV.Name = "edEndV";
            this.edEndV.Size = new System.Drawing.Size(75, 22);
            this.edEndV.TabIndex = 21;
            // 
            // edMaxY
            // 
            this.edMaxY.DecimalPlaces = 3;
            this.edMaxY.Enabled = false;
            this.edMaxY.Location = new System.Drawing.Point(542, 39);
            this.edMaxY.Name = "edMaxY";
            this.edMaxY.Size = new System.Drawing.Size(75, 22);
            this.edMaxY.TabIndex = 20;
            // 
            // edMaxX
            // 
            this.edMaxX.DecimalPlaces = 3;
            this.edMaxX.Enabled = false;
            this.edMaxX.Location = new System.Drawing.Point(542, 11);
            this.edMaxX.Name = "edMaxX";
            this.edMaxX.Size = new System.Drawing.Size(75, 22);
            this.edMaxX.TabIndex = 19;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(633, 11);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(112, 78);
            this.btStart.TabIndex = 6;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "End V = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max Y = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Max X = ";
            // 
            // edStep
            // 
            this.edStep.DecimalPlaces = 3;
            this.edStep.Location = new System.Drawing.Point(316, 67);
            this.edStep.Name = "edStep";
            this.edStep.Size = new System.Drawing.Size(120, 22);
            this.edStep.TabIndex = 12;
            this.edStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // edSize
            // 
            this.edSize.DecimalPlaces = 2;
            this.edSize.Location = new System.Drawing.Point(316, 39);
            this.edSize.Name = "edSize";
            this.edSize.Size = new System.Drawing.Size(120, 22);
            this.edSize.TabIndex = 11;
            this.edSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // edWeight
            // 
            this.edWeight.DecimalPlaces = 2;
            this.edWeight.Location = new System.Drawing.Point(316, 10);
            this.edWeight.Name = "edWeight";
            this.edWeight.Size = new System.Drawing.Size(120, 22);
            this.edWeight.TabIndex = 10;
            this.edWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // laStep
            // 
            this.laStep.AutoSize = true;
            this.laStep.Location = new System.Drawing.Point(257, 69);
            this.laStep.Name = "laStep";
            this.laStep.Size = new System.Drawing.Size(35, 16);
            this.laStep.TabIndex = 9;
            this.laStep.Text = "Step";
            // 
            // laSize
            // 
            this.laSize.AutoSize = true;
            this.laSize.Location = new System.Drawing.Point(257, 41);
            this.laSize.Name = "laSize";
            this.laSize.Size = new System.Drawing.Size(33, 16);
            this.laSize.TabIndex = 8;
            this.laSize.Text = "Size";
            // 
            // laWeight
            // 
            this.laWeight.AutoSize = true;
            this.laWeight.Location = new System.Drawing.Point(257, 13);
            this.laWeight.Name = "laWeight";
            this.laWeight.Size = new System.Drawing.Size(49, 16);
            this.laWeight.TabIndex = 7;
            this.laWeight.Text = "Weight";
            // 
            // edSpeed
            // 
            this.edSpeed.Location = new System.Drawing.Point(91, 67);
            this.edSpeed.Name = "edSpeed";
            this.edSpeed.Size = new System.Drawing.Size(120, 22);
            this.edSpeed.TabIndex = 5;
            this.edSpeed.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // edAngle
            // 
            this.edAngle.Location = new System.Drawing.Point(91, 39);
            this.edAngle.Name = "edAngle";
            this.edAngle.Size = new System.Drawing.Size(120, 22);
            this.edAngle.TabIndex = 4;
            this.edAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.edAngle.ValueChanged += new System.EventHandler(this.edAngle_ValueChanged);
            // 
            // edHeight
            // 
            this.edHeight.Location = new System.Drawing.Point(91, 11);
            this.edHeight.Name = "edHeight";
            this.edHeight.Size = new System.Drawing.Size(120, 22);
            this.edHeight.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Angle ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Height";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chart1
            // 
            chartArea4.AxisX.Maximum = 25D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisY.Maximum = 6D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart1.Location = new System.Drawing.Point(0, 116);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(800, 528);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 644);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edEndV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown edSpeed;
        private System.Windows.Forms.NumericUpDown edAngle;
        private System.Windows.Forms.NumericUpDown edHeight;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label laStep;
        private System.Windows.Forms.Label laSize;
        private System.Windows.Forms.Label laWeight;
        private System.Windows.Forms.NumericUpDown edStep;
        private System.Windows.Forms.NumericUpDown edSize;
        private System.Windows.Forms.NumericUpDown edWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown edEndV;
        private System.Windows.Forms.NumericUpDown edMaxY;
        private System.Windows.Forms.NumericUpDown edMaxX;
    }
}

