using scootznet.domain;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Create a neural network with 4 layers: 16, 32, 32, 16 neurons
NeuralNetwork network = new NeuralNetwork(new int[] { 16, 32, 32, 16 });
Console.WriteLine("NeuralNetwork created with 4 layers: 16, 32, 32, 16 neurons.");

// Training parameters
int epochs = 1000000;
double learningRate = 0.01;
Random rng = new Random();

// Helper to convert int to 16-bit array
static double[] IntToBits(int n)
{
    double[] bits = new double[16];
    for (int i = 0; i < 16; i++)
        bits[15 - i] = (n >> i) & 1;
    return bits;
}

// Helper to convert 16-bit array to int
static int BitsToInt(double[] bits)
{
    int n = 0;
    for (int i = 0; i < 16; i++)
        n = (n << 1) | (bits[i] > 0.5 ? 1 : 0);
    return n;
}

// Training loop
for (int epoch = 0; epoch < epochs; epoch++)
{
    int inputNum = rng.Next(0, 32768); // 15-bit to avoid overflow
    double[] inputBits = IntToBits(inputNum);
    int targetNum = inputNum * 2;
    double[] targetBits = IntToBits(targetNum);

    // Forward pass with layer outputs tracked
    double[][] layerInputs = new double[network.Layers.Count + 1][];
    layerInputs[0] = inputBits;
    double[] current = inputBits;
    for (int l = 0; l < network.Layers.Count; l++)
    {
        current = network.Layers[l].Activate(current);
        layerInputs[l + 1] = current;
    }
    double[] output = layerInputs[layerInputs.Length - 1];

    // Backpropagation (very simple, not a real implementation)
    // Just update output layer weights with a simple delta rule
    NetworkLayer outputLayer = network.Layers[network.Layers.Count - 1];
    double[] outputLayerInput = layerInputs[layerInputs.Length - 2];
    Parallel.For(0, outputLayer.Neurons.Count, i =>
    {
        Neuron neuron = outputLayer.Neurons[i];
        double error = targetBits[i] - neuron.Output;
        for (int w = 0; w < neuron.Weights.Length; w++)
        {
            neuron.Weights[w] += learningRate * error * outputLayerInput[w];
        }
        neuron.Bias += learningRate * error;
    });

    if (epoch % 100 == 0)
    {
        Console.WriteLine($"Epoch {epoch}: Input {inputNum} -> Output {BitsToInt(output)} (Target {targetNum})");
    }
}

// Test
Parallel.For(0, 10, test =>
{
    int inputNum = rng.Next(0, 32768);
    double[] inputBits = IntToBits(inputNum);
    double[] output = network.Activate(inputBits);
    int predicted = BitsToInt(output);
    int expected = inputNum * 2;
    string result = predicted == expected ? "correct" : "INCORRECT";
    Console.WriteLine($"Test: {inputNum} * 2 = {predicted} (Expected {expected}) [{result}]");
});
