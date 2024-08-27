
using System;

public class Class1
{
    public class Cinema
    {

        public string Name { get; set; }
        public int Screen { get; set; }
        public schedule Schedule { get; set; }

        public Cinema(string name, int screen, schedule schedule)
        {
            Name = name;
            Screen = screen;
            Schedule = schedule;

        }
        
    }

    

}
