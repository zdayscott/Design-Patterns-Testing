using UnityEngine;

public class InputCommand
{
    protected float timestamp;
    public InputCommand() { timestamp = Time.time; }
    public virtual string GetName()
    {
        return "null";
    }
}

public class Punch1Command : InputCommand
{
    public override string GetName()
    {
        return "Punch1";
    }
}

public class Punch2Command : InputCommand
{
    public override string GetName()
    {
        return "Punch2";
    }
}

public class Kick1Command : InputCommand
{
    public override string GetName()
    {
        return "Kick1";
    }
}

public class Kick2Command : InputCommand
{
    public override string GetName()
    {
        return "Kick2";
    }
}

public class DirectionalInputCommand : InputCommand
{
    protected float magnitude;

    public DirectionalInputCommand(float m = 0)
    {
        magnitude = m;
        timestamp = Time.time;
    }

    public float GetMagnitude()
    {
        return magnitude;
    }
}

public class UpCommand: DirectionalInputCommand
{
    public UpCommand(float m)
    {
         magnitude = m;
         timestamp = Time.time;
    }

    public override string GetName()
    {
        return "Up";
    }
}

public class DownCommand : DirectionalInputCommand
{
    public DownCommand(float m)
    {
        magnitude = m;
        timestamp = Time.time;
    }

    public override string GetName()
    {
        return "Down";
    }
}

public class LeftCommand : DirectionalInputCommand
{
    public LeftCommand(float m)
    {
        magnitude = m;
        timestamp = Time.time;
    }

    public override string GetName()
    {
        return "Left";
    }
}

public class RightCommand : DirectionalInputCommand
{
    public RightCommand(float m)
    {
        magnitude = m;
        timestamp = Time.time;
    }

    public override string GetName()
    {
        return "Right";
    }
}