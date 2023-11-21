﻿using HR.LeaveManagement.BlazorUI.Models.LeaveRequest;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface ILeaveRequestService
    {
        Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest);
        Task<LeaveRequestVM> GetLeaveRequestById(int id);
        Task DeleteLeaveRequest(int id);
        Task ApproveLeaveRequest(int id, bool approved);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
    }
}
