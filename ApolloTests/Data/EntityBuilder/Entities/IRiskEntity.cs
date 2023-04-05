﻿using ApolloTests.Data.EntityBuilder.Models.Risks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public interface IRiskEntity
    {

        [JsonIgnore]
        public RiskType RiskType { get; }

        [JsonIgnore]
        protected Risk? Risk { get; set; }

        public Risk GetRisk() => Risk ?? throw new NullReferenceException("Risk was null");

        public void SetRisk(Risk value) => this.Risk = value;


        public JObject ToJObject()
        {
            return JObject.FromObject(this);
        }

        public string? ToString()
        {
            if (this == null)
                return null;
            return JObject.FromObject(this).ToString();
        }

    }

}