using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //[SerializeField]
    private float speed = 4.0f; // 2.0f 4.0f 7.0f
    void Start()
    {

    }
    void Update()
    {
        //this.transform.Translate(Vector3.left * speed);
        this.transform.Translate(Time.deltaTime * speed * Vector3.left, Space.World);
    }
}
