using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // �������� �������� ������

    void Update()
    {
        // ������� ������ ������ ��� Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
