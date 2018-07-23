using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Business;
using ProjectsManager.Models;

namespace ProjectsManager.Controllers
{
    class ComponentController
    {
        private IComponentService servComponent;
        private IAdminView _view;
        

        public ComponentController(IComponentService service, IAdminView view)
        {
            
            servComponent = service;
            _view = view;
            
            _view.AddComponent += _view_AddComponent;
            _view.ShowProject += _view_ShowProject;
        }

        void _view_ShowProject(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.fillingComponents();
        }

        private void _view_AddComponent(object sender, System.Windows.RoutedEventArgs e)
        {
            //it's must get content from connected UI object
            servComponent.AddNew(new Component {
                Name=_view.NewComponentName,
                Description=_view.NewComponentDescr,
                ComponentLeadId=2,
                ProjectId=_view.EntireProject.Id});
        }

        private void fillingComponents()
        {

            var coll = servComponent.GetAllForProject(_view.EntireProject.Id);
                List<ComponentModel> viewColl = new List<ComponentModel>();
                foreach (var it in coll)
                {
                    viewColl.Add(new ComponentModel { 
                        Id = it.Id,
                        ComponentLeadId = it.ComponentLeadId,
                        Name = it.Name,
                        Description = it.Description});
                }
                _view.ComponentsOfProject = viewColl;
        }
        

    }
}
