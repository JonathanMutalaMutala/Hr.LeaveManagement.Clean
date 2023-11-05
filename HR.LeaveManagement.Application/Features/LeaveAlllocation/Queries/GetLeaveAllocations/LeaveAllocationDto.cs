﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAlllocation.Queries.GetLeaveAllocations
{
    public  class LeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public Domain.LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
