using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifeAnim : MonoBehaviour
{
    Animator anim;
    bool runanim = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(firstAnimation());


    }

    private void Update()
    {
        if (runanim)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            gameObject.transform.Translate(0, 0, Time.deltaTime * 6);
            
        }
    }
    // Update is called once per frame

    IEnumerator firstAnimation()
    {
        yield return new WaitForSeconds(10);
       
        anim.SetTrigger("run");
        runanim = true;
    }
    
}
