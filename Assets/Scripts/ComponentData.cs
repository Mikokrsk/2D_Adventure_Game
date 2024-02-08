using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Save
{
    [Serializable]
    public class ComponentData
    {
        protected Dictionary<string, float> _floats = new Dictionary<string, float>();
        protected Dictionary<string, int> _ints = new Dictionary<string, int>();
        protected Dictionary<string, string> _strings = new Dictionary<string, string>();

        public void SetFloat(string uniqueName, float value)
        {
            _floats[uniqueName] = value;
            Debug.Log($"Set {uniqueName} = {value}");
        }
        public void SetInt(string uniqueName,int value)
        {
            _ints[uniqueName] = value;
        }
        public void SetString(string uniqueName, string value)
        {
            _strings[uniqueName] = value;
        }

        public float GetFloat(string uniqueName)
        {
            Debug.Log($"Get {uniqueName} = {_floats[uniqueName]}");
            return _floats[uniqueName];
        }
        public int GetInt(string uniqueName)
        { 
            return _ints[uniqueName];
        }
        public string GetString(string uniqueName)
        {
            return _strings[uniqueName];
        }
    }
}