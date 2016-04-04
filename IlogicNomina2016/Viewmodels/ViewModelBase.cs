using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using IlogicNomina2016.Helpers;

namespace IlogicNomina2016.Viewmodels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        //basic ViewModelBase
        public RelayCommand CommandCerrarWindow { get; set; }
        public ViewModelBase()
        {
            CommandCerrarWindow = new RelayCommand(CerrarVentana);
        }

        private void CerrarVentana(object obj)
        {
            MainWindow ventana = obj as MainWindow;
            ventana.Close();
            
        }

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Extra Stuff, shows why a base ViewModel is useful
        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null 
                    ? true 
                    : !CloseWindowFlag;
            }));
        }
    }
}
