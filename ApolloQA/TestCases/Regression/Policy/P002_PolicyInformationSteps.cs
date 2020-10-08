using System;
using TechTalk.SpecFlow;
using ApolloQA.DataFiles;

namespace ApolloQA.TestCases.Regression.Policy
{
    [Binding]
    public class P002_PolicyInformationSteps
    { 

        State state;
        public P002_PolicyInformationSteps(State state)
        {

            this.state = state;

            //this.policy = new Entity.Policy(int.Parse(state.PolicyId));

        }
        [When(@"user Selects an Organization with the following relevant values")]
        public void WhenUserSelectsAnOrganizationWithTheFollowingRelevantValues(Table table)
        {

            foreach (TableRow row in table.Rows)
            {
                foreach (var field in row)
                {
                    state.engine.setKnownFieldValue(field.Key, field.Value);
                }
            }
            
        }
        
        [When(@"user Selects Vehicle Type risks with the following relevant values")]
        public void WhenUserSelectsVehicleTypeRisksWithTheFollowingRelevantValues(Table table)
        {
            var vehicles = state.engine.root.GetVehicles();
            if (table.RowCount > vehicles.Count)
            {
                throw new NotImplementedException("Needs funciton to add vehicle to Policy/App");
            }
            if (table.RowCount < vehicles.Count)
            {
                throw new NotImplementedException("Needs funciton to Remove vehicles to Policy/App");
            }
            else
            {
                int index = 0;
                foreach (TableRow row in table.Rows)
                {
                    state.engine.interpreter.SetVariable("Vehicle", vehicles[index]);

                    foreach (var field in row)
                    {                       
                        state.engine.setKnownFieldValue(field.Key, field.Value);
                    }
                }
            }
        }
    }
}
