using System;

namespace scootznet.domain
{
    /// <summary>
    /// Represents a single neuron in a neural network.
    /// </summary>
    public class Neuron
    {
        // The weights for each input to this neuron
        public double[] Weights { get; set; }

        // The bias term for this neuron
        public double Bias { get; set; }

        // The output value after activation
        public double Output { get; private set; }

        public Neuron(int inputCount)
        {
            Weights = new double[inputCount];
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < inputCount; i++)
            {
                Weights[i] = rng.NextDouble() * 2 - 1; // random value between -1 and 1
            }
            Bias = rng.NextDouble() * 2 - 1; // random value between -1 and 1
        }

        /// <summary>
        /// Computes the output of the neuron given an input vector.
        /// </summary>
        public double Activate(double[] inputs)
        {
            if (inputs.Length != Weights.Length)
                throw new ArgumentException("Input count does not match weight count.");

            double sum = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            sum += Bias;
            Output = Sigmoid(sum);
            return Output;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
