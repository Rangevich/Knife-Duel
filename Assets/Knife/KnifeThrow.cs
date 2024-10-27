using UnityEngine;
using UnityEngine.UI;

public class KnifeThrow : MonoBehaviour
{
    public GameObject redKnifePrefab;        // Префаб красного ножа
    public GameObject blueKnifePrefab;       // Префаб синего ножа
    public Transform knifeSpawnPointRed;     // Точка спавна для красного ножа
    public Transform knifeSpawnPointBlue;    // Точка спавна для синего ножа
    public float throwForce = 10f;           // Сила броска ножа

    public Button buttonRedBladeForward;     // Кнопка для броска красным игроком лезвием вперед
    public Button buttonRedHandleForward;    // Кнопка для броска красным игроком ручкой вперед
    public Button buttonBlueBladeForward;    // Кнопка для броска синим игроком лезвием вперед
    public Button buttonBlueHandleForward;   // Кнопка для броска синим игроком ручкой вперед

    void Start()
    {
        // Подключаем методы к кнопкам красного игрока
        buttonRedBladeForward.onClick.AddListener(() => ThrowKnife(true, knifeSpawnPointRed, redKnifePrefab));
        buttonRedHandleForward.onClick.AddListener(() => ThrowKnife(false, knifeSpawnPointRed, redKnifePrefab));

        // Подключаем методы к кнопкам синего игрока
        buttonBlueBladeForward.onClick.AddListener(() => ThrowKnife(true, knifeSpawnPointBlue, blueKnifePrefab));
        buttonBlueHandleForward.onClick.AddListener(() => ThrowKnife(false, knifeSpawnPointBlue, blueKnifePrefab));
    }

    void ThrowKnife(bool isBladeFirst, Transform spawnPoint, GameObject knifePrefab)
    {
        // Создаем нож и применяем силу броска
        GameObject knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = knife.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0; // Отключаем гравитацию для ножа
        rb.isKinematic = false; // Убедитесь, что нож не кинематический, чтобы он мог двигаться

        // Рассчитываем направление броска к центру колеса
        Vector2 throwDirection = (Vector2.zero - (Vector2)spawnPoint.position).normalized;
        rb.velocity = throwDirection * throwForce;

        if (!isBladeFirst)
        {
            // Поворачиваем нож на 180 градусов, если он летит ручкой вперед
            knife.transform.Rotate(0f, 0f, 180f);
        }
    }
}
