using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    private EnemyController[] enemies;
    private List<EnemyController>[] pool;
    // Use this for initialization
    void Awake () {
        enemies = Resources.LoadAll<EnemyController>("Enemy");
        pool = new List<EnemyController>[enemies.Length];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<EnemyController>();
        }
    }
	
    public EnemyController GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].gameObject.activeInHierarchy)
            {
                return pool[index][i];
            }
        }
        EnemyController temp = Instantiate(enemies[index]);
        pool[index].Add(temp);
        return temp;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
