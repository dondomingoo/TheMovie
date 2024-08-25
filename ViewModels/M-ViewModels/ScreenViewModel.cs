﻿using TheMovie.Models;

namespace TheMovie.ViewModels
{
    public class ScreenViewModel(Screen screen)
    {
        public Screen Screen { get; set; } = screen;
        public string CinemaName { get; set; } = screen.CinemaName;
        public string Name { get; set; } = screen.Name;
        public int Capacity { get; set; } = screen.Capacity;
        public PlayTimeRepository PlayTimes { get; set; } = screen.PlayTimes;
    }
}
