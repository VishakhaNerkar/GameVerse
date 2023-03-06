using UnityEngine;

public class RotateGameCube: MonoBehaviour
{
    // Reference to the cube we want to rotate
    public GameObject gameCubes;

    // Rotation angles for the cube
    private Quaternion startRotation;
    private Quaternion targetRotation;

    // How fast to rotate the cube
    public float rotationSpeed = 5f;

    // Whether the switch is currently pressed or not
    private bool switchPressed = false;
    private bool rotationComplete = true;

    void Start()
    {
        // Store the original rotation of the cube
        startRotation = cubeObject.transform.rotation;

        // Calculate the target rotation for the cube (90 degrees clockwise around Y-axis)
        targetRotation = Quaternion.Euler(0f, 90f, 0f) * startRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the switch has been triggered and the rotation is complete
        if (other.CompareTag("Player") && rotationComplete)
        {
            // Set the switch state to pressed
            switchPressed = true;

            // Set the rotation target to 90 degrees clockwise
            targetRotation = Quaternion.Euler(0f, 90f, 0f) * cubeObject.transform.rotation;

            // Set the rotation complete flag to false
            rotationComplete = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the switch has been released
        if (other.CompareTag("Player"))
        {
            // Set the switch state to released
            switchPressed = false;
        }
    }

    void Update()
    {
        // If the switch is pressed and the rotation is not complete, rotate the cube towards the target rotation
        if (switchPressed && !rotationComplete)
        {
            cubeObject.transform.rotation = Quaternion.Lerp(cubeObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the rotation is close enough to the target rotation to consider it complete
            if (Quaternion.Angle(cubeObject.transform.rotation, targetRotation) < 0.1f)
            {
                // Set the rotation complete flag to true
                rotationComplete = true;
            }
        }
        // Otherwise, rotate the
