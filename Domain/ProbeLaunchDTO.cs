namespace Domain
{
  public class ProbeLaunchDTO : Probe
  {
    public string Moves { get; set; }

    public ProbeLaunchDTO(int position_X, int position_Y, char facingDirection, Highland highland, string moves) : base() 
    {
      Position_X = position_X;
      Position_Y = position_Y;
      FacingDirection = facingDirection;
      Highland = highland;
      Moves = moves;
    }
  }
}