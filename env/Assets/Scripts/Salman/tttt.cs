using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Scripting.Python;

public class tttt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Python/KMeans.py";
        PythonRunner.RunFile(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
