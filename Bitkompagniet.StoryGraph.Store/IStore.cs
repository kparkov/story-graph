using Bitkompagniet.StoryGraph.Model;

namespace Bitkompagniet.StoryGraph.Store
{
	public interface IStore
    {
        object Add(IEntity entity);
        IEntity GetEntity(object id);
        bool EntityExists(object id);
        object AddRelation(IRelation relation);
        IIdEnumerable<IEntity> AllEntities();
        IIdEnumerable<IRelation> GetOutgoingRelationsOf(object id);
    }
}
