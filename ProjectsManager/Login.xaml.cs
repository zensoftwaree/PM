using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ProjectManager.Business;

namespace ProjectsManager
{
    public interface ILogin
    {
        event RoutedEventHandler LogIn;
        event RoutedEventHandler Register;
    }
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window, ILogin
    {
        public event RoutedEventHandler LogIn
        {
            add
            {
                btnLogin.Click += value;
            }
            remove
            {
                btnLogin.Click -= value;
            }
        }

        public event RoutedEventHandler Register
        {
            add
            {
                btnRegistration.Click += value;
            }
            remove
            {
                btnRegistration.Click -= value;
            }
        }
        
        
        public Login()
        {
            InitializeComponent();
            
            
        }

        
    }
}
