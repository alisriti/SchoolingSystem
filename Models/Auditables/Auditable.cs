using System;

namespace SchoolingSystem.Models.Auditables
{
    public class Auditable
    {
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}