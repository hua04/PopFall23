using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour
{
    public GameObject popup;
    public SpriteRenderer renderers;
    public int totalPopups;
    public int currentPopups;
   
    

    public float minTime;
    public float maxTime;
    private int spawnZone;
    private float randomXpos, randomYpos;
    private Vector3 spawnPos;
    void Start()
    {
        InvokeRepeating("SpawnPop", 3f, Random.Range(minTime, maxTime)); //spawns pop ups at random intervals between min and max times
        
    }

    private void SpawnPop()
    {
        totalPopups+=1;
        currentPopups += 1;
        spawnZone = Random.Range(0, 4);
        

        switch (spawnZone)
        {
            case 0:
                randomXpos = Random.Range(0, 5);
                randomYpos = Random.Range(0, 2);
                break;
            case 1:
                randomXpos = Random.Range(0, -5);
                randomYpos = Random.Range(0, 2);
                break;
            case 2:
                randomXpos = Random.Range(0, -5);
                randomYpos = Random.Range(0, -2);
                break;
            case 3:
                randomXpos = Random.Range(0, 5);
                randomYpos = Random.Range(0, -2);
                break;

        }

        spawnPos = new Vector3(randomXpos, randomYpos, 0f);
        GameObject spawnedObj = Instantiate(popup, spawnPos, Quaternion.identity);
        SpriteRenderer[] renderers = spawnedObj.GetComponentsInChildren<SpriteRenderer>();
        foreach (var rend in renderers)
        {
            rend.sortingOrder=rend.sortingOrder += totalPopups;
           

        }


    }
}
