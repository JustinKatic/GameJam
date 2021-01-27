using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    Color color;
    Color altColor;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        altColor = new Vector4(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, 0);
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(color, altColor, Time.deltaTime * speed);

    }

    // Update is called once per frame
    void Update()
    {
       // gameObject.GetComponent<Renderer>().material.color = altColor;
    }
}
