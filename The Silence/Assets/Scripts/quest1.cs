using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest1 : MonoBehaviour
{
    // Start is called before the first frame update

     public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            gameObject.SetActive(false);
        }
    }
   
}
