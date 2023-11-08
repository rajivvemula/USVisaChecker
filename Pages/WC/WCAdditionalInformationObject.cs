using System.Collections.Generic;
using HitachiQA;

namespace BiBerkLOB.Pages.WC
{
    [ResettableContextObject]
    public sealed class WCAdditionalInformationObject
    {
        public int IncludedOfficers { get; set; }
        public int ExcludedOfficers { get; set; }
        public int NoOfOOForBusiness { get; set; }

        //Covered Owner Officers
        [Clearable] public List<WCOwnerOfficerObject> CoveredOOList { get; set; } = new List<WCOwnerOfficerObject>();
        //Excluded Owner Officers
        [Clearable] public List<WCOwnerOfficerObject> ExcludedOOList { get; set;} = new List<WCOwnerOfficerObject>();
        //Owner Officer question and answers
        [Clearable] public List<OwnerOfficerQuestionObject> OwnerOfficerQuestions { get; set; } = new();
    }
}