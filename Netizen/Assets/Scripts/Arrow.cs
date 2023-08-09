using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool player1;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1)
        {
            if (!Variables.p1Priority||Variables.noPriority)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
            }
        }
        else
        {
            if (Variables.p1Priority || Variables.noPriority)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
            }
        }
    }
}
