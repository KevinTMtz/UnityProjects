using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public List<float[]> positions = new List<float[]>();
    public List<float[]> childPositions = new List<float[]>();
    public List<string> types = new List<string>(); 

    public GameData () {
        foreach (Transform child in GameObject.Find("- Game Elements -").transform) {
            float[] position = new float[3];
            position[0] = child.position.x;
            position[1] = child.position.y;
            position[2] = child.position.z;

            positions.Add(position);
            
            types.Add(child.gameObject.name.Substring(0, child.gameObject.name.Length-7));

            if (types[types.Count-1].Equals("PingPongPlatform")) {
                float[] positionChild = new float[9];

                int count = 0;
                int counter = 0;
                foreach (Transform childOFChild in child) {
                    positionChild[count] = childOFChild.position.x;
                    positionChild[count+1] = childOFChild.position.y;
                    positionChild[count+2] = childOFChild.position.z;

                    count += 3;

                    if (counter == 0 && childOFChild.childCount > 3) { 
                        for(int i = 3; i < childOFChild.childCount; i++) {
                            Transform temp = childOFChild.GetChild(i);

                            float[] position2 = new float[3];
                            position2[0] = temp.position.x;
                            position2[1] = temp.position.y;
                            position2[2] = temp.position.z;

                            positions.Add(position2);
                            types.Add(temp.gameObject.name.Substring(0, temp.gameObject.name.Length-7));
                        }
                    }
                }

                childPositions.Add(positionChild);
                counter++;
            }
        }
    }
}
