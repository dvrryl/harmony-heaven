using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{
    public string sortingLayerName = "Foreground"; // Set your desired sorting layer
    public int orderInLayer = 10; // Set your desired order in layer

    void Start()
    {
        // Set sorting layer and order in layer
        GetComponent<Renderer>().sortingLayerName = sortingLayerName;
        GetComponent<Renderer>().sortingOrder = orderInLayer;
    }
}
