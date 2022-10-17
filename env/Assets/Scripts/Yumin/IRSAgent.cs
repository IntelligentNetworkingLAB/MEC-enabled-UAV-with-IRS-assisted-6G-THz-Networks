using System;
using UnityEngine;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEditor;
using UnityEditor.Scripting.Python;

public class IRSAgent : Agent
{
    public Vector3 IRSs;
    public Vector3 UAV;
    public Vector2[] Users;
    public float[] Users_Demands;

    public float minRate;
    public float[] Up_Rates;
    public float[] Down_Rates;
    public float lowest_time;

    public float[] phase_shift_up;
    public float[] phase_shift_down;

    private void Start()
    {
        // Initialize IRS, UAV positions
    }

    public override void Initialize()
    {
        ReSettingEnv();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Observation size: 42
        for (int i = 0; i < Users.Length; ++i)
        {
            sensor.AddObservation(Users[i]); 
            sensor.AddObservation(Users_Demands[i]);
        }
        sensor.AddObservation(IRSs);
        sensor.AddObservation(UAV);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        AddReward(-0.01f);
        var actions = actionBuffers.ContinuousActions;
        for(int i = 0; i < 30; ++i)
        {
            phase_shift_up[i] = Mathf.Clamp(actions[i], 0f, 2 * Mathf.PI);
            phase_shift_down[i] = Mathf.Clamp(actions[i + 30], 0f, 2 * Mathf.PI);
        }
        CallofPython();
        for(int i = 0; i < 12; ++i)
        {
            if(Up_Rates[i] < minRate || Down_Rates[i] < minRate)
            {
                SetReward(-2f);
                EndEpisode();
            }
        }
        bool done = true;
        for (int i = 0; i < 12; ++i)
        {
            if (Users_Demands[i] != 0)
            {
                done = false;
                break;
            }
        }
        if (done)
        {
            SetReward(2f);
            EndEpisode();
        }
        else
        {
            AddReward(1.0f / lowest_time);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
    }

    public override void OnEpisodeBegin()
    {
        ReSettingEnv();
    }

    void ReSettingEnv()
    {
        // Initialize Users positions and Demands
    }

    public void CallofPython()
    {
        string path = Application.dataPath + "/Python/test.py";
        PythonRunner.RunFile(path);
    }
}
