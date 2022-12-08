using FluentAssertions;

namespace Day7.Test;

public class Tests
{
    private string[] _input;
    private string[] _exampleInput;
    
    [SetUp]
    public void Setup()
    {
        _input = System.IO.File.ReadAllLines("input.txt");
        _exampleInput = System.IO.File.ReadAllLines("exampleInput.txt");
    }

    [Test]
    public void Part1Example()
    {
        const int expectedAnswer = 95437;
        var actualResult = Day7.Part1(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 1427048;
        var actualResult = Day7.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2Example()
    {
        const int expectedAnswer = 24933642;
        var actualResult = Day7.Part2(_exampleInput);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 2940614;
        var actualResult = Day7.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}