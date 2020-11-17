using System.Collections.Generic;
using Domain;

namespace Application.Probes
{
  public class Launch
  {
    private List<ProbeLaunchDTO> Probes { get; set; }

    public Launch(List<ProbeLaunchDTO> probes) {
      Probes = probes;
    }
     
    public List<string> ProbeLaunch() 
    {
      List<string> probeLastPosition = new List<string>();
      foreach (ProbeLaunchDTO probe in Probes) 
      {
        probe.Move(probe.Moves);
        probeLastPosition.Add(probe.LastPosition());
      }

      return probeLastPosition;
    }
  }
}