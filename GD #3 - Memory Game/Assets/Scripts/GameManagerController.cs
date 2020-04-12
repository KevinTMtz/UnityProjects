using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public Sprite[] spritesArray;
    public CardController[] cards; 

    int activeCard1;
    int activeCard2; 

    int[] randomFront = new int[6] {0,0,1,1,2,2};
    
    public static int cardsFlipped;  
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<3; i++) {
            int tempRandom1 = Random.Range(0,5);
            int tempRandom2 = 0;

            while (true) {
                tempRandom2 = Random.Range(0,5);
                if (tempRandom1 != tempRandom2)
                    break;
            }

            int temp = randomFront[tempRandom1];
            randomFront[tempRandom1] = randomFront[tempRandom2];
            randomFront[tempRandom2] = temp;
        }

        for (int i=0; i<6; i++) {
            cards[i].Front = spritesArray[randomFront[i]];
            cards[i].index = randomFront[i];
        }

        cardsFlipped = 0;
        activeCard1 = -1;
        activeCard2 = -1; 
    }

    void Update()
    {   
        for (int i=0; i<6; i++) {
            if (cards[i].active && activeCard1 == -1) {
                activeCard1 = i;
            }
            
            if (cards[i].active && activeCard1 != i) {
                activeCard2 = i;
            } 
        }

        if (cardsFlipped == 2 && (activeCard1!=-1 && activeCard2!=-1)) {
            if (cards[activeCard1].index == cards[activeCard2].index) {
                cards[activeCard1].showBack();
                cards[activeCard2].showBack();
                cards[activeCard1].isKill = true;                
                cards[activeCard2].isKill = true;   
            } else {
                cards[activeCard1].showBack();
                cards[activeCard2].showBack();
            }
            activeCard1 = -1;
            activeCard2 = -1;        
        }
    }
}
