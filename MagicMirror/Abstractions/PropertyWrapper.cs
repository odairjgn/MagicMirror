using System.Reflection;

namespace MagicMirror.Abstractions
{
    public class PropertyWrapper
    {
        private readonly object _object;
        private readonly PropertyInfo _property;

        public PropertyWrapper(string name, Type type, object @object)
        {
            _object = @object;
            var property = type.GetProperty(name);
            ArgumentNullException.ThrowIfNull(property);
            _property = property;
        }

        public void Set(object value) => _property.SetValue(_object, value);

        public object? Get() => _property.GetValue(_object);

        public T? GetAndCast<T>() => (T?)Get();

        public ObjectWrapper? GetAndWrap()
        {
            var value = Get();
            return value == null ? null : new ObjectWrapper(value);
        }

        public bool CanSet => _property.CanWrite;

        public string Name => _property.Name;

        public override string ToString()
        {
            return $"{_property.DeclaringType?.Name}.{_property.Name}";
        }
    }
}
