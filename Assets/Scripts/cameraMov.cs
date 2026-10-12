using UnityEngine;

//example from: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
// This class allows to control the object to which it is attached to using the arrow keys
public class PlayerDriven : MonoBehaviour
{
    public Transform orientation;

    public float mouseSens = 400f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        //Pour bien mettre le curseur au centre, et qu'il y reste
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        // Rotation de la camera avec la souris
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens;

        mouseX *= Time.deltaTime;
        mouseY *= Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Pour éviter de regarder trop haut ou trop bas

        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // Rotation du joueur
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // Rotation de la camera
        // Ici, on n'utilise pas un .Rotate sinon Unity modifierais a chaque frame la rotation avec l'angle donné
        // (au lieu d'aller directement a l'angle donné)
    }
}