using System.Collections.Generic;

public interface ICodeReadable
{
    public bool CanReadCode(Code code);
    public void ReceiveCode(Code code);
    public string GetDescForCode(Code code);
    public IEnumerable<Code> GetAllCodes();
}
