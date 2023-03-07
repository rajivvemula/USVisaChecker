using ApolloTests.Data.Entities;
using HitachiQA.Helpers;
using Polly;
using System;
using System.Diagnostics;
using System.Linq;

namespace ApolloTests.Data.Entity
{
    public class SubLine:BaseEntity
    {
        public SubLine(int Id)
        {
            this.Id = Id;
            Load();
            this.Name.NullGuard();
            this.Code.NullGuard();

        }

        public SubLine(long Id)
        {
            this.Id = Id;
            Load();
            this.Name.NullGuard();
            this.Code.NullGuard();

        }

        public void Load()
        {
            var props = SQL.executeQuery($"SELECT * FROM [reference].[SubLine] WHERE Id = {Id}")[0];

            foreach (var prop in props)
            {
                try
                {
                    if (prop.Key == "Id")
                    {
                        continue;
                    }
                    this.GetType().GetProperty(prop.Key)?.SetValue(this, prop.Value is DBNull ? null : prop.Value);
                }
                catch (Exception)
                {
                    Log.Critical("Property Key: " + prop.Key + " Property Value: " + prop.Value ?? "null");
                    throw;
                }
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            SQL.executeQuery($"UPDATE [reference].[SubLine] SET {propertyName}=@value WHERE Id = {this.Id} ", ("@value", value));
        }


        public readonly long Id;

        private Line? _ParentLine = null;
        public Line ParentLine=> _ParentLine??=new Line(this.ParentLineId);

        public int ParentLineId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? IsDefault { get; set; }

        public DateTimeOffset TimeFrom { get; set; }

        public DateTimeOffset TimeTo { get; set; }

        public long InsertedByPersonId { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public string? InsertedBy { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public string? UpdatedBy { get; set; }

        public int? SourceSystemId { get; set; }

        public string? SourceSystemKey { get; set; }

        public int StatusId { get; set; }

    }


}
