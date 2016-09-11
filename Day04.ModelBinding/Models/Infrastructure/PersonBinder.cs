using System;
using System.Web.Mvc;
using Models.Models;

namespace Models.Infrastructure
{
    public class PersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (Person)bindingContext.Model ?? new Person();
            model.FirstName = this.GetValue(bindingContext, "FirstName");
            model.LastName = this.GetValue(bindingContext, "LastName");
            model.BirthDate = this.GetBirthDateValue(bindingContext, "BirthDate");
            model.Role = (Role)Enum.Parse(typeof(Role), this.GetRoleValue(bindingContext, "Role", controllerContext.RequestContext.HttpContext.Request.IsLocal), true);
            model.HomeAddress.Line1 = this.GetAddressValue(bindingContext, "Line1");
            model.HomeAddress.Line2 = this.GetAddressValue(bindingContext, "Line2");
            model.HomeAddress.City = this.GetValue(bindingContext, "City");
            model.HomeAddress.Country = this.GetValue(bindingContext, "Country");
            model.HomeAddress.PostalCode = this.GetPostalValue(bindingContext, "PostalCode");
            model.HomeAddress.AddressSummary = this.GetAddressSummaryValue(model);
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            var result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
            {
                return "<not-defined>";
            }
            else
            {
                return result.AttemptedValue;
            }
        }

        private DateTime GetBirthDateValue(ModelBindingContext context, string name)
        {
            DateTime birthDate;
            var birthDateString = this.GetValue(context, name);
            if (!DateTime.TryParse(birthDateString, out birthDate))
            {
                return birthDateString == "<not-defined>" ? DateTime.Now : ParseDateString(birthDateString);
            }
            else
            {
                return birthDate;
            }
        }

        // uncommon data format: yyyy-mm-dd
        private DateTime ParseDateString(string date)
        {
            DateTime result;
            if (date.Length < 10)
            {
                return DateTime.MinValue;
            }

            DateTime.TryParse($"{date.Substring(5, 2)}/{date.Substring(8, 2)}/{date.Substring(0, 4)}", out result);
            return result;
        }

        private string GetRoleValue(ModelBindingContext context, string role, bool isLocal)
        {
            var result = this.GetValue(context, role);
            if (result == "<not-defined>")
            {
                return "Guest";
            }
            if (result == "Admin" && !isLocal)
            {
                return "User";
            }
            else
            {
                return result;
            }
        }

        private string GetAddressValue(ModelBindingContext context, string addrLine)
        {
            var result = this.GetValue(context, addrLine);
            return result == "PO Box" ? "<not-defined>" : result;
        }

        private string GetPostalValue(ModelBindingContext context, string addrLine)
        {
            var result = this.GetValue(context, addrLine);
            return result.Length < 6 ? "<not-defined>" : result;
        }

        private string GetAddressSummaryValue(Person model)
        {
            if (model.HomeAddress.Line1 == "<not-defined>")
            {
                return "No Personal Address";
            }

            return model.HomeAddress.PostalCode + " " + model.HomeAddress.City + "," + model.HomeAddress.Line1;
        }
    }
}