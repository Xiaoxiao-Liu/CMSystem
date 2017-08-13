﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CMSystem.Controllers;

namespace CMSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    

    public void Application_Error(Object sender, EventArgs e)
    {
        Exception exception = Server.GetLastError();
        Server.ClearError();

        var routeData = new RouteData();
        routeData.Values.Add("controller", "ErrorPage");
        routeData.Values.Add("action", "Error");
        routeData.Values.Add("exception", exception);

        if (exception.GetType() == typeof(HttpException))
        {
            routeData.Values.Add("statusCode", ((HttpException)exception).GetHttpCode());
            routeData.Values.Add("statusMsg", ((HttpException)exception).GetHtmlErrorMessage());
        }
        else
        {
            routeData.Values.Add("statusCode", 500);
            routeData.Values.Add("statusMsg", "Something went haywire, maybe try again later?");
        }

        Response.TrySkipIisCustomErrors = true;
        IController controller = new ErrorPageController();
        controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        Response.End();
    }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
        if (Context.Response.StatusCode == 401 || Context.Response.StatusCode == 403)
        {
            // this is important, because the 401 is not an error by default!!!
            throw new HttpException(401, "You are not authorised");
        }
    }
}
}
