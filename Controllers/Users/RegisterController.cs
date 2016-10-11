using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatterboxAppApi.Controllers
{
    [Route("users/register")]
    public class RegisterController : Controller
    {
        [HttpPost]
        public void Post()
        {
        }
    }
}