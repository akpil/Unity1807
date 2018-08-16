using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private EnemyController[] enemies;
    [SerializeField]
    private Transform leftSpawnPos, rightSpawnPos;
    private Coroutine enemySpawn;
	// Use this for initialization
	void Awake () {
        enemies = Resources.LoadAll<EnemyController>("Enemy");
	}

    private void Start()
    {
        //enemySpawn = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds oneSec = new WaitForSeconds(1);
        while (true)
        {
            yield return oneSec;
            EnemyController temp1 = Instantiate(enemies[Random.Range(0, enemies.Length)],
                                    leftSpawnPos.position, 
                                    leftSpawnPos.rotation);
            EnemyController temp2 = Instantiate(enemies[Random.Range(0, enemies.Length)],
                                    rightSpawnPos.position,
                                    rightSpawnPos.rotation);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
