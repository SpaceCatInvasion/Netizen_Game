using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float minX, maxX, minY, maxY;

    private Vector3 target;
    private float smooth = 4f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
		target = (player1.transform.position + player2.transform.position) / 2;
		transform.position = target;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
	}

    void CameraTeleport()
    {
        if (Variables.p1Priority) target = player1.transform.position;
        else target = player2.transform.position;

		transform.position = target;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
	}

    // Update is called once per frame
    void Update()
    {
        if (Variables.teleportTrigger)
        {
            CameraTeleport();
            Variables.teleportTrigger = false;
            return;
        }
		if (Variables.noPriority)
		{
			target = (player1.transform.position + player2.transform.position) / 2;
		}
		else if (Variables.p1Priority)
        {
            target = player1.transform.position;
        }
        else if (!Variables.p1Priority)
        {
            target = player2.transform.position;
        }
        
        transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),  Mathf.Clamp(transform.position.y, minY, maxY), -10);
    }
}
