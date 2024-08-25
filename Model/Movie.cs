﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheMovie.Model
{
    public class Movie(int? movieId, string title, int? duration, string genre): IEntity
    {
        public int? MovieId { get; set; } = movieId;
        public string Title { get; set; } = title;
        public int? Duration { get; set; } = duration;
        public string Genre { get; set; } = genre;

        public override string ToString()
        {
            return $"{MovieId};{Title};{Duration};{Genre}";
        }
    }
}
