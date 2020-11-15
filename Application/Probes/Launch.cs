using System.Security.AccessControl;
using Domain;

namespace Application.Probes
{
  public class Launch
  {
    public ProbeDTO Probe { get; set; }

    public Launch(ProbeDTO probe) {
      Probe = probe;
    }
    
    
    public string ProbeLaunch() 
    {
      Highland highland = new Highland(5, 5);
      Probe newProbe = new Probe(Probe.Position_X, Probe.Position_Y, Probe.FacingDirection, highland);

      // char[] moves = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };

      if (Probe.Moves != null)
      {
        char[] moves = new char[Probe.Moves.Length];
        int counter = 0;

        foreach (char c in Probe.Moves)
        {
          moves[counter] = c;
          counter++;
        }

        newProbe.Move(moves);
        return newProbe.LastPosition();
      }

      return "Error";
    }
  }
}