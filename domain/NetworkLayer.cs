using System;
using System.Collections.Generic;

namespace scootznet.domain
{
    /// <summary>
    /// Represents a layer of neurons in a neural network.
    /// </summary>
    public class NetworkLayer
    {
        public List<Neuron> Neurons { get; }

        public NetworkLayer(int neuronCount, int inputCountPerNeuron)
        {
            Neurons = new List<Neuron>();
            for (int i = 0; i < neuronCount; i++)
            {
                Neurons.Add(new Neuron(inputCountPerNeuron));
            }
            Console.WriteLine($"NetworkLayer created with {Neurons.Count} neurons.");
        }

        /// <summary>
        /// Feeds the input through all neurons in the layer and returns their outputs.
        /// </summary>
        public double[] Activate(double[] inputs)
        {
            double[] outputs = new double[Neurons.Count];
            for (int i = 0; i < Neurons.Count; i++)
            {
                outputs[i] = Neurons[i].Activate(inputs);
            }
            return outputs;
        }
    }
}
