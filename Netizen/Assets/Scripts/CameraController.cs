using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float minX, maxX, minY, maxY;

    private Vector3 target;
    private float smooth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = (player1.transform.position + player2.transform.position) / 2;
        transform.position = Vector3.Lerp(transform.position, target, smooth);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),  Mathf.Clamp(transform.position.y, minY, maxY), -10);
    }
}
