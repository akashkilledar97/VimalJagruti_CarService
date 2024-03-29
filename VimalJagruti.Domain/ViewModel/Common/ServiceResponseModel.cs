﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Domain.ViewModel.Common
{
    public class ServiceResponseModel<T> where T : class
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
