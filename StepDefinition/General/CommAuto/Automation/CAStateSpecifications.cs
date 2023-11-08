using BiBerkLOB.Source.Driver;
using System.Collections.Generic;
using static BiBerkLOB.Source.Driver.State; //this let's us skip having to put "State.XXXX" for state names

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

/*
 * This class holds methods that list out states for specific purposes
 * ex: method that returns a list of states that qualify for uninsured/underinsured motorist coverage
 */
public static class CAStateSpecifications
{
    public static State[] StatesWithBothUIMAndUM()
    {
        return new[] {
            Alabama,
            Arizona,
            Illinois,
            Indiana,
            Maryland,
            Minnesota,
            Missouri,
            NewJersey,
            NorthCarolina,
            Ohio,
            SouthCarolina,
            Texas,
            Virginia,
            Wisconsin
        };
    }

    public static State[] StatesWithUMBI()
    {
        return new[]
        {
            Pennsylvania,
            Indiana,
            Missouri,
            Wisconsin,
            Florida,
            Colorado,
            California,
            Arizona,
            Illinois
        };
    }

    public static State[] StatesWithUIMBI()
    {
        return new[]
        {
            Pennsylvania,
            Indiana,
            Missouri,
            Wisconsin,
            Ohio,
            Arizona,
            Illinois
        };
    }

    public static State[] StatesWithUMBIPD()
    {
        return new[]
        {
            Colorado,
            Ohio,
            Tennessee,
            Florida
        };
    }

    public static State[] StatesWithVehicleUMAndUIM()
    {
        return new[]
        {
            SouthCarolina
        };
    }

    public static State[] StatesWithUMOrUIMBIPD()
    {
        return new[]
        {
            Maryland,
            NewJersey,
            Texas
        };
    }

    public static State[] StatesWithUMOrUIMBI()
    {
        return new[]
        {
            Minnesota,
            Nevada
        };
    }
}