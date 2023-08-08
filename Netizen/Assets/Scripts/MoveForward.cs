using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float size;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale= new Vector3(size,size,size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0)*Time.deltaTime);
        transform.localScale = new Vector3(size, size, size);
    }
}
