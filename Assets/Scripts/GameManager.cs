using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;

    private int enemiesOnScreen = 0;

    const float spawnDelay = 0.5f;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn () {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
            for (int i = 0; i < enemiesPerSpawn; i++) {
                if (enemiesOnScreen < maxEnemiesOnScreen) {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen++;
                }
            }
        }

        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawn());
    }

    public void RemoveEnemyFromScreen () {
        if (enemiesOnScreen > 0) {
            enemiesOnScreen--;
        }
    }
}
