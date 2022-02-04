using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class BughiAttack : MonoBehaviour
{
    private bool attack = false;
    private bool retrieve = false;
    public float speedMod = 2f;
    public Transform from;
    public Transform to;

    private float timeCount = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
    
        if (attack)
        {
            
           transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
           timeCount = timeCount + speedMod/(timeCount + 1) * Time.deltaTime; 
           Debug.Log(timeCount);
           if (timeCount > 0.99f)
           {
               attack = false;
               retrieve = true;
               timeCount = 0.0f;
           }
        }
        if (retrieve)
        {
            
            transform.rotation = Quaternion.Slerp(to.rotation, @from.rotation, timeCount);
            timeCount = timeCount + speedMod/(timeCount + 1) * Time.deltaTime; 
            if (timeCount > 0.99f)
            {
                retrieve = false;
                timeCount = 0.0f;
            }
        }

        if(Input.GetButtonDown("Fire1") && retrieve!=true)
        {
            attack = true;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
