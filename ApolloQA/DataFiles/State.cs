using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.DataFiles
{
    public class State
    {
        public string FirstName;
        public string LastName;
        public List<string> policyList = new List<string>() { "One", "Two" };

        /*
        How to add state:

        Use state variable in ctor for Step Definations


        private State state
        public R001_UserLoginAsAdminSteps(State _state)
        {
            state = _state

        }
        */
    }
}
