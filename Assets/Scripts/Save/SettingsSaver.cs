using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class SettingsSaver : MonoBehaviour, ISavableComponent
    {
        [SerializeField] private int _uniqueID;
        [SerializeField] private int _executionOrder;
        [SerializeField] private readonly string _volumValueUniqueName = "volumValue";
        [SerializeField] private readonly string _isFullscreenUniqueName = "isFullscreenValue";
        [SerializeField] private readonly string _resolutinValueName = "resolution";
        [SerializeField] private readonly string _qualityValueName = "quality";
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
            ExtendedComponentData data = new ExtendedComponentData();
            data.SetFloat(_volumValueUniqueName, SoundSettings.Instance.volumeValue);
            data.SetBool(_isFullscreenUniqueName, SettingsMenu.Instance.IsFullsreenMode);
            data.SetInt(_resolutinValueName, SettingsMenu.Instance.ResolutionIndex);
            data.SetInt(_qualityValueName, SettingsMenu.Instance.QualityIndex);
            return data;
        }
        public void Deserialize(ComponentData data)
        {
            ExtendedComponentData unpacked = (ExtendedComponentData)data;
            SoundSettings.Instance.volumeValue = unpacked.GetFloat(_volumValueUniqueName);
            SettingsMenu.Instance.IsFullsreenMode = unpacked.GetBool(_isFullscreenUniqueName);
            SettingsMenu.Instance.ResolutionIndex = unpacked.GetInt(_resolutinValueName);
            SettingsMenu.Instance.QualityIndex = unpacked.GetInt(_qualityValueName);
        }
    }
}