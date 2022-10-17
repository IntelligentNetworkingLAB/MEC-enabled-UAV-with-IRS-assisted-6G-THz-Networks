using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Scripting.Python;

public class PythonLancher : Editor
{
    public void CallofPython()
    {
        string path = Application.dataPath + "/Python/IRSSimulation.py";
        PythonRunner.RunFile(path);
        Debug.Log("Work");
    }

}
