using UnityEngine;

public class KnifeCollisionDelay : MonoBehaviour
{
    private Collider2D knifeCollider;

    void Start()
    {
        knifeCollider = GetComponent<Collider2D>();
        if (knifeCollider != null)
        {
            knifeCollider.enabled = false;
            Invoke("EnableCollider", 0.2f); // Задержка в 0.2 секунды перед включением коллайдера
        }
    }

    void EnableCollider()
    {
        if (knifeCollider != null)
        {
            knifeCollider.enabled = true;
        }
    }
}
