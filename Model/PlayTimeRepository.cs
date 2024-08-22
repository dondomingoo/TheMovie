using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class PlayTimeRepository(string name)
    {
        public string Name { get; set; } = name;
        public List<PlayTime> PlayTimes { get; set; }

        public void LoadPlayTimes()
        {
            string[] lines = DataHandler.LoadFromFile((Name + "_PlayTimes"));
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                PlayTimes.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2]));
            }
        }
    }
}
