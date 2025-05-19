using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parent = collision.transform.parent;
        GameObject.Destroy(collision.gameObject);

        while(parent != null )
        {
            GameObject toDestroy = parent.gameObject;
            parent = parent.parent;
            GameObject.Destroy(toDestroy);
        }
    }
}
