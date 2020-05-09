using System.Collections.Generic;
using UnityEngine;

public class InputStream : MonoBehaviour
{
    private List<InputCommand> inputs = new List<InputCommand>();

    public void Add(InputCommand ic)
    {
        inputs.Add(ic);
    }

    public InputCommand Remove()
    {
        if(inputs.Count > 0)
        {
            InputCommand ic = inputs[0];
            inputs.RemoveAt(0);
            return ic;
        }

        return new InputCommand();
    }

    public void Clear()
    {
        inputs.Clear();
    }
}
