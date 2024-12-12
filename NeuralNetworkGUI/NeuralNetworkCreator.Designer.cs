namespace NeuralNetworkGUI
{
    partial class NeuralNetworkCreator
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
            this.statusStripNN = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStripNN = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTrainingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTrainNetwork = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblHiddenNeurons = new System.Windows.Forms.Label();
            this.txtHiddenNeurons = new System.Windows.Forms.TextBox();
            this.dgvTrainingData = new System.Windows.Forms.DataGridView();
            this.txtNumOfOuputNeurons = new System.Windows.Forms.TextBox();
            this.lblNumOfOutputNeurons = new System.Windows.Forms.Label();
            this.lblNumOfInputs = new System.Windows.Forms.Label();
            this.txtNumOfInputs = new System.Windows.Forms.TextBox();
            this.lblErrThreshold = new System.Windows.Forms.Label();
            this.txtErrThreshold = new System.Windows.Forms.TextBox();
            this.lblMaxIterNum = new System.Windows.Forms.Label();
            this.txtMaxNumOfIter = new System.Windows.Forms.TextBox();
            this.lblNumberOfLayers = new System.Windows.Forms.Label();
            this.cbNumOfLayers = new System.Windows.Forms.ComboBox();
            this.bsTrainingExamples = new System.Windows.Forms.BindingSource(this.components);
            this.statusStripNN.SuspendLayout();
            this.menuStripNN.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrainingExamples)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripNN
            // 
            this.statusStripNN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStripNN.Location = new System.Drawing.Point(0, 383);
            this.statusStripNN.Name = "statusStripNN";
            this.statusStripNN.Size = new System.Drawing.Size(633, 22);
            this.statusStripNN.TabIndex = 0;
            this.statusStripNN.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStripNN
            // 
            this.menuStripNN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.trainingDataToolStripMenuItem});
            this.menuStripNN.Location = new System.Drawing.Point(0, 0);
            this.menuStripNN.Name = "menuStripNN";
            this.menuStripNN.Size = new System.Drawing.Size(633, 24);
            this.menuStripNN.TabIndex = 1;
            this.menuStripNN.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNetworkToolStripMenuItem,
            this.saveNetworkToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exiToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loadNetworkToolStripMenuItem
            // 
            this.loadNetworkToolStripMenuItem.Name = "loadNetworkToolStripMenuItem";
            this.loadNetworkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadNetworkToolStripMenuItem.Text = "Load Network";
            this.loadNetworkToolStripMenuItem.Click += new System.EventHandler(this.loadNetworkToolStripMenuItem_Click);
            // 
            // saveNetworkToolStripMenuItem
            // 
            this.saveNetworkToolStripMenuItem.Name = "saveNetworkToolStripMenuItem";
            this.saveNetworkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveNetworkToolStripMenuItem.Text = "Save Network";
            this.saveNetworkToolStripMenuItem.Click += new System.EventHandler(this.saveNetworkToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exiToolStripMenuItem
            // 
            this.exiToolStripMenuItem.Name = "exiToolStripMenuItem";
            this.exiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exiToolStripMenuItem.Text = "Exit";
            // 
            // trainingDataToolStripMenuItem
            // 
            this.trainingDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTrainingDataToolStripMenuItem});
            this.trainingDataToolStripMenuItem.Name = "trainingDataToolStripMenuItem";
            this.trainingDataToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.trainingDataToolStripMenuItem.Text = "Training Data";
            // 
            // loadTrainingDataToolStripMenuItem
            // 
            this.loadTrainingDataToolStripMenuItem.Name = "loadTrainingDataToolStripMenuItem";
            this.loadTrainingDataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.loadTrainingDataToolStripMenuItem.Text = "Load training data";
            this.loadTrainingDataToolStripMenuItem.Click += new System.EventHandler(this.loadTrainingDataToolStripMenuItem_Click);
            // 
            // btnTrainNetwork
            // 
            this.btnTrainNetwork.Location = new System.Drawing.Point(7, 328);
            this.btnTrainNetwork.Name = "btnTrainNetwork";
            this.btnTrainNetwork.Size = new System.Drawing.Size(286, 27);
            this.btnTrainNetwork.TabIndex = 2;
            this.btnTrainNetwork.Text = "Train network";
            this.btnTrainNetwork.UseVisualStyleBackColor = true;
            this.btnTrainNetwork.Click += new System.EventHandler(this.btnTrainNetwork_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblHiddenNeurons);
            this.splitContainer1.Panel2.Controls.Add(this.txtHiddenNeurons);
            this.splitContainer1.Panel2.Controls.Add(this.dgvTrainingData);
            this.splitContainer1.Panel2.Controls.Add(this.txtNumOfOuputNeurons);
            this.splitContainer1.Panel2.Controls.Add(this.lblNumOfOutputNeurons);
            this.splitContainer1.Panel2.Controls.Add(this.lblNumOfInputs);
            this.splitContainer1.Panel2.Controls.Add(this.txtNumOfInputs);
            this.splitContainer1.Panel2.Controls.Add(this.lblErrThreshold);
            this.splitContainer1.Panel2.Controls.Add(this.txtErrThreshold);
            this.splitContainer1.Panel2.Controls.Add(this.lblMaxIterNum);
            this.splitContainer1.Panel2.Controls.Add(this.txtMaxNumOfIter);
            this.splitContainer1.Panel2.Controls.Add(this.lblNumberOfLayers);
            this.splitContainer1.Panel2.Controls.Add(this.cbNumOfLayers);
            this.splitContainer1.Panel2.Controls.Add(this.btnTrainNetwork);
            this.splitContainer1.Size = new System.Drawing.Size(633, 359);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(209, 359);
            this.treeView1.TabIndex = 0;
            // 
            // lblHiddenNeurons
            // 
            this.lblHiddenNeurons.AutoSize = true;
            this.lblHiddenNeurons.Location = new System.Drawing.Point(4, 97);
            this.lblHiddenNeurons.Name = "lblHiddenNeurons";
            this.lblHiddenNeurons.Size = new System.Drawing.Size(82, 13);
            this.lblHiddenNeurons.TabIndex = 15;
            this.lblHiddenNeurons.Text = "Hidden neurons";
            // 
            // txtHiddenNeurons
            // 
            this.txtHiddenNeurons.Location = new System.Drawing.Point(172, 94);
            this.txtHiddenNeurons.Name = "txtHiddenNeurons";
            this.txtHiddenNeurons.Size = new System.Drawing.Size(121, 20);
            this.txtHiddenNeurons.TabIndex = 14;
            this.txtHiddenNeurons.Text = "10";
            // 
            // dgvTrainingData
            // 
            this.dgvTrainingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainingData.Location = new System.Drawing.Point(7, 172);
            this.dgvTrainingData.Name = "dgvTrainingData";
            this.dgvTrainingData.Size = new System.Drawing.Size(286, 150);
            this.dgvTrainingData.TabIndex = 13;
            // 
            // txtNumOfOuputNeurons
            // 
            this.txtNumOfOuputNeurons.Location = new System.Drawing.Point(172, 68);
            this.txtNumOfOuputNeurons.Name = "txtNumOfOuputNeurons";
            this.txtNumOfOuputNeurons.Size = new System.Drawing.Size(121, 20);
            this.txtNumOfOuputNeurons.TabIndex = 12;
            this.txtNumOfOuputNeurons.Text = "2";
            // 
            // lblNumOfOutputNeurons
            // 
            this.lblNumOfOutputNeurons.AutoSize = true;
            this.lblNumOfOutputNeurons.Location = new System.Drawing.Point(4, 71);
            this.lblNumOfOutputNeurons.Name = "lblNumOfOutputNeurons";
            this.lblNumOfOutputNeurons.Size = new System.Drawing.Size(130, 13);
            this.lblNumOfOutputNeurons.TabIndex = 11;
            this.lblNumOfOutputNeurons.Text = "Number of output neurons";
            // 
            // lblNumOfInputs
            // 
            this.lblNumOfInputs.AutoSize = true;
            this.lblNumOfInputs.Location = new System.Drawing.Point(4, 45);
            this.lblNumOfInputs.Name = "lblNumOfInputs";
            this.lblNumOfInputs.Size = new System.Drawing.Size(123, 13);
            this.lblNumOfInputs.TabIndex = 10;
            this.lblNumOfInputs.Text = "Number of input neurons";
            // 
            // txtNumOfInputs
            // 
            this.txtNumOfInputs.Location = new System.Drawing.Point(172, 42);
            this.txtNumOfInputs.Name = "txtNumOfInputs";
            this.txtNumOfInputs.Size = new System.Drawing.Size(121, 20);
            this.txtNumOfInputs.TabIndex = 9;
            this.txtNumOfInputs.Text = "2";
            // 
            // lblErrThreshold
            // 
            this.lblErrThreshold.AutoSize = true;
            this.lblErrThreshold.Location = new System.Drawing.Point(4, 149);
            this.lblErrThreshold.Name = "lblErrThreshold";
            this.lblErrThreshold.Size = new System.Drawing.Size(75, 13);
            this.lblErrThreshold.TabIndex = 8;
            this.lblErrThreshold.Text = "Error threshold";
            // 
            // txtErrThreshold
            // 
            this.txtErrThreshold.Location = new System.Drawing.Point(172, 146);
            this.txtErrThreshold.Name = "txtErrThreshold";
            this.txtErrThreshold.Size = new System.Drawing.Size(121, 20);
            this.txtErrThreshold.TabIndex = 7;
            this.txtErrThreshold.Text = "0.0001";
            // 
            // lblMaxIterNum
            // 
            this.lblMaxIterNum.AutoSize = true;
            this.lblMaxIterNum.Location = new System.Drawing.Point(4, 123);
            this.lblMaxIterNum.Name = "lblMaxIterNum";
            this.lblMaxIterNum.Size = new System.Drawing.Size(146, 13);
            this.lblMaxIterNum.TabIndex = 6;
            this.lblMaxIterNum.Text = "Maximum number of iterations";
            // 
            // txtMaxNumOfIter
            // 
            this.txtMaxNumOfIter.Location = new System.Drawing.Point(172, 120);
            this.txtMaxNumOfIter.Name = "txtMaxNumOfIter";
            this.txtMaxNumOfIter.Size = new System.Drawing.Size(121, 20);
            this.txtMaxNumOfIter.TabIndex = 5;
            this.txtMaxNumOfIter.Text = "Inf";
            // 
            // lblNumberOfLayers
            // 
            this.lblNumberOfLayers.AutoSize = true;
            this.lblNumberOfLayers.Location = new System.Drawing.Point(4, 18);
            this.lblNumberOfLayers.Name = "lblNumberOfLayers";
            this.lblNumberOfLayers.Size = new System.Drawing.Size(86, 13);
            this.lblNumberOfLayers.TabIndex = 4;
            this.lblNumberOfLayers.Text = "Number of layers";
            // 
            // cbNumOfLayers
            // 
            this.cbNumOfLayers.FormattingEnabled = true;
            this.cbNumOfLayers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbNumOfLayers.Location = new System.Drawing.Point(172, 15);
            this.cbNumOfLayers.MaxDropDownItems = 50;
            this.cbNumOfLayers.Name = "cbNumOfLayers";
            this.cbNumOfLayers.Size = new System.Drawing.Size(121, 21);
            this.cbNumOfLayers.TabIndex = 3;
            // 
            // NeuralNetworkCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 405);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripNN);
            this.Controls.Add(this.menuStripNN);
            this.MainMenuStrip = this.menuStripNN;
            this.Name = "NeuralNetworkCreator";
            this.Text = "..:Neural Network Creator:..";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStripNN.ResumeLayout(false);
            this.statusStripNN.PerformLayout();
            this.menuStripNN.ResumeLayout(false);
            this.menuStripNN.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrainingExamples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripNN;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.MenuStrip menuStripNN;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exiToolStripMenuItem;
        private System.Windows.Forms.Button btnTrainNetwork;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox cbNumOfLayers;
        private System.Windows.Forms.Label lblNumberOfLayers;
        private System.Windows.Forms.Label lblMaxIterNum;
        private System.Windows.Forms.TextBox txtMaxNumOfIter;
        private System.Windows.Forms.TextBox txtErrThreshold;
        private System.Windows.Forms.Label lblErrThreshold;
        private System.Windows.Forms.TextBox txtNumOfInputs;
        private System.Windows.Forms.Label lblNumOfInputs;
        private System.Windows.Forms.TextBox txtNumOfOuputNeurons;
        private System.Windows.Forms.Label lblNumOfOutputNeurons;
        private System.Windows.Forms.DataGridView dgvTrainingData;
        private System.Windows.Forms.ToolStripMenuItem trainingDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTrainingDataToolStripMenuItem;
        private System.Windows.Forms.BindingSource bsTrainingExamples;
        private System.Windows.Forms.Label lblHiddenNeurons;
        private System.Windows.Forms.TextBox txtHiddenNeurons;
    }
}

