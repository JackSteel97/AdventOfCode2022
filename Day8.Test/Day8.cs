using FluentAssertions;

namespace Day8.Test;

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
        const int expectedAnswer = 21;
        var actualResult = Day8.Part1(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 1870;
        var actualResult = Day8.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const int expectedAnswer = 8;
        var actualResult = Day8.Part2(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 517440;
        var actualResult = Day8.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}