using UnityEngine;

public class SurfCube : MonoBehaviour
{
    private bool _isUsed;
    private void OnCollisionEnter(Collision collision)
    {
        if (!_isUsed)
        {
            collision.gameObject.GetComponent<CubeSurf>().AddCube();
            _isUsed = true;
            Destroy(gameObject);
        }
    }
}
