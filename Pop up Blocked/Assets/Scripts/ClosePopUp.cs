using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    public GameObject popUp;
    private void OnMouseDown()
    {
        Destroy(popUp);
    }
}
