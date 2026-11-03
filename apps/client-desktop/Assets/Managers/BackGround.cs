using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private GameObject fieldPrefab;

    void Start()
    {
        
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 position = new Vector3(i, j, 1);
                Instantiate(fieldPrefab, position, Quaternion.identity);
            }
        }

    }

}