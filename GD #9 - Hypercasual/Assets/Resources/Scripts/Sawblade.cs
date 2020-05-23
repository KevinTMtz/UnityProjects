using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    public Sprite[] saws;
    public float speed;
    public int speed2;
    private Rigidbody2D rb;
    private void Start()
    {
        int selected = Random.Range(0, saws.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = saws[selected];
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed2, ForceMode2D.Impulse);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed*Time.deltaTime));
    }

}
