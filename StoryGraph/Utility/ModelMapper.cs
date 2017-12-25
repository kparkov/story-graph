using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KVP.StoryGraph.Utility
{
    public interface IModelMapper<TSource, TDestination> : IModelMapper
    {
        void Map(TSource source, TDestination destination);
        TDestination Map(TSource source);
    }

    public interface IModelMapper
    {
        void Map(object source, object destination);
        object Map(object source, Type destinationType);
    }

    public class ModelMapper : IModelMapper
    {
        public void Map(object source, object destination)
        {
            Automap(source, destination);
            AfterAutomapping(source, destination);
        }

        public object Map(object source, Type destinationType)
        {
            var destination = Activator.CreateInstance(destinationType);
            Map(source, destination);
            return destination;
        }

        protected void Automap(object source, object destination)
        {
            foreach (var property in GetOverlappingProperties(source.GetType(), destination.GetType()))
            {
                property.Destination.SetValue(destination, property.Source.GetValue(source));
            }
        }

        protected virtual void AfterAutomapping(object source, object destination)
        {
        }

        private IEnumerable<PropertyMap> GetOverlappingProperties(Type source, Type destination)
        {
            var sourceProperties = source
                .GetRuntimeProperties()
                .Where(p => p.GetMethod != null && p.SetMethod != null)
                .ToList();

            var result = new List<PropertyMap>();

            foreach (var property in sourceProperties)
            {
                var destinationProperty = destination
                    .GetRuntimeProperties()
                    .SingleOrDefault(p =>
                        property.Name == p.Name &&
                        property.PropertyType == p.PropertyType &&
                        p.GetMethod != null && p.SetMethod != null
                    );

                if (destinationProperty != null) result.Add(new PropertyMap
                {
                    Source = property,
                    Destination = destinationProperty,
                });
            }

            return result;
        }
    }

    public class ModelMapper<TSource, TDestination> : ModelMapper, IModelMapper<TSource, TDestination>
        where TDestination : new()
    {
        public virtual void Map(TSource source, TDestination destination)
        {
            Automap(source, destination);
        }

        public TDestination Map(TSource source)
        {
            var destination = new TDestination();
            Map(source, destination);
            return destination;
        }

        protected sealed override void AfterAutomapping(object source, object destination)
        {
            AfterAutomapping((TSource) source, (TDestination) destination);
        }

        protected virtual void AfterAutoMapping(TSource source, TDestination destination)
        {
        }
    }

    internal class PropertyMap
    {
        public PropertyInfo Source { get; set; }
        public PropertyInfo Destination { get; set; }
    }
}