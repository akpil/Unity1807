using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    HPBarPool HPBarP;
	// Use this for initialization
	void Awake () {
        EnemyP = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<EnemyPool>();

    }

    private void Start()
    {
        enemyHP = 2;
        enemySpawn = StartCoroutine(SpawnEnemies());
        ingameUI.SetMoneyText(money);
    }

    public void AddMoney(int income)
    {
        money += income;
        ingameUI.SetMoneyText(money);
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
