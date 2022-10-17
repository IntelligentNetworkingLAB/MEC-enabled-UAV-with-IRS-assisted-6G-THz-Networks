import random as rand
import math
import UnityEngine as ue

def Euclidean(p, q):
    return math.sqrt(math.pow(p[0]-q[0],2) + math.pow(p[1]-q[1],2))

def ReadUnity():
    object = object = ue.GameObject.FindGameObjectWithTag("Agent")
    object.GetComponent("IRSAgent").UAV = ue.Vector3(1.0, 1.0, 1.0)
    ue.Debug.Log(object.GetComponent("IRSAgent").UAV)
    return

def main():
    ue.Debug.Log("asdfasdfasf")
    ReadUnity()
    return

if __name__ == '__main__':
    main()

'''
    for go in objects:
        ue.Debug.Log("A")
        ue.Debug.Log(go.gameObject.transform.position.x)
        go.gameObject.transform.position = ue.Vector3(1.0, 1.0, 1.0)
        ue.Debug.Log(go.gameObject.transform.position.x)


'''