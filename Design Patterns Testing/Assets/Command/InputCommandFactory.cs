using UnityEngine;

public class DirectionalInputFactory
{
    // Assumes that will only be called if x or y out of deadzone.
    public InputCommand MakeCommand(float x, float y)
    {
        if(Mathf.Abs(x) <= Mathf.Abs(y))
        {
            if (y > 0)
            {
                return new UpCommand(y);
            }
            else
            {
                return new DownCommand(y);
            }
        }
        else
        { 
            if (x > 0)
            {
                return new RightCommand(x);
            }
            else
            {
                return new LeftCommand(x);
            }
        }
    }
}
