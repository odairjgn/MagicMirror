namespace MagicMirror.Abstractions
{
    public class ObjectWrapper
    {
        private readonly object _object;
        private readonly Type _type;

        public ObjectWrapper(object @object)
        {
            _object = @object;
            _type = @object.GetType();
        }

        public PropertyCollection Properties => new PropertyCollection(_object, _type);

        public object Object => _object;

        public override string ToString()
        {
            return $"Object: {_type.Name}";
        }
    }
}
