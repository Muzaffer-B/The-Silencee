using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManagement : MonoBehaviour
{

    public GameObject InvUI;
    public GameObject PagesUI;

     public void InvPanel()
    {
        InvUI.SetActive(true);
        PagesUI.SetActive(false);
        Debug.Log("InvPanel");
    }
   public void PagesPanel()
    {
        InvUI.SetActive(false);
        PagesUI.SetActive(true);
        Debug.Log("PagesPanel");
    }
}
