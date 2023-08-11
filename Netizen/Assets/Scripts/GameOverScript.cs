using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private bool trigger = false;
    private bool trigger2 = false;
    private bool p1 = true;
    public float speed;
    public float speed2;
    private Rigidbody2D rbp1;
    private Rigidbody2D rbp2;
    public GameObject endScreen;
    public TextMeshProUGUI winner;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            if (p1)
            {
                rbp1 = Variables.player1.GetComponent<Rigidbody2D>();
                rbp1.gravityScale = 0;
                rbp1.velocity = Vector3.zero;
                if (Variables.player1.transform.position.x < 0)
                {
                    Variables.player1.transform.Translate((new Vector3(0,4.4f,0)-Variables.player1.transform.position)/Vector3.Distance(Variables.player1.transform.position,new Vector3(0,4.4f,0))*Time.deltaTime*speed);
                }
                else
                {
                    Variables.player1.transform.position= new Vector3(0,4.4f,0);
                    trigger = false;
                    trigger2 = true;
                }
            }
            else
            {
                rbp2 = Variables.player2.GetComponent<Rigidbody2D>();
                rbp2.gravityScale = 0;
                rbp2.velocity = Vector3.zero;
                if (Variables.player2.transform.position.x > 0)
                {
                    Variables.player2.transform.Translate((new Vector3(0, 4.4f, 0) - Variables.player2.transform.position) / Vector3.Distance(Variables.player2.transform.position, new Vector3(0, 4.4f, 0)) * Time.deltaTime * speed);
                }
                else
                {
                    Variables.player2.transform.position = new Vector3(0, 4.4f, 0);
                    trigger = false;
                    trigger2 = true;
                }
            }
        }
        else if(trigger2)
        {
            if (p1)
            {
                Variables.player1.transform.position += Vector3.up * Time.deltaTime * speed2;
                Variables.player1.transform.position = new Vector3(0, Variables.player1.transform.position.y, 0);
                if (Variables.player1.transform.position.y > 15)
                {
                    endScreen.SetActive(true);
                    winner.text = "Blue Wins";
                }
            }
            else
            {
                Variables.player2.transform.position += Vector3.up * Time.deltaTime * speed2;
                Variables.player2.transform.position = new Vector3(0, Variables.player2.transform.position.y, 0);
                if (Variables.player2.transform.position.y > 15)
                {
                    endScreen.SetActive(true);
                    winner.text = "Red Wins";
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            trigger = true;
            p1 = true;
            Variables.startedGame = false;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            trigger = true;
            p1= false;
            Variables.startedGame = false;
        }
    }
    public void restart()
    {
        Variables.startedGame = false;
        Variables.noPriority = true;
        Variables.fromDirection = 0;
        SceneManager.LoadScene("Level 0");
    }
}
