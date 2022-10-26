using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTiling : MonoBehaviour
{
    private new Renderer renderer;
    
    private List<Material> materials = new List<Material>();

    private Material newMaterial;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        newMaterial = new Material(renderer.material);
        newMaterial.mainTextureScale = new Vector2(1, transform.localScale.y);
        materials.Add(newMaterial);

        renderer.materials = materials.ToArray();
    }
}