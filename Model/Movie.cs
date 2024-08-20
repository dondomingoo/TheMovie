﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Movie: IEntity
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public Movie(string title, int duration, string genre)
        {
            Title = title;
            Duration = duration;
            Genre = genre;
        }
        public Movie()
        {
        }
    }
}
