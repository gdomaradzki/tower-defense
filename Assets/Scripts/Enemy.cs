using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int target = 0;
    public Transform exitPoint;
    public Transform[] checkPoints;
    public float navigationUpdate;

    private Transform enemy;
    private float navigationTime = 0;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (checkPoints != null) {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate) {
                if (target < checkPoints.Length) {
                    enemy.position = Vector2.MoveTowards(enemy.position, checkPoints[target].position, navigationTime);
                } else {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }

                navigationTime = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Checkpoint") {
            target++;
        } else if (collision.tag == "Finish") {
            GameManager.instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
