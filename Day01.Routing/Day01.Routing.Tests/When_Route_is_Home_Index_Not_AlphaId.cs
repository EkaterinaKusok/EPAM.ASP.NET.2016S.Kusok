using System.Web;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Day01.Routing.Tests
{
    [Subject("Routing")]
    public class When_Route_is_Home_Index_Not_AlphaId
    {
        static RouteCollection routes;
        static Mock<HttpContextBase> httpContextMock;
        protected static RouteData routeData;

        Establish that = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Index/11");
        };

        Because of = () => routeData = routes.GetRouteData(httpContextMock.Object);
        
        Behaves_like<A_Route_That_Has_Been_Found> a_route_that_has_been_found;

        It should_have_id_with_value_11 = () =>
        {
            routeData.Values["Id"].ShouldEqual("11");
        };
        It should_have_route_with_value_NamespacePriority1 = () =>
        {
            routeData.Route.ShouldEqual(routes["NamespacePriority2"]);
        };
    }
}
