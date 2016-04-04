using System;
using System.Collections.Generic;
using System.Linq;
using IlogicNomina2016.Helpers;
using System.Windows.Controls;
using System.Windows;

namespace IlogicNomina2016.Viewmodels
{
    class LogingViewModel:ViewModelBase
    {
        nominaEntities userContext= new nominaEntities();
        public RelayCommand IngresarCommand { get;set; }
        public LogingViewModel()
        {
            IngresarCommand = new RelayCommand(Ingresar);
            CargarUsuarios();
        }

         void Ingresar(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            if (UsuarioActual != null && UsuarioActual.keyCi.Trim()== password.Trim())
            {
                MessageBox.Show("ingresando");
            }
            else
            {
                MessageBox.Show("Clave o Usuario Incorrecto");
                passwordBox.Password = string.Empty;
            }
            

        }

        private void CargarUsuarios()
        {
            this.usuarios = userContext.users.ToList();
        }

        private List<users> _usuarios;
        public List<users> usuarios
        {
            get
            {
                return _usuarios;
            }
            set
            {
                _usuarios = value;
                RaisePropertyChanged("usuarios");
                
            }
                        
        }
        private users _UsuarioActual;
        public users UsuarioActual
        {
            get
            {
                return _UsuarioActual;
            }
            set
            {
                _UsuarioActual = (users)value;
                
                RaisePropertyChanged("UsuarioActual");
            }
        }

        private string _UsuarioClave;
        public string UsuarioClave
        {
            get{
                return _UsuarioClave;
            }
            set {
                _UsuarioClave = value;
            }

        }
      


    }
}
