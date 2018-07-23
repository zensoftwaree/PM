using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ProjectManager.Business
{
    public interface IUserService
    {
        bool ValidateRole(string login, string role);
        bool IsUserRegistered(string login);
        bool AvtorizeUser(string login, string psw);
        List<string> GetAllLogins();
        List<User> GetAllDevelopers();
        int GetIdOnFullname(string fname);
    }

    public class UserService : IUserService

    {
        
        private IQueryable<User> users;
        const int NumUsersWithSomeLogin = 1;
        const int developerRoleId = 2;

        public UserService(IQueryable<User> repo)
        {
            users = repo;
            
            
        }


        public int GetIdOnFullname(string fname)
        {
            return users.Where(u => u.Fullname == fname).Select(u => u.Id).First();
        }
        
        public List<User> GetAllDevelopers()
        {
            return users.Where(u => u.RoleId == developerRoleId).Select(u=>u).ToList<User>();
           
        }

       
        public bool IsUserRegistered(string login)
        {
            if (users.Count(u => u.Login == login) == NumUsersWithSomeLogin) return true;
            return false;
        }

        public bool AvtorizeUser(string login, string psw)
        {
            if (users.Where(u => u.Login == login).Where(u => u.Psw == psw).Count() == NumUsersWithSomeLogin) return true;
            return false;
        }

        public bool ValidateRole(string login, string role)
        {
            if (users.Count(u => u.Login == login) == NumUsersWithSomeLogin)
            {
                return true;
                //if (users.Where(u => u.Login == login).First().Role == role) return true;
            }
            return false;
        }

        public List<string> GetAllLogins()
        {
            return users.Select(u => u.Login).ToList<string>();
        }
    }
}
