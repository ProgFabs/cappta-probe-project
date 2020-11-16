using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain;
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
            var probeLaunchJson = JObject.Parse(probeLaunchDTO.ToString());

            var highlander = probeLaunchJson["highland"].ToString().Split(' ');
            var probe = probeLaunchJson["probe"].ToObject<List<ProbeLaunchDTO>>();

            Highland highland = new Highland(int.Parse(highlander[0]), int.Parse(highlander[1]));

            List<ProbeLaunchDTO> probeList = new List<ProbeLaunchDTO>();
            foreach (var p in probe)
            {
                ProbeLaunchDTO pp = new ProbeLaunchDTO(
                    p.Position_X,
                    p.Position_Y,
                    p.FacingDirection,
                    highland,
                    p.Moves
                );

                probeList.Add(pp);
            }

            var launch = new Launch(probeList);
            return launch.ProbeLaunch();
        }
    }
}
