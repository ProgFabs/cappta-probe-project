using System.Collections.Generic;
using Application;
using Domain;
using Newtonsoft.Json.Linq;

namespace Application.Probes
{
    public class Validate
    {
        private JObject Json { get; set; }

        public Validate(JObject json) {
            Json = json;
        }

        public List<string> ValidateBeforeLaunch() {
            var probeLaunchJson = JObject.Parse(Json.ToString());

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