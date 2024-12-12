using System;
using System.Collections.Generic;
using System.Text;

namespace Neural_network_lib
{
    [Serializable]
    public abstract class NN_LearningAlgorithm
    {
        private double[][] outputs;

        private NN_NeuralNetwork neuralNetwork;

        private int maxIterationNumber;

        private int iterationNumber;

        private double[][] inputs;

        private double errorThreshold;

        private double error;

        private Random rand = new Random();

        public NN_LearningAlgorithm(NN_NeuralNetwork neuralNet)
        {
            this.neuralNetwork = neuralNet;
            this.maxIterationNumber = 1000;
            this.iterationNumber = 0;
            this.errorThreshold = 0.0001;
            this.error = rand.NextDouble();
        }

        public NN_LearningAlgorithm()
        {
            this.maxIterationNumber = 1000;
            this.iterationNumber = 0;
            this.errorThreshold = 0.0001;
            this.error = rand.NextDouble();
        }

        public double Error
        {
            get
            {
                return this.error;
            }
            set
            {
                this.error = value;
            }
        }

        public double ErrorThreshold
        {
            get
            {
                return this.errorThreshold;
            }
            set
            {
                this.errorThreshold = value;
            }
        }

        public double[][] Inputs
        {
            get
            {
                return this.inputs;
            }
            set
            {
                this.inputs = value;
            }
        }

        public double[][] Outputs
        {
            get
            {
                return this.outputs;
            }
            set
            {
                this.outputs = value;
            }
        }

        public int IterationNumber
        {
            get
            {
                return this.iterationNumber;
            }
            set
            {
                this.iterationNumber = value;
            }
        }

        public int MaxIterationNumber
        {
            get
            {
                return this.maxIterationNumber;
            }
            set
            {
                this.maxIterationNumber = value;
            }
        }

        public NN_NeuralNetwork NeuralNetwork
        {
            get
            {
                return this.neuralNetwork;
            }
            set
            {
                this.neuralNetwork = value;
            }
        }
    }
}
