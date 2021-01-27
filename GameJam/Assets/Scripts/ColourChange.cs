using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private Material mat;
    public float speed;

    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (mat.color.a > 0)
        {
            Color newColor = mat.color;
            newColor.a -= Time.deltaTime * speed;
            mat.color = newColor;
            gameObject.GetComponent<MeshRenderer>().material = mat;
        }
    }

}
