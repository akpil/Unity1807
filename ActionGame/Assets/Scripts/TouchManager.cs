using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    [SerializeField]
    private GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
#if UNITY_EDITOR
    // 에디터 전용 파트
#elif UNITY_ANDROID || UNITY_IOS
    // 안드로이드 디바이스 전용파트
#endif
    // Update is called once per frame
    void Update () {
        if (Touch())
        {
            // 게임 내 touch기능 수행
        }


#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    GameObject newEffect = Instantiate(effect);
                    newEffect.transform.position = hit.point;

                }
            }
        }
#endif
    }

    private Ray GenerateRay(Vector3 position)
    {
        Vector3 farPos = Camera.main.ScreenToWorldPoint(
                                            new Vector3(position.x, position.y, Camera.main.farClipPlane));
        Vector3 nearPos = Camera.main.ScreenToWorldPoint(
                                            new Vector3(position.x, position.y, Camera.main.nearClipPlane));

        return new Ray(nearPos, Vector3.Normalize(farPos - nearPos));
    }

    private bool Touch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = GenerateRay(touch.position);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform.gameObject == gameObject)
                    {
                        GameObject newEffect = Instantiate(effect);
                        newEffect.transform.position = hit.point;
                        return true;
                    }
                }
            }
        }
        return false;
    }


}
