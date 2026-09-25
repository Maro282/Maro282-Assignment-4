using BenchmarkDotNet.Attributes;
using System.Text;
namespace AcademyScheduleAnalyzer;

[MemoryDiagnoser]
public class StringBenchMark
{
    [Params(10, 100, 1000, 10000, 100000)]
    public int iteration;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < iteration; i++)
        {
            result += "Hema";
        }
        return result;
    }


    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < iteration; i++)
        {
            result.Append("Hema");
        }
        return result.ToString();
    }
}
