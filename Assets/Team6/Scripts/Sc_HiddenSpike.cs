using UnityEngine;

public class HiddenSpike : MonoBehaviour
{   
    public Transform player;
    public float distance= 3f;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        float d = Vector2.Distance(player.position, transform.position);
        if (d < distance)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }   
    }

}
