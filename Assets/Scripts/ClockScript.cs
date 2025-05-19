using UnityEngine;

public class ClockScript : MonoBehaviour
{ 
    private TMPro.TextMeshProUGUI clock;
    private float time;
    void Start()
    {
        clock = GetComponent<TMPro.TextMeshProUGUI>();
        time = 0f;
    }

 
    void Update()
    {
        time += Time.deltaTime;
        int t = (int)time;
        int h = t / 3600;
        int m = (t % 3600) / 60;
        int s = t % 60;
        clock.text = $"{h:00}:{m:00}:{s:00}";
    }
}
