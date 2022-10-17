import random as rand
import math
from munkres import Munkres
# import UnityEngine as ue

def Euclidean(p, q):
    return math.sqrt(math.pow(p[0]-q[0],2) + math.pow(p[1]-q[1],2))

def main():
    users = []
    user_num = 36
    # create random user
    for _ in range(user_num):
        tmpUser = [200*rand.random()-100, 200*rand.random()]
        users.append(tmpUser)
    # initialize centroid
    centroids = []
    for _ in range(12):
        centroids.append([0.0, 100.0])
        centroids.append([-100.0, -100.0])
        centroids.append([100.0, -100.0])
    # Main Loop for Balanced K-Means
    max_iter = 100
    for _ in range(max_iter):
        # Calculate edge weights
        G = []
        for i in range(user_num):
            node = []
            for j in range(36):
                node.append(Euclidean(users[i], centroids[j]))
            G.append(node)
        # Solve Assignment Problem based Hungarian Algorithm
        m = Munkres()
        indexes = m.compute(G)
        # Calculate new centroid locations
        newCentroids = [[0.0,0.0],[0.0,0.0],[0.0,0.0]]
        for row, column in indexes:
            newCentroids[column%3][0] += users[row][0]
            newCentroids[column%3][1] += users[row][1]
        for i in range(3):
            newCentroids[i][0] = newCentroids[i][0]/12.0
            newCentroids[i][1] = newCentroids[i][1]/12.0
        # if not change centroid
        if centroids[0]==newCentroids[0] and centroids[1]==newCentroids[1] and centroids[2]==newCentroids[2]:
            break
        # else continue
        for i in range(12):
            for j in range(3):
                centroids[3*i + j] = newCentroids[j]
    print(centroids[0])
    print(centroids[1])
    print(centroids[2])

    # Bring result to Unity
    for row, column in indexes:
        value = G[row][column]
        print(f'({row}, {column%3}) -> {value}')
    '''
    objects = ue.GameObject.FindGameObjectsWithTag("Finish")
    for go in objects:
        ue.Debug.Log("A")
        ue.Debug.Log(go.gameObject.transform.position.x)
        go.gameObject.transform.position = ue.Vector3(1.0, 1.0, 1.0)
        ue.Debug.Log(go.gameObject.transform.position.x)
    '''
    return

if __name__ == '__main__':
    main()