using System;
using System.Configuration;
using System.Web.Mvc;

namespace Models.Infrastructure
{
    public class CustomValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var provider = ConfigurationManager.AppSettings["ValueProvider"];
            var targetType = Type.GetType(provider);
            return (IValueProvider)Activator.CreateInstance(targetType, controllerContext);
            //return new CountryValueProvider();
        }
    }
}