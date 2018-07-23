using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjectManager.Business;
using System.Data.Entity;
using ProjectsManager.Models;

namespace ProjectsManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //DbContext context = new DbContext("name=BaseOnServerEntities");  

            ILogin introView = new Login();
            ILoginEnter viewForLogin = new LoginEnter();
            introView.LogIn += delegate
            {
                
                (viewForLogin as Window).Show();
                (introView as Window).Close();
            };

            (introView as Window).Show();

            IGlobalRepo<ProjectManager.Business.User> repoUser = new ProjectManager.DataAccess.GlobalRepo<ProjectManager.Business.User>(); 
            IUserService userSrv = new UserService(repoUser.Items);            
            Controllers.AccountController accountControll = new Controllers.AccountController(userSrv, viewForLogin);
            accountControll.ShowAdminWindow += accountControll_ShowAdminWindow;

           

            
        }

        public void accountControll_ShowAdminWindow(string arg1, IEnumerable<UserModel> arg2, Window arg3)
        {
            IAdminView adminView = new AdminWindow();
            adminView.EnteredUser = arg1;
            adminView.AllLeads = arg2;

            IGlobalRepo<ProjectManager.Business.Project> repoProject = new ProjectManager.DataAccess.GlobalRepo<ProjectManager.Business.Project>();
            IProjectService projectService = new ProjectService(repoProject);
            Controllers.ProjectController projControll = new Controllers.ProjectController(projectService, adminView);

            IGlobalRepo<ProjectManager.Business.Component> repoComponent = new ProjectManager.DataAccess.GlobalRepo<ProjectManager.Business.Component>();
            IComponentService componentService = new ComponentService(repoComponent);
            Controllers.ComponentController compoControll = new Controllers.ComponentController(componentService, adminView);

            (adminView as Window).Show();
            arg3.Close();
        }


    }
}
