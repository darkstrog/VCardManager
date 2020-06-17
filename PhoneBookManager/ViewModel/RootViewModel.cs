using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PhoneBookManager.ViewModel
{
    class RootViewModel:INotifyPropertyChanged
    {
        private object rootVM;
        public object RootVM { get { return rootVM; } set { rootVM = value;OnPropertyChanged("RoorVM"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
