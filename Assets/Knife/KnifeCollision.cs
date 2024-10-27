using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public bool isHandleFirst = false; // Определяет, бросается ли нож ручкой вперед

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
        }
        else if (collision.CompareTag("Knife") && !isHandleFirst)
        {
            // Если нож сталкивается с другим ножом острием вперед
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.velocity = randomDirection * 5f; // Отлетает в случайном направлении с определенной скоростью
            }

            // Уничтожаем нож после небольшой задержки
            Destroy(gameObject, 0.5f);
        }
    }
}