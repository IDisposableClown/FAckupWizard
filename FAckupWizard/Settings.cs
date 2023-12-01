using FAckupWizard.FAClient;
using Newtonsoft.Json;
using System.Security.Policy;

namespace FAckupWizard
{
    public class Settings
    {
        public bool UseProxy { get; set; }
        public ProxySettings ProxySettings { get; set; }
        public Session Session { get; set; }
        public ESubmissionType SubmissionTypes { get; set; }
        public EGallerySection Sections { get; set; }
        public ERating SubmissionRatings { get; set; }

        public Settings() 
        {
            ProxySettings = new ProxySettings();
            Session = new Session("", "");
            UseProxy = false;
            SubmissionRatings = ERating.General | ERating.General;
            SubmissionTypes = ESubmissionType.Text | ESubmissionType.Audio | ESubmissionType.Image | ESubmissionType.Flash | ESubmissionType.Other;
            Sections = EGallerySection.Gallery | EGallerySection.Scraps;
        }

        public static Settings Load(string path)
        {
            if (File.Exists(path))
            {
                Settings? sets = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                if(sets != null)
                    return sets;
            }
            return new Settings();
        }

        public void Save(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
                }
            }
            catch { }
        }
    }
}
