using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trapDoor;

    private float respawnTimer=-1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnTimer > 0)
        {
            respawnTimer-=Time.deltaTime;
        }
        else if (respawnTimer > -1)
        {
            trapDoor.SetActive(true);
            respawnTimer = -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        trapDoor.SetActive(false);
        respawnTimer = 5;
    }
}
