//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.Business
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
       
        public int Id { get; set; }
        public string Login { get; set; }
        public string Psw { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public int RoleId { get; set; }
        //public int NewProperty { get; set; }

        public User()
        { }

        public User(int id, string login, string psw, string email, string fullname, int roleId)
        {
            Id = id;
            Login = login;
            Psw = psw;
            Email = email;
            Fullname = fullname;
            RoleId = roleId;
        }
    }
}
