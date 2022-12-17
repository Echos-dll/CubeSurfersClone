using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int height;
    private ObstacleGroup _parentGroup;
    private void Start()
    {
        _parentGroup = transform.parent.GetComponent<ObstacleGroup>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_parentGroup.IsUsed)
        {
            for (int i = 0; i < height; i++)
            {
                collision.gameObject.GetComponent<CubeSurf>().RemoveCube();
            }
            _parentGroup.IsUsed = true;
            
            _parentGroup.DisableCollision();
        }
    }
}
