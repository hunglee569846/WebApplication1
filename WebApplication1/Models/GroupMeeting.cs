using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace WebApplication1.Models
{
    //mã tao thuộc tính cho đối tượng
    public class GroupMeeting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter project Name!")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Enter Lead Name!")]
        public string GroupMeetingLeadName { get; set; }

        [Required(ErrorMessage = "Enter Team Lead Name!")]
        public string TeamLeadName { get; set; }

        [Required(ErrorMessage = "Enter Descciption!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Group Meeting Date! ")]
        public DateTime GroupMeetingDate { get; set; }

        public static string strConnectionString = "Data Source=DESKTOP-APIVU2V/SQLEXPRESS;Initial Catalog=ProjectMeeting;Integrated Security=True";

    }
}




    
  
 


