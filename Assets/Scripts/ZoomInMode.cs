using UnityEngine;

public class ZoomInMode : MonoBehaviour
{
    public Camera camera;
    public GameObject scope;
    public float zoomValue;
    float defaultZoom;

    private void Start()
    {
        defaultZoom = camera.fieldOfView;
    }

    public void Zoom()
    {
        if (camera.fieldOfView == defaultZoom)
        {
            scope.SetActive(true);
            camera.fieldOfView -= zoomValue;
        }
        else
        {
            scope.SetActive(false);
            camera.fieldOfView += zoomValue;
        }
    }
}
