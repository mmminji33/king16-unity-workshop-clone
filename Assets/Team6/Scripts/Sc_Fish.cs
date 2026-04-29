using UnityEngine;

public class Sc_Fish : MonoBehaviour
{
    public float scaleAmount = 2f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale *= scaleAmount;
            Destroy(gameObject);
        }
    }
}
