using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BiBerkLOB.Source.Driver;

namespace BiBerkLOB.Pages.CommAuto
{
    public class DriversObject
    {
        public DriversObject() { }

        public int PanelIndex { get; set; }

        public string DriverHeader { get; set; } = "";
        public string DriverFirstName { get; set; } = "";
        public string DriverLastName { get; set; } = "";
        [DefaultValue(null)] public State DriversLicenseState { get; set; } = null;
        public string DriverCDL {get; set; } = "";
        public string DriverDefDrivingCourse {get; set; } = "";
        public string DriverILViolations {get; set; } = "";
        public string DriverILDLRevoked {get; set; } = "";
        public string DateOfBirth { get; set; } = "";
        public string AccidentOrVIolation { get; set; } = "";
        public string DriverLicenseNumber { get; set; } = "";

        public string DriverFullName => $"{DriverFirstName} {DriverLastName}";
    }
}
