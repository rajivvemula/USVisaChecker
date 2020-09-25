using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ApolloQA.DataFiles
{
    public class IOrganization : IEquatable<IOrganization>
    {
        public string Name { get; set; }
        public string DBA { get; set; }
        public string OrgType { get; set; }
        public string TaxType { get; set; }
        public string TaxIdNo { get; set; }
        public string BusPhone { get; set; }
        public string BusEmail { get; set; }
        public string BusWeb { get; set; }
        public string YearStart { get; set; }
        public string YearOwn { get; set; }
        public string Keyword { get; set; }


        public bool Equals([AllowNull] IOrganization other)
        {
            throw new NotImplementedException();
        }

        
    }
}

