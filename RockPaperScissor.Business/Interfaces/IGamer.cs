namespace RockPaperScissor.Business.Interfaces
{
    /// <summary>
    /// Get user result
    /// </summary>
    public interface IGamer
    {
        /// <summary>
        /// Show the final result
        /// </summary>
        /// <param name="flagNum"></param>
        /// <returns></returns>
        string GameResult(int flagNum);

        /// <summary>
        /// Math user insput selection with computer.
        /// </summary>
        string GameSelection(int input);

        /// <summary>
        /// Method return final winner result.
        /// </summary>
        string DisplayResult(int userCount, int computerCount);
    }
}
