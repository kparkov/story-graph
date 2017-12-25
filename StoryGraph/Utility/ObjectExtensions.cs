namespace KVP.StoryGraph.Utility
{
    public static class ObjectExtensions
    {
        public static TDestination MapTo<TDestination>(this object source)
            where TDestination : new ()
        {
            var map = new ModelMapper();
            return (TDestination) map.Map(source, typeof(TDestination));
        }

        public static TDestination MapTo<TDestination>(this object source, IModelMapper mapper)
            where TDestination : new()
        {
            return (TDestination) mapper.Map(source, typeof(TDestination));
        }

        public static void MapTo<TDestination>(this object source, TDestination destination)
            where TDestination : new()
        {
            var map = new ModelMapper();
            map.Map(source, destination);
        }
    }
}