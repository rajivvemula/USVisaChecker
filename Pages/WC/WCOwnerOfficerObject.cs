using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WCOwnerOfficerObject
    {
        public string OfficerFullName { get; set; } = "";
        public string OfficerRole { get; set; } = "";
        public string OfficerSSN { get; set; } = "";
        public string OfficerPayroll { get; set; } = "";
        public bool DoesOfficerReceieveW2Payroll { get; set; } = false;
        //included or excluded are the potential values
        //used to populate the XPath on the Additional Info page
        public string OfficerInOrEx { get; set; } = "";
    }
}