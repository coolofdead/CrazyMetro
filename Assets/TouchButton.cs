using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Touch touch;

    public void Touch()
    {
        TouchpadManager.Instance.RegisterTouch(touch);
    }
}
