//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectProfessor
    {
        public int Id { get; set; }
        public int SubjectSemesterId { get; set; }
        public int ProfessorId { get; set; }
    
        public virtual Professor Professor { get; set; }
        public virtual SubjectSemester SubjectSemester { get; set; }
    }
}
