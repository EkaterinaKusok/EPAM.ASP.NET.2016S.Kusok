using System.Web;
using System.Web.Routing;
using Machine.Specifications;
using Moq;

namespace Day01.Routing.Tests
{
    [Subject("Routing")]
    public class When_Route_Home_Index
    {
        static RouteCollection routes;
        static Mock<HttpContextBase> httpContextMock;
        protected static RouteData routeData;

        Establish that = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Index");
        };

        Because of = () => routeData = routes.GetRouteData(httpContextMock.Object);

        Behaves_like<A_Route_That_Has_Been_Found> a_route_that_has_been_found;

    }
}
