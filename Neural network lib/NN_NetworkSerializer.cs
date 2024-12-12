using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Neural_network_lib
{
    public class NN_NetworkSerializer
    {
        public void SerializeNetwork(string filename, NN_NeuralNetwork networkToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, networkToSerialize);
            stream.Close();
        }

        public NN_NeuralNetwork DeSerializeNetwork(string filename)
        {
            NN_NeuralNetwork networkToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            networkToSerialize = (NN_NeuralNetwork)bFormatter.Deserialize(stream);
            stream.Close();
            return networkToSerialize;
        }
    }
}
