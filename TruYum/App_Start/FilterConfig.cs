using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruYum.App_Start
{
    public class FilterConfig
    {
     
        internal static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}