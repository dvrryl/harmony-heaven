using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedHierarchyController1 : MonoBehaviour
{
    public int d;
    public int e;
    public int f;
    public int g;
    public GameObject RythemDisplay1;
    public GameObject RythemDisplay2;
    private float intervalDuration = 2.0f;
    private float intervalDurati = 2.0f;
    TimeSpan duration = TimeSpan.FromSeconds(6);
    TimeSpan durati = TimeSpan.FromSeconds(2);

    private void Start()
    {
        // Jalankan coroutine untuk mengubah status hirarki setiap interval
        e = 1;
        f = 1;
        g = 1;
        d = 2;
        //Debug.Log("Start - Value of d: " + d);
    }

    public void ProcessDValue(int dValue)
    {
        d = dValue;
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    public void ProcessEValue(int eValue)
    {
        e = eValue;
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    public void ProcessFValue(int fValue)
    {
        f = fValue;
        //Debug.Log("ProcessDValue - Value of d set to: " + d);
    }
    
    void Update()
    {
        ProcessFValue(f);
        ProcessEValue(e);
        ProcessDValue(d);
        StartCoroutine(VerifDie());
        StartCoroutine(IntervalFunction());
    }
    private IEnumerator VerifDie()
    {
        //Debug.Log("Update - d is 1, waiting for 2 seconds...");
        //yield return new WaitForSeconds(intervalDurati);

        while (g == 1)
        {
            //Debug.Log("sudah ada di VerifDie");
            if (e == 2)
            {
                RythemDisplay2.SetActive(false);
                Debug.Log("matiin rythemdisplay1 di VerifDie");
            }
            else if (e == 2 && f == 2)
            {
                d = 1;
                Debug.Log("d menjadi 1 di VerifDie");
                g = 2;
            }
            yield break;
            //yield return null; // Ini dibutuhkan agar coroutine dapat melanjutkan pada setiap frame
        }
    }
    private IEnumerator IntervalFunction(){
       yield return new WaitForSeconds(intervalDurati);
       while(d == 1)
       {
            g = 1;
            f = 1;
            e = 1;
            //Debug.Log("Update - d is 1, waiting for 2 seconds...");
            DisableGameObject();
          Debug.Log("DisableGameObject di IntervalFunction");
          //Debug.Log("Update - Disabled game objects, waiting for 5 seconds...");
          yield return new WaitForSeconds(intervalDuration);
          d = 2;
          //Debug.Log("Update - Value of d set to 0");
          EnableGameObject();
          Debug.Log("EnableGameObject di IntervalFunction");
          //Debug.Log("Update - Enabled game objects");
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
