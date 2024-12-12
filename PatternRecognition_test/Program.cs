using System;
using System.Collections.Generic;
using System.Text;

namespace PatternRecognition_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Neural_network_lib.NN_NeuralNetwork patternRecognition = null;
            Neural_network_lib.NN_NetworkSerializer NetworkSerializer = new Neural_network_lib.NN_NetworkSerializer();

            Neural_network_lib.NN_BackPropagationLearningAlgorithm teacher = new Neural_network_lib.NN_BackPropagationLearningAlgorithm(patternRecognition, 0.3, 0.03);
            patternRecognition = new Neural_network_lib.NN_NeuralNetwork(4, teacher);
            teacher.NeuralNetwork = patternRecognition;

            patternRecognition.Layers[0] = new Neural_network_lib.NN_Layer(2, null);
            patternRecognition.Layers[1] = new Neural_network_lib.NN_Layer(10, patternRecognition.Layers[0]);
            patternRecognition.Layers[2] = new Neural_network_lib.NN_Layer(10, patternRecognition.Layers[1]);
            patternRecognition.Layers[3] = new Neural_network_lib.NN_Layer(1, patternRecognition.Layers[2]);

            patternRecognition.LearningAlgorithm.MaxIterationNumber = Int32.MaxValue;
            patternRecognition.LearningAlgorithm.ErrorThreshold = 0.00001;

            learningPatterns lp = new learningPatterns();



            NetworkSerializer.SerializeNetwork("D://XOR.network", patternRecognition);

            teacher.forwardPropagate(lp.inputPatterns[0]);
            double testRes = patternRecognition.Layers[patternRecognition.NumberOfLayers - 1].Neurons[0].Output;
            teacher.forwardPropagate(lp.inputPatterns[1]);
            testRes = patternRecognition.Layers[patternRecognition.NumberOfLayers - 1].Neurons[0].Output;
            teacher.forwardPropagate(lp.inputPatterns[2]);
            testRes = patternRecognition.Layers[patternRecognition.NumberOfLayers - 1].Neurons[0].Output;
            teacher.forwardPropagate(lp.inputPatterns[3]);
            testRes = patternRecognition.Layers[patternRecognition.NumberOfLayers - 1].Neurons[0].Output;

            teacher.forwardPropagate(new double[] {0});
            testRes = patternRecognition.Layers[patternRecognition.NumberOfLayers - 1].Neurons[0].Output;
        }
    }
}
