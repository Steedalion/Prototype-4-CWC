using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	PlayerInputController player;
	float rotationAxis;
	public float rotationSpeed;
    // Start is called before the first frame update
	void Awake()
	{
		Debug.Assert( rotationSpeed != 0);
	    player = new PlayerInputController();
	    player.Player.CameraRotate.started += axis => Rotate(axis.ReadValue<float>());
	    player.Player.CameraRotate.canceled += (x)=> rotationAxis = 0;
	    //player;
    }

    // Update is called once per frame
    void Update()
	{
		if(rotationAxis != 0)
		{
			transform.Rotate(Vector3.up * rotationAxis * rotationSpeed * Time.deltaTime);
		}
        
    }
    
	void Rotate(float axis)
	{
		rotationAxis = axis;
		//transform.Rotate(Vector3.up*axis);
		//Debug.Log("Rotate"+axis);
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
