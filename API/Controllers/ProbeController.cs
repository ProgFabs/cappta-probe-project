using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Application.Probes;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbeController : ControllerBase
    {

        [HttpPost]
        public List<string> Post([FromBody] JObject probeLaunchDTO) 
        {
            var validate = new Validate(probeLaunchDTO);
            return validate.ValidateBeforeLaunch();
        }
    }
}
