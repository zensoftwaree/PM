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
    
    public partial class DetailIssue
    {
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public string DescriptionWork { get; set; }
        public System.DateTime TimeIn { get; set; }
        public System.DateTime TimeOut { get; set; }
        public bool NewVersion { get; set; }
    
        public virtual Issue Issue { get; set; }
        public virtual User User { get; set; }
    }
}