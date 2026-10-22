using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private GameHandler gameMasterScript;

    [SerializeField] private float LookSensitivity = 0.2f;
    [SerializeField] private float LookAngleLimit = 90f;

    private Camera mainCamera;

    private float lookAngle = 0.0f;

    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();

        mainCamera = GetComponentInChildren<Camera>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void Update()
    {
        if (gameMasterScript.gameState == 1) return;
        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());
        HandleLooking(mouseDelta);
    }

    private void HandleLooking(Vector2 mouseDelta)
    {
        lookAngle -= mouseDelta.y * LookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -LookAngleLimit, LookAngleLimit);

        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x, 0);
    }
}
