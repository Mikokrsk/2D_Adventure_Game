using Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSaver : MonoBehaviour, ISavableComponent
{
    [SerializeField] private int _uniqueID;
    [SerializeField] private int _executionOrder;
    [SerializeField] private readonly string _transformName = "transformValue";
    [SerializeField] private Transform _transform;

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

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public ComponentData Serialize()
    {

        ExtendedComponentData data = new ExtendedComponentData();
        data.SetTransform(_transformName,_transform);
        return data;
    }
    public void Deserialize(ComponentData data)
    {
        ExtendedComponentData unpacked = (ExtendedComponentData)data;
        unpacked.GetTransform(_transformName, _transform);
    }
}
