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
	bool hasPowerup;
	public float powerupStrength = 100;
	public GameObject powerupIndicator;
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
	    if(hasPowerup)
	    {
	    	powerupIndicator.transform.position = transform.position - new Vector3(0,0.5f, 0);
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
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Powerup"))
		{
			EnablePowerup();
			Destroy(other.gameObject);
			StartCoroutine(PowerupDelay());
		}
	}
	IEnumerator PowerupDelay()
	{
		yield return new WaitForSeconds (7);
		DisablePowerup();
	}
	void EnablePowerup()
	{
		powerupIndicator.SetActive(true);
		hasPowerup = true;
	}
	void DisablePowerup()
	{
		powerupIndicator.SetActive(false);
		hasPowerup = false;
	}
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	protected IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		
		if(hasPowerup && collisionInfo.other.CompareTag("Enemy"))
		{
			GameObject enemy = collisionInfo.other.gameObject;
			Rigidbody body = enemy.GetComponent<Rigidbody>();
			Debug.Log("Boom");
			Vector3 away = (enemy.transform.position - transform.position).normalized;
			body.AddForce(away * powerupStrength, ForceMode.Impulse);
			
		}
		yield return null;
	}
}
