using UnityEngine;

public class ControllerInputHandler : iInputHandler
{
    [SerializeField]
    private float xDeadzone = .4f;
    [SerializeField]
    private float yDeadzone = .4f;

    DirectionalInputFactory directionalInputFactory = new DirectionalInputFactory();

    public void HandleInput(InputStream stream)
    {
        if(Input.GetButton("A"))
        {
            stream.Add(new Punch1Command());
        }

        if (Input.GetButton("B"))
        {
            stream.Add(new Punch2Command());
        }

        if (Input.GetButton("X"))
        {
            stream.Add(new Kick1Command());
        }

        if (Input.GetButton("Y"))
        {
            stream.Add(new Kick2Command());
        }

        float x = Input.GetAxis("Joy1X");
        float y = Input.GetAxis("Joy1Y");

        if (Mathf.Abs(x) > xDeadzone || Mathf.Abs(y) > yDeadzone)
        {
            stream.Add(directionalInputFactory.MakeCommand(x, y));
        }
    }
}
