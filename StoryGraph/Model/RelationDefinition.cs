namespace KVP.StoryGraph.Model
{
    public enum RelationDefinition
    {
        Parent = 1,
        Child = ~Parent,
        Enemy = 2,
        Uncle = 3,
        Nephew = ~Uncle,
        Sibling = 4,

    }
}