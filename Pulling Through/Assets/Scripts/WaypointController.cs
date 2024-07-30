using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public int waypointIndex;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("entered");
        if (collision.CompareTag("Shadow"))
        {
            PlayerMovement playerMoveScript = collision.GetComponent<PlayerMovement>();
            if (playerMoveScript.shadowIsMoving && playerMoveScript.currentWaypointIndex == waypointIndex)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
