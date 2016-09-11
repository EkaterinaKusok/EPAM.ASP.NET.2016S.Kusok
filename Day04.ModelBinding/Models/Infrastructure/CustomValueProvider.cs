using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;

namespace Models.Infrastructure
{
    public class CustomValueProvider : IValueProvider
    {
        private NameValueCollection data;

        public CustomValueProvider(NameValueCollection data)
        {
            this.data = data;
        }

        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            return new ValueProviderResult(this.data[key], this.data[key], CultureInfo.CurrentCulture);
        }
    }
}