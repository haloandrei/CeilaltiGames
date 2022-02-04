using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BughiIdle : MonoBehaviour
{
    [SerializeField] float speedMod = 1;
    [SerializeField] float distance = 0.5f;
    bool floatUp = true;
    float rate = 0;

    void Update()
    {
        if (rate <= 1 && floatUp)
        {
            rate += Time.deltaTime * speedMod;
            if (rate > 1)
            {
                rate = 1;
                floatUp = false;
            }
        }
        if (rate >= 0 && floatUp == false)
        {
            rate -= Time.deltaTime * speedMod;
            if (rate < 0)
            {
                rate = 0;
                floatUp = true;
            }
        }
        gameObject.transform.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up * distance, rate);
    }
}
