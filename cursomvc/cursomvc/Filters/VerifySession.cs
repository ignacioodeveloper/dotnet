using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursomvc.Controllers;
using cursomvc.Models;
namespace cursomvc.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            // verificar si el usuario existe
            
            var oUser = (user)HttpContext.Current.Session["user"];
            if (oUser == null)
            {
                // evaluamos que sea diferente a AccessController
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }

            }
            else
            {
                // redirigimos a home si esta logeado
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}