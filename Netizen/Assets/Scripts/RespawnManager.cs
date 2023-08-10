using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public bool p1Respawn = false;
    public bool p2Respawn = false;
    public List<GameObject> respawnPoints;
    public GameObject rightRespawnAttack, rightRespawnDefend, leftRespawnAttack, leftRespawnDefend;

    private int index = 0;
    private float lowestDist = 10000000000;
    private float respawnTime = 0.1f;
    private float p1Timer = -1;
    private float p2Timer = -1;
    // Start is called before the first frame update
    void Start()
    {
        if(Variables.fromDirection == 1)
        {
            Variables.player2.transform.position = rightRespawnAttack.transform.position;
            Variables.player1.transform.position = rightRespawnDefend.transform.position;
        }

		if (Variables.fromDirection == -1)
		{
			Variables.player2.transform.position = leftRespawnAttack.transform.position;
			Variables.player1.transform.position = leftRespawnDefend.transform.position;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (p1Respawn)
        {
            lowestDist = 10000000000;
            if (Variables.p1Priority)
            {
                Variables.p1Priority = false;
            }
            for (int i=0;i<respawnPoints.Count; i++)
            {
                if (respawnPoints[i].transform.position.x > Variables.player2.transform.position.x)
                {
                    continue;
                }
                if(lowestDist>Vector3.Distance(Variables.player2.transform.position, respawnPoints[i].transform.position))
                {
                    lowestDist = Vector3.Distance(Variables.player2.transform.position, respawnPoints[i].transform.position);
                    index = i;
                }
            }
            Variables.player1.transform.position = respawnPoints[index].transform.position;
            p1Respawn = false;
            p1Timer = respawnTime;
        }
        if (p2Respawn)
        {
            lowestDist = 10000000000;
            if (!Variables.p1Priority)
            {
                Variables.p1Priority = true;
            }
            for (int i = 0; i < respawnPoints.Count; i++)
            {
                if (respawnPoints[i].transform.position.x < Variables.player1.transform.position.x)
                {
                    continue;
                }
                if (lowestDist > Vector3.Distance(Variables.player1.transform.position, respawnPoints[i].transform.position))
                {
                    lowestDist = Vector3.Distance(Variables.player1.transform.position, respawnPoints[i].transform.position);
                    index = i;
                }
            }
            Variables.player2.transform.position = respawnPoints[index].transform.position;
            p2Respawn = false;
            p2Timer = respawnTime;
        }
        if (p1Timer > 0)
        {
            p1Timer-=Time.deltaTime;
        }
        else if(p1Timer>-1)
        {
            Variables.player1.gameObject.SetActive(true);
            p1Timer = -1;
        }
        if (p2Timer > 0)
        {
            p2Timer -= Time.deltaTime;
        }
        else if (p2Timer > -1)
        {
            Variables.player2.gameObject.SetActive(true);
            p2Timer = -1;
        }
    }
}
