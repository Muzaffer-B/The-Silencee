using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            xPos = Random.Range(140, -200);
            zPos = Random.Range(-156, 100);
            this.gameObject.transform.position = new Vector3(xPos, 1, zPos);
            Debug.Log("Deyiyor");
        }

    }
}
