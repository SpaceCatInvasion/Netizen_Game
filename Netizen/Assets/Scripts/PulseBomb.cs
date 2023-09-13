using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBomb : MonoBehaviour
{
    public float radius;
    public bool pulseAway;
    public float strength;
    public AudioSource pulseSource;
    // Start is called before the first frame update
    void Start()
    {
        pulseSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("Collide");
            if (pulseAway)
            {
                pulseSource.Play();
                float p1Dist = Vector3.Distance(transform.position, Variables.player1.transform.position);
                float p2Dist = Vector3.Distance(transform.position, Variables.player2.transform.position);
                if (p1Dist < radius)
                {
                    PlayerController script = Variables.player1.GetComponent<PlayerController>();
                    bool temp = Variables.p1Priority;
                    bool temp2 = Variables.noPriority;
                    script.knockBack((Variables.player1.transform.position - transform.position)/ (p1Dist+0.5f),strength/p1Dist);
                    Variables.p1Priority = temp;
                    Variables.noPriority = temp2;
                }
                if (p2Dist < radius)
                {
                    PlayerController script = Variables.player2.GetComponent<PlayerController>();
                    bool temp = Variables.p1Priority;
                    bool temp2 = Variables.noPriority;
                    script.knockBack((Variables.player2.transform.position - transform.position)/ (p2Dist+0.5f), strength / p2Dist);
                    Variables.p1Priority = temp;
                    Variables.noPriority = temp2;
                }
            }
            else
            {
                pulseSource.Play();
                float p1Dist = Vector3.Distance(transform.position, Variables.player1.transform.position);
                float p2Dist = Vector3.Distance(transform.position, Variables.player2.transform.position);
                if (p1Dist < radius)
                {
                    PlayerController script = Variables.player1.GetComponent<PlayerController>();
                    bool temp = Variables.p1Priority;
                    bool temp2 = Variables.noPriority;
                    script.knockBack((transform.position-Variables.player1.transform.position) / p1Dist, strength / p1Dist);
                    Variables.p1Priority = temp;
                    Variables.noPriority = temp2;
                }
                if (p2Dist < radius)
                {
                    PlayerController script = Variables.player2.GetComponent<PlayerController>();
                    bool temp = Variables.p1Priority;
                    bool temp2 = Variables.noPriority;
                    script.knockBack((transform.position-Variables.player2.transform.position) / p2Dist, strength / p2Dist);
                    Variables.p1Priority = temp;
                    Variables.noPriority = temp2;
                }
            }
        }
    }
}
