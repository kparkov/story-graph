using System;

namespace KVP.StoryGraph.Model
{
    public static class RelationExtensions
    {
        public static bool Asymmetrical(this RelationDefinition definition)
        {
            return Enum.IsDefined(typeof(RelationDefinition), ~(int) definition);
        }

        public static RelationDefinition GetOppositeRelation(this RelationDefinition definition)
        {
            return definition.Asymmetrical() ? ~definition : definition;
        }
    }

    public static class IdentityExtensions
    {
        public static bool IdentityIs(this IIdentity identity, object id)
        {
            return identity.Id.Equals(id);
        }
    }
}