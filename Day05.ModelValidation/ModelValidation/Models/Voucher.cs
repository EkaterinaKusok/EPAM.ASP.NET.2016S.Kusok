using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    [VoucherValidation]
	public class Voucher : IValidatableObject
	{
        [Remote("ValidateName","Home")]
		public string Name { get; set; }

        [PrefixLogic(6)]
		public string Prefix { get; set; }
		public string Postfix { get; set; }

        [DisplayName("Min Amount")]
		public decimal? MinimalAmount { get; set; }

		public decimal? Percentage { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Range(typeof(bool),"true","true")]
		public bool SingleUse { get; set; }

		public string Title
		{
			get
			{
				return string.Format("Voucher {0}", 
					string.Format("{0} {1} {2}", Prefix, Name, Postfix)
					.Trim().Replace(' ','_'));
			}
		}

	    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	    {
	        var errorList = new List<ValidationResult>();
	        if (string.IsNullOrWhiteSpace(Name))
	        {
	            errorList.Add(new ValidationResult("Please enter voucher name"));
	        }
            else if (Name.Length > 50)
            {
                errorList.Add(new ValidationResult(""));
            }
	        throw new NotImplementedException();
	    }
	}
}