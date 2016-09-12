using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModelValidation.Models;

namespace ModelValidation.Infrastructure
{
    public class VoucherValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as Voucher;
            if (model == null)
            {
                return false;
            }
            if (model.Prefix != null && model.Postfix != null && model.Prefix.Length + model.Postfix.Length > 6)
            {
                return false;
            }
            return true;
        }
    }
}