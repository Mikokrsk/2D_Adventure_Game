using Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour, ISavableComponent
{
    [SerializeField] private int _uniqueID;
    [SerializeField] private int _executionOrder;
    [SerializeField] private readonly string _playerDateSaveName = "playerDateSave";
    [SerializeField] private PlayerController _playerController;

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
        data.SetInt(_playerDateSaveName, _playerController.healthManager.Health);
        return data;
    }
    public void Deserialize(ComponentData data)
    {
        ExtendedComponentData unpacked = (ExtendedComponentData)data;
        _playerController.healthManager.Health = unpacked.GetInt(_playerDateSaveName);
    }
}
