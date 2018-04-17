using Bitkompagniet.StoryGraph.Model;
using Bitkompagniet.StoryGraph.Store.Common;

namespace Bitkompagniet.StoryGraph.Store
{
	public interface IStore
    {
        IEntity CreateEntity(ICreateEntity entity);
        IEntity GetEntity(object id);
        bool EntityExists(object id);
        IRelation CreateRelation(ICreateRelation relation);
        IIdEnumerable<IEntity> AllEntities();
        IIdEnumerable<IRelation> GetOutgoingRelationsOf(object id);
        IRelation GetRelation(object id);
    }
}
