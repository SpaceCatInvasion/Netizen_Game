using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialAppear : MonoBehaviour
{
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player1"))
        {
            winText.text = "Blue Wins!!";
        }
        else if (collision.CompareTag("Player2"))
        {
            winText.text = "Red Wins!!";
        }

        winText.gameObject.SetActive(true);
        Variables.noPriority = true;
	}
}
