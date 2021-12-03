using System;

namespace Warehouse.Services.Exceptions
{
    public class MaximumFileSizeExceededException : Exception
    {
        public MaximumFileSizeExceededException()
            : base("Maximum file size exceeded.")
        {
        }
    }
}
