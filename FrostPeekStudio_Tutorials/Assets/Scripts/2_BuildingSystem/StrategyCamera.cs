using UnityEngine;

public class StrategyCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    private Transform myTransform;

    [SerializeField] float keyboardMovementSpeed = 5f;
    [SerializeField] float panningSpeed = 10f;

    [SerializeField] float keyboardRotationSpeed = 15f;
    [SerializeField] float mouseRotationSpeed = 10f;

    [SerializeField] float scrollWheelZoomingSensitivity = 25f;
    [SerializeField] float minZoom = 5f;
    [SerializeField] float maxZoom = 15f;

    [SerializeField] float movementLerpTime = 10f;
    [SerializeField] float zoomLerpTime = 5f;

    private float zoomPos = 0;

    #region Input
    private readonly KeyCode MouseMoveKey = KeyCode.Mouse0;
    private readonly KeyCode mouseRotationKey = KeyCode.Mouse1;
    private readonly KeyCode rotateRightKey = KeyCode.Q;
    private readonly KeyCode rotateLeftKey = KeyCode.E;

    private Vector2 KeyboardInput => new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    private Vector2 MouseAxis => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    private int RotationDirection
    {
        get
        {
            bool rotateRight = Input.GetKey(rotateRightKey);
            bool rotateLeft = Input.GetKey(rotateLeftKey);
            if (rotateLeft && rotateRight) return 0;
            else if (rotateLeft && !rotateRight) return -1;
            else if (!rotateLeft && rotateRight) return 1;
            else return 0;
        }
    }
    #endregion
    private void Start()
    {
        myTransform = transform;
        newPosition = transform.position;
    }
    private void Update() => CameraUpdate();
    private void CameraUpdate()
    {
        Move();
        Rotation();
        Zoom();
    }
    private void Move()
    {
        LerpCameraPosition(new Vector3(KeyboardInput.x, 0, KeyboardInput.y), keyboardMovementSpeed);

        if (Input.GetKey(MouseMoveKey) && MouseAxis != Vector2.zero)
            LerpCameraPosition(new Vector3(-MouseAxis.x, 0, -MouseAxis.y), panningSpeed);
    }
    private Vector3 newPosition;
    private void LerpCameraPosition(Vector3 desiredMove, float speed) // TRIED MOVE TOWARDS
    {
        desiredMove *= Time.deltaTime;
        desiredMove = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * desiredMove;
        float heightMultiplier = cameraTransform.position.y / minZoom;

        newPosition += (desiredMove * speed * heightMultiplier);
        myTransform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementLerpTime);
    }
    private void Rotation()
    {
        if (Input.GetKey(rotateRightKey) || Input.GetKey(rotateLeftKey))
            myTransform.Rotate(Vector3.up, RotationDirection * Time.deltaTime * keyboardRotationSpeed, Space.World);

        if (Input.GetKey(mouseRotationKey))
            myTransform.Rotate(Vector3.up, MouseAxis.x * Time.deltaTime * mouseRotationSpeed, Space.World);
    }
    private void Zoom()
    {
        zoomPos -= Input.mouseScrollDelta.y * Time.deltaTime * scrollWheelZoomingSensitivity;
        zoomPos = Mathf.Clamp01(zoomPos);

        float target = Mathf.Lerp(minZoom, maxZoom, zoomPos);

        cameraTransform.localPosition =
        Vector3.Lerp(cameraTransform.localPosition, new Vector3(cameraTransform.localPosition.x, target, -target), Time.deltaTime * zoomLerpTime);
    }
}
