namespace FAckupWizard.FAClient.FAParser
{
    internal interface IPageParser<T>
    {
        Task<T> Parse();
    }
}
