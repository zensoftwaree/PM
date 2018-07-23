//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Component = new HashSet<Component>();
            this.ProjVersion = new HashSet<ProjVersion>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectLeadId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Component> Component { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProjVersion> ProjVersion { get; set; }
    }
}
