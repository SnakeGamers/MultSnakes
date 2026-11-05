using UnityEngine;

public class BackGround : MonoBehaviour
{

    public GameObject tile;
    public GameObject fortile;

    [SerializeField] private GameObject fieldPrefab;

    void Start()
    {
        int width = 10;  
        int height = 5;  
        float tileSize = 1f; 

        // смещение, чтобы было по центру (0,0,0)
        float offsetX = (width - 1) * tileSize / 2f;
        float offsetY = (height - 1) * tileSize / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                
                GameObject prefabToSpawn = ((x + y) % 2 == 0) ? tile : fortile;

                Vector3 spawnPos = new Vector3(x * tileSize - offsetX, y * tileSize - offsetY, 0);

                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, transform);
            }
        }
    }

}