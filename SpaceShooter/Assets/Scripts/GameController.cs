using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private AsteroidPool AsteroidP;
    [SerializeField]
    private EnemyPool EnemyP;
    [SerializeField]
    private EffectPool EffectP;
    [SerializeField]
    private int Score;
	// Use this for initialization
	void Start () {
        StartCoroutine(Hazards());
        Score = 0;

    }

    public GameObject GetEffect(eEffecType input)
    {
        return EffectP.GetFromPool(input);
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    private void SpawnAsteroid()
    {
        AsteroidMovement temp = AsteroidP.GetFromPool(Random.Range(0, 3));
        temp.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
        temp.gameObject.SetActive(true);
    }
    private void SpawnEnemy()
    {
        EnemyController temp = EnemyP.GetFromPool();
        temp.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
        temp.gameObject.SetActive(true);
    }
    private IEnumerator Hazards()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            int asteroidSpawnCount = 10, enemySpawnCount = 3;
            while (true)
            {
                if (asteroidSpawnCount > 0 && enemySpawnCount > 0)
                {
                    int randValue = Random.Range(0, 2);
                    if (randValue == 1)
                    {
                        SpawnAsteroid();
                        asteroidSpawnCount--;
                        yield return new WaitForSeconds(.2f);
                    }
                    else
                    {
                        SpawnEnemy();
                        enemySpawnCount--;
                        yield return new WaitForSeconds(.2f);
                    }
                }
                else if (enemySpawnCount > 0)
                {
                    for (int i = 0; i < enemySpawnCount; i++)
                    {
                        SpawnEnemy();
                        yield return new WaitForSeconds(.2f);
                    }
                    break;
                }
                else if (asteroidSpawnCount > 0)
                {
                    for (int i = 0; i < asteroidSpawnCount; i++)
                    {
                        SpawnAsteroid();
                        yield return new WaitForSeconds(.2f);
                    }
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }


	// Update is called once per frame
	void Update () {
	}
}
