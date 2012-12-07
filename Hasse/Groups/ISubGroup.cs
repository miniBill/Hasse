using System;

namespace Hasse.Groups {
    public interface ISubGroup<TSub> : IEquatable<TSub> {
        bool Contains(uint element);

        TSub Generate(uint element);
    }
}
