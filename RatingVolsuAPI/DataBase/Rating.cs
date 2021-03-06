﻿using RatingVolsuAPI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatingVolsuAPI.DataBase;

namespace RatingVolsuAPI
{
    [Table]
    public class Rating : PropertyChangedBase, IRepository, INotifyPropertyChanging
    {
        private string _id;

        [Column(IsPrimaryKey = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _semestr;
       
        [Column]
        public string Semestr
        {
            get { return _semestr; }
            set
            {
                NotifyPropertyChanging("Semestr");
                _semestr = value;
                RaisePropertyChanged("Semestr");
            }
        }

        private string _subjectId;

        [Column]
        public string SubjectId
        {
            get { return _subjectId; }
            set
            {
                NotifyPropertyChanging("SubjectId");
                _subjectId = value;
                RaisePropertyChanged("SubjectId");
            }
        }

        private EntityRef<Subject> _subject;

        [Association(Storage = "_subject", ThisKey = "SubjectId", OtherKey = "Id", IsForeignKey = true)]

        public Subject Subject
        {
            get { return _subject.Entity; }
            set
            {
                RaisePropertyChanged("Subject");
                _subject.Entity = value;

                if (value != null)
                {
                    SubjectId = value.Id;
                }

                NotifyPropertyChanging("Subject");
            }
        }

        [Column]
        public string StudentId;

        private EntityRef<Student> _student;

        [Association(Storage = "_student", ThisKey = "StudentId", OtherKey = "Id", IsForeignKey = true)]

        public Student Student
        {
            get { return _student.Entity; }
            set
            {
                RaisePropertyChanged("Student");
                _student.Entity = value;

                if (value != null)
                {
                    StudentId = value.Id;
                }

                NotifyPropertyChanging("Student");
            }
        }

        private int? _att1;
        

        [Column]
        public int? Att1
        {
            get { return _att1; }
            set
            {
                _att1 = value;
                RaisePropertyChanged("Att1");
            }
        }

        private int? _att2;

        [Column]
        public int? Att2
        {
            get { return _att2; }
            set
            {
                _att2 = value;
                RaisePropertyChanged("Att2");
            }
        }

        private int? _att3;

        [Column]
        public int? Att3
        {
            get { return _att3; }
            set
            {
                _att3 = value;
                RaisePropertyChanged("Att3");
            }
        }

        private int? _sum;

        [Column]
        public int? Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                RaisePropertyChanged("Sum");
            }
        }

        private int? _exam;

        [Column]
        public int? Exam
        {
            get { return _exam; }
            set
            {
                _exam = value;
                RaisePropertyChanged("Exam");
            }
        }

        private int? _total;

        [Column]
        public int? Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }

        public string BallsToNextPlace { get; set;}

        public string BallsToFirstPlace { get; set;}

        public void Update(IRepository item)
        {
            var ratingItem = (Rating) item;
            if (ratingItem.Att1 != null) Att1 = ratingItem.Att1;
            if (ratingItem.Att2 != null) Att2 = ratingItem.Att2;
            if (ratingItem.Att3 != null) Att3 = ratingItem.Att3;
            if (ratingItem.Sum != null) Sum = ratingItem.Sum;
            if (ratingItem.Exam != null) Exam = ratingItem.Exam;
            if (ratingItem.Total != null) Total = ratingItem.Total;

        }

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
