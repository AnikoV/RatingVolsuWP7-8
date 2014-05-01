﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RatingVolsuAPI.Base;

namespace RatingVolsuAPI
{
    public enum RatingType
    {
        RatingOfStudent,
        RatingOfGroup
    }

    public class CacheManager : PropertyChangedBase
    {
        public int CurrentFavorites;
        public RatingType CurrentRatingType;
        private ObservableCollection<Facult> _facultCollection;
        public ObservableCollection<Facult> facultCollection
        {
            get { return _facultCollection; }
            set
            {
                _facultCollection = value;
                RaisePropertyChanged("facultCollection");
            }
        }
        public ObservableCollection<Group> _groupCollection;
        public ObservableCollection<Group> groupCollection
        {
            get { return _groupCollection; }
            set
            {
                _groupCollection = value;
                RaisePropertyChanged("groupCollection");
            }
        }
        public ObservableCollection<Student> _studentCollection;
        public ObservableCollection<Student> studentCollection
        {
            get { return _studentCollection; }
            set
            {
                _studentCollection = value;
                RaisePropertyChanged("studentCollection");
            }
        }
    }
    public class StudentRat
    {
        public Dictionary<string, BasePredmet> Predmet;
        public Dictionary<string, List<string>> Table;
        
    }
    public class GroupRat
    {
        public Dictionary<string, BasePredmet> Predmet;
        public Dictionary<string, BaseStudent> Table;

    }

    public class BaseStudent
    {
        public string Name;
        public Dictionary<string, string> Predmet;
    }

    public class BasePredmet
    {
        public string Name;
        public string Type;
    }
}
