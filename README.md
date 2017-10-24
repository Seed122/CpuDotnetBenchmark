# Simple .NET Benchmark for CPU
Calculation of floats by a complex formula

The benchmark is available in two editions: .NET Framework 4.7 and .NET Core 2.0.

## How to run

### .NET Core

in cmd (win) or terminal (*nix):

`dotnet CpuDotnetBenchmark.NetCore.dll [threads] [numbers]`


This command without params starts computing 10k floats @ 1 thread. To calculate performance for 5400 floats @ 22 threads run:

`dotnet CpuDotnetBenchmark.NetCore.dll 22 5400`

### .NET Framework

in cmd (win):

`CpuDotnetBenchmark.NetFramework.exe [threads] [numbers]`

The parameters are exactly equal to .NET Core version.

Example output for Ryzen 7 1700:


```
> dotnet CpuDotnetBenchmark.NetCore.dll 16 10000
Calculating 10000 numbers in 16 theads [.NET Core 2.0]
Calculated 10000 numbers in 9384 ms
```
