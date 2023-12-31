﻿using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    /// <summary>
    /// Class reprensentation une bad Request Exception 
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message,ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();

        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
