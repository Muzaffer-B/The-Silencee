using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveandLoad : MonoBehaviour
{
    
    

   
    // Update is called once per frame
    public void Save( InventoryObject inventory)
    {
        inventory.Save();
    }

    

}
