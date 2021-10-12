using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFromPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    public AudioSource sound;
    public AudioClip GoAwayy;

    bool is_trigger = false;
    bool goawaysound = true;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        RunAndDeath(is_trigger);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            is_trigger = true;
            
            RunAndDeath(is_trigger);
        }
    }

    void RunAndDeath(bool is_trigger)
    {
        if (is_trigger)
        {
            StartCoroutine(settime());
            GoAway(goawaysound);
            anim.SetTrigger("injuryRun");
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            gameObject.transform.Translate(0, 0, Time.deltaTime * 2);
            StartCoroutine(deadtime());
        }
        

        
    }

    IEnumerator settime()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator deadtime()
    {
        yield return new WaitForSeconds(6);
        anim.ResetTrigger("injuryRun");
        anim.SetTrigger("dead");
        
        //gameObject.transform.Translate(0, 0, 0);

        yield return new WaitForSeconds(2);
        is_trigger = false;
        
        yield return new WaitForSeconds(6);
        
        Destroy(gameObject);
    }

    void GoAway(bool goaway)
    {
        if (goaway)
        {
            sound.clip = GoAwayy;
            sound.Play();
            goawaysound = false;
            
        }
    }
}
