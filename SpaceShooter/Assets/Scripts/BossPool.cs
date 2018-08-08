using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPool : MonoBehaviour {
    [SerializeField]
    private BoltPool BossBoltPool;

    [SerializeField]
    private BossController boss;

    private List<BossController> bossList;

    // Use this for initialization
    void Start()
    {
        bossList = new List<BossController>();
    }

    public BossController GetFromPool()
    {
        for (int i = 0; i < bossList.Count; i++)
        {
            if (!bossList[i].gameObject.activeInHierarchy)
            {
                return bossList[i];
            }
        }
        BossController newEnemy = Instantiate(boss);
        newEnemy.SetBoltPool(BossBoltPool);
        bossList.Add(newEnemy);
        return newEnemy;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
