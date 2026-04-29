using UnityEngine;

public class Sc_Bone : MonoBehaviour
{
    public float scaleAmount = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale *= scaleAmount;
            Destroy(gameObject);
        }
    }
}
