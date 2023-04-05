using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.SectionBuilders;


namespace ApolloTests.Data.EntityBuilder
{
    public static class RisksUtil
    {
        public static void SetNumberOfRisks(this IRiskBuilder builder, uint value)
        {
            var Self = (List<object>)builder;
            if (Self.Count > value)
            {
                while (Self.Count != value)
                {
                    Self.RemoveAt(Self.Count - 1);
                }
            }
            else
            {

                while (Self.Count != value)
                {
                    builder.AddOne();
                }
            }
        }
    }
}
