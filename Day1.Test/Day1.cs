using FluentAssertions;

namespace Day1.Test;

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
        const int expectedAnswer = 24_000;
        var actualResult = Day1.Part1(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 66_306;
        var actualResult = Day1.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const int expectedAnswer = 45_000;
        var actualResult = Day1.Part2(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 195_292;
        var actualResult = Day1.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}