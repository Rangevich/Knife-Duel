using UnityEngine;
using UnityEngine.UI;

public class KnifeControl : MonoBehaviour
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

    void Start()
    {
        // ���������� ������ � ������� �������� ������
        buttonRedBladeForward.onClick.AddListener(() => ThrowKnife(true, true));
        buttonRedHandleForward.onClick.AddListener(() => ThrowKnife(false, true));

        // ���������� ������ � ������� ������ ������
        buttonBlueBladeForward.onClick.AddListener(() => ThrowKnife(true, false));
        buttonBlueHandleForward.onClick.AddListener(() => ThrowKnife(false, false));
    }

    void ThrowKnife(bool isBladeFirst, bool isRedPlayer)
    {
        // ����������, ����� ����� ������� ��� � ���������� ��������������� ����� ������
        Transform spawnPoint = isRedPlayer ? knifeSpawnPointRed : knifeSpawnPointBlue;
        GameObject knifePrefab = isRedPlayer ? redKnifePrefab : blueKnifePrefab;

        // ������� ��� � ��������� ���� ������
        GameObject knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();

        if (isBladeFirst)
        {
            // ������ ���� ������� ������
            rb.velocity = spawnPoint.up * throwForce;
        }
        else
        {
            // ������ ���� ������ ������
            rb.velocity = spawnPoint.up * throwForce;
            knife.GetComponent<KnifeCollision>().isHandleFirst = true; // �������������, ��� ��� ��������� ������ ������
        }
    }
}
