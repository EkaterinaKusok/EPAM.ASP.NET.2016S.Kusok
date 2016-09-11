using System.Web.Mvc;

namespace Models.Infrastructure
{
    public class CustomQueryStringValueProvider : CustomValueProvider
    {
        public CustomQueryStringValueProvider(ControllerContext controllerContext) : base(controllerContext.HttpContext.Request.QueryString) { }
    }
}