namespace Day2;

public class RoundPart2
{
    private readonly Outcome _recommendation;
    private readonly Shape _mine;

    public RoundPart2(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var opponent = parts[0] switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors
        };

        switch (parts[1])
        {
            case "X":
                _recommendation = Outcome.Lose;
                _mine = GetLoser(opponent);
                break;
            case "Y":
                _recommendation = Outcome.Draw;
                _mine = opponent;
                break;
            case "Z":
                _recommendation = Outcome.Win;
                _mine = GetWinner(opponent);
                break;
        }
    }

    public int Score()
    {
        int total = (int)_mine;
        return total + GetOutcomeScore();
    }

    private int GetOutcomeScore()
    {
        return _recommendation switch
        {
            Outcome.Win => 6,
            Outcome.Draw => 3,
            _ => 0
        };
    }

    private Shape GetWinner(Shape other)
    {
        return other switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Scissors,
            Shape.Scissors => Shape.Rock,
        };
    }
    
    private Shape GetLoser(Shape other)
    {
        return other switch
        {
            Shape.Rock => Shape.Scissors,
            Shape.Paper => Shape.Rock,
            Shape.Scissors => Shape.Paper,
        };
    }
}