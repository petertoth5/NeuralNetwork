using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;

namespace NeuralNetworkGUI
{
    public partial class NeuralNetworkCreator : Form
    {
        public Neural_network_lib.NN_NeuralNetwork patternRecognition;
        public Neural_network_lib.NN_NetworkSerializer NetworkSerializer;
        public Neural_network_lib.NN_BackPropagationLearningAlgorithm teacher;
        public double[][] inputPatterns;
        public double[][] outputPatterns;
        /* This class can parse the csv file */
        TrainingData trainingData = new TrainingData();
        /* This list is used to store the training data of the network */
        List<string[]> trainingDataList = new List<string[]>();
        /* This data table is the data source of the data grid view of the gui */
        DataTable dt = new DataTable();
        /* Create the separate thread for the learning process */
        BackgroundWorker learningThread = new BackgroundWorker();

        public NeuralNetworkCreator()
        {
            InitializeComponent();
            learningThread.WorkerReportsProgress = true;
            learningThread.WorkerSupportsCancellation = true;
            learningThread.DoWork += new DoWorkEventHandler(learningThread_DoWork);
            learningThread.ProgressChanged += new ProgressChangedEventHandler(learningThread_ProgressChanged);
            learningThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(learningThread_RunWorkerCompleted);

            this.toolStripProgressBar.Minimum = 0;
            this.toolStripProgressBar.Maximum = 100;
            this.toolStripProgressBar.Style = ProgressBarStyle.Continuous;

            NetworkSerializer = new Neural_network_lib.NN_NetworkSerializer();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        /* This function loads the training data to the neural network */
        private void loadTrainingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String myStream = null;

            /* First choose the csv file with the training data */
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            /* Load the data to the traing data's list */
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /* Open the CSV file and parse it */
                    if ((myStream = openFileDialog1.FileName) != null)
                    {
                        /* The parsing operation */
                        trainingDataList = trainingData.parseCSV(myStream);

                        /* Create as many columns in the dataTable as many training data columns are available */
                        for (int i = 0; i < trainingDataList[0].Length; i++)
			            {
                            dt.Columns.Add(i.ToString());
			            }

                        /* Fill the data into the dataTable */
                        foreach (String[] data in trainingDataList)
                        {
                            dt.Rows.Add(data);
                        }

                        /* Add the dataTable as data source to the DataGridView */
                        this.dgvTrainingData.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            /* Show the data in the datGridView */
        }

        private void btnTrainNetwork_Click(object sender, EventArgs e)
        {
            #region initialize Network

            /* Init the neural network */
            patternRecognition = null;

            /* Init the teacher object */
            teacher = new Neural_network_lib.NN_BackPropagationLearningAlgorithm(patternRecognition, 0.3, 0.03);
            patternRecognition = new Neural_network_lib.NN_NeuralNetwork(Convert.ToInt32(cbNumOfLayers.SelectedItem), teacher);
            teacher.NeuralNetwork = patternRecognition;

            /* Create the layers of the network */
            patternRecognition.Layers[0] = new Neural_network_lib.NN_Layer(Convert.ToInt32(txtNumOfInputs.Text), null);
            for (int i = 1; i < Convert.ToInt32(cbNumOfLayers.SelectedItem); i++)
            {
                patternRecognition.Layers[i] = new Neural_network_lib.NN_Layer(Convert.ToInt32(txtHiddenNeurons.Text), patternRecognition.Layers[i - 1]);
            }
            patternRecognition.Layers[Convert.ToInt32(cbNumOfLayers.SelectedItem) - 1] = new Neural_network_lib.NN_Layer(Convert.ToInt32(txtNumOfOuputNeurons.Text), patternRecognition.Layers[Convert.ToInt32(cbNumOfLayers.SelectedItem) - 2]);

            /* Set up max iter number and the error threshold */
            patternRecognition.LearningAlgorithm.MaxIterationNumber = Convert.ToInt32(this.txtMaxNumOfIter.Text);
            patternRecognition.LearningAlgorithm.ErrorThreshold = Convert.ToDouble(this.txtErrThreshold.Text);

            #endregion

            #region Initialize learning patterns

            /* array to store the input values */
            inputPatterns = new double[dt.Rows.Count][];

            /* variable to count the rows */
            int inputRow = 0;

            /* For every row in the data set on the GUI */
            foreach (DataRow row in dt.Rows)
            {
                /* Create a new row for the inputs which come from the respective row of the data set */
                inputPatterns[inputRow] = new double[Convert.ToInt32(txtNumOfInputs.Text)];
                /* For every element in the row fill the requested input values */
                for (int i = 0; i < Convert.ToInt32(txtNumOfInputs.Text); i++)
                {
                    /* Fill the new array with data */
                    inputPatterns[inputRow][i] = Convert.ToDouble(row.ItemArray[i]);
                }
                /* increment the row counter */
                inputRow++;
            }

            /* array to store the output values */
            outputPatterns = new double[dt.Rows.Count][];

            /* variable to count the rows */
            int outputRow = 0;

            /* For every row in the data set on the GUI */
            foreach (DataRow row in dt.Rows)
            {
                /* Create a new row for the outputs which come from the respective row of the data set */
                outputPatterns[outputRow] = new double[Convert.ToInt32(txtNumOfOuputNeurons.Text)];
                for (int i = Convert.ToInt32(txtNumOfInputs.Text); i < row.ItemArray.Length; i++)
                {
                    /* Fill the new array with data */
                    outputPatterns[outputRow][i - Convert.ToInt32(txtNumOfInputs.Text)] = Convert.ToDouble(row.ItemArray[i]);
                }
                /* Increment the row counter */
                outputRow++;
            }

            #endregion

            /* Start the learning process on a separate thread */
            learningThread.RunWorkerAsync();

            updateTreeView();
        }

        public void learningThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            /* Start the learning process of the network by calling the teacher function of it. 
             * The learning is made through the back propagation algorithm */
            teacher.Learn(inputPatterns, outputPatterns, worker);
        }

        public void learningThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            this.toolStripProgressBar.Value = e.ProgressPercentage;
        }

        public void learningThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Network training completed succesfully. \nNow you can save it for further usage.");
        }

        private void saveNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* First choose the csv file with the training data */
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";

            /* Load the data to the traing data's list */
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /* Open the CSV file and parse it */
                    if (saveFileDialog1.FileName != null)
                    {
                        NetworkSerializer.SerializeNetwork(saveFileDialog1.FileName, this.patternRecognition);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }
            }
        }

        private void loadNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* First choose the csv file with the training data */
            OpenFileDialog fileOpen = new OpenFileDialog();

            fileOpen.InitialDirectory = "c:\\";

            /* Load the data to the traing data's list */
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /* Open the CSV file and parse it */
                    if (fileOpen.FileName != null)
                    {
                        this.patternRecognition = NetworkSerializer.DeSerializeNetwork(fileOpen.FileName);
                        updateTreeView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }
            }
        }

        /* This function is to update the treeview of the GUI. After learning or after loading of the already stored network. */
        private void updateTreeView()
        {
            /* If the tree already has elements remove them */
            this.treeView1.Nodes.Clear();

            /* If the teaching ended fill the treeview with data of the neurons */
            foreach (Neural_network_lib.NN_Layer layer in patternRecognition.Layers)
            {
                if (layer != null)
                {
                    TreeNode layerNode = new TreeNode();
                    layerNode.Text = layer.ToString();
                    layerNode.Tag = layer;
                    this.treeView1.Nodes.Add(layerNode);

                    foreach (Neural_network_lib.NN_Neuron neuron in layer.Neurons)
                    {
                        if (neuron != null)
                        {
                            TreeNode neuronNode = new TreeNode();
                            neuronNode.Text = neuron.ToString();
                            neuronNode.Tag = neuron;
                            layerNode.Nodes.Add(neuronNode);

                            foreach (double weight in neuron.Weights)
                            {
                                TreeNode weightNode = new TreeNode();
                                weightNode.Text = "weight:" + weight.ToString();
                                weightNode.Tag = weight;
                                neuronNode.Nodes.Add(weightNode);
                            }
                        }
                    }
                }
            }
        }
    }
}
