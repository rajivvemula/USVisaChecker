using System;

namespace BiBerkLOB.Source.Driver;

public class AlwaysFailException : Exception
{
    public AlwaysFailException()
    {
    }

    public AlwaysFailException(string message) : base(message)
    {
    }

    public AlwaysFailException(string message, Exception innerException) : base(message, innerException)
    {
    }
}