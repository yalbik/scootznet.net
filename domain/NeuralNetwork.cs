using System;
using System.Collections.Generic;

namespace scootznet.domain
{
    /// <summary>
    /// Represents a simple feedforward neural network composed of layers.
    /// </summary>
    public class NeuralNetwork
    {
        public List<NetworkLayer> Layers { get; }

        public NeuralNetwork(int[] layerSizes)
        {
            if (layerSizes.Length < 2)
                throw new ArgumentException("A network must have at least input and output layers.");

            Layers = new List<NetworkLayer>();
            for (int i = 1; i < layerSizes.Length; i++)
            {
                int neuronCount = layerSizes[i];
                int inputCountPerNeuron = layerSizes[i - 1];
                Layers.Add(new NetworkLayer(neuronCount, inputCountPerNeuron));
                Console.WriteLine($"Layer {i} created with {neuronCount} neurons, each with {inputCountPerNeuron} inputs.");
            }
        }

        /// <summary>
        /// Feeds the input through all layers of the network and returns the final output.
        /// </summary>
        public double[] Activate(double[] inputs)
        {
            double[] outputs = inputs;
            foreach (NetworkLayer layer in Layers)
            {
                outputs = layer.Activate(outputs);
            }
            return outputs;
        }
    }
}
