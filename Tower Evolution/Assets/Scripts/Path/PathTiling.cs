using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTiling : MonoBehaviour
{
    private Renderer pathRenderer;
    
    private List<Material> materials = new List<Material>();

    private Material newMaterial;

    void Start()
    {
        pathRenderer = GetComponent<Renderer>();

        newMaterial = new Material(pathRenderer.material);
        newMaterial.mainTextureScale = new Vector2(1, transform.localScale.y);
        materials.Add(newMaterial);

        pathRenderer.materials = materials.ToArray();
    }
}