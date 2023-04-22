using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Enums
{
    public enum TetherStatusType
    {
        PRESUBMISSION = 0,
        REFERRED = 1000,
        DECLINED = 3000,
        NONRENEWON = 3010,
        QUOTED = 4000,
        RENEWED = 4010,
        ISSUED = 5000,
        BOUND = 6000,
        RESCINDED = 7000,
        CANCELLED = 8000,
        EXPIRED = 9000,
        ARCHIVED = 12000
    }
}
