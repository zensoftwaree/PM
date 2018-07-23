using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Business;
using System.IO;
using System.Reflection;
using System.Linq.Expressions;


namespace ProjectManager.DataAccess
{
    
    public class GlobalRepo<V> : IGlobalRepo<V> where V : class 
    {
        private string assemblyName = "ProjectManager.DataAccess";
        private Type requied;
        Type[] genType;
        private PropertyInfo[] pi;
        
        Type entityType;
        private PropertyInfo[] piEntity;
        object altRepoObject;

        public IQueryable<V> Items
        {
            get
            {
                return GetItems().AsQueryable();
            }
            
        }

        public GlobalRepo()
        {
            requied = typeof(V);
            pi = requied.GetProperties();

            entityType = typeof(ProjectManager.DataAccess.AltRepo<>);
            genType = new Type[] { Type.GetType(assemblyName + "." + requied.Name) };    //assemblyName + 
            piEntity = genType[0].GetProperties();
            entityType = entityType.MakeGenericType(genType);

            //Type[] typeParamConstr = { typeof(String) };
            ConstructorInfo altRepoConstructor = entityType.GetConstructor(Type.EmptyTypes);
            altRepoObject = altRepoConstructor.Invoke(new object[] { });
        }

        public void AddItem(V item)
        {
            var obj = Activator.CreateInstance(genType[0]);
            
            int i;
            for (i = 0; i < pi.Length; i++)
            {
                foreach (var p in piEntity)
                {
                    if ((pi[i].Name == p.Name) && (pi[i].PropertyType == p.PropertyType))
                        p.SetValue(obj, pi[i].GetValue(item));
                }
            }

            (entityType.GetMethod("AddItem")).Invoke(altRepoObject, new object[] { obj });
            (entityType.GetMethod("Save")).Invoke(altRepoObject, new object[] {  });
        }

        public void ModifyItem(V item)
        {
            var obj = Activator.CreateInstance(genType[0]);

            int i;
            for (i = 0; i < pi.Length; i++)
            {
                foreach (var p in piEntity)
                {
                    if ((pi[i].Name == p.Name) && (pi[i].PropertyType == p.PropertyType))
                        p.SetValue(obj, pi[i].GetValue(item));
                }
            }

            (entityType.GetMethod("UpdateItem")).Invoke(altRepoObject, new object[] { obj });
            (entityType.GetMethod("Save")).Invoke(altRepoObject, new object[] { });
        }

        private IQueryable<V> GetItems()
        {
           
            var obj = (entityType.GetMethod("GetAllItems")).Invoke(altRepoObject, null);
            if (obj == null) return null;
            
            ConstructorInfo outElementConstr;
            
            Type[] typesInOutElement = new Type[pi.Length];
            int i=0;
            foreach (var prop in pi)
            {
                typesInOutElement[i] = prop.PropertyType;
                
                i = i + 1;
            }
            List<V> result = new List<V>();

            List<object> arrayParam;

            foreach (var item in obj as IQueryable)
            {
                //arrayParam наполняется необходимыми для конструктора V значениями
                
                arrayParam = new List<object>();

                for (i = 0; i < pi.Length; i++)
                {
                    foreach (var p in piEntity)
                    {
                        if ((pi[i].Name == p.Name)&&(pi[i].PropertyType == p.PropertyType)) 
                                arrayParam.Add(p.GetValue(item));
                    }
                }

                outElementConstr = requied.GetConstructor(typesInOutElement);
                object outElement = outElementConstr.Invoke(arrayParam.ToArray());
                result.Add(outElement as V);

            }
                

            return result.AsQueryable();
              
        }



    }

    public class AltRepo<T> : IAltRepo<T> where T : class
    {
        
        protected readonly ObjectContext context;
        protected readonly ObjectSet<T> objectSet;

        public AltRepo()
        {

            this.context = new ObjectContext("name=BaseOnServerEntities");

            this.objectSet = context.CreateObjectSet<T>();
        }

        public AltRepo(string conn = "name=BaseOnServerEntities")
        {
            if (conn == null)
            {
                throw new ArgumentNullException("context");
            }
            
            this.context = new ObjectContext(conn);
            
            this.objectSet = context.CreateObjectSet<T>();
            
        }

        public IQueryable<T> GetAllItems()
        {
            return objectSet;
        }

        public IQueryable<T> GetAllWith(string includes)
        {
            ObjectQuery<T> value = objectSet;
            if (!String.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    value = value.Include(includeProperty.Trim());
                }
            }
            return value;
        }
        
        public void AddItem(T entity)
        {
           
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            objectSet.AddObject(entity);
            //Save();
        }

        public void RemoveItem(T entity)
        {
            
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            objectSet.DeleteObject(entity);
            //Save();
        }

        public void UpdateItem(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            objectSet.ApplyCurrentValues(entity);
            //Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
