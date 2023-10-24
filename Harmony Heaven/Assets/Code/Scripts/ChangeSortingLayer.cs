using UnityEngine;

public class ChangeSortingLayer : MonoBehaviour
{
    public string sortingLayerName = "Default"; 
    public int orderInLayer = 0; 

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        spriteRenderer.sortingLayerName = sortingLayerName;
        spriteRenderer.sortingOrder = orderInLayer;
    }
}
