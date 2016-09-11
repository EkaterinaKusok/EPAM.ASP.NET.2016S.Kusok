using System.Web.Mvc;

namespace Models.Infrastructure
{
    public class CustomFormValueProvider : CustomValueProvider
    {
        public CustomFormValueProvider(ControllerContext controllerContext) : base(controllerContext.HttpContext.Request.Form) { }
    }
}