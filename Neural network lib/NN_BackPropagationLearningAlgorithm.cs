using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace Neural_network_lib
{
    [Serializable]
    public class NN_BackPropagationLearningAlgorithm : NN_LearningAlgorithm
    {
        private double alpha;
        private double gamma;
        private Random rand = new Random();
    
        public NN_BackPropagationLearningAlgorithm(NN_NeuralNetwork neuralNetwork)
        {
            this.alpha = 0.3;
            this.gamma = 0.3;
        }

        public NN_BackPropagationLearningAlgorithm(NN_NeuralNetwork neuralNet, double Alpha, double Gamma)
        {
            this.alpha = Alpha;
            this.gamma = Gamma;
        }

        public double Alpha
        {
            get
            {
                return this.alpha;
            }
            set
            {
                this.alpha = value;
            }
        }

        public double Gamma
        {
            get
            {
                return this.gamma;
            }
            set
            {
                this.gamma = value;
            }
        }

        public void Learn(double[][] inputs, double[][] expectedOutputs, BackgroundWorker bw)
        {
            int i = 0;

            bw.ReportProgress(0);

            while ((Math.Abs(this.Error) > this.ErrorThreshold) && (this.MaxIterationNumber > this.IterationNumber))
            {
                i = 0;
                computeError(expectedOutputs[0], true);

                while (i < inputs.GetLength(0))
                {
                    forwardPropagate(inputs[i]);

                    computeError(expectedOutputs[i], false);

                    backPropagate();

                    i++;
                }

                this.Error = (this.Error / 2);

                bw.ReportProgress(Convert.ToInt32((this.ErrorThreshold / this.Error) * 100));

                this.IterationNumber++;
            }
        }

        public void forwardPropagate(double[] inputPattern)
        {
            /* If there are enough input parameters for the computation */
            if (inputPattern.Length >= this.NeuralNetwork.Layers[0].NumberOfNeurons)
            {
                /* Set up the pattern as input to the input neurons of the network */
                for (int i = 0; i < inputPattern.Length; i++)
                {
                    this.NeuralNetwork.Layers[0].Neurons[i].Inputs[0] = inputPattern[i];
                }

                /* Go through all layers of the network */
                for (int i = 0; i < this.NeuralNetwork.NumberOfLayers; i++)
                {
                    /* Go through all neurons of the layer and compute the output of them */
                    for (int j = 0; j < this.NeuralNetwork.Layers[i].NumberOfNeurons; j++)
                    {
                        this.NeuralNetwork.Layers[i].Neurons[j].Output = this.NeuralNetwork.Layers[i].Neurons[j].computeOutput();

                        /* If there is a following layer */
                        if (this.NeuralNetwork.Layers[i].PostLayer != null)
                        {
                            /* Set up the input of the following layer's neurons to the output of the current
                             * layer's neurons*/
                            for (int k = 0; k < this.NeuralNetwork.Layers[i].PostLayer.NumberOfNeurons; k++)
                            {
                                this.NeuralNetwork.Layers[i].PostLayer.Neurons[k].Inputs[j] = this.NeuralNetwork.Layers[i].Neurons[j].Output;
                            }
                        }
                    }
                }                   
            }
            else
            {
                Console.WriteLine("Not enough patterns are available for computing the output");
            }
        }

        public void backPropagate()
        {
            double lastErrorDeltaValue = 0;
            /* Propagate the error backward into the network, from the last layer */
            for (int i = this.NeuralNetwork.NumberOfLayers - 2; i >= 0; i--)
            {
                /* For every single neuron in the respective layer */
                for (int j = 0; j < this.NeuralNetwork.Layers[i].NumberOfNeurons; j++)
                {
                    /* Modify the weights of the respective neurons */
                    for (int k = 0; k < this.NeuralNetwork.Layers[i].PostLayer.NumberOfNeurons; k++)
                    {
                        this.NeuralNetwork.Layers[i].PostLayer.Neurons[k].Weights[j] +=
                                  alpha
                                * this.NeuralNetwork.Layers[i].PostLayer.Neurons[k].Last_Error
                                * this.NeuralNetwork.Layers[i].Neurons[j].Output;
                    }

                    /* Init the temporary variable */
                    lastErrorDeltaValue = 0;

                    /* For every neuron in the post layer of the currently evaluated layer */
                    for (int k = 0; k < this.NeuralNetwork.Layers[i].PostLayer.NumberOfNeurons; k++)
                    {
                        lastErrorDeltaValue += 
                              this.NeuralNetwork.Layers[i].PostLayer.Neurons[k].Last_Error 
                            * this.NeuralNetwork.Layers[i].PostLayer.Neurons[k].Weights[j];
                    }

                    /* Compute the delta value */
                    this.NeuralNetwork.Layers[i].Neurons[j].Last_Error = 
                        lastErrorDeltaValue * this.NeuralNetwork.Layers[i].Neurons[j].computeOutputDiff();
                }
            }
        }

        public void computeError(double[] expectedPattern, bool clearAccumulatedError)
        {
            if (clearAccumulatedError)
            {
                this.Error = 0;
            }
            else
            {
                if (expectedPattern.Length >= this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].NumberOfNeurons)
                {
                    /* For every output neuron in the last layer */
                    for (int i = 0; i < this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].NumberOfNeurons; i++)
                    {
                        /* Compute the delta value for the correction of the weights in the output layer */
                        this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].Neurons[i].Last_Error =
                             (expectedPattern[i] - this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].Neurons[i].Output)
                           * this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].Neurons[i].computeOutputDiff();

                        /* The squared error */
                        this.Error += (expectedPattern[i] - this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].Neurons[i].Output)
                        *(expectedPattern[i] - this.NeuralNetwork.Layers[this.NeuralNetwork.NumberOfLayers - 1].Neurons[i].Output);
                    }
                }
            }
        }
    }
}
