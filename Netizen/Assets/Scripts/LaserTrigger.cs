using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject laserWall;
    private Traps script;
    // Start is called before the first frame update
    void Start()
    {
        script = laserWall.GetComponent<Traps>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        script.laser();
    }
}
