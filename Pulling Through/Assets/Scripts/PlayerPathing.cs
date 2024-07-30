using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPathing : MonoBehaviour
{
    public GameObject player;
    private List<Vector3> positions = new List<Vector3>();

    //public int[] difficulty = new int[10];  // COULD USE THESE TWO TO DETERMINE HOW MANY WAYPOINTS TO HAVE, BUT KEEPING AT 10 FOR NOW I GUESS
    //public int levelNumber;

    private bool startedPathing = false;

    public List<Vector3> path = new List<Vector3>();

    public GameObject waypointPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().inShadowMode && !startedPathing)
        {
            startedPathing = true;
            CreatePath();
        }
        if (!positions.Contains(player.transform.position) && Mathf.Abs(player.GetComponent<PlayerMovement>().dirX) >= 0.5f && !startedPathing)
        {
            positions.Add(player.transform.position);
            Debug.Log(positions.Count);
        }
    }

    private void CreatePath()  // MIGHT NOT WANT THIS TO BE VOID
    {
        float avgX = 0f;
        float avgY = 0f;
        int poolSize = positions.Count / 10;
        Debug.Log("pool size: " + poolSize);

        for (int i = 0; i < 10; i++) {
            Debug.Log("i: " + i);
            for (int j = 0; j < poolSize; j++)
            {
                Debug.Log("j: " + j);
                avgX += positions[j + i*poolSize].x;
                avgY += positions[j + i*poolSize].y;
                //Debug.Log("j + i*10: " + (j + i * 10));
            }
            avgX /= poolSize;
            avgY /= poolSize;
            Debug.Log("hi");
            path.Add(new Vector3(avgX, avgY, 0f));  // z value should always be 0 since this is 2d game
            Debug.Log("bye");
        }
        int index = 0;
        foreach (Vector3 waypoint in path)
        {
            GameObject wp = Instantiate(waypointPrefab, waypoint, Quaternion.identity);
            wp.GetComponent<WaypointController>().waypointIndex = index;
            index++;
        }
    }
}
