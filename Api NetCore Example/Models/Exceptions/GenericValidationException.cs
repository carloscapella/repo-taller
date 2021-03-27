using Api_NetCore_Example.Models.Validations;
using System;
using System.Collections.Generic;

namespace Api_NetCore_Example.Models.Exceptions
{
    public class GenericValidationException : Exception
    {
        public GenericValidationException()
        {
            ValidationErrors = new List<Validation>();
        }

        public GenericValidationException(List<Validation> errorList)
        {
            ValidationErrors = errorList;
        }

        public List<Validation> ValidationErrors
        {
            get; set;
        }

    }
}
