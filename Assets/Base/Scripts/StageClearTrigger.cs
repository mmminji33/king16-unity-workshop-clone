using UnityEngine;

public class StageClearTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // GameManager.Instance.LoadNextRandomStage();
            
            // 임시코드
            GameManager.Instance.ShowGameClear();
            SoundManager.Instance.StopBgm();
        }
    }
}
