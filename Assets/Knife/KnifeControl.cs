using UnityEngine;
using UnityEngine.UI;

public class KnifeControl : MonoBehaviour
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
        buttonRedBladeForward.onClick.AddListener(() => ThrowKnife(true, true));
        buttonRedHandleForward.onClick.AddListener(() => ThrowKnife(false, true));

        // Подключаем методы к кнопкам синего игрока
        buttonBlueBladeForward.onClick.AddListener(() => ThrowKnife(true, false));
        buttonBlueHandleForward.onClick.AddListener(() => ThrowKnife(false, false));
    }

    void ThrowKnife(bool isBladeFirst, bool isRedPlayer)
    {
        // Определяем, какой игрок бросает нож и используем соответствующую точку спавна
        Transform spawnPoint = isRedPlayer ? knifeSpawnPointRed : knifeSpawnPointBlue;
        GameObject knifePrefab = isRedPlayer ? redKnifePrefab : blueKnifePrefab;

        // Создаем нож и применяем силу броска
        GameObject knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();

        if (isBladeFirst)
        {
            // Бросок ножа острием вперед
            rb.velocity = spawnPoint.up * throwForce;
        }
        else
        {
            // Бросок ножа ручкой вперед
            rb.velocity = spawnPoint.up * throwForce;
            knife.GetComponent<KnifeCollision>().isHandleFirst = true; // Устанавливаем, что нож бросается ручкой вперед
        }
    }
}
