using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    private IngameUIController ingameUI;
    private EnemyPool EnemyP;
    [SerializeField]
    private Transform leftSpawnPos, rightSpawnPos;
    private Coroutine enemySpawn;

    [SerializeField]
    private int enemyHP;
    [SerializeField]
    private int money;
    private int stageMoney;

    private int killCount;
    [SerializeField]
    private HPBarPool HPBarP;
    [SerializeField]
    private PlayerController player;
    // Use this for initialization
    private void Awake () {
        EnemyP = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<EnemyPool>();

    }

    private void Start()
    {
        player.SetData(22, 1);
        ingameUI.SetMoneyText(money);
        enemyHP = 2;
        enemySpawn = StartCoroutine(SpawnEnemies());
        stageMoney = 0;
        killCount = 0;
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void AddMoney(int income)
    {
        money += income;
        ingameUI.SetMoneyText(money);
        killCount++;
        stageMoney += income;
    }

    public void GameOver()
    {
        ingameUI.ShowResultWindow(stageMoney, killCount);
    }

    private int incomeIncreaseCount = 5;

    private IEnumerator SpawnEnemies()
    {
        int spawnCount = 0;
        int income = 1;
        WaitForSeconds oneSec = new WaitForSeconds(3);
        while (true)
        {
            yield return oneSec;
            EnemyController temp1 = EnemyP.GetFromPool(Random.Range(0, 2));
            temp1.transform.rotation = leftSpawnPos.rotation;
            temp1.transform.position = leftSpawnPos.position;
            temp1.gameObject.SetActive(true);
            temp1.SetData(enemyHP, income);
            

            EnemyController temp2 = EnemyP.GetFromPool(Random.Range(0, 2));
            temp2.transform.rotation = rightSpawnPos.rotation;
            temp2.transform.position = rightSpawnPos.position;
            temp2.gameObject.SetActive(true);
            temp2.SetData(enemyHP, income);
            spawnCount++;
            if (incomeIncreaseCount <= spawnCount)
            {
                income++;
                spawnCount -= incomeIncreaseCount;
            }
        }
    }

    public HPBar GetHPBar()
    {
        return HPBarP.GetFromPool();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
