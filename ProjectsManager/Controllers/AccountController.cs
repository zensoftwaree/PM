using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManager.Models;


namespace ProjectsManager.Controllers
{
    public interface IAccountController
    {
        
        List<UserModel> GetDevelopers();
        event Action<string, IEnumerable<UserModel>, Window> ShowAdminWindow;
        
    }
    
    public class AccountController : IAccountController
    {
        private ProjectManager.Business.IUserService userServ;
        private ILoginEnter workView;
        private Action<string, IEnumerable<UserModel>, Window> ShowAdminWindow_handler;

        
        public AccountController(ProjectManager.Business.IUserService logic, ILoginEnter view)
        {
            userServ = logic;
            workView = view;
            workView.RegisteredUsers = userServ.GetAllLogins();
            workView.Login += workView_Login;
            
        }

        public event Action<string, IEnumerable<UserModel>, Window> ShowAdminWindow
        {
            add
            {
                ShowAdminWindow_handler += value;
            }
            remove
            {
                ShowAdminWindow_handler -= value;
            }
        }

        private void workView_Login(object sender, System.Windows.RoutedEventArgs e)
        {
            if (userServ.AvtorizeUser(workView.SelectedUser, workView.EnteredPassword))
            {
                ShowAdminWindow_handler("Entered as: " + workView.SelectedUser, this.GetDevelopers(), workView as Window);
            }
            else
            {
                MessageBox.Show("Entered account data is not correct!");
            }
        }

        public List<UserModel> GetDevelopers()
        {
            List<UserModel> coll = new List<UserModel>();
            foreach (var it in userServ.GetAllDevelopers())
            {
                UserModel one = new UserModel { Id = it.Id, Login = it.Login, FullName = it.Fullname };
                
                coll.Add(one);
            }
            return coll;
        }
    }
}
