using System.Web;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Day01.Routing.Tests
{
    [Subject("Routing")]
    public class When_Route_is_Home_Something
    {
        static RouteCollection routes;
        static Mock<HttpContextBase> httpContextMock;
        protected static RouteData routeData;

        Establish that = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Something");
        };

        Because of = () => routeData = routes.GetRouteData(httpContextMock.Object);
        
        It should_have_route_with_value_Constrains = () =>
        {
            routeData.Route.ShouldEqual(routes["Constrains"]);
        };
    }
}
