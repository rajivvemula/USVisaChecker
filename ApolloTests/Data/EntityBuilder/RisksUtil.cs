using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.SectionBuilders;
using System.Diagnostics.Metrics;

namespace ApolloTests.Data.EntityBuilder
{
    public static class RisksUtil
    {
        public static void SetNumberOfRisks(this IRiskBuilder builder, uint value)
        {
            var counter = 0;   
            if (builder.NumberOfRisks > value)
            {
                while (builder.NumberOfRisks != value)
                {
                    builder.RemoveAt((int)builder.NumberOfRisks - 1);
                    if(counter++>200) { throw new StackOverflowException(); }
                }
            }
            else
            {

                while (builder.NumberOfRisks != value)
                {
                    builder.AddOne();
                    if (counter++> 200) { throw new StackOverflowException(); }

                }
            }
        }
    }
}
