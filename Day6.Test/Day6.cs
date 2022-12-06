using FluentAssertions;

namespace Day6.Test;

public class Tests
{
    private string _input;
    
    [SetUp]
    public void Setup()
    {
        _input = File.ReadAllText("input.txt");
    }

    [Test]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1Example(string input, int answer)
    {
        var actualResult = Day6.Part1(input);

        actualResult.Should().Be(answer);
    }
    
    [Test]
    public void Part1()
    {
        const int expectedAnswer = 1623;
        var actualResult = Day6.Part1(_input);

        actualResult.Should().Be(expectedAnswer);
    }
    
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2Example(string input, int answer)
    {
        var actualResult = Day6.Part2(input);

        actualResult.Should().Be(answer);
    }
    
    [Test]
    public void Part2()
    {
        const int expectedAnswer = 3774;
        var actualResult = Day6.Part2(_input);

        actualResult.Should().Be(expectedAnswer);
    }
}