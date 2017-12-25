using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KVP.StoryGraph.Api.ViewModel
{
    public class ViewModel
    {
        [JsonProperty(Order = -99)]
        public string Id { get; set; }
    }

    public class EntitySummary : ViewModel
    {
        [JsonProperty(Order = -100)]
        public string Type { get; set; }

        [JsonProperty(Order = -10)]
        public bool Anonymous { get; set; }

        [JsonProperty(Order = -9)]
        public string Name { get; set; }
    }

    public class Entity : ViewModel
    {
        [JsonProperty(Order = -100)]
        public string Type => GetType().Name;

        [JsonProperty(Order = -10)]
        public bool Anonymous { get; set; }

        [JsonProperty(Order = -9)]
        public string Name { get; set; }

        [JsonProperty(Order = -8)]
        public string Description { get; set; }

        [JsonProperty(Order = -7)]
        public DateTime Creation { get; set; }

        [JsonProperty(Order = -6)]
        public DateTime? Destruction { get; set; }

        public string DestructionCause { get; set; }

        public IEnumerable<Relation> Relations { get; set; }
    }

    public class Relation : ViewModel
    {
        public string RelationRole { get; set; }
        public EntitySummary Entity { get; set; }
    }
}
