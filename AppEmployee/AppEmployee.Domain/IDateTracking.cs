using System;

namespace AppEmployee.Domain
{
    public interface IDateTracking
    {
        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
