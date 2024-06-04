using UnityEngine;

public class FlyRobot : MonoBehaviour
{
    public GameObject targetObject; 
    public float rotationSpeed = 90.0f; 
    public float movementSpeed = 5.0f; 

    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private bool isMovingForward = false;
    private bool isMovingBackward = false;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    private void OnTriggerEnter(Collider other)
    {
        if (targetObject == null) return;

        switch (other.tag)
        {
            case "Left":
                isRotatingLeft = true;
                break;
            case "Right":
                isRotatingRight = true;
                break;
            case "Up":
                isMovingUp = true;
                break;
            case "Down":
                isMovingDown = true;
                break;
            case "Front":
                isMovingForward = true;
                break;
            case "Back":
                isMovingBackward = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetObject == null) return;

        switch (other.tag)
        {
            case "Left":
                isRotatingLeft = false;
                break;
            case "Right":
                isRotatingRight = false;
                break;
            case "Up":
                isMovingUp = false;
                break;
            case "Down":
                isMovingDown = false;
                break;
            case "Front":
                isMovingForward = false;
                break;
            case "Back":
                isMovingBackward = false;
                break;
        }
    }

    private void Update()
    {
        if (targetObject == null) return;

        if (isRotatingLeft)
        {
            targetObject.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (isRotatingRight)
        {
            targetObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        Vector3 movementDirection = Vector3.zero;
        if (isMovingUp)
        {
            movementDirection += Vector3.up;
        }
        if (isMovingDown)
        {
            movementDirection += Vector3.down;
        }
        if (isMovingForward)
        {
            movementDirection += targetObject.transform.forward;
        }
        if (isMovingBackward)
        {
            movementDirection -= targetObject.transform.forward;
        }

        targetObject.transform.position += movementDirection.normalized * movementSpeed * Time.deltaTime;
    }
}
