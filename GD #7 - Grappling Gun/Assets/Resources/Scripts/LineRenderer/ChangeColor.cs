using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private LineRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<LineRenderer>();

        renderer.startColor = Color.black;
        renderer.endColor = Color.black;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        renderer.material = whiteDiffuseMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
