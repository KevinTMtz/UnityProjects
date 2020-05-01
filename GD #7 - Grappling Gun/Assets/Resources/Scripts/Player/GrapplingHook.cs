using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private Transform hookStartTransform;
    private Vector3 hookStart;
    private Vector3 hookEnd;

    private Animator animator;
    private DistanceJoint2D joint;
    private LineRenderer line;

    private bool isHookActive;
    
    // Start is called before the first frame update
    void Start()
    {
        isHookActive = false;
        hookStartTransform = GameObject.Find("Hook").transform;
        animator = GetComponent<Animator>();
        joint = GetComponent<DistanceJoint2D>();
        line = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GrapplingHookShoot();
        UpdateLine();
    }

    void GrapplingHookShoot() {
        if (Input.GetMouseButtonDown(0) && !isHookActive && Time.timeScale != 0) {
            SoundManager.PlaySound("Chain");
            hookStart = hookStartTransform.position;
            hookEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            animator.SetBool("Jumping", true);
            isHookActive = true;
            joint.enabled = true;
            //joint.distance = Vector3.Distance(hookStart, hookEnd);
            joint.connectedAnchor = new Vector2(hookEnd.x, hookEnd.y);
            joint.autoConfigureDistance = false;

            line.SetPosition(0, new Vector3(hookStart.x, hookStart.y, -1));
            line.SetPosition(1, new Vector3(hookEnd.x, hookEnd.y, -1));            
        } else if (Input.GetMouseButtonDown(0) && isHookActive) {
            joint.autoConfigureDistance = true;
            joint.enabled = false;
            isHookActive = false;
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
        }
    }

    void UpdateLine() {
        if (isHookActive) {
            animator.SetBool("Jumping", true);
            hookStart = hookStartTransform.position;
            line.SetPosition(0, new Vector3(hookStart.x, hookStart.y, -1));
            line.SetPosition(1, new Vector3(hookEnd.x, hookEnd.y, -1));
        }
    }

    void FixedUpdate() {
        if (joint.autoConfigureDistance == false) {
            joint.distance -= 0.05f;
        }
    }

    public bool IsHookActive {
        set { isHookActive = value; }
    }
}
