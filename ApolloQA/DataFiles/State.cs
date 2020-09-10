﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.DataFiles
{
    public class State
    {
        
        public string smokeOrganization = "10085";
        public bool smokeOrgCreated = false;
        public string createdOrgName = "Smoke Test"; 
        public string createdOrgAddress = "";
        public string taxName = "12-3489123";
        public string createdAppID = "";
        public string createdClaimID = "";
        public bool queryFound = false;
        public bool claimFound = false;
        //public List<string> policyList = new List<string>() { "One", "Two" };

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
