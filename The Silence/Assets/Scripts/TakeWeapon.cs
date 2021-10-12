using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ýmage;
    public Transform Weapon;

    public Inventory inventory;

    private void OnTriggerStay(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (other.gameObject.tag == "weapon")
        {
            ýmage.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(Ereset());

                if (item != null)
                {
                    Debug.Log("Girdi");
                    inventory.AddItem(item);
                }
                //other.transform.rotation = Quaternion.Euler(-177.12f, -179.612f, 173.942f);
                //other.transform.position = Weapon.position;
                //other.transform.parent = GameObject.Find("WeaponDest").transform;
                //Weapon.transform.rotation = Quaternion.Euler(-55.994f, -84.759f, -154.182f);

            }
        }

    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
    //    if (hit.gameObject.tag == "weapon")
    //    {
    //        ýmage.SetActive(true);
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            StartCoroutine(Ereset());

    //            if (item != null)
    //            {
    //                inventory.AddItem(item);
    //            }
    //            //other.transform.rotation = Quaternion.Euler(-177.12f, -179.612f, 173.942f);
    //            //other.transform.position = Weapon.position;
    //            //other.transform.parent = GameObject.Find("WeaponDest").transform;
    //            //Weapon.transform.rotation = Quaternion.Euler(-55.994f, -84.759f, -154.182f);

    //        }
    //    }
    //}


    IEnumerator Ereset()
    {
        
        yield return new WaitForSeconds(1.5f);
        ýmage.SetActive(false);
    }
    

}
