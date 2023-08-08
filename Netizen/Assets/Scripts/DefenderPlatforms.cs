using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlatforms : MonoBehaviour
{

    private Component rb1;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
