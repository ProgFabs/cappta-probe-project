namespace Domain
{
  public class ProbeLaunchDTO : Probe
  {
    public string Moves { get; private set; }

    public ProbeLaunchDTO(int position_X, int position_Y, char facingDirection, Highland highland, string moves) 
      : base(position_X, position_Y, facingDirection, highland)
    {
      Moves = moves;
    }
  }
}