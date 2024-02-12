using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GifTexture : MonoBehaviour
{
    [SerializeField] private float tileX = 1;
    [SerializeField] private float tileY = 1;
    Mesh _mesh;
    private Material _mat;

    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        _mesh = GetComponent<MeshFilter>().mesh;
    }

    private void OnValidate()
    {
        UpdateTextureTiling();
    }

    void UpdateTextureTiling()
    {
        _mat.mainTextureScale = new Vector2((_mesh.bounds.size.x *
                                             transform.localScale.x) / 100 * tileX,
            (_mesh.bounds.size.y * transform.localScale.y) / 100 * tileY);
    }
}