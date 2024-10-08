using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Modules
{
    public class Response<T>
    {
        public string Message { get; set; }

        public T Payload { get; set; }

        public Boolean IsSuccess { get; set; }
    }
}