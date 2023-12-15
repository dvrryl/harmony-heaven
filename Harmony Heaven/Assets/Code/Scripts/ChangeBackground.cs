using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject backgroound1;
    public GameObject backgroound2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundChanger()
    {
        backgroound1.SetActive(false);
        backgroound2.SetActive(true);
    }
}
