import random as rand
import math
import UnityEngine as ue

object = ue.GameObject.FindGameObjectWithTag("Agent")
object.GetComponent("IRSAgent").UAV = ue.Vector3(2.0,2.0,2.0)
ue.Debug.Log(object.GetComponent("IRSAgent").UAV)