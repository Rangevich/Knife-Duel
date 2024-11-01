using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KnifeThrow : MonoBehaviour
{
    public GameObject redKnifePrefab;        // ������ �������� ����
    public GameObject blueKnifePrefab;       // ������ ������ ����
    public Transform knifeSpawnPointRed;     // ����� ������ ��� �������� ����
    public Transform knifeSpawnPointBlue;    // ����� ������ ��� ������ ����
    public float throwForce = 10f;           // ���� ������ ����

    public Button buttonRedBladeForward;     // ������ ��� ������ ������� ������� ������� ������
    public Button buttonRedHandleForward;    // ������ ��� ������ ������� ������� ������ ������
    public Button buttonBlueBladeForward;    // ������ ��� ������ ����� ������� ������� ������
    public Button buttonBlueHandleForward;   // ������ ��� ������ ����� ������� ������ ������
    public TMP_Text scoreText;               // UI ������� ��� ����������� �����

    public static KnifeThrow instance;
    void Start()
    {
        // ���������� ������ � ������� �������� ������
        buttonRedBladeForward.onClick.AddListener(() => ThrowKnife(true, knifeSpawnPointRed, redKnifePrefab));
        buttonRedHandleForward.onClick.AddListener(() => ThrowKnife(false, knifeSpawnPointRed, redKnifePrefab));

        // ���������� ������ � ������� ������ ������
        buttonBlueBladeForward.onClick.AddListener(() => ThrowKnife(true, knifeSpawnPointBlue, blueKnifePrefab));
        buttonBlueHandleForward.onClick.AddListener(() => ThrowKnife(false, knifeSpawnPointBlue, blueKnifePrefab));

        instance = this;
    }

    void ThrowKnife(bool isBladeFirst, Transform spawnPoint, GameObject knifePrefab)
    {
        // ������� ��� � ��������� ���� ������
        GameObject knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = knife.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0; // ��������� ���������� ��� ����
        rb.isKinematic = false; // ���������, ��� ��� �� ��������������, ����� �� ��� ���������

        // ������������ ����������� ������ � ������ ������
        Vector2 throwDirection = (Vector2.zero - (Vector2)spawnPoint.position).normalized;
        rb.velocity = throwDirection * throwForce;

        if (!isBladeFirst)
        {
            // ������������ ��� �� 180 ��������, ���� �� ����� ������ ������
            knife.transform.Rotate(0f, 0f, 180f);
        }
        knife.GetComponent<KnifeCollision>().isHandleFirst = Vector2.Dot(throwDirection, Vector2.up) > 0 ? !isBladeFirst : isBladeFirst;
    }
}
