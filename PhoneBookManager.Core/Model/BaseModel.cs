﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBookManager.Core.Model
{
    class BaseModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
