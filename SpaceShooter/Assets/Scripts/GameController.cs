using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    private AsteroidPool AsteroidP;
    [SerializeField]
    private int Score;
	// Use this for initialization
	void Start () {
        StartCoroutine(Hazards());
        Score = 0;

    }

    public void AddScore(int value)
    {
        Score += value;
    }

    private IEnumerator Hazards()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 0; i < 3; i++)
            {
                AsteroidMovement temp = AsteroidP.GetFromPool(Random.Range(0, 3));
                temp.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 16);
                temp.gameObject.SetActive(true);
                yield return new WaitForSeconds(.2f);
            }
        }
    }


	// Update is called once per frame
	void Update () {
	}
}
