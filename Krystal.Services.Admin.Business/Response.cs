using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Krystal.Services.Admin.Business
{
    public interface IResponse
    {
        DateTime Timestamp { get; set; }

        TimeSpan Execution { get; set; }

        bool Error { get; set; }

        bool Warning { get; set; }

        string Message { get; set; }

        Exception Exception { get; set; }
    }

    public class Response : IResponse
    {
        public DateTime Timestamp { get; set; }

        public TimeSpan Execution { get; set; }

        public bool Warning { get; set; }

        public bool Error { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public Response()
        {
            Timestamp = DateTime.Now;
        }

        public Response(IEnumerable<ValidationFailure> failures)
        {
            Timestamp = DateTime.Now;

            Error = true;

            foreach (var failure in failures)
            {
                Message += failure.ErrorMessage + " ";
            }
        }
    }
}