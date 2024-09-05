using System.Collections;
using System.Collections.Generic;

public interface ICodeReadable
{
    public bool CanReadCode(List<Touch> touches);
    public void ReceiveCode(List<Touch> touches);
}
