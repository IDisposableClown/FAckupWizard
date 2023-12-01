namespace FAckupWizard.FAClient
{
    [Flags]
    public enum ESubmissionType
    {
        None  = 0,
        Image = 1 << 0,
        Audio = 1 << 1,
        Text  = 1 << 2,
        Flash = 1 << 3,
        Other = 1 << 4,
    }
}
