using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    [Serializable]
    public class ExtendedComponentData : ComponentData
    {
        public void SetTransform(string uniqueName, Transform transform)
        {
            SetVector(uniqueName + ".position", transform.position);
            SetVector(uniqueName + ".rotation", transform.rotation.eulerAngles);
            SetVector(uniqueName + ".scale", transform.localScale);
        }
        public void SetVector(string uniqueName, Vector3 vector3)
        {
            SetFloat(uniqueName + ".x", vector3.x);
            SetFloat(uniqueName + ".y", vector3.y);
            SetFloat(uniqueName + ".z", vector3.z);
        }

        public void GetTransform(string uniqueName, Transform transform)
        {
            transform.position = GetVector(uniqueName + ".position");
            transform.eulerAngles = GetVector(uniqueName + ".rotation");
            transform.localScale = GetVector(uniqueName + ".scale");
        }
        public Vector3 GetVector(string uniqueName)
        {
            var vector3 = new Vector3(
            GetFloat(uniqueName + ".x"),
            GetFloat(uniqueName + ".y"),
            GetFloat(uniqueName + ".z"));

            return vector3;
        }

        /*public float GetFloatValue(string uniqueName)
        {
            return GetFloat(uniqueName);
        }*/
    }
}