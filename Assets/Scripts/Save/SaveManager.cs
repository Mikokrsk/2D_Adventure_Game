using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveManager : MonoBehaviour
{
/*    private string _SaveFolderPath;
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //  DontDestroyOnLoad(gameObject);
        }
        *//*        else
                {
                    Destroy(gameObject);
                }*//*
        AssetDatabase.CreateFolder("Assets", "Save");
        _SaveFolderPath = Application.dataPath + "Save";
        AssetDatabase.CreateFolder("Assets/Save","Save2");
    }

    public void Save()
    {

    }*/
}
