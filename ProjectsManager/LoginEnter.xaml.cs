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
using ProjectsManager.Controllers;

namespace ProjectsManager
{
    public interface ILoginEnter
    {
        List<string> RegisteredUsers { set; }
        string EnteredPassword { get; }
        string SelectedUser { get; }
        event RoutedEventHandler Login;
        
    }      
    /// <summary>
    /// Логика взаимодействия для LoginEnter.xaml
    /// </summary>
    public partial class LoginEnter : Window, ILoginEnter
    {
        
        public LoginEnter()
        {
            InitializeComponent();
          
        }
        
        public List<string> RegisteredUsers
        {
            set
            {
                lbRegisteredUsers.ItemsSource = value;
            }

        }

        public string SelectedUser
        {
            get
            {
                return lbRegisteredUsers.SelectedItem.ToString();
            }
        }

        public string EnteredPassword
        {
            get
            {
                return pbPasswordField.Password;
            }

        }

        public event RoutedEventHandler Login
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

    }
}
