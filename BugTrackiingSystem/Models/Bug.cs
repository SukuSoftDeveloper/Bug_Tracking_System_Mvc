//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BugTrackiingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Bug
    {
        public int BugID { get; set; }
        [Required(ErrorMessage = "Please Enter Tracker")]
        public string Tracker { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please Enter StartDate")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required(ErrorMessage = "Please Enter Priority")]
        public string Priority { get; set; }
        [Required(ErrorMessage = "Please Enter DueDate")]
        public Nullable<System.DateTime> DueDate { get; set; }
        [Required(ErrorMessage = "Please Enter Assignee")]
        public string Assignee { get; set; }
        [Required(ErrorMessage = "Please Enter Estimated Time")]
        public string EstimatedTime { get; set; }
        [Required(ErrorMessage = "Please Enter Percentage Done")]
        public string PercentageDone { get; set; }
    }
}
