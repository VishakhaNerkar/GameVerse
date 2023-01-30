using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childFollower : MonoBehaviour
{
	public GameObject Player; // assign the second cube in the inspector
	private bool isFollowing = false;
	public float followSpeed = 5.0f;  
	public float followDistance = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
		//debug.log(isFollowing)
    if (Input.GetKeyDown(KeyCode.Space) && !isFollowing && (Player.transform.position - transform.position).magnitude < 2.5f ) // if enter is pressed and the first cube is not currently following
    {
        isFollowing = true; // set the following flag to true
    }
    else if (Input.GetKeyDown(KeyCode.Space) && isFollowing) // if enter is pressed and the first cube is currently following
    {
        isFollowing = false; // set the following flag to false
    }

    if (isFollowing) // if the first cube is currently following the second cube
    {
		Vector3 targetPosition = Player.transform.position - (Player.transform.forward * followDistance);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
	}

}

