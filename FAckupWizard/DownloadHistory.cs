using Newtonsoft.Json;

namespace FAckupWizard
{
    internal class DownloadHistory
    {
        private string HistoryPath;
        private string UserPath;
        private List<DownloadHistoryItem> History;

        private object _lock = new object();

        public DownloadHistory(string path) 
        { 
            UserPath = path;
            HistoryPath = Path.Combine(path, "dl.jsonl");
            History = new List<DownloadHistoryItem>();
        }

        public bool Load()
        {
            bool foundMissing = false;
            try
            {
                if (File.Exists(HistoryPath))
                {
                    using(var sr = File.OpenText(HistoryPath))
                    {
                        string line = string.Empty;
                        while((line = sr.ReadLine()) != null)
                        {
                            var item = JsonConvert.DeserializeObject<DownloadHistoryItem>(line);
                            if(item != null)
                            {
                                if (File.Exists(Path.Join(UserPath, item.DestPath)))
                                {
                                    History.Add(item);
                                }
                                else 
                                {
                                    foundMissing = true;
                                }
                            }
                        }
                    }
                }
            } 
            catch 
            { 
                return false;
            }

            if(foundMissing)
            {
                WriteAll();
            }
            
            return true;
        }

        public void WriteAll()
        {
            try
            {
                using (var tw = new StreamWriter(HistoryPath))
                {
                    foreach(var item in History)
                    {
                        tw.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }
            }
            catch { }
        }

        public bool Contains(string url)
        {
            var items = History.Where(x => x.SourceURL == url);
            if (items.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Contains(ulong subid)
        {
            var items = History.Where(x => x.SubmissionID == subid);
            if(items.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Append(string url, string dlpath, ulong subid = 0)
        {
            var item = new DownloadHistoryItem(subid, url, dlpath.Substring(UserPath.Length));
            try
            {
                lock (_lock)
                {
                    History.Add(item);
                    using (var sw = new StreamWriter(HistoryPath,true))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }
            } 
            catch 
            {
                return false;
            }
            return true;
        }
    }
}
