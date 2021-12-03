using System;

namespace Warehouse.Services.Exceptions
{
    public class NullFileException : Exception
    {
        public NullFileException()
            : base("Null file.")
        {
        }
    }
}
