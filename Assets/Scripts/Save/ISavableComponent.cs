using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public interface ISavableComponent
    {
        public int uniqueID { get; }
        public int executionOrder { get; }

        public ComponentData Serialize();
        public void Deserialize(ComponentData componentData);
    }
}
