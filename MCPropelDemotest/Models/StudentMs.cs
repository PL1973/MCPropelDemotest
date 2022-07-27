using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MCPropelDemotest.Models
{
    public partial class StudentMs
    {
        public int Regno { get; set; }
        public string StudentfullName { get; set; }
        public string CourseJoining { get; set; }
        public decimal? CourseFee { get; set; }
        public string BatchId { get; set; }
        public DateTime? Doj { get; set; }
        public string Address { get; set; }
        public int? MobileNumber { get; set; }
        public string EmailId { get; set; }
    }
}
