using System.Collections.Generic;
using HitachiQA.Driver;

namespace BiBerkLOB.Pages.PL
{
    public sealed class SummaryCardObj
    {
        public SummaryCardObj() 
        { 
            
        }
        public string Title { get; set; }
        public Element TitleElement {get; set;}
        public Element EditIcon { get; set; }
        public List<SummaryStatementObj> SummaryStatements { get; set; }
    }
}
