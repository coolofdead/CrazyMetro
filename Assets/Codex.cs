using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Codex : MonoBehaviour
{
    public static Codex Instance;

    public List<Code> AllCodes;
    public List<List<Touch>> UnlockedCodes;

    public void UnlockCode(List<Touch> touches)
    {
        if (UnlockedCodes.Any(allCode => allCode[0] == touches[0] && allCode[1] == touches[1])) return;

        UnlockedCodes.Add(touches);
    }

    public string GetDescForCode(List<Touch> touches)
    {
        return AllCodes.First(allCode => allCode.touches[0] == touches[0] && allCode.touches[1] == touches[1]).description;
    }
}

[System.Serializable]
public struct Code
{
    public List<Touch> touches;
    public string description;
}
