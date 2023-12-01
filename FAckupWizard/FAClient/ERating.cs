namespace FAckupWizard.FAClient
{
    [Flags]
    public enum ERating
    {
        None    = 0,
        General = 1 << 0,
        Mature  = 1 << 1,
        Adult   = 1 << 2,
    }
}
