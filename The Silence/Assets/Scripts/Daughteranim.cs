using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Daughteranim : MonoBehaviour
{

    Animator anim;
    bool runanim = false;
    public AudioSource sound;
    public AudioClip çevre;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(firstAnimation());
        sound = GetComponent<AudioSource>();

        StartCoroutine(Playmusic());
    }

    private void Update()
    {
        if (runanim)
        {
            gameObject.transform.Translate(0, 0, Time.deltaTime * 5);
        }
    }
    // Update is called once per frame

    IEnumerator firstAnimation()
    {
        yield return new WaitForSeconds(2.5f);
        anim.SetTrigger("point");
        StartCoroutine(secondAnimation());
    }
    IEnumerator secondAnimation()
    {
        yield return new WaitForSeconds(3.2f);
        anim.SetTrigger("getup");
        StartCoroutine(thirdAnimation());
    }

    IEnumerator thirdAnimation()
    {
        yield return new WaitForSeconds(3.5f);
        
        anim.SetTrigger("run");
        runanim = true;
        StartCoroutine(PlayScene());
    }
    IEnumerator PlayScene()
    {
        yield return new WaitForSeconds(7.5f);

        SceneManager.LoadScene("LoadScene");
    }
    IEnumerator Playmusic()
    {
        yield return new WaitForSeconds(4.5f);

        sound.clip = çevre;
        sound.Play();
    }

}
