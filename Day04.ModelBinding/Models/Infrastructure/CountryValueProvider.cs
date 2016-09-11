using System;
using System.Globalization;

namespace Models.Infrastructure
{
    public class CountryValueProvider : System.Web.Mvc.IValueProvider
    {public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country", StringComparison.Ordinal) > -1;
        }

        public System.Web.Mvc.ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new System.Web.Mvc.ValueProviderResult("Belarus", "Belarus", CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}