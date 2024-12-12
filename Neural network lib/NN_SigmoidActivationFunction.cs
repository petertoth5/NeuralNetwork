using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Neural_network_lib
{
    [Serializable]
    public class NN_SigmoidActivationFunction : NN_ActivationFunction
    {
        private double beta;
        private Random rand = new Random();

        public NN_SigmoidActivationFunction(double Beta)
        {
            this.beta = Beta;
        }

        public NN_SigmoidActivationFunction()
        {
            this.beta = 1.0;
        }
    
        public double Beta
        {
            get
            {
                return this.beta;
            }
            set
            {
                this.beta = value;
            }
        }
        #region NN_ActivationFunction Members

        /* This function returns the output of the sigmoid function */
        public double Output(double input)
        {
            double returnValue = ((2 / (1 + Math.Exp(-beta * input))) - 1);
            return returnValue;
        }

        /* This function returns the prime of the sigmoid function */
        public double OutputDiff(double input)
        {
            double y = Output(input);

            double returnValue = (beta * (1 - y * y) / 2);
            return returnValue;
        }

        #endregion
    }
}
