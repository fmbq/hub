namespace FMBQ.Hub.Models
{
    public enum QuizType
    {
        /// A team quiz round. Team quizzing validation rules will be applied
        /// to the quiz, and only teams can be added to it.
        Team,

        /// An individual quiz round. Individual quizzing validation rules will
        /// be applied to the quiz, and only individual quizzers can be added to
        /// it.
        Individuals,

        /// A custom quiz. No validation will be applied.
        Custom,
    }
}
