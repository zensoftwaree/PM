using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManager.Models;
using System.Windows;
using System.Windows.Controls;

using ProjectManager.Business;

namespace ProjectsManager.Controllers
{
    
    
    public class ProjectController
    {
        private ProjectManager.Business.IProjectService servProj;
        private IAdminView _view;
        
        
        public ProjectController(ProjectManager.Business.IProjectService serv, IAdminView view)
        {
            servProj = serv;
            _view = view;
            _view.ActualProjects = servProj.Items.Select(it => it.Name);
            _view.Save += _view_Save;
            _view.Save_Activate = false;
            _view.ShowProject += _view_ShowProject;
            _view.AddNewProj += _view_AddNewProj;
            _view.SetLeadOfProj += _view_SetLeadOfProj;
        }

        private void _view_SetLeadOfProj(object sender, RoutedEventArgs e)
        {

            _view.EntireProject.TeamLeadName = _view.ProjLead.FullName;
            _view.Status = "Please Save your changes of Lead!";
        }

        private void _view_AddNewProj(object sender, RoutedEventArgs e)
        {
            
                //Validation EntireProject
                
                this.AddNewProject(_view.EntireProject);
                _view.EntireProject = null;
                 
                _view.Status = "New Project was added";
            
        }

        private void AddNewProject(ProjectModel model)
        {
            if (servProj.Items.Where(i => i.Name == model.Name).Count() != 0)
            {
                MessageBox.Show("Project with this name is exist! Please edit this one...");
            }
            else servProj.AddNewProject(
                new Project { Description = model.Description, Name = model.Name, 
                    ProjectLeadId = _view.AllLeads.Where(n=>n.FullName == model.TeamLeadName).First().Id }
            );
            _view.ActualProjects = servProj.Items.Select(it => it.Name);
        }

        private void _view_ShowProject(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string selItemName = (sender as ListBox).SelectedItem.ToString();
            var selItem = servProj.Items.Where(i => i.Name == selItemName).FirstOrDefault();
            if (selItem != null)
            {
                //Must send ProjectModel on UI
                ProjectModel el = new ProjectModel
                {
                    TeamLeadName = _view.AllLeads.Where(it => it.Id == selItem.ProjectLeadId).First().FullName,
                    Name = selItem.Name,
                    Description = selItem.Description,
                    Id = selItem.Id
                    //,
                    //TeamLeadId = selItem.ProjectLeadId
                };

                _view.EntireProject = el;
            }
        }

        private void _view_Save(object sender, RoutedEventArgs e)
        {
            ProjectModel el = _view.EntireProject;
                
            if (el != null)
            {
                this.ModifyProject(el);
                _view.EntireProject = null;
               
                _view.Status = "Project \'" + el.Name + "\' was modified";
            }
        }
        
        private void ModifyProject(ProjectModel model)
        {
            servProj.ModifyCurrItem(
                new Project { Id = model.Id, Description = model.Description, Name = model.Name, 
                              ProjectLeadId = _view.AllLeads.Where(u=>u.FullName == model.TeamLeadName).First().Id }
            );
            _view.ActualProjects = servProj.Items.Select(it => it.Name);
        }
      
    }
    
}
