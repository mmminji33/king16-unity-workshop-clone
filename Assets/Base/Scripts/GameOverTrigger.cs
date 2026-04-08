using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.OnGameOver();
            SoundManager.Instance.PlaySfx("SFX/Common/stage-fail");
            SoundManager.Instance.StopBgm();
        }
    }

    // 만약 Collider의 Is Trigger가 꺼져 있다면 아래 함수를 사용하세요
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.OnGameOver();
        }
    }
    */
}