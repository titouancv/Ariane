
using UnityEngine;

public class ptsfaible : MonoBehaviour
{
    public GameObject objectToDestroy;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//v�rifier si le player rentre en collision
        {
            Destroy(objectToDestroy);
        }
    }
}
