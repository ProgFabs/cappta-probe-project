using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using Application;
using Application.Probes;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbeController : ControllerBase
    {

    [HttpGet]
        public string Get()
        {
            Highland highland = new Highland(5, 5);
            Probe probe = new Probe(1, 2, 'N', highland);

            char[] moves = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };
            probe.Move(moves);

            return probe.LastPosition();
        }

    // [HttpPost]
    //     public string Post([FromBody] ProbeDTO probe) 
    //     {
    //         var launch = new Launch(probe);

    //         return launch.ProbeLaunch();
    //     }
        [HttpPost]
        public List<ProbeList> Post([FromBody] JObject probes) 
        {
                var jo = JObject.Parse(probes.ToString());
                var probe = jo["probe"].ToObject<ProbeList[]>();

                List<ProbeList> probeList = new List<ProbeList>();
                foreach (var p in probe)
                {
                    probeList.Add(p);
                }
                return probeList;






            // List<ProbeList> list = new List<ProbeList>();

            // foreach (var element in probes)
            // {
            //     ProbeList datalist = JsonConvert.DeserializeObject<ProbeList>(probes.ToString());
            //     list.Add(datalist);
            // }
            // return list;
        }
    }
}
