public struct Question
{
    public string QuestionText;
    public int CorrectAnswerIndex;
    public List<string> Choices;

    public Question(string questionText, int correctAnswerIndex, List<string> choices)
    {
        QuestionText = questionText;
        CorrectAnswerIndex = correctAnswerIndex;
        Choices = choices;
    }
}