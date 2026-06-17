using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 只有玩家碰到才触发收集
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}