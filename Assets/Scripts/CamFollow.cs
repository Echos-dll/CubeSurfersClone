using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private Vector3 offset;
    
    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        mainCam.transform.position = transform.position + offset;
    }
}
