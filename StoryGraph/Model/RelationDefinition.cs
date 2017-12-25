namespace KVP.StoryGraph.Model
{
    public enum RelationDefinition
    {
        Creator = 1,
        CreatedBy = ~Creator,

        Owner = 2,
        OwnedBy = ~Owner,

        Association = 3,

        Affection = 4,
        Hate = 5,
    }
}