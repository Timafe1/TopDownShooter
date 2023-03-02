using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Reference to the camera GameObject
    public GameObject cameraObject;

    // The position and rotation of the camera in the 3D view
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    // Boolean variable to track whether the camera is in 3D view or not
    private bool isCameraIn3DView = false;

    // Function to switch the camera perspective to 3D view
    public void SwitchTo3DView()
    {
        // Set the camera's position and rotation to the 3D view values
        cameraObject.transform.position = cameraPosition;
        cameraObject.transform.rotation = Quaternion.Euler(cameraRotation);

        // Set the camera's projection to perspective
        cameraObject.GetComponent<Camera>().orthographic = false;

        // Set the isCameraIn3DView variable to true
        isCameraIn3DView = true;
    }

    // Function to switch the camera perspective back to 2D view
    public void SwitchTo2DView()
    {
        // Set the camera's position and rotation to default values for 2D view
        cameraObject.transform.position = new Vector3(0, 0, -10);
        cameraObject.transform.rotation = Quaternion.identity;

        // Set the camera's projection to orthographic
        cameraObject.GetComponent<Camera>().orthographic = true;

        // Set the isCameraIn3DView variable to false
        isCameraIn3DView = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isCameraIn3DView)
            {
                // Call the SwitchTo2DView function if the camera is in 3D view
                SwitchTo2DView();
            }
            else
            {
                // Call the SwitchTo3DView function if the camera is in 2D view
                SwitchTo3DView();
            }
        }
    }
}