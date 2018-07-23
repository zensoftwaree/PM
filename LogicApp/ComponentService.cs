using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public class ComponentService : IComponentService
    {
        private IGlobalRepo<Component> _repo;
        private IQueryable<Component> Items
        {
            get
            {
                return _repo.Items;
            }
        }

        public ComponentService(IGlobalRepo<Component> repo)
        {
            _repo = repo;

        }
        
        public IEnumerable<Component> GetAllForProject(int idProject)
        {
            return Items.Where(it => it.ProjectId == idProject).AsEnumerable();
        }

        public void AddNew(Component item)
        {
            if (item != null) _repo.AddItem(item);
        }
    }
}
