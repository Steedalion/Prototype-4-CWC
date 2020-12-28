using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
	GameObject player;
	Vector3 moveDirection;
	Rigidbody rb;
	public float moveForce;
    // Start is called before the first frame update
    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
	    moveDirection = player.transform.position - transform.position;
	    Move();
	    
    }
    
	void Move()
	{
		rb.AddForce(moveDirection * moveForce * Time.deltaTime);
	}
}
