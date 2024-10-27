using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public bool isHandleFirst = false; // ����������, ��������� �� ��� ������ ������

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wheel") && !isHandleFirst)
        {
            // ���� ��� ������������ � ������� ������� ������
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // ������������� �������� ����
                rb.isKinematic = true; // ������ ��� ��������������
            }

            // ������������ ��� � ������, ����� �� �������� ������ � ���
            transform.SetParent(collision.transform);
        }
        else if (collision.CompareTag("Knife") && !isHandleFirst)
        {
            // ���� ��� ������������ � ������ ����� ������� ������
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.velocity = randomDirection * 5f; // �������� � ��������� ����������� � ������������ ���������
            }

            // ���������� ��� ����� ��������� ��������
            Destroy(gameObject, 0.5f);
        }
    }
}