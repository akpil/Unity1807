using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPool : MonoBehaviour {
    [SerializeField]
    private Transform Canvas;
    [SerializeField]
    private HPBar hpBar;

    private List<HPBar> pool;

	// Use this for initialization
	void Awake () {
        pool = new List<HPBar>();
	}

    public HPBar GetFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i];
            }
        }
        HPBar temp = Instantiate(hpBar);
        pool.Add(temp);
        temp.transform.SetParent(Canvas);
        temp.transform.localScale = Vector3.one;
        return temp;
    }


	// Update is called once per frame
	void Update () {
		
	}
}
