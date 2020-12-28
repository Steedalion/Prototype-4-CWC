using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnMin, spawnMax;
	WaitForSeconds wait;
	float delay = 5;
    // Start is called before the first frame update
    void Start()
	{
		wait = new WaitForSeconds(delay);
	    StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	IEnumerator Spawn()
	{
		while (true){}
		Vector3 spawnPos = new Vector3(Random.Range(spawnMin, spawnMax), Random.Range(spawnMin, spawnMax), Random.Range(spawnMin, spawnMax));
		Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
		yield return wait;
	}
}
