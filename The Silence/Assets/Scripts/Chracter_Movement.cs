using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chracter_Movement : MonoBehaviour
{
    Rigidbody physic;
    public  int speed = 20;

    Animator anim;

    public AudioSource sound;
    public AudioClip çevre;
    public AudioClip intorsound;
    public AudioClip baðýrma;

    public Text healthtext;
    public int health = 100;

    public InventoryObject inventory;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        sound = GetComponent<AudioSource>();
        sound.clip = intorsound;
        
        sound.Play();
       

        StartCoroutine(ambiance());
        healthtext.text = health.ToString();

        inventory.Load();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        healthtext.text = health.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, Time.deltaTime * speed);
            
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Run");
                StartCoroutine(WalkTime());
                anim.SetTrigger("Walk");


            //  anim.SetTrigger("Idle");



        }
        else
        {
            anim.SetTrigger("Idle");
        }

        if (!sound.isPlaying)
        {
            sound.clip = çevre;
            sound.Play();
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
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Idle");
            StartCoroutine(RunTime());
            anim.SetTrigger("Run");
            
        }
        else
        {
            
            speed = 15;
                       
                    
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Lady")
    //    {
    //        Debug.Log("Lady Girdi");

           
    //        StartCoroutine(BagýrmaTime());
    //        StartCoroutine(ambiance());

    //        //sound.Stop();
    //        //sound.clip = çevre;
    //        //sound.Play();
    //    }
    //}

    IEnumerator ambiance()
    {
        yield return new WaitForSeconds(4);
        sound.clip = çevre;
        sound.Play();
    }

    IEnumerator RunTime()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator WalkTime()
    {
        yield return new WaitForSeconds(2f);
    }
    //IEnumerator BagýrmaTime()
    //{
    //    sound.Stop();
    //    yield return new WaitForSeconds(4);
    //    Debug.Log("baðýrma girdi");

    //    sound.clip = baðýrma;
    //    sound.Play();
    //}

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}
