using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public interface IComponentService
    {
        IEnumerable<Component> GetAllForProject(int idProject);
        void AddNew(Component item);
    }
}
