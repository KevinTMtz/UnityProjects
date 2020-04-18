using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPlatform : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    
    public Vector3 currentTarget;
    public Transform currentTargetTransform;

    public float speed;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start() {
        currentTarget = target1.position;
        currentTargetTransform = target1;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() {
        UpdateCurrentTargetPosition();
        
        if (gameController.isPlaying)
            Move();
    }

    public void UpdateCurrentTargetPosition() {
        currentTarget = currentTargetTransform.position;
    }

    private void Move() {
        float distance = Vector3.Distance(transform.position, currentTarget);
        transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * speed) / distance);

        if (transform.position == target1.position) {
            currentTarget = target2.position;
            currentTargetTransform = target2;
        } else if (transform.position == target2.position) {
            currentTarget = target1.position;
            currentTargetTransform = target1;
        }
    }
}
