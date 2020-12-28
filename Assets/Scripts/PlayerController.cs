using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	PlayerInputController player;
	float movementAxis;
	public float movementSpeed;
	GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
	{
		focalPoint = GameObject.Find("Focal point");
		rb = GetComponent<Rigidbody>();
		player.Player.Move.started += axis => UpdateMoveDirection(axis.ReadValue<float>());
		player.Player.Move.canceled += (x)=> movementAxis = 0;
        
	}
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		Debug.Assert( movementSpeed != 0);
		player = new PlayerInputController();
		
		
	}

    // Update is called once per frame
    void Update()
    {
	    if(movementAxis != 0)
	    {
	    	rb.AddForce(-focalPoint.transform.forward * movementAxis * movementSpeed * Time.deltaTime);
	    }
    }
	void UpdateMoveDirection(float axis)
	{
		Debug.Log("Moved");
		movementAxis = axis;
	}
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		player.Enable();
	}
	
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		player.Disable();
	}
}
