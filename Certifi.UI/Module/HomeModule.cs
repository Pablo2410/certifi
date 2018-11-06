using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Module
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", p => View["main"]);
        }
    }
}
