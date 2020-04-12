using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public SpriteRenderer TheSpriteRenderer;
    public Sprite Front;
    public Sprite Back;
    
    public bool isKill;
    
    public bool active;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        isKill = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKill) {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown() {
        if (!active) {
            showFront();
        } else {
            showBack();
        }
    }

    public void showFront() {
        TheSpriteRenderer.sprite = Front;
        active = true;
        GameManagerController.cardsFlipped++;
    }

    public void showBack() {
        TheSpriteRenderer.sprite = Back;
        active = false;
        GameManagerController.cardsFlipped--;
    }
}
