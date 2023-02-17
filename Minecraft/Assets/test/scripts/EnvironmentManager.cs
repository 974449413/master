using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public float alternateTime = 0;
    public GameObject envGameObject;
    // Start is called before the first frame update
    void Start()
    {
        if(alternateTime == 0)
        {
            alternateTime = 10f;
        }
        GenerateEnvironmentItem();
        StartCoroutine(DayFollowNightCirculation());
    }

    //昼夜交替
    IEnumerator DayFollowNightCirculation()
    {
        while(true)
        {
            this.transform.Rotate(Vector3.right * alternateTime * Time.deltaTime, Space.World);
            yield return 0;
        }
    }

    void GenerateEnvironmentItem()
    {
        Instantiate(envGameObject, Vector3.zero, Quaternion.identity);
    }


}