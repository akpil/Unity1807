using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    private AsteroidPool AsteroidP;
    [SerializeField]
    private EnemyPool EnemyP;
    [SerializeField]
    private EffectPool EffectP;
    [SerializeField]
    private int Score;
    private MainUIController ui;
    private Coroutine hazardRoutine;

    [SerializeField]
    private BGScroll[] BGs;
    private bool IsGameOver;

    private PlayerController player;
	// Use this for initialization
	void Start () {
        IsGameOver = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        hazardRoutine = StartCoroutine(Hazards());
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].StartScroll();
        }
        Score = 0;
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<MainUIController>();
        ui.SetScore(Score);
    }

    public GameObject GetEffect(eEffecType input)
    {
        return EffectP.GetFromPool(input);
    }

    public void GameOver()
    {
        StopCoroutine(hazardRoutine);
        Invoke("WaitGameOver", 5);
    }
    private void WaitGameOver()
    {
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].StopScroll();
        }
        ui.SetGameOver();
        IsGameOver = true;
    }

    public void GameRestart()
    {
        //SceneManager.LoadScene(0);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);

        Score = 0;
        ui.SetScore(Score);
        ui.HideGameOver();

        hazardRoutine = StartCoroutine(Hazards());
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].StartScroll();
        }
    }

    public void AddScore(int value)
    {
        Score += value;
        ui.SetScore(Score);
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
        if (IsGameOver && Input.GetKeyDown(KeyCode.R))
        {
            GameRestart();
        }
	}
}
