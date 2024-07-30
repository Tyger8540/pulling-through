using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityController : MonoBehaviour
{
    public GameObject normalTerrain;
    public GameObject shadowTerrain;

    public GameObject player;
    public GameObject shadowPlayer;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shadowTerrain.SetActive(true);
            normalTerrain.SetActive(false);
            shadowPlayer.SetActive(true);
            player.GetComponent<PlayerMovement>().inShadowMode = true;
            shadowPlayer.GetComponent<PlayerMovement>().inShadowMode = true;
        }
        else if (collision.CompareTag("Shadow"))
        {
            shadowPlayer.SetActive(false);
            shadowTerrain.SetActive(false);
            normalTerrain.SetActive(true);
            player.GetComponent<PlayerMovement>().inShadowMode = false;
            shadowPlayer.GetComponent<PlayerMovement>().inShadowMode = false;
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shadowPlayer.SetActive(false);
            shadowTerrain.SetActive(false);
            normalTerrain.SetActive(true);
            player.GetComponent<PlayerMovement>().inShadowMode = false;
            shadowPlayer.GetComponent<PlayerMovement>().inShadowMode = false;
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        shadowPlayer.SetActive(false);
        normalTerrain.SetActive(true);
        shadowTerrain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
