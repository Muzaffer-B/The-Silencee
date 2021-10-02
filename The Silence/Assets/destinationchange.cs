using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destinationchange : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AI")
        {
            xPos = Random.Range(-30,25);
            zPos = Random.Range(-90 , 80 );
            this.gameObject.transform.position = new Vector3(xPos, 1, zPos);
            Debug.Log("Deyiyor");
        }
        
    }
}
