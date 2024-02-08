using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class SettingsSaver : MonoBehaviour, ISavableComponent
    {
        [SerializeField] private int _uniqueID;
        [SerializeField] private int _executionOrder;
        public int uniqueID
        {
            get
            {
                return _uniqueID;
            }
        }
        public int executionOrder
        {
            get
            {
                return _executionOrder;
            }
        }

        public ComponentData Serialize()
        {
            Debug.Log("11");
            ExtendedComponentData data = new ExtendedComponentData();
            data.SetFloat("volumValue", SoundSettings.Instance.volumeValue);
            return data;
        }
        public void Deserialize(ComponentData data)
        {
            ExtendedComponentData unpacked = (ExtendedComponentData)data;
            SoundSettings.Instance.volumeValue = unpacked.GetFloat("volumValue");
        }
    }
}