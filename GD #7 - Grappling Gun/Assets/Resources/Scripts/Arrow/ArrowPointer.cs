using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    private Vector3 target;
    private RectTransform pointerRectTransform;
    private GameController gameController;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        target = gameController.ActivePosition;
        Vector3 fromPosition = player.position;
        fromPosition.z = 0f;
        Vector3 direction = (target - fromPosition).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
