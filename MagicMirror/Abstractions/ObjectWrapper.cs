using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
