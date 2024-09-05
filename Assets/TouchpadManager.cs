using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchpadManager : MonoBehaviour
{
    public static TouchpadManager Instance;

    public List<Touch> touches = new(2);

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
        touches.Add(touch);

        if (touches.Count == 2)
        {
            Codex.Instance.UnlockCode(touches);
            TouchManager.Instance.SendCode(touches);
        }
    }

    public void RemoveLastTouch()
    {
        if (touches.Count == 0) return;

        touches.RemoveAt(touches.Count - 1);
    }
}

public enum Touch
{
    Green,
    Red,
    Yellow,
    Blue,
}