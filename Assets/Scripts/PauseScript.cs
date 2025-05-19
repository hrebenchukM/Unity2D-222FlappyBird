using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private GameObject content;
    private Slider pipeIntervalSlider;
    private Slider pipeGapSlider;
    void Start()
    {
        content = transform.Find("Content").gameObject;
        pipeIntervalSlider  = transform.Find("Content/PipeIntervalSlider").GetComponent<Slider>();
        pipeGapSlider = transform.Find("Content/PipeGapSlider").GetComponent<Slider>();
    }

  
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (content.activeInHierarchy) 
            {
                content.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                content.SetActive(true);
                Time.timeScale = 0.0f;
            }

        }

    }

    public void OnButtonCklick()
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void PipeIntervalValueChanged(float value)
    {
        SpawnerScript.pipeIntervalLevel = 1.0f -  value; 
    }

    public void PipeGapValueChanged(float value)
    {
        SpawnerScript.pipeGapLevel = Mathf.Lerp(5.0f, 7.0f, 1.0f - value);
    }
}
