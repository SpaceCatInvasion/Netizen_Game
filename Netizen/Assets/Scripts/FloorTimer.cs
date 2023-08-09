using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTimer : MonoBehaviour
{
    public float timer=-1;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer > -1)
        {
            floor.SetActive(true);
            timer = -1;
        }
    }
}
