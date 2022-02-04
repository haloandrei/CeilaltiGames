using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BughiIdle : MonoBehaviour
{
    private int bobbingElipse = 0;
    float speedMod = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bobbingElipse <= 100)
        {
            gameObject.transform.position += Vector3.up * speedMod * Time.deltaTime;
        }
        else if (bobbingElipse > 100 && bobbingElipse < 202)
        {
            gameObject.transform.position -= Vector3.up * speedMod * Time.deltaTime;
        }
        else 
            bobbingElipse = -1;
        bobbingElipse++;
    }
}
