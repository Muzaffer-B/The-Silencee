using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chracter_Movement : MonoBehaviour
{
    Rigidbody physic;
    public  int speed = 20;

    Animator anim;

    public AudioSource sound;
    public AudioClip çevre;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        sound = GetComponent<AudioSource>();
        sound.clip = çevre;
        sound.Play();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        


        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetTrigger("Walk");
               
            }
            //  anim.SetTrigger("Idle");



        }
        

        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.Translate(Time.deltaTime * -speed, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {

            gameObject.transform.Translate(0, 0, Time.deltaTime * -speed);

        }
        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.Translate(Time.deltaTime * speed, 0, 0);

        }
        if (Input.GetKey(KeyCode.Space))
        {

            gameObject.transform.Translate(0, Time.deltaTime * 10, 0);

            


        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 30;
            anim.SetTrigger("Run");
        }
        else
        {
            
            speed = 5;
                       
                    
        }
    }
}
