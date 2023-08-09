using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject laser;
    private LaserScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = laser.GetComponent<LaserScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            laser.SetActive(true);
            script.timer = 3;
        }
    }
}
