using UnityEngine;

public class ObstacleGroup : MonoBehaviour
{
    private bool _isUsed;

    public void DisableCollision()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody>().detectCollisions = false;
        }
    }
    
    public bool IsUsed
    {
        get => _isUsed;
        set => _isUsed = value;
    }
}
