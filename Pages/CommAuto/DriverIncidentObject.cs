using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    public class DriverIncidentObject
    {
        public DriverIncidentObject() { }

        public int PanelIndex { get; set; }
        public string DriverInvolvedInIncident { get; set; } = "";
        public string DateOfIncident { get; set; } = "";
        public string IncidentType { get; set; } = "";
        public string AccidentAtFault { get; set; } = "";
        
        public List<CAViolation> VCList = new List<CAViolation>();

    }
}
