using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Neural_network_lib
{
    [Serializable]
    public class NN_Layer
    {
        private Neural_network_lib.NN_Neuron[] neurons = new NN_Neuron[1500];
        private NN_Layer previousLayer;
        private NN_Layer postLayer;
        private int numberOfNeurons;
        private NN_ActivationFunction activationFunction;
        private Random rand = new Random();

        public NN_Layer(int numOfNeurons, NN_Layer prevLayer, NN_ActivationFunction actFunction)
        {
            this.previousLayer = prevLayer;
            this.postLayer = null;
            this.numberOfNeurons = numOfNeurons;
            this.activationFunction = actFunction;

            if (this.previousLayer != null)
            {
                this.previousLayer.postLayer = this;
            }

            createNeuronsOfLayer();
        }

        public NN_Layer(int numOfNeurons, NN_Layer prevLayer)
        {
            this.previousLayer = prevLayer;
            this.postLayer = null;
            this.numberOfNeurons = numOfNeurons;
            this.activationFunction = new NN_SigmoidActivationFunction(1.0);

            if (this.previousLayer != null)
            {
                this.previousLayer.postLayer = this;
            }

            createNeuronsOfLayer();
        }

        public Neural_network_lib.NN_Neuron[] Neurons
        {
            get
            {
                return this.neurons;
            }
            set
            {
                this.neurons = value;
            }
        }

        public NN_Layer PreviousLayer
        {
            get
            {
                return this.previousLayer;
            }
            set
            {
                this.previousLayer = value;
            }
        }

        public NN_Layer PostLayer
        {
            get
            {
                return this.postLayer;
            }
            set
            {
                this.postLayer = value;
            }
        }

        public int NumberOfNeurons
        {
            get
            {
                return this.numberOfNeurons;
            }
            set
            {
                this.numberOfNeurons = value;
            }
        }

        public NN_ActivationFunction ActivationFunction
        {
            get
            {
                return this.activationFunction;
            }
            set
            {
                this.activationFunction = value;
            }
        }

        /*! This function is to create the neurons of the layer. This function is called by the constructor by default. */
        public void createNeuronsOfLayer()
        {
            UInt32 i = 0U;

            /* Create the neurons of the layer */
            for (i = 0; i < this.numberOfNeurons; i++)
            {
                Thread.Sleep(20);
                /* If the layer contains input neurons, than only 1 input is needed per neuron */
                if (this.previousLayer == null)
                {
                    this.neurons[i] = new NN_Neuron(1, this.activationFunction);
                    this.neurons[i].Weights[0] = 1.0;
                }
                /* In case there is a previous layer, the number of the inputs of the neurons's of the layer
                 * is the number of the neurons in the previous layer. */
                else
                {
                    this.neurons[i] = new NN_Neuron(this.previousLayer.NumberOfNeurons, this.activationFunction);
                    this.neurons[i].randomizeWeight();
                }
            }
        }
    }
}
