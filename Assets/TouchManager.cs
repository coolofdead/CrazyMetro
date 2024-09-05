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
        codeReadables = FindObjectsOfType<MonoBehaviour>().OfType<ICodeReadable>();
    }

    public void SendCode(List<Touch> touches)
    {
        foreach (var codeReadable in codeReadables)
        {
            if (codeReadable.CanReadCode(touches))
            {
                codeReadable.ReceiveCode(touches);
            }
        }
    }
}

