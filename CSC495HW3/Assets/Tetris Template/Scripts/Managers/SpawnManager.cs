using UnityEngine;
using System.Collections;
using Firebase;
using Firebase.Analytics;

public class SpawnManager: MonoBehaviour {

    public GameObject[] shapeTypes;

    public void Spawn() {
        // Random Shape
        int i = Random.Range(0, shapeTypes.Length);

        // Spawn Group at current Position
        GameObject temp = Instantiate(shapeTypes[i]);
        Managers.Game.currentShape = temp.GetComponent<TetrisShape>();
        temp.transform.parent = Managers.Game.blockHolder;
        Managers.Input.isActive = true;
        // Log a ShapeSpawned Event with FirebaseAnalytics
        FirebaseAnalytics.LogEvent("ShapeSpawned");
    }
}
