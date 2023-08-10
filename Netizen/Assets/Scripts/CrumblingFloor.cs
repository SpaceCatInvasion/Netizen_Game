using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingFloor : MonoBehaviour
{
    private float crumbleTimer=-1;
    public float respawnTime = 3;
    public FloorTimer timer;
    public Animator crumble;
    public AudioSource crumbelSource;
    // Start is called before the first frame update
    void Start()
    {
        crumble = GetComponent<Animator>();
        crumbelSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crumbleTimer > 0)
        {
            crumbleTimer -= Time.deltaTime;
        }
        else if(crumbleTimer > -1)
        {
            timer.timer = respawnTime;
            crumbleTimer = -1;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (crumbleTimer==-1)
        {
            crumbelSource.Play();
            crumbleTimer = 1.5f;
            crumble.SetTrigger("animateCrumble");
            crumble.SetFloat("crumbleSpeed", crumbleTimer);
        }
        
    }
}
