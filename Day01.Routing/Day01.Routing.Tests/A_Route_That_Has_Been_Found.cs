using Machine.Specifications;
using System.Web.Routing;
using System.Web.Helpers;

namespace Day01.Routing.Tests
{
    [Behaviors]
    public class A_Route_That_Has_Been_Found
    {
        protected static RouteData routeData;

        It should_have_found_the_route = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Index");
        };
    }
}
