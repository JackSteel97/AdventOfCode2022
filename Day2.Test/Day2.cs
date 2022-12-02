using FluentAssertions;

namespace Day2.Test;

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
        const int expectedAnswer = 15;
        var actual = Day2.Part1(_exampleInput);
        actual.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 9177;
        var actual = Day2.Part1(_input);
        actual.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const int expectedAnswer = 12;
        var actual = Day2.Part2(_exampleInput);
        actual.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 12111;
        var actual = Day2.Part2(_input);
        actual.Should().Be(expectedAnswer);
    }
}