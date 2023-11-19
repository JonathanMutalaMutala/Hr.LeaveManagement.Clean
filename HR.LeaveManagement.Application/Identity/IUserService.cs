﻿using HR.LeaveManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(string userId);

    }
}
