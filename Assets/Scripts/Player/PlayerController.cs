using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private GameHandler gameMasterScript;
    private float Walkspeed = 5f;
    private float Runningspeed = 10f;

    private float Jumpforce = 8.0f;
    private float Gravity = 20.0f;

    public Camera playerCamera;

    private CharacterController characterController;

    public GameObject collectibles;
    private float totalPoids = 0;

    public CollectionHandler collectionHandler;
    private float playerPoids = 0;
    private float speedMult = 1f;

    private InputAction moveInput;
    private InputAction runInput;

    private InputAction jumpInput;
    private bool jumped = false;

    private float currentMoveSpeed = 0.0f;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        gameMasterScript = GameObject.Find("GameMaster").GetComponent<GameHandler>();
        // Pour récuperer la somme des poids de tout les collectibles
        characterController = GetComponentInChildren<CharacterController>();
        for (int i = 0; i < collectibles.transform.childCount; i++)
        {
            totalPoids += collectibles.transform.GetChild(i).GetComponent<CollectibleVariables>().poids;
        }

        moveInput = InputSystem.actions.FindAction("Move");
        runInput = InputSystem.actions.FindAction("Sprint");

        jumpInput = InputSystem.actions.FindAction("Jump");
        jumpInput.started += Jumped;

        currentMoveSpeed = Walkspeed;
    }

    private void Update()
    {
        if (gameMasterScript.gameState == 1) return;

        Vector2 moveVector = moveInput.ReadValue<Vector2>();

        if (!characterController.isGrounded) jumped = false;

        playerPoids = collectionHandler.playerPoids;
        if (totalPoids !=0) speedMult = 1f - (playerPoids / (totalPoids*2)); // A aucun objet collecté, speedMult est a 1, avec tout les objets collectés, speedMult est a 0.5 

        var rate = 40;
        playerCamera.fieldOfView = runInput.IsPressed() ? Mathf.MoveTowards(playerCamera.fieldOfView, 80, rate * Time.deltaTime) : Mathf.MoveTowards(playerCamera.fieldOfView, 60, rate * Time.deltaTime);
        if (moveVector == Vector2.zero) playerCamera.fieldOfView = Mathf.MoveTowards(playerCamera.fieldOfView, 60, rate * Time.deltaTime);

        currentMoveSpeed = runInput.IsPressed() ? Runningspeed * speedMult : Walkspeed * speedMult;
        HandleMovement(moveVector);
    }

    private void HandleMovement(Vector2 moveVector)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        Vector2 newSpeed = new Vector2(moveVector.y * currentMoveSpeed, moveVector.x * currentMoveSpeed);

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
        moveDirection.y = (jumped && characterController.isGrounded) ? Jumpforce : oldY;

        if (!characterController.isGrounded)
            moveDirection.y -= Gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Jumped(InputAction.CallbackContext _)
    {
        jumped = true;  
    }
}
