﻿using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.Employee;
using HR.LeaveManagement.BlazorUI.Models.LeaveAllocation;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequest;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, mapper, localStorageService)
        {
        }

        public async Task ApproveLeaveRequest(int id, bool approved)
        {
            try
            {
                var request = new ChangeLeaveRequestApprovalCommand { Approved = approved, Id = id };
                await _client.UpdateApprovalAsync(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<Guid>> CancelLeaveRequestById(int id)
        {
            try
            {
                var response = new Response<Guid>();
                var request = new CancelLeaveRequestCommand { Id = id };
                await _client.CancelRequestAsync(request);
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<Guid>(ex);
               
            }
        }

        public  async Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
        {
            try
            {
                var response = new Response<Guid>();
                var createLeaveRequest = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);

                await _client.LeaveRequestPOSTAsync(createLeaveRequest);
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<Guid>(ex);
            }
        }

        public Task DeleteLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
           var leaveRequests = await _client.LeaveRequestAllAsync(isLoggedInUser: false);
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(x => x.Approved == null),
                RejectedRequests = leaveRequests.Count(x => x.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            return model;
        }

        public async Task<LeaveRequestVM> GetLeaveRequestById(int id)
        {
           var leaveRequest = await _client.LeaveRequestGETAsync(id);

            return _mapper.Map<LeaveRequestVM>(leaveRequest);
        }

        public async Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests()
        {

            var leaveRequests = await _client.LeaveRequestAllAsync(isLoggedInUser: true);
            ICollection<LeaveAllocationDto> allocations = await _client.LeaveAllocationAllAsync(isLoggedInUser: true);

            var model = new EmployeeLeaveRequestViewVM
            {
                leaveAllocationVMs = _mapper.Map<List<LeaveAllocationVM>>(allocations),
                leaveRequestVMs = _mapper.Map<List<LeaveRequestVM>>(leaveRequests),
            };

            return model;

        }
    }
}
