namespace Domain
{
    public class Probe
    {
        public int Position_X { get; protected set; }
        public int Position_Y { get; protected set; }
        public char FacingDirection { get; protected set; }
        public Highland Highland { get; protected set; }

    public Probe(int position_X, int position_Y, char facingDirection, Highland highland)
    {
      Position_X = position_X;
      Position_Y = position_Y;
      FacingDirection = facingDirection;
      Highland = highland;
    }

    public void Move(string moves)
    {
      for (int i = 0; i < moves.Length; i++)
      {
        char move = moves[i];

        // TURNS

        if (move == 'L' && FacingDirection == 'N')
        {
          FacingDirection = 'W';
          continue;
        }

        if (move == 'L' && FacingDirection == 'W')
        {
          FacingDirection = 'S';
          continue;
        }

        if (move == 'L' && FacingDirection == 'S')
        {
          FacingDirection = 'E';
          continue;
        }

        if (move == 'L' && FacingDirection == 'E')
        {
          FacingDirection = 'N';
          continue;
        }

        if (move == 'R' && FacingDirection == 'N')
        {
          FacingDirection = 'E';
          continue;
        }

        if (move == 'R' && FacingDirection == 'E')
        {
          FacingDirection = 'S';
          continue;
        }

        if (move == 'R' && FacingDirection == 'S')
        {
          FacingDirection = 'W';
          continue;
        }

        if (move == 'R' && FacingDirection == 'W')
        {
          FacingDirection = 'N';
          continue;
        }

        // MOVES

        if (move == 'M' && FacingDirection == 'W')
        {
          if (Position_X != 0)
          {
            Position_X -= 1;   
          }
          continue;
        }

        if (move == 'M' && FacingDirection == 'E')
        {
          if (Highland.Boundary_X != Position_X)
          {
            Position_X += 1;
          }

          continue;
        }

        if (move == 'M' && FacingDirection == 'N')
        {
          if (Highland.Boundary_Y != Position_Y)
          {
            Position_Y += 1;
          }

          continue;
        }

        if (move == 'M' && FacingDirection == 'S')
        {
          if (Position_Y != 0)
          {
            Position_Y -= 1;
          }
        }
      }

    }
    public string LastPosition()
    {
      return $"{Position_X} {Position_Y} {FacingDirection}";
    }
    
    }
}