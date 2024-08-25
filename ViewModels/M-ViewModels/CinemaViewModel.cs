﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class CinemaViewModel
    {
        public Cinema Cinema { get; set; }
        public string Name { get; set; }
        public List<ScreenViewModel> Screens { get; set; }

        public CinemaViewModel (Cinema cinema)
        {
            Cinema = cinema;
            Name = cinema.Name;
            Screens = [];
            foreach (Screen screen in Cinema.Screens.GetScreens())
            {
                Screens.Add(new ScreenViewModel(screen));
            }
        }
    }
}
