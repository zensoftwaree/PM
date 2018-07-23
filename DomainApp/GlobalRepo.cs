using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace DomainApp
{
    public class GlobalRepo
    {
        BaseOnServerEntities currDb;
        public GlobalRepo(BaseOnServerEntities db)
        {
            currDb = db;
            
        }

        public string NameProperty (DeepObj item)
        {
            
                //if (typeof(T) != null)
                //{
                    object ob = "Tester";
                    Type t = typeof(DeepObj);
                    PropertyInfo prop = t.GetProperty("Incase");
                    Type original = prop.PropertyType;
                    MethodInfo origMethod = original.GetMethod("Echo");
                    return origMethod.Invoke(prop, new object[] { ob }) as string;
                    
                //}
            
            return null;
        }

        
        public void AddItem<T> (T item)
        {
            
                if (typeof(T) != null)
                {
                    
                }
            
        }

        public T GetOneItem<T>(int id) where T: class
        {
            using (BaseOnServerEntities db = new BaseOnServerEntities())
            {
                if (typeof(T).ToString() == "DomainApp.User")
                {
                    return db.User.Include("UserRole").First(u => u.Id == id) as T; //
                    
                }
                return default(T);
            }
        }

        public IQueryable<T> GetAllItems<T>()
        {
            using (BaseOnServerEntities db = new BaseOnServerEntities())
            {
                if (typeof(T).ToString() == "DomainApp.User")
                {
                    return db.User.ToList<User>() as IEnumerable<T>;
                }
                if (typeof(T).ToString() == "DomainApp.UserRole")
                {
                    return db.UserRole.Include("User").ToList<UserRole>() as IEnumerable<T>;
                }
            }
            return null;
        }

        public void UpdateItem<T>(T item) where T : class
        {
            using (BaseOnServerEntities db = new BaseOnServerEntities())
            {
                if (typeof(T).ToString() == "DomainApp.User")
                {
                    //db.User.ToList<User>() as IEnumerable<T>;
                }
            }
        }

        public void RemoveItem<T>(int id) where T : class
        {
            //Not used
        }

    }
}
