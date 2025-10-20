using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Takip Edilecek Nesne")]
    public Transform target;

    [Header("Kamera Ayarları")]
    public float height = 10f;         // Kameranın yüksekliği
    public float distance = 8f;        // Hedefin arkasındaki mesafe
    public float angle = 45f;          // Kameranın eğim açısı (üstten bakış açısı)
    public float smoothSpeed = 0.125f; // Takip yumuşaklığı

    private Vector3 refVelocity;       // SmoothDamp için geçici değişken

    void LateUpdate()
    {
        if (target == null)
            return;

        // Kameranın hedefe göre bakış yönü (ileriye doğru)
        Vector3 direction = Quaternion.Euler(angle, 0f, 0f) * Vector3.forward;

        // Hedefin arkasında, yukarıda olacak şekilde pozisyon hesapla
        Vector3 desiredPosition = target.position - direction * distance;
        desiredPosition.y = target.position.y + height;

        // Yumuşak geçiş
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref refVelocity, smoothSpeed);

        // Kameranın hedefe bakmasını sağla
        transform.LookAt(target.position + Vector3.up * 1.5f); // 1.5f = biraz yukarıya bak
    }
}