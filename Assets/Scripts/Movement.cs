using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private float forwardSpeed;
    [Range(1,10)]
    [SerializeField] private float sideSpeed;
    
    void Update()
    {
        if (!GameManager.ManagerInstance.GameOn) return;
        
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position +=  Vector3.left * sideSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position +=  Vector3.right * sideSpeed * Time.deltaTime;
        }
    }
}
