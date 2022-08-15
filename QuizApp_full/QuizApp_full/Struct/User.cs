struct User
{
    public string Name;
    public int NumberOfCorrectAnswers;
    public int TotalAnswers;

    public User(string name, int numberOfCorrectAnswers, int totalAnswers)
    {
        Name = name;
        NumberOfCorrectAnswers = numberOfCorrectAnswers;
        TotalAnswers = totalAnswers;
    }

    public int ToPercent()
    {
        return (int)(((double)NumberOfCorrectAnswers / (double)TotalAnswers) * 100);
    }

    public string ToStringPercent()
    {
        return $"{ToPercent()}%";
    }
}