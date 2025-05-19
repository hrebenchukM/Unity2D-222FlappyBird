using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BirdScript : MonoBehaviour
{
    [SerializeField] private float forceFactor = 100.0f;    // 1.0e2

    [SerializeField] private Image healthIndicator;
    [SerializeField] private GameObject alertCanvas;
    [SerializeField] private TMPro.TextMeshProUGUI alertTitle;
    [SerializeField] private TMPro.TextMeshProUGUI triesTitle;

    [SerializeField] private Transform triesContainer;
    [SerializeField] private GameObject tryBirdPrefab;
    private Rigidbody2D rb;
    private float health;
    private int tries;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 100f;
        alertCanvas.SetActive(false);
        tries = 3;
        //triesTitle.text = tries.ToString();
        TriesDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * forceFactor);
        }
        health -= 5 * Time.deltaTime;
        if (health < 0 && Time.timeScale > 0f)
        {
            Loose("Погана спроба. Ви - не Ви, коли голодні...");
        }
        else
        {
            healthIndicator.fillAmount = health / 100f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            GameObject.Destroy(collision.gameObject);
            health = Mathf.Clamp(health + 50f, 0f, 100f);
        }
        else if (collision.CompareTag("Pipe"))
        {
            Loose("Погана спроба. Ви влучили в перешкоду");
        }
        else if (collision.CompareTag("Heart"))
        {
            GameObject.Destroy(collision.gameObject);
            tries = Mathf.Clamp(tries + 1, 0, 3);
            //triesTitle.text = tries.ToString();
            TriesDisplay();
        }
        Debug.Log(collision.tag);
    }

    private void Loose(string alertMessage)
    {
        tries -= 1;
        //triesTitle.text = tries.ToString();
        TriesDisplay();
        if (tries > 0)
        {
            alertTitle.text = alertMessage;
        }
        else
        {
            alertTitle.text = "Game Over";
        }
        alertCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnAlertButtonClick()
    {
        if(tries > 0)
        {
            foreach (var pipe in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                if (pipe.transform.parent != null)
                {
                    GameObject.Destroy(pipe.transform.parent.gameObject);
                }
                else
                {
                    GameObject.Destroy(pipe);
                }

            }
            foreach (var food in GameObject.FindGameObjectsWithTag("Food"))
            {
                GameObject.Destroy(food);
            }
            alertCanvas.SetActive(false);
            health = 100f;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        Time.timeScale = 1.0f;
    }


    private void TriesDisplay()
    {
        foreach (Transform t in triesContainer)
        {
            Destroy(t.gameObject);
        }

      
        for (int i = 0; i < tries; i++)
        {
            GameObject g = Instantiate(tryBirdPrefab, triesContainer);
            g.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }


}
