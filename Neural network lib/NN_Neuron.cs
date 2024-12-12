using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Neural_network_lib
{
    [Serializable]
    public class NN_Neuron
    {
        private double[] inputs;
        private double output;
        private double threshold;
        private double[] weights;
        private double last_Error;
        private NN_ActivationFunction activationFunction;
        private Random rand;

        /* Default constructor. The input number specifies the number of the inputs of the neuron. */
        public NN_Neuron(int inputNumber)
        {
            this.inputs = new double[inputNumber];
            this.weights = new double[inputNumber];
            this.last_Error = 0.0;
            this.activationFunction = new NN_SigmoidActivationFunction(1.0);
            this.threshold = 0.1;
            this.rand = new Random();
        }

        /* Differs from the default constructor in that way that the activation function can be specified */
        public NN_Neuron(int inputNumber, NN_ActivationFunction ActivationFunction)
        {
            this.inputs = new double[inputNumber];
            this.weights = new double[inputNumber];
            this.last_Error = 0.0;
            this.threshold = 0.1;
            this.activationFunction = ActivationFunction;
            this.rand = new Random();
        }
        /// <summary>
        /// This value represents the weights of a neuron in the NN
        /// </summary>
        public double[] Weights
        {
            get
            {
                return this.weights;
            }
            set
            {
                this.weights = value;
            }
        }

        /// <summary>
        /// This value represents the weights of the neuron in the previous learning loop
        /// </summary>
        public double Last_Error
        {
            get
            {
                return this.last_Error;
            }
            set
            {
                this.last_Error = value;
            }
        }

        /// <summary>
        /// This value represents the output value of the neuron.
        /// </summary>
        public double Output
        {
            get
            {
                return this.output;
            }
            set
            {
                this.output = value;
            }
        }

        /// <summary>
        /// This value represents the input vector of the neuron
        /// </summary>
        public double[] Inputs
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

        /// <summary>
        /// This is the actual threshold of the neuron
        /// </summary>
        public double Threshold
        {
            get
            {
                return this.threshold;
            }
            set
            {
                this.threshold = value;
            }
        }

        /// <summary>
        /// This is the activation function of the current neuron
        /// </summary>
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

        public void randomizeWeight()
        {
            UInt32 i = 0U;
            for (i = 0U; i < weights.Length; i++)
            {
                if (rand.NextDouble() < 0.5)
                {
                    weights[i] = rand.NextDouble() * -1;
                    Console.WriteLine("Weight:" + weights[i]);
                    Thread.Sleep(20);
                }
                else
                {
                    weights[i] = rand.NextDouble() * 1;
                    Console.WriteLine("Weight:" + weights[i]);
                    Thread.Sleep(20);
                }
            }
        }

        public double computeOutput()
        {
            double sum = 0;
            double returnValue = 0;
            /* Calculate the sum of the weights multiplied by the inputs */
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += (this.inputs[i] * this.weights[i]);
            }
            sum += this.threshold;

            /* Compute the value of the activation function */
            returnValue = this.activationFunction.Output(sum);

            return returnValue;
        }

        public double computeOutputDiff()
        {
            double sum = 0.0;
            double returnValue = 0.0;
            /* Calculate the sum of the weights multiplied by the inputs */
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += (this.inputs[i] * this.weights[i]);
            }
            sum += this.threshold;

            /* Compute the value of the activation function */
            returnValue = this.activationFunction.OutputDiff(sum);

            /* Compute the value of the activation function diff */
            return returnValue;
        }
    }
}
