using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.Source.Driver;
using static BiBerkLOB.Source.Driver.State;

namespace BiBerkLOB.StepDefinition.General.PL.Automation
{
    public static class PLStateSpecifications
    {
        public static State[] StatesWithoutBusinessAddress()
        {
            return new[]
            {
                NewYork,
                Washington,
                Alaska,
                Vermont,
                Massachusetts
            };
        }
    }
}
