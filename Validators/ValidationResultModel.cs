using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Validators
{
    public class ValidationResultModel
    {
        public int StatusCode { get; }

        public string Message { get; }

        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
            var msgString = "";
            foreach (ValidationError c in Errors)
            {
                msgString += c.Message+' ';
            }
            StatusCode = 422;
            Message = "Falha na validação : "+msgString;
            
        }
    }
}