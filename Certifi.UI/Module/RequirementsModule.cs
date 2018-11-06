using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Module
{
    public class RequirementsModule : NancyModule
    {
        public RequirementsModule()
        {
            Get("/requirements/page1", p => View["page1"]);
        }
    }
}
