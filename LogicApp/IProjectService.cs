using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace ProjectManager.Business
{
    public interface IProjectService
    {
        //IEnumerable<string> GetAllProjNames();
        void AddNewProject(Project item);
        void ModifyCurrItem(Project item);
        IQueryable<Project> Items { get; }
    }
    
    public class ProjectService : IProjectService
    {
        
        IGlobalRepo<Project> projects;

        public IQueryable<Project> Items
        {
            get
            {
                return projects.Items;
            }
        }
        
        public ProjectService(IGlobalRepo<Project> repoProjects)
        {
            
            projects = repoProjects;
        }
        
        public void AddNewProject(Project item)
        {
            projects.AddItem(item);
        }

        public void ModifyCurrItem(Project item)
        {
            projects.ModifyItem(item);
        }

        public IEnumerable<string> GetAllProjNames()
        {
            //Будет добавлено условие отбора именно актуальных, с незакрытыми Issues
            return projects.Items.Select(p => p.Name);
        }



    }
}
