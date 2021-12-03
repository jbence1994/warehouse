using System;

namespace Warehouse.Services.Exceptions
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException()
            : base("Invalid file type.")

        {
        }
    }
}
