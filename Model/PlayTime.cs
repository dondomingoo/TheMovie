﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class PlayTime
    {
        public DateTime Start { get; set; }
        public DateTime Date { get; set; }
        public Movie Movie { get; set; }
        public int Screen { get; set; }
    }
}
