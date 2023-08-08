using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void trapdoor() //instantly removes a trapdoor
    {
        Destroy(gameObject);
    }

    public void crumble() //destroys a block when a player stands on it after a short delay
    {
        Destroy(gameObject, 1.5f);
    }

    public void laser()
    {
        Instantiate(laserPrefab, new Vector3(0, 2, 0), Quaternion.LookRotation(new Vector2(0, 0)));
    }
    //LookRotation(new Vector2(-1,0)));
}
