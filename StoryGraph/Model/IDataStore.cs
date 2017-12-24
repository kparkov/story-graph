namespace KVP.StoryGraph.Model
{
    public interface IDataStore
    {
        /// <summary>
        /// Fetch an entity, and include all relations and related entities, but do not continue to
        /// second tier.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>An entity</returns>
        Entity GetEntityAndRelations(object id);

        /// <summary>
        /// Fetch a relation, and include the entity on both ends, but do not populate the
        /// relationships of either.
        /// </summary>
        /// <returns>A relation</returns>
        Relation GetRelationWithParticipations(object id);
    }
}