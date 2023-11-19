﻿namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);

        Task<bool> RegisterAsync(string firstName,string lastName, string email,string userName,string password);

        Task Logout();
    }
}
