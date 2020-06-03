using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private LineRenderer rendererLine;

    // Start is called before the first frame update
    void Start()
    {
        rendererLine = GetComponent<LineRenderer>();

        rendererLine.startColor = Color.black;
        rendererLine.endColor = Color.black;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        rendererLine.material = whiteDiffuseMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
