using Cinemachine;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    //Camera camera;
    //public float defaultFOV = 60;
    //public float maxZoomFOV = 15;
    //[Range(0, 1)]
    //public float currentZoom;
    //public float sensitivity = 1;


    //void Awake()
    //{
    //    // Get the camera on this gameObject and the defaultZoom.
    //    camera = GetComponent<Camera>();
    //    if (camera)
    //    {
    //        defaultFOV = camera.fieldOfView;
    //    }
    //}

    //void Update()
    //{
    //    // Update the currentZoom and the camera's fieldOfView.
    //    currentZoom += Input.mouseScrollDelta.y * sensitivity * .05f;
    //    currentZoom = Mathf.Clamp01(currentZoom);
    //    camera.fieldOfView = Mathf.Lerp(defaultFOV, maxZoomFOV, currentZoom);
    //}


    public bool enableZoom = true;
    public bool holdToZoom = false;
    public KeyCode zoomKey = KeyCode.Mouse1;
    public float zoomFOV = 30f;
    public float zoomStepTime = 5f;

    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] float fov = 60f;

    public FirstPersonMovement FPMoveScript;

    // Internal Variables
    private bool isZoomed = false;

    
    private void Update()
    {
        CamZoom();
    }

    void CamZoom()
    {
        if (enableZoom)
        {
            // Changes isZoomed when key is pressed
            // Behavior for toogle zoom
            if (Input.GetKeyDown(zoomKey) && !holdToZoom && !FPMoveScript.IsRunning)
            {
                if (!isZoomed)
                {
                    isZoomed = true;
                }
                else
                {
                    isZoomed = false;
                }
            }

            // Changes isZoomed when key is pressed
            // Behavior for hold to zoom
            if (holdToZoom && !FPMoveScript.IsRunning)
            {
                if (Input.GetKeyDown(zoomKey))
                {
                    isZoomed = true;
                }
                else if (Input.GetKeyUp(zoomKey))
                {
                    isZoomed = false;
                }
            }

            // Lerps camera.fieldOfView to allow for a smooth transistion
            if (isZoomed)
            {
                playerCamera.m_Lens.FieldOfView = Mathf.Lerp(playerCamera.m_Lens.FieldOfView, zoomFOV, zoomStepTime * Time.deltaTime);
            }
            else if (!isZoomed && !FPMoveScript.IsRunning)
            {
                playerCamera.m_Lens.FieldOfView = Mathf.Lerp(playerCamera.m_Lens.FieldOfView, fov, zoomStepTime * Time.deltaTime);
            }
        }
    }

}
