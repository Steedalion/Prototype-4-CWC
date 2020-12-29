using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnMin, spawnMax;
	WaitForSeconds wait;
	float delay = 5;
	int enemyCount = 0;
	int waveNumber =1;
	public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
	{
		wait = new WaitForSeconds(delay);
		SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
	    
    }
	void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++) {
			StartCoroutine(Spawn(enemyPrefab));
		}
		StartCoroutine(Spawn(powerupPrefab));
	}
    
	IEnumerator Spawn(GameObject prefab)
	{
	
		Vector3 spawnPos = new Vector3(Random.Range(spawnMin, spawnMax), 0, Random.Range(spawnMin, spawnMax));
			Instantiate(prefab, spawnPos, Quaternion.identity);
			yield return wait;
		
	}
	
	public void UpdateEnemyCount()
	{
		enemyCount = FindObjectsOfType<MoveTowardPlayer>().Length;
		Debug.Log("Enemies left "+enemyCount);
		Debug.Log("Enemies left "+FindObjectOfType<MoveTowardPlayer>());
		if (enemyCount == 0)
		{
			waveNumber++;
			SpawnEnemyWave(waveNumber);
		}
	}
}
