using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isPlaying;

    // For loading
    private GameObject newGameObject;
    private int counter;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // For saving at editing
    public void SaveGame() {
        SaveSystem.SaveGameData();
    }

    // For loading at editing
    public void LoadGame() {
        GameData gameData = SaveSystem.LoadGameData();
        ReadLoadFile(gameData);
    }

    // For saving at playing
    public void SaveGameAtPlay() {
        SaveSystemAtPlay.SaveGameData();
    }

    // For loading at end playing
    public void LoadGameAtPlay() {
        GameData gameData = SaveSystemAtPlay.LoadGameData();
        ReadLoadFile(gameData);
    }

    private void ReadLoadFile(GameData gameData) {
        foreach (Transform child in GameObject.Find("- Game Elements -").transform) {
           Destroy(child.gameObject);
        }

        foreach (Transform child in GameObject.Find("- Bullets -").transform) {
           Destroy(child.gameObject);
        }

        counter = 0;

        if (gameData != null)
            for (int i=0; i<gameData.types.Count; i++) {
                newGameObject = Instantiate(Resources.Load("Prefabs/"+gameData.types[i], typeof(GameObject))) as GameObject;

                Vector3 position;
                position.x = gameData.positions[i][0];
                position.y = gameData.positions[i][1];
                position.z = gameData.positions[i][2];

                newGameObject.transform.position = position;

                if (gameData.types[i].Equals("PingPongPlatform")) {
                    int count = 0;
                    foreach (Transform child in newGameObject.transform) {
                        Vector3 childPosition;
                        childPosition.x = gameData.childPositions[counter][count];
                        childPosition.y = gameData.childPositions[counter][count+1];
                        childPosition.z = gameData.childPositions[counter][count+2];

                        child.position = childPosition;

                        count += 3;
                    }

                    counter++;
                }

                newGameObject.transform.SetParent(GameObject.Find("- Game Elements -").transform);
            }
        else {
            Debug.Log("There is not saved data");
        }
    }
}
