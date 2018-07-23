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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ProjectsManager.Controllers;
using ProjectsManager.Models;
using ProjectManager.Business;



namespace ProjectsManager
{
    public interface IAdminView
    {
        string EnteredUser { set; } 
        IEnumerable<string> ActualProjects { set; } 
       
        UserModel ProjLead { get; }
        
        IEnumerable<UserModel> AllLeads { get; set; }
        ProjectModel EntireProject { get; set; }

        string Status { set; }
        bool Save_Activate { set; }
        string NewComponentName { get; }
        string NewComponentDescr { get; }
        IEnumerable<ComponentModel> ComponentsOfProject { get; set; }

        event RoutedEventHandler SetLeadOfProj;
        event RoutedEventHandler Save;
        event RoutedEventHandler AddNewProj;
        event RoutedEventHandler AddComponent;
        event MouseButtonEventHandler ShowProject;
    }

    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window, IAdminView
    {
        

        public AdminWindow()
        {
                             
            InitializeComponent();
            tbProjectName.TextChanged += ChangedField_Handler;
            tbProjectDescription.TextChanged += ChangedField_Handler;

            this.Save += delegate
            {
                Save_Activate = false;
            };
            
            //Create content for elements of form

        }

        public ProjectModel EntireProject
        {
            set
            {
                tiProjectData.DataContext = value;
            }
            get
            {
                return tiProjectData.DataContext as ProjectModel;
            }
            
        }


        public string EnteredUser
        {
            set
            {
                lblCurrUser.Content = value;
            }
        }

        public IEnumerable<string> ActualProjects
        {
            set
            {
                lbActualProjects.ItemsSource = value;
            }
        }

       

        private void ChangedField_Handler(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "") Save_Activate = true;
        }

        public event RoutedEventHandler SetLeadOfProj
        {
            add
            {
                btnSetNewLead.Click += value;
            }
            remove
            {
                btnSetNewLead.Click -= value;
            }
        }
        
        public event RoutedEventHandler Save
        {
            add
            {
                btnSaveChanges.Click += value;
            }
            remove
            {
                btnSaveChanges.Click -= value;
            }
        }

        public event RoutedEventHandler AddNewProj
        {
            add
            {
                btnAddNewProj.Click += value;
            }
            remove
            {
                btnAddNewProj.Click -= value;
            }
        }

        public event MouseButtonEventHandler ShowProject
        {
            add
            {
                lbActualProjects.MouseDoubleClick += value;
            }
            remove
            {
                lbActualProjects.MouseDoubleClick -= value;
            }
        }

        public bool Save_Activate
        {
            set
            {
                btnSaveChanges.IsEnabled = value;
            }
        }

        public event RoutedEventHandler AddComponent
        {
            add
            {
                btnAddComponents.Click += value;
            }
            remove
            {
                btnAddComponents.Click -= value;
            }
        }

        public IEnumerable<UserModel> AllLeads
        {
            set { cbDevelopersName.ItemsSource = value; }
            get { return cbDevelopersName.ItemsSource as IEnumerable<UserModel>; }
        }

        
        public UserModel ProjLead
        {
            
            get { return cbDevelopersName.SelectedItem as UserModel; }
        }

        public string NewComponentName
        {
            get { return tbCompoName.Text; }
        }

        public string NewComponentDescr
        {
            get { return tbCompoDescr.Text; }
        }

        public IEnumerable<ComponentModel> ComponentsOfProject
        {
            set {
                grComponentsDetail.ItemsSource = value;
            }
            get
            {
                return grComponentsDetail.ItemsSource as IEnumerable<ComponentModel>;
            }
        }

        public string Status
        {
            set { lblStatus.Content = value; }
        }
    }
}
