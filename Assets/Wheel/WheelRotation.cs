using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения колеса

    void Update()
    {
        // Вращаем колесо вокруг оси Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
