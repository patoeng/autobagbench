using System;

namespace AutoBagBench
{
    public class AutoBagException : Exception
    {
        
    public AutoBagException(string message)
        : base(message)
    {
    }

    public AutoBagException(string message, Exception inner)
        : base(message, inner)
    {
    }
    }
}
