using FluentAssertions;

namespace Day5.Test;

public class Tests
{
    private string[] _input;
    private string[] _exampleInput;
    
    [SetUp]
    public void Setup()
    {
        _input = File.ReadAllLines("input.txt");
        _exampleInput = File.ReadAllLines("exampleInput.txt");
    }

    [Test]
    public void Part1Example()
    {
        const string expectedAnswer = "CMZ";
        var actualResult = Day5.Part1(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const string expectedAnswer = "RNZLFZSJH";
        var actualResult = Day5.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const string expectedAnswer = "MCD";
        var actualResult = Day5.Part2(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const string expectedAnswer = "CNSFCGJSM";
        var actualResult = Day5.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}