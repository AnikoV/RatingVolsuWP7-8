﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatingVolsuAPI;

namespace ForTesting
{
    public class MainViewModel : PropertyChangedBase
    {
        public string VolsuReview { get; set; }
        private RatingDatabase rating;

        private ObservableCollection<FavoritesItem> _favoritesCollection;
        public ObservableCollection<FavoritesItem> favoritesCollection
        {
            get { return _favoritesCollection; }
            set
            {
                _favoritesCollection = value;
                RaisePropertyChanged("favoritesCollection");
            }
        }

        public MainViewModel()
        {
            VolsuReview = "ВолГУ – университет, известный в стране и за рубежом качеством образования, высоким научным потенциалом, инновационными проектами, активной социальной позицией.";
            rating = new RatingDatabase(RatingVolsuWP8.App.DbConnectionString);
            favoritesCollection = rating.GetFavorites();
        }

    }
}
