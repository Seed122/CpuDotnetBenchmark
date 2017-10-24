# Benchmark results

Calculation of 10k float values with a complex formula.

Results in milliseconds. Lower is better.

### AMD Ryzen 7 1700
| Cores 	| .NET Core 	| .NET  	|
|--------	|-----------	|-------	|
| 1      	| 78072     	| 91661 	|
| 2      	| 42561     	| 47056 	|
| 4      	| 21022     	| 23987 	|
| 8      	| 12608     	| 13692 	|
| 16     	| 9386      	| 10433 	|
| 32     	| 9496      	| 10506 	|

### Intel Core i7-4702MQ	
| Cores 	| .NET Core 	| .NET   	|
|-------	|-----------	|--------	|
| 1     	| 122092    	| 128488 	|
| 2     	| 63573     	| 63959  	|
| 4     	| 39932     	| 34606  	|
| 8     	| 29837     	| 30786  	|
| 16    	| 28348     	| 30228  	|
| 32    	| 29210     	| 30268  	|
