using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchpadManager : MonoBehaviour
{
    public static TouchpadManager Instance;

    public Code code;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            RemoveLastTouch();
        }
    }

    public void RegisterTouch(Touch touch)
    {
        if (code.firstInput == Touch.None)
        {
            code.firstInput = touch;
        }
        else
        {
            code.secondInput = touch;

            Codex.Instance.UnlockCode(code);
            TouchManager.Instance.SendCode(code);

            code = new();
        }
    }

    public void RemoveLastTouch()
    {
        if (code.firstInput == Touch.None)
        {
            code.firstInput = Touch.None;
        }
        else
        {
            code.secondInput = Touch.None;
        }
    }
}

public enum Touch
{
    None,
    Green,
    Red,
    Yellow,
    Blue,
}