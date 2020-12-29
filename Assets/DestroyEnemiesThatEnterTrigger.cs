using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesThatEnterTrigger : MonoBehaviour
{
	public SpawnManager enemySpawner;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected IEnumerator OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
			yield return null;
			enemySpawner.UpdateEnemyCount();
		}
		
		yield return null;
	}
}
