namespace MagicMirror.Abstractions
{
    public class PropertyCollection
    {
        private readonly object _object;
        private readonly Type _type;

        public PropertyCollection(object @object, Type type)
        {
            _object = @object;
            _type = type;
        }

        public PropertyWrapper this[string name] => new PropertyWrapper(name, _type, _object);
    }
}
