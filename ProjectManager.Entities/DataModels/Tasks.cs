using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Entities.DataModels
{
    public class Tasks
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //public int Project { get; set; }
        [ForeignKey("Project_Id")]
        public Projects Project { get; set; }
        public int Project_Id { get; set; }


        public Nullable<int> Parent_Task { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<DateTime> Start_Date { get; set; }
        public Nullable<DateTime> End_Date { get; set; }
        public Nullable<int> User { get; set; }     // Not important as we are not showing this in View Task wireframe
        public bool status { get; set; }
    }
}
