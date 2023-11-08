using System.Linq;
using System.Reflection;

namespace BiBerkLOB.Source.Driver;

public class State
{
    public string Abbreviation { get; init; }
    public string Name { get; init; }

    private State(string abbreviation, string name)
    {
        Abbreviation = abbreviation;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public static State FromName(string name)
    {
        var states = typeof(State)
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Select(prop => prop.GetValue(null) as State);

        return states.First(s => s.Name == name);
    }

    public static State FromAbbreviation(string abbreviation)
    {
        var states = typeof(State)
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Select(prop => prop.GetValue(null) as State);
        
        return states.First(s => s.Abbreviation == abbreviation);
    }

    public static State FromAny(string state)
    {
        if (state.Length == 2)
        {
            return FromAbbreviation(state);
        }

        return FromName(state);
    }

    protected bool Equals(State other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((State)obj);
    }

    public override int GetHashCode()
    {
        return (Name != null ? Name.GetHashCode() : 0);
    }

    public static bool operator ==(State left, State right)
    {
        if (left is null)
        {
            return right is null;
        }

        return right is not null && left.Equals(right);
    }

    public static bool operator !=(State left, State right)
    {
        return !(left == right);
    }

    public static State Alabama => new State("AL", "Alabama");
    public static State Alaska => new State("AK", "Alaska");
    public static State Arizona => new State("AZ", "Arizona");
    public static State Arkansas => new State("AR", "Arkansas");
    public static State California => new State("CA", "California");
    public static State Colorado => new State("CO", "Colorado");
    public static State Connecticut => new State("CT", "Connecticut");
    public static State Delaware => new State("DE", "Delaware");
    public static State DistrictOfColumbia => new State("DC", "District of Columbia");
    public static State Florida => new State("FL", "Florida");
    public static State Georgia => new State("GA", "Georgia");
    public static State Hawaii => new State("HI", "Hawaii");
    public static State Idaho => new State("ID", "Idaho");
    public static State Illinois => new State("IL", "Illinois");
    public static State Indiana => new State("IN", "Indiana");
    public static State Iowa => new State("IA", "Iowa");
    public static State Kansas => new State("KS", "Kansas");
    public static State Kentucky => new State("KY", "Kentucky");
    public static State Louisiana => new State("LA", "Louisiana");
    public static State Maine => new State("ME", "Maine");
    public static State Maryland => new State("MD", "Maryland");
    public static State Massachusetts => new State("MA", "Massachusetts");
    public static State Michigan => new State("MI", "Michigan");
    public static State Minnesota => new State("MN", "Minnesota");
    public static State Mississippi => new State("MS", "Mississippi");
    public static State Missouri => new State("MO", "Missouri");
    public static State Montana => new State("MT", "Montana");
    public static State Nebraska => new State("NE", "Nebraska");
    public static State Nevada => new State("NV", "Nevada");
    public static State NewHampshire => new State("NH", "New Hampshire");
    public static State NewJersey => new State("NJ", "New Jersey");
    public static State NewMexico => new State("NM", "New Mexico");
    public static State NewYork => new State("NY", "New York");
    public static State NorthCarolina => new State("NC", "North Carolina");
    public static State NorthDakota => new State("ND", "North Dakota");
    public static State Ohio => new State("OH", "Ohio");
    public static State Oklahoma => new State("OK", "Oklahoma");
    public static State Oregon => new State("OR", "Oregon");
    public static State Pennsylvania => new State("PA", "Pennsylvania");
    public static State RhodeIsland => new State("RI", "Rhode Island");
    public static State SouthCarolina => new State("SC", "South Carolina");
    public static State SouthDakota => new State("SD", "South Dakota");
    public static State Tennessee => new State("TN", "Tennessee");
    public static State Texas => new State("TX", "Texas");
    public static State Utah => new State("UT", "Utah");
    public static State Vermont => new State("VT", "Vermont");
    public static State Virginia => new State("VA", "Virginia");
    public static State Washington => new State("WA", "Washington");
    public static State WestVirginia => new State("WV", "West Virginia");
    public static State Wisconsin => new State("WI", "Wisconsin");
    public static State Wyoming => new State("WY", "Wyoming");
    public static State ForeignCountry => new State("FC", "Foreign Country");
}