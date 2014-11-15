﻿using PropertyChanged;

namespace AutoNamer.Entities
{
    [ImplementPropertyChanged]
    public class SpineData
    {
        public string Title { get; set; }
        public string Author { get; set; }

        internal SpineData() { }

        internal SpineData(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}