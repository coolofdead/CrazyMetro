using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Codex : MonoBehaviour, ICodeReadable
{
    public static Codex Instance;

    public Code openCodexCode;

    public IEnumerable<ICodeReadable> AllCodes;
    public List<Code> UnlockedCodes;

    private void Awake()
    {
        Instance = this;

        AllCodes = FindObjectsOfType<MonoBehaviour>().OfType<ICodeReadable>();
    }

    public void UnlockCode(Code code)
    {
        if (UnlockedCodes.Any(unlockedCode => unlockedCode.Equals(code))) return;

        UnlockedCodes.Add(code);
    }

    public string GetDescForCode(Code code)
    {
        return "Open Codex"; // AllCodes.First(allCode => allCode.firstInput == code.firstInput && allCode.secondInput == code.secondInput).description;
    }

    public bool CanReadCode(Code code)
    {
        return code.Equals(openCodexCode);
    }

    public void ReceiveCode(Code code)
    {
        // TODO : Show Codex OR Close Codex
    }

    public IEnumerable<Code> GetAllCodes()
    {
        return new List<Code>() { openCodexCode };
    }
}

[System.Serializable]
public struct CodeDesc
{
    public Code touches;
    public string description;
}
