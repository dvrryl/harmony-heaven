using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedHierarchyController : MonoBehaviour
{
    public int d;
    public GameObject RythemDisplay1;
    public GameObject RythemDisplay2;
    private float intervalDuration = 2.0f;
    private float intervalDurati = 2.0f;
    TimeSpan duration = TimeSpan.FromSeconds(6);
    TimeSpan durati = TimeSpan.FromSeconds(2);

    private void Start()
    {
        // Jalankan coroutine untuk mengubah status hirarki setiap interval
        
        d = 2;
        Debug.Log("Start - Value of d: " + d);
    }

    public void ProcessDValue(int dValue)
    {
        d = dValue;
        Debug.Log("ProcessDValue - Value of d set to: " + d);
    }

    void Update()
    {
        ProcessDValue(d);
        StartCoroutine(IntervalFunction());
    }
     private IEnumerator IntervalFunction(){
         while(d == 1)
         {
            Debug.Log("Update - d is 1, waiting for 2 seconds...");
            yield return new WaitForSeconds(intervalDurati);
            DisableGameObject();
            Debug.Log("Update - Disabled game objects, waiting for 5 seconds...");
            yield return new WaitForSeconds(intervalDuration);
            d = 0;
            Debug.Log("Update - Value of d set to 0");
            EnableGameObject();
            Debug.Log("Update - Enabled game objects");
            break;    
         }   
     }

    public void DisableGameObject()
    {
        // Nonaktifkan kedua game object
        RythemDisplay1.SetActive(false);
        RythemDisplay2.SetActive(false);
        Debug.Log("DisableGameObject - Disabled game objects");
    }

    public void EnableGameObject()
    {
        // Aktifkan kedua game object
        RythemDisplay1.SetActive(true);
        RythemDisplay2.SetActive(true);
        Debug.Log("EnableGameObject - Enabled game objects");
    }
}