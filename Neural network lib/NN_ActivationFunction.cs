using System;
using System.Collections.Generic;
using System.Text;

namespace Neural_network_lib
{
    public interface NN_ActivationFunction
    {
        double Output(double input);

        double OutputDiff(double input);
    }
}
