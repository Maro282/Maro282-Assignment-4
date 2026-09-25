# Benchmark Analysis
## Benchmark Setup

The benchmark compares two approaches for repeatedly appending the same text: 
1. String concatenation using `+=` 
2. StringBuilder using `Append()` 

The benchmark was executed using BenchmarkDotNet with the following iteration counts: 
- 100 
- 1,000 
- 10,000
- 100,000
Memory allocations were measured using `MemoryDiagnoser`.

## Results


![[BenchmarkResult.jpeg]]


• Which approach was faster with 100 iterations? 
     it was stringBuilder

• Which approach was faster with 100,000 iterations?
    absolutely it was stringBuilder also

• Which approach allocated more memory? 
     string for sure, it created a new string object with every modification within the iteration 

•  What happened to string concatenation performance as the loop size increased? 
    As the number of iterations increased, repeated string concatenation became significantly more expensive.

• Why does repeated string concatenation create additional allocations?
     Strings in C# are immutable. This means that when we modify a string using `+=`, the existing string cannot be changed. A new string has to be created containing the old content plus the new text.

• Why does StringBuilder usually perform better when text is repeatedly appended? 
     StringBuilder is designed for repeatedly modifying text. Instead of creating a new string for every append operation, it maintains an internal buffer that can grow when necessary. Therefore, repeated appends usually require fewer allocations and less copying.

• Is StringBuilder always better than normal string operations? Explain.
     No,  For a small number of concatenations, normal string operations can be simpler and may be fast enough. 
     StringBuilder becomes more useful when text is being modified repeatedly, especially inside large loops.