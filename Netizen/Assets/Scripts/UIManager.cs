using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startGameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.startedGame)
        {
            startGameScreen.SetActive(false);
        }
    }
    public void startGame()
    {
        Variables.startedGame = true;
        startGameScreen.SetActive(false);
    }

    public void Tutorial()
    {
		Variables.startedGame = true;
        SceneManager.LoadScene("Level Tutorial");
	}


}
