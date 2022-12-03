using FluentAssertions;

namespace Day3.Test;

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
        const int expectedAnswer = 157;
        var actualResult = Day3.Part1(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 7795;
        var actualResult = Day3.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const int expectedAnswer = 70;
        var actualResult = Day3.Part2(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 2703;
        var actualResult = Day3.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}