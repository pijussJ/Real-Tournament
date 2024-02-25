using UnityEngine;

public class ZoomInMode : MonoBehaviour
{
    public Camera camera;
    public GameObject scope;
    //public Weapon weapon;
    public float zoomValue;
    float defaultZoom;

    private void Start()
    {
        //weapon.onRightClick.AddListener(Zoom);
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
