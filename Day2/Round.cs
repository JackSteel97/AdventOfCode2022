namespace Day2;

public class Round
{
    private Shape _opponent;
    private Shape _recommendation;

    public Round(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _opponent = parts[0] switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors
        };
        
        _recommendation = parts[1] switch
        {
            "X" => Shape.Rock,
            "Y" => Shape.Paper,
            "Z" => Shape.Scissors
        };
    }

    public int Score()
    {
        int total = (int)_recommendation;
        return total + GetOutcomeScore();
    }

    private int GetOutcomeScore()
    {
        if (_opponent == _recommendation) return 3;
        switch (_opponent)
        {
            case Shape.Rock when _recommendation == Shape.Paper:
            case Shape.Paper when _recommendation == Shape.Scissors:
            case Shape.Scissors when _recommendation == Shape.Rock:
                return 6;
            default:
                return 0;
        }
    }
}