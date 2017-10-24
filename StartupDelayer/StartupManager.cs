using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace startup_delayer
{
    public class StartupManager
    {
        private List<StartupItem> items;
        private string saveLocation;


        public string FileLocation
        {
            get
            {
                return saveLocation;
            }
        }

        public bool IsSaveRequired { get; private set; }        


        public StartupManager()
        {
            items = new List<StartupItem>();
        }

        /// <summary>
        /// Loads the startup items from the default location for the startup.json file.
        /// </summary>
        /// <param name="location">Path to stored startup.json file.</param>
        public void Load(string location = null)
        {
            if (location == null) location = ConfigurationManager.AppSettings["DefaultLocation"];
            saveLocation = location;

            using (StreamReader fileReader = new StreamReader(location))
            {
                items = JsonConvert.DeserializeObject<List<StartupItem>>(fileReader.ReadToEnd());
            }

            SortItems();
        }

        public void Save()
        {
            using (StreamWriter fileWriter = new StreamWriter(saveLocation))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(fileWriter) { Formatting = Formatting.Indented })
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, items);
                }
            }

            IsSaveRequired = false;
        }

        public void AddStartupItem(StartupItem item)
        {
            items.Add(item);
            SortItems();
            IsSaveRequired = true;
        }

        public void EditStartupItem(StartupItem oldItem, StartupItem newItem)
        {
            if (!items.Contains(oldItem))
            {
                Debug.WriteLine("Manager items does not contain " + oldItem.ToString());
                return;
            }

            items.Remove(oldItem);
            items.Add(newItem);

            SortItems();

            IsSaveRequired = true;
        }

        public void RemoveStartupItem(StartupItem item)
        {
            items.Remove(item);

            IsSaveRequired = true;
        }

        public ReadOnlyCollection<StartupItem> GetItems()
        {
            return new ReadOnlyCollection<StartupItem>(items);
        }

        private void SortItems()
        {
            items = items
                .OrderBy(s => s.Offset)
                .ToList();
        }
    }
}
