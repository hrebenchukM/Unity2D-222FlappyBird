using UnityEngine;

public class PassedTextScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();   
    }

    
    void Update()
    {
        text.text = BirdScript.pipesPassed.ToString();
    }
}
