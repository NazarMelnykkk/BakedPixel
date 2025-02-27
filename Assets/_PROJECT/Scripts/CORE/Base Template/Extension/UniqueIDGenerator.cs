using System;

public class UniqueIDGenerator
{
    public static string GenerateID()
    {
        return Guid.NewGuid().ToString();
    }
}
