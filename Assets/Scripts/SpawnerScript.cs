using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private static float _pipeIntervalLevel = 0.5f;
    public static float pipeIntervalLevel
    {
        get {  return _pipeIntervalLevel; }
        set { _pipeIntervalLevel = value; timeLeftFood = timeLeft + timeout / 2.0f; }
    }

    private static float _pipeGapLevel = 6.0f;
    public static float pipeGapLevel
    {
        get { return _pipeGapLevel; }
        set { _pipeGapLevel = Mathf.Clamp(value, 5.0f, 7.0f); timeLeftFood = timeLeft + timeout / 2.0f; }
    }

    [SerializeField]
    private GameObject pipePrefab;  // серіалізувати можна ресурси (не тільки числа)

    [SerializeField]
    private GameObject cloudPrefab;

    [SerializeField]
    private GameObject lifePrefab;


    [SerializeField]
    private GameObject[] foodPrefabs;

    // Реалізація таймера (періодичних подій)
    private static float timeout => 1.0f + 2.0f * pipeIntervalLevel;
    private static float timeLeft;
    private static float timeLeftFood;
    private  float timeLeftCloud;

    void Start()
    {
        timeLeft = 0;
        timeLeftFood =timeLeft+ timeout / 2.0f;
        timeLeftCloud = timeout / 1.5f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = timeout;
            SpawnPipe();
            if (Random.Range(0f, 1f) < 0.25f)
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
        float gap = pipeGapLevel;
        pipe.transform.position = this.transform.position    // точка Spawner
            + Vector3.up * Random.Range(-1.5f, 1.5f);        // + випадкове зміщення по вертикалі
        var pipescript= pipe.GetComponent<PipeScript>();
        pipescript.SetGap(gap);
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
