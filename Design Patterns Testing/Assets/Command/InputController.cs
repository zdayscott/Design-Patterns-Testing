using UnityEngine;

[RequireComponent(typeof(iInputHandler), typeof(InputProcessor))]
public class InputController : MonoBehaviour
{
    private iInputHandler inputHandler;
    private InputStream inputStream = new InputStream();
    private InputProcessor inputProcessor;

    private void Start()
    {
        inputHandler = GetComponent<iInputHandler>();
        inputProcessor = GetComponent<InputProcessor>();
    }

    public InputCommand HandleInput(GameObject go)
    {
        inputHandler.HandleInput(inputStream);

        InputCommand command = inputStream.Remove();

        inputStream.Clear();
        return command;
    }
}
