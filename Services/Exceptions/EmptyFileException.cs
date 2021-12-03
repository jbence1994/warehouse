using System;

namespace Warehouse.Services.Exceptions
{
    public class EmptyFileException : Exception
    {
        public EmptyFileException()
            : base("Empty file.")
        {
        }
    }
}
