using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public static float LevelPxWidth;
    public static float LevelPxHeight;

    public int LevelWidth;
    public int LevelHeight;

    public GameObject TerrainContainer;
    public GameObject[] Terrains;

    public float PropSpawnChance;

    public GameObject PropsContainer;
    public GameObject[] Props;

    public float SpriteDefPxWidth;
    public float SpriteDefPxHeight;
    public float SpriteScale;

    void Awake()
    {
        if (Terrains.Length == 0)
        {
            return;
        }

        LevelPxWidth = LevelWidth * SpriteDefPxWidth * SpriteScale;
        LevelPxHeight = LevelHeight * SpriteDefPxHeight * SpriteScale;

        for (int i = 0; i < LevelWidth; i++)
        {
            for (int j = 0; j < LevelHeight; j++)
            {
                float spriteScaledPxWidth = SpriteDefPxWidth * SpriteScale;
                float spriteScaledPxHeight = SpriteDefPxHeight * SpriteScale;

                float spriteX = i * spriteScaledPxWidth + spriteScaledPxWidth / 2;
                float spriteY = j * spriteScaledPxHeight + spriteScaledPxHeight / 2;

                GameObject terrain = (GameObject)Instantiate(
                    Terrains[Random.Range(0, Terrains.Length - 1)],
                    new Vector3(spriteX, spriteY),
                    Quaternion.identity
                );

                terrain.transform.localScale = new Vector3(SpriteScale, SpriteScale, SpriteScale);

                terrain.transform.parent = TerrainContainer.transform;
            }
        }
    }
}
