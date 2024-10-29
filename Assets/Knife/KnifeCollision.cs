using UnityEngine;
using TMPro;

public class KnifeCollision : MonoBehaviour
{
    public bool isHandleFirst = false; // ����������, ��������� �� ��� ������ ������
    public static int redScore = 0; // ���� �������� ������
    public static int blueScore = 0; // ���� ������ ������

    public TMP_Text scoreText; 

    private bool isOnWheel = false;
    public bool isRed; 
    
    
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
        else if (collision.CompareTag("ScorePointRed") && !isHandleFirst && isRed)
        {
            // ������� ����� �������� ����
            redScore++;
            UpdateScoreText();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ScorePointBlue") && !isHandleFirst && !isRed)
        {
            // ����� ����� �������� ����
            blueScore++;
            UpdateScoreText();
            Destroy(gameObject);
        }
    }

    void UpdateScoreText()
    {
        KnifeThrow.instance.scoreText.text = $"{blueScore}\n" +
                                             $"{redScore}";
    }
}