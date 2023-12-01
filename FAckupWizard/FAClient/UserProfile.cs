namespace FAckupWizard.FAClient
{
    public class UserProfile
    {
        public string Name { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public int Views { get; set; } = 0;
        public int SubmissionsCount { get; set; } = 0;
        public int Favs { get; set; } = 0;
        public int CommentsMade { get; set; } = 0;
        public int CommentsEarned { get; set; } = 0;

        public UserProfile() { }
    }
}
