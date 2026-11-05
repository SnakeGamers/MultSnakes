using UnityEngine;
using System.Threading.Tasks;
public class Default : MonoBehaviour
{
    [SerializeField] private GameObject snakePrefab;
    private static GameObject Snake;
    private Snake snake;
    public Vector2[] vectors = new Vector2[3] 
    { 
        new Vector2(0, 0),
        new Vector2(1, 0),
        new Vector2(2, 0)
    };

    void Start()
    {
        Snake = Instantiate(snakePrefab, gameObject.transform);
        DestroySnake();
    }
    void Update()
    {
        
    }

    static async Task DestroySnake()
    {
        await Task.Delay(1000);
        Destroy(Snake);
    }


}
