using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private EnemyPool EnemyP;
    [SerializeField]
    private Transform leftSpawnPos, rightSpawnPos;
    private Coroutine enemySpawn;
	// Use this for initialization
	void Awake () {
        EnemyP = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<EnemyPool>();

    }

    private void Start()
    {
        enemySpawn = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds oneSec = new WaitForSeconds(1);
        while (true)
        {
            yield return oneSec;
            EnemyController temp1 = EnemyP.GetFromPool(Random.Range(0, 2));
            temp1.transform.rotation = leftSpawnPos.rotation;
            temp1.transform.position = leftSpawnPos.position;
            

            EnemyController temp2 = EnemyP.GetFromPool(Random.Range(0, 2));
            temp2.transform.rotation = rightSpawnPos.rotation;
            temp2.transform.position = rightSpawnPos.position;
            
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
