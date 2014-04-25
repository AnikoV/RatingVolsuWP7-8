﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingVolsuWP8
{
    internal class MagicAttribute : Attribute { }

    public class NoMagicAttribute : Attribute { }

    [Magic]
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public virtual void RaisePropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
