using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private bool _isUsed;
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.ManagerInstance.HasWon = true;
        if (!_isUsed)
        {
            collision.gameObject.GetComponent<CubeSurf>().RemoveCube();
        }
        _isUsed = true;
    }
}
