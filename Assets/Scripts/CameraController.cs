using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Transform minBounds;

    [SerializeField]
    private Transform maxBounds;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        if (minBounds != null && maxBounds != null)
        {
            // ѕолучаем размеры камеры
            float cameraHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float cameraHalfHeight = Camera.main.orthographicSize;

            // ќграничение камеры в пределах minBounds и maxBounds с учетом размеров камеры
            newPosition.x = Mathf.Clamp(newPosition.x, minBounds.position.x + cameraHalfWidth, maxBounds.position.x - cameraHalfWidth);
            newPosition.y = Mathf.Clamp(newPosition.y, minBounds.position.y + cameraHalfHeight, maxBounds.position.y - cameraHalfHeight);
        }

        transform.position = newPosition;
    }
}