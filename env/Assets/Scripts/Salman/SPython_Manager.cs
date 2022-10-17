using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Scripting.Python;

public class SPython_Manager : MonoBehaviour
{
    public void KMeans()
    {
        string path = Application.dataPath + "/Python/KMeans.py";
        PythonRunner.RunFile(path);
    }
}
