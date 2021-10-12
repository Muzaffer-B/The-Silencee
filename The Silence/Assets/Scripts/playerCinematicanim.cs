using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCinematicanim : MonoBehaviour
{
    Animator anim;
    bool runanim = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(firstAnimation());


    }

    private void Update()
    {
        if (runanim)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            gameObject.transform.Translate(0, 0, Time.deltaTime * 2.5f);

        }
    }
    // Update is called once per frame

    IEnumerator firstAnimation()
    {
        yield return new WaitForSeconds(5);

        anim.SetTrigger("talk");
        runanim = false;
    }

}
