using UnityEngine;
using TMPro;

public class KnifeCollision : MonoBehaviour
{
    public bool isHandleFirst = false; // Определяет, бросается ли нож ручкой вперед
    public static int redScore = 0; // Очки красного игрока
    public static int blueScore = 0; // Очки синего игрока

    public TMP_Text scoreText; // UI элемент для отображения счета

    public bool isOnWheel = false;
    
    void Start()
    {
        UpdateScoreText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wheel") && !isHandleFirst)
        {
            // Если нож сталкивается с колесом острием вперед
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Останавливаем движение ножа
                rb.isKinematic = true; // Делаем нож кинематическим
            }

            // Присоединяем нож к колесу, чтобы он вращался вместе с ним
            transform.SetParent(collision.transform);
            isOnWheel = true;
        }
        else if (collision.CompareTag("Wheel") && isHandleFirst)
        {
            // Если нож, брошенный ручкой вперед, сталкивается с колесом, он уничтожается
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Knife") && isHandleFirst)
        {
            // Если нож сталкивается с другим ножом, оба ножа уничтожаются
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Knife"))
        {
            // Если нож сталкивается с другим ножом острием вперед, нож уничтожаются
            if (!isOnWheel)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("ScorePointRed") && !isHandleFirst && gameObject.CompareTag("RedKnife"))
        {
            // Красный игрок получает очко
            redScore++;
            UpdateScoreText();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ScorePointBlue") && !isHandleFirst && gameObject.CompareTag("BlueKnife"))
        {
            // Синий игрок получает очко
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
