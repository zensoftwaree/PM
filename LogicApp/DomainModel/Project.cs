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
    
    public partial class Project
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectLeadId { get; set; }
        public string Description { get; set; }

        public Project()
        { }

        public Project(int id, string name, int projectLeadId, string description)
        {
            Id = id;
            Name = name;
            ProjectLeadId = projectLeadId;
            Description = description;
        }
    }
}
