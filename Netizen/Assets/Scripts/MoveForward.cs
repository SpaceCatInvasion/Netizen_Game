using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float size;
    public float speed;
    public Vector2 dir;
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
        if (Vector2.Distance(transform.position, Variables.player1.transform.position) > 20 || Vector2.Distance(transform.position, Variables.player2.transform.position) > 20)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player1"))
        {
            PlayerController script = Variables.player1.gameObject.GetComponent<PlayerController>();
            script.knockBack(dir,size);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            PlayerController script = Variables.player2.gameObject.GetComponent<PlayerController>();
            script.knockBack(dir, size);
        }
        Destroy(gameObject);
    }
}
