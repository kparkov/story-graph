using Bitkompagniet.StoryGraph.Model;

namespace Bitkompagniet.StoryGraph.Store
{
	public interface IStore
    {
        void Add(IEntity entity);
        IEntity GetEntity(object id);
        IIdEnumerable<IEntity> AllEntities();
        IIdEnumerable<IRelation> GetOutgoingRelationsOf(object id);
    }
}
