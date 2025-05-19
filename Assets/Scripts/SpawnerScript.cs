using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;  // серіалізувати можна ресурси (не тільки числа)

    [SerializeField]
    private GameObject cloudPrefab;

    [SerializeField]
    private GameObject lifePrefab;


    [SerializeField]
    private GameObject[] foodPrefabs;

    // Реалізація таймера (періодичних подій)
    private float timeout = 5.0f;
    private float timeLeft;
    private float timeLeftFood;
    private float timeLeftCloud;

    void Start()
    {
        timeLeft = 0;
        timeLeftFood = timeout / 2.0f;
        timeLeftCloud = timeout / 1.5f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = timeout;
            SpawnPipe();
            if (Random.Range(0f, 1f) < 0.05f)
            {
                SpawnLife();
            }
        }
        timeLeftFood -= Time.deltaTime;
        if (timeLeftFood <= 0)
        {
            timeLeftFood = timeout;
            SpawnFood();
        }
        timeLeftCloud -= Time.deltaTime;
        if (timeLeftCloud <= 0)
        {
            timeLeftCloud = timeout;
            SpawnCloud();
        }
     
    }

    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);       // ~ new pipePrefab
        pipe.transform.position = this.transform.position    // точка Spawner
            + Vector3.up * Random.Range(-1.5f, 1.5f);        // + випадкове зміщення по вертикалі
    }
    private void SpawnFood()
    {
        GameObject prefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
        var food = Instantiate(prefab);
        food.transform.position = this.transform.position + Vector3.up * Random.Range(-3f, 3f);
        food.transform.localEulerAngles  = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    private void SpawnCloud()
    {
        var cloud = Instantiate(cloudPrefab);
        cloud.transform.position = transform.position + new Vector3(10f, Random.Range(-2f, 2f), 0); 
        cloud.transform.localScale *= Random.Range(0.5f, 1.5f); 

    }
    private void SpawnLife()
    {
        var life = Instantiate(lifePrefab);
        life.transform.position = transform.position + new Vector3(10f, Random.Range(-1f, 1f), 0);

    }
}
