using System;

namespace HitachiQA;

public class ClearableAttribute : Attribute { }

public class DoNotResetAttribute : Attribute { }

public class ResettableContextObjectAttribute : Attribute { }

public class TestCreditCardAttribute : Attribute
{
    public string Number { get; }

    public TestCreditCardAttribute(string number)
    {
        Number = number;
    }
}