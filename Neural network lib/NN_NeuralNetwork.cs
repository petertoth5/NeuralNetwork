using System;
using System.Collections.Generic;
using System.Text;

namespace Neural_network_lib
{
    [Serializable]
    public class NN_NeuralNetwork
    {
        private Neural_network_lib.NN_Layer[] layers = new NN_Layer[50];
        private NN_LearningAlgorithm learningAlgorithm;
        private int numberOfLayers;

        public NN_NeuralNetwork(int numOfLayers)
        {
            this.numberOfLayers = numOfLayers;
            this.learningAlgorithm = new NN_BackPropagationLearningAlgorithm(this);
        }

        public NN_NeuralNetwork(int numOfLayers, NN_LearningAlgorithm learnAlgo)
        {
            this.numberOfLayers = numOfLayers;
            this.learningAlgorithm = learnAlgo;
        }

        public Neural_network_lib.NN_Layer[] Layers
        {
            get
            {
                return this.layers;
            }
            set
            {
                this.layers = value;
            }
        }

        public NN_LearningAlgorithm LearningAlgorithm
        {
            get
            {
                return this.learningAlgorithm;
            }
            set
            {
                this.learningAlgorithm = value;
            }
        }

        public int NumberOfLayers
        {
            get
            {
                return this.numberOfLayers;
            }
            set
            {
                this.numberOfLayers = value;
            }
        }
    }
}
