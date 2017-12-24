using System;

namespace KVP.StoryGraph.Model
{
    public interface IModel : IIdentity
    {
        DateTime Creation { get; set; }
    }
}