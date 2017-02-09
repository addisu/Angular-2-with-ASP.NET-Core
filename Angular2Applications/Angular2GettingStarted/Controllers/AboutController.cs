using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2GettingStarted.Controllers
{
    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+1-555-123-4567";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Canada";
        }
    }
}
