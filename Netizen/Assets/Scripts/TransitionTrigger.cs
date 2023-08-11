using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour
{
    public string levelName;
    public string player;

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
        if(player == "")
        {
            SceneManager.LoadScene(levelName);
            return;
        }

        if (collision.gameObject.CompareTag(player))
        {
            if (player == "Player2" && !Variables.p1Priority)
            {
                Variables.fromDirection = -1;
				SceneManager.LoadScene(levelName);
			}
            if (player == "Player1" && Variables.p1Priority)
            {
                Variables.fromDirection = 1;
				SceneManager.LoadScene(levelName);
			}
		}
	}
}
