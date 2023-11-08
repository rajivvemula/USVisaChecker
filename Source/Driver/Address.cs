namespace BiBerkLOB.Source.Driver;

public class Address
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public State State { get; set; }
    public string ZipCode { get; set; }

    public override string ToString()
    {
        return (State, Line2) switch
        {
            //no state, no line 2
            (null, "None" or "" or null) => $"{Line1}, {City}",
            //no state, has line 2
            (null, _) => $"{Line1} {Line2}, {City}",
            //has state, no line 2
            (_, "None" or "" or null) => $"{Line1}, {City}, {State.Abbreviation} {ZipCode}",
            //has state, has line 2 
            (_, _) => $"{Line1} {Line2}, {City}, {State.Abbreviation} {ZipCode}",
        };
    }

    // override object.Equals    
    protected bool Equals(Address other)
    {
        return this.ToString() == other.ToString();
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Address)obj);
    }

    public override int GetHashCode()
    {
        var addressStr = ToString();
        return (addressStr != null ? addressStr.GetHashCode() : 0);
    }
}