using UnityEngine;
using TMPro;

public class KnifeCollision : MonoBehaviour
{
    public bool isHandleFirst = false; // ����������, ��������� �� ��� ������ ������
    public static int redScore = 0; // ���� �������� ������
    public static int blueScore = 0; // ���� ������ ������

    public TMP_Text scoreText; // UI ������� ��� ����������� �����

    public bool isOnWheel = false;
    
    void Start()
    {
        UpdateScoreText();
    }

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
            isOnWheel = true;
        }
        else if (collision.CompareTag("Wheel") && isHandleFirst)
        {
            // ���� ���, ��������� ������ ������, ������������ � �������, �� ������������
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Knife") && isHandleFirst)
        {
            // ���� ��� ������������ � ������ �����, ��� ���� ������������
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Knife"))
        {
            // ���� ��� ������������ � ������ ����� ������� ������, ��� ������������
            if (!isOnWheel)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("ScorePointRed") && !isHandleFirst && gameObject.CompareTag("RedKnife"))
        {
            // ������� ����� �������� ����
            redScore++;
            UpdateScoreText();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ScorePointBlue") && !isHandleFirst && gameObject.CompareTag("BlueKnife"))
        {
            // ����� ����� �������� ����
            blueScore++;
            UpdateScoreText();
            Destroy(gameObject);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{redScore}" +
                $"{blueScore}";
        }
    }
}
