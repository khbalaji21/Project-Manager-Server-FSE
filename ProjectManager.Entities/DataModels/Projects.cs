using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Entities.DataModels
{
    public class Projects
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Priority { get; set; }
        public Nullable<DateTime> Start_Date { get; set; }
        public Nullable<DateTime> End_Date { get; set; }

        public int Manager_Id { get; set; }

        public bool status { get; set; }

        public List<Tasks> tasks { get; set; }

    }
}
