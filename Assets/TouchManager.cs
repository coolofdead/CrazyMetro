using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;

    public IEnumerable<ICodeReadable> codeReadables;

    private void Awake()
    {
        Instance = this;

        codeReadables = FindObjectsOfType<MonoBehaviour>().OfType<ICodeReadable>();
    }

    public void SendCode(Code code)
    {
        var codeHasBeenRead = false;

        foreach (var codeReadable in codeReadables)
        {
            if (codeReadable.CanReadCode(code))
            {
                codeReadable.ReceiveCode(code);
                codeHasBeenRead = true;
            }
        }

        if (!codeHasBeenRead)
        {
            ConsoleManager.Instance.PrintLog("Error on code");
        }
    }
}

[System.Serializable]
public struct Code
{
    public Touch firstInput;
    public Touch secondInput;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        return firstInput == ((Code)obj).firstInput && secondInput == ((Code)obj).secondInput;
    }
}

