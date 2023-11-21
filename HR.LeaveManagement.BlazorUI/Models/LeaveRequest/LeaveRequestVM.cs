﻿using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;
using HR.LeaveManagement.BlazorUI.Models.Employee; 

namespace HR.LeaveManagement.BlazorUI.Models.LeaveRequest
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]  
        public DateTime DateRequested { get; set; }

        [Display(Name ="Date Actionned")]
        public DateTime DateActionned { get; set; }

        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }

        public LeaveTypeVM LeaveType { get; set; } = new LeaveTypeVM();
        public int LeaveTypeId { get; set; }
        public EmployeeVM Employee {  get; set; } = new EmployeeVM();

        [Display(Name ="Start Date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Display(Name ="End Date")]
        [Required]
        public DateTime? EndDate { get; set; }

        [Display(Name ="Comments")]
        [MaxLength(300)]
        public string? RequestComments { get; set; }
    }
}
