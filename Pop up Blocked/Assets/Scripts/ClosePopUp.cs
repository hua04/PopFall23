using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    public GameObject popUp;
    public GameObject spawner;
    PopUpSpawner popUpSpawner;
    private void OnMouseDown()
    {
        spawner = GameObject.Find("PopUpSpawner");
        popUpSpawner = spawner.GetComponent<PopUpSpawner>();
        popUpSpawner.currentPopups -= 1;
        Destroy(popUp);
    }
}
