using System;
using UnityEngine;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using PA_DronePack;

public class DronesAgent : Agent
{
    private PA_DroneController dcoScript;
    public SPython_Manager py;

    Vector3 droneInitPos;             // 드론의 초기 위치 변수
    Quaternion droneInitRot;            // 드론의 초기 회전 상태 변수

    private void Start()
    {
    }
    public override void Initialize()
    {
        dcoScript = GetComponent<PA_DroneController>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;

        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
    }

    public override void OnEpisodeBegin()
    {
    }
}
