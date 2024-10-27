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
            Invoke("EnableCollider", 0.2f); // �������� � 0.2 ������� ����� ���������� ����������
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
