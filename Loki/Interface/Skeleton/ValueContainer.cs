using System.Collections.Generic;

namespace Loki.Interface.Skeleton {
    class ValueContainer<T> {
        internal ValueContainer(T def = default) => Value = def;
        internal T Value { get; set; }
    }
}