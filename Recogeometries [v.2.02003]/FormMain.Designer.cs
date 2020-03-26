namespace Recogeometries_project
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label_Discription = new System.Windows.Forms.Label();
            this.tabControl_ControlPanel = new System.Windows.Forms.TabControl();
            this.tabPage_Input = new System.Windows.Forms.TabPage();
            this.pictureBox_input = new System.Windows.Forms.PictureBox();
            this.tabPage_process = new System.Windows.Forms.TabPage();
            this.button_exportProcess = new System.Windows.Forms.Button();
            this.chart_edgesAlloChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox_edgesAllocationResults = new System.Windows.Forms.ListBox();
            this.pictureBox_process = new System.Windows.Forms.PictureBox();
            this.tabPage_result = new System.Windows.Forms.TabPage();
            this.button_addNewModel = new System.Windows.Forms.Button();
            this.groupBox_mostSimiliarModel = new System.Windows.Forms.GroupBox();
            this.listBox_mostSimiliarModels = new System.Windows.Forms.ListBox();
            this.groupBox_extractedModel = new System.Windows.Forms.GroupBox();
            this.listBox_extractedModel = new System.Windows.Forms.ListBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_finalResult = new System.Windows.Forms.Label();
            this.tabControl_ControlPanel.SuspendLayout();
            this.tabPage_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_input)).BeginInit();
            this.tabPage_process.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_edgesAlloChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_process)).BeginInit();
            this.tabPage_result.SuspendLayout();
            this.groupBox_mostSimiliarModel.SuspendLayout();
            this.groupBox_extractedModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Discription
            // 
            this.label_Discription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Discription.Location = new System.Drawing.Point(-2, 2);
            this.label_Discription.Name = "label_Discription";
            this.label_Discription.Size = new System.Drawing.Size(575, 23);
            this.label_Discription.TabIndex = 0;
            this.label_Discription.Text = "Discription: A project mainly aimed to simulate the XAi(Explainable A.I.) based a" +
    "lgorithm of simple shape recognition.";
            this.label_Discription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Discription.Click += new System.EventHandler(this.label_Discription_Click);
            // 
            // tabControl_ControlPanel
            // 
            this.tabControl_ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_ControlPanel.Controls.Add(this.tabPage_Input);
            this.tabControl_ControlPanel.Controls.Add(this.tabPage_process);
            this.tabControl_ControlPanel.Controls.Add(this.tabPage_result);
            this.tabControl_ControlPanel.Location = new System.Drawing.Point(12, 28);
            this.tabControl_ControlPanel.Name = "tabControl_ControlPanel";
            this.tabControl_ControlPanel.SelectedIndex = 0;
            this.tabControl_ControlPanel.Size = new System.Drawing.Size(549, 384);
            this.tabControl_ControlPanel.TabIndex = 1;
            // 
            // tabPage_Input
            // 
            this.tabPage_Input.Controls.Add(this.pictureBox_input);
            this.tabPage_Input.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Input.Name = "tabPage_Input";
            this.tabPage_Input.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Input.Size = new System.Drawing.Size(541, 358);
            this.tabPage_Input.TabIndex = 0;
            this.tabPage_Input.Text = "INPUT";
            this.tabPage_Input.UseVisualStyleBackColor = true;
            // 
            // pictureBox_input
            // 
            this.pictureBox_input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_input.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_input.Name = "pictureBox_input";
            this.pictureBox_input.Size = new System.Drawing.Size(532, 349);
            this.pictureBox_input.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_input.TabIndex = 0;
            this.pictureBox_input.TabStop = false;
            // 
            // tabPage_process
            // 
            this.tabPage_process.Controls.Add(this.button_exportProcess);
            this.tabPage_process.Controls.Add(this.chart_edgesAlloChart);
            this.tabPage_process.Controls.Add(this.listBox_edgesAllocationResults);
            this.tabPage_process.Controls.Add(this.pictureBox_process);
            this.tabPage_process.Location = new System.Drawing.Point(4, 22);
            this.tabPage_process.Name = "tabPage_process";
            this.tabPage_process.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_process.Size = new System.Drawing.Size(541, 358);
            this.tabPage_process.TabIndex = 1;
            this.tabPage_process.Text = "PROCESS";
            this.tabPage_process.UseVisualStyleBackColor = true;
            // 
            // button_exportProcess
            // 
            this.button_exportProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exportProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_exportProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_exportProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_exportProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exportProcess.Location = new System.Drawing.Point(479, 333);
            this.button_exportProcess.Name = "button_exportProcess";
            this.button_exportProcess.Size = new System.Drawing.Size(55, 24);
            this.button_exportProcess.TabIndex = 4;
            this.button_exportProcess.Text = "Export";
            this.button_exportProcess.UseVisualStyleBackColor = true;
            this.button_exportProcess.Click += new System.EventHandler(this.button_exportProcess_Click);
            // 
            // chart_edgesAlloChart
            // 
            this.chart_edgesAlloChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chart_edgesAlloChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_edgesAlloChart.Legends.Add(legend4);
            this.chart_edgesAlloChart.Location = new System.Drawing.Point(6, 265);
            this.chart_edgesAlloChart.Name = "chart_edgesAlloChart";
            this.chart_edgesAlloChart.Size = new System.Drawing.Size(529, 87);
            this.chart_edgesAlloChart.TabIndex = 3;
            // 
            // listBox_edgesAllocationResults
            // 
            this.listBox_edgesAllocationResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_edgesAllocationResults.FormattingEnabled = true;
            this.listBox_edgesAllocationResults.Location = new System.Drawing.Point(382, 7);
            this.listBox_edgesAllocationResults.Name = "listBox_edgesAllocationResults";
            this.listBox_edgesAllocationResults.Size = new System.Drawing.Size(153, 251);
            this.listBox_edgesAllocationResults.TabIndex = 2;
            // 
            // pictureBox_process
            // 
            this.pictureBox_process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_process.Location = new System.Drawing.Point(4, 3);
            this.pictureBox_process.Name = "pictureBox_process";
            this.pictureBox_process.Size = new System.Drawing.Size(372, 255);
            this.pictureBox_process.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_process.TabIndex = 1;
            this.pictureBox_process.TabStop = false;
            // 
            // tabPage_result
            // 
            this.tabPage_result.Controls.Add(this.label_finalResult);
            this.tabPage_result.Controls.Add(this.button_addNewModel);
            this.tabPage_result.Controls.Add(this.groupBox_mostSimiliarModel);
            this.tabPage_result.Controls.Add(this.groupBox_extractedModel);
            this.tabPage_result.Location = new System.Drawing.Point(4, 22);
            this.tabPage_result.Name = "tabPage_result";
            this.tabPage_result.Size = new System.Drawing.Size(541, 358);
            this.tabPage_result.TabIndex = 2;
            this.tabPage_result.Text = "RESULT";
            this.tabPage_result.UseVisualStyleBackColor = true;
            // 
            // button_addNewModel
            // 
            this.button_addNewModel.Location = new System.Drawing.Point(222, 52);
            this.button_addNewModel.Name = "button_addNewModel";
            this.button_addNewModel.Size = new System.Drawing.Size(75, 45);
            this.button_addNewModel.TabIndex = 3;
            this.button_addNewModel.Text = "Add new model";
            this.button_addNewModel.UseVisualStyleBackColor = true;
            this.button_addNewModel.Click += new System.EventHandler(this.button_addNewModel_Click);
            // 
            // groupBox_mostSimiliarModel
            // 
            this.groupBox_mostSimiliarModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_mostSimiliarModel.Controls.Add(this.listBox_mostSimiliarModels);
            this.groupBox_mostSimiliarModel.Location = new System.Drawing.Point(303, 52);
            this.groupBox_mostSimiliarModel.Name = "groupBox_mostSimiliarModel";
            this.groupBox_mostSimiliarModel.Size = new System.Drawing.Size(235, 303);
            this.groupBox_mostSimiliarModel.TabIndex = 2;
            this.groupBox_mostSimiliarModel.TabStop = false;
            this.groupBox_mostSimiliarModel.Text = "Most similiar model(s)";
            // 
            // listBox_mostSimiliarModels
            // 
            this.listBox_mostSimiliarModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_mostSimiliarModels.FormattingEnabled = true;
            this.listBox_mostSimiliarModels.Location = new System.Drawing.Point(6, 19);
            this.listBox_mostSimiliarModels.Name = "listBox_mostSimiliarModels";
            this.listBox_mostSimiliarModels.Size = new System.Drawing.Size(223, 277);
            this.listBox_mostSimiliarModels.TabIndex = 0;
            // 
            // groupBox_extractedModel
            // 
            this.groupBox_extractedModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_extractedModel.Controls.Add(this.listBox_extractedModel);
            this.groupBox_extractedModel.Location = new System.Drawing.Point(3, 52);
            this.groupBox_extractedModel.Name = "groupBox_extractedModel";
            this.groupBox_extractedModel.Size = new System.Drawing.Size(213, 303);
            this.groupBox_extractedModel.TabIndex = 1;
            this.groupBox_extractedModel.TabStop = false;
            this.groupBox_extractedModel.Text = "Extracted model";
            // 
            // listBox_extractedModel
            // 
            this.listBox_extractedModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_extractedModel.FormattingEnabled = true;
            this.listBox_extractedModel.Location = new System.Drawing.Point(8, 19);
            this.listBox_extractedModel.Name = "listBox_extractedModel";
            this.listBox_extractedModel.Size = new System.Drawing.Size(199, 277);
            this.listBox_extractedModel.TabIndex = 0;
            // 
            // button_load
            // 
            this.button_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_load.Location = new System.Drawing.Point(12, 418);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "Browse Image";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_next
            // 
            this.button_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.Location = new System.Drawing.Point(93, 418);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 3;
            this.button_next.Text = "NEXT STEP";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_finalResult
            // 
            this.label_finalResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_finalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_finalResult.Location = new System.Drawing.Point(107, 16);
            this.label_finalResult.Name = "label_finalResult";
            this.label_finalResult.Size = new System.Drawing.Size(309, 23);
            this.label_finalResult.TabIndex = 4;
            this.label_finalResult.Text = "UNKNOWN";
            this.label_finalResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 457);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.tabControl_ControlPanel);
            this.Controls.Add(this.label_Discription);
            this.Name = "FormMain";
            this.Text = "Recogeometries [v.2.02003]";
            this.tabControl_ControlPanel.ResumeLayout(false);
            this.tabPage_Input.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_input)).EndInit();
            this.tabPage_process.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_edgesAlloChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_process)).EndInit();
            this.tabPage_result.ResumeLayout(false);
            this.groupBox_mostSimiliarModel.ResumeLayout(false);
            this.groupBox_extractedModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Discription;
        private System.Windows.Forms.TabControl tabControl_ControlPanel;
        private System.Windows.Forms.TabPage tabPage_Input;
        private System.Windows.Forms.TabPage tabPage_process;
        private System.Windows.Forms.TabPage tabPage_result;
        private System.Windows.Forms.PictureBox pictureBox_input;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.PictureBox pictureBox_process;
        private System.Windows.Forms.ListBox listBox_edgesAllocationResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_edgesAlloChart;
        private System.Windows.Forms.Button button_exportProcess;
        private System.Windows.Forms.GroupBox groupBox_extractedModel;
        private System.Windows.Forms.ListBox listBox_extractedModel;
        private System.Windows.Forms.GroupBox groupBox_mostSimiliarModel;
        private System.Windows.Forms.ListBox listBox_mostSimiliarModels;
        private System.Windows.Forms.Button button_addNewModel;
        private System.Windows.Forms.Label label_finalResult;
    }
}

