# scootznet

This is a simple C# .NET console application that demonstrates a basic, trainable neural network from scratch.

## Features
- Custom `Neuron`, `NetworkLayer`, and `NeuralNetwork` classes (see `domain/`)
- Trains a network to double 16-bit numbers (input: 16 bits, output: 16 bits)
- Simple (non-backprop) weight update for demonstration
- Parallelized training and testing for speed

## Project Structure
- `Program.cs` — Main entry point, training/testing logic
- `domain/Neuron.cs` — Single neuron implementation
- `domain/NetworkLayer.cs` — Layer of neurons
- `domain/NeuralNetwork.cs` — Multi-layer feedforward network

## How it works
- The network is created with 4 layers: 16, 32, 32, 16 neurons
- Trains for 1,000,000 epochs to learn the function: output = input * 2
- Uses bitwise encoding for input/output
- Prints test results with correctness after training

## Running
1. Build: `dotnet build scootznet.sln`
2. Run: `dotnet run --project scootznet.console.csproj`

## Example Output
```
Epoch 0: Input 12345 -> Output 0 (Target 24690)
...
Test: 12345 * 2 = 24690 (Expected 24690) [correct]
Test: 10000 * 2 = 20000 (Expected 20000) [correct]
Test: 5432 * 2 = 10864 (Expected 10864) [correct]
```

## Notes
- This is a demonstration and not a production neural network implementation.
- For real tasks, use a library like ML.NET, TensorFlow, or PyTorch.
- The current training rule only updates the output layer (no true backpropagation).

---

Generated with assistance from GitHub Copilot.
