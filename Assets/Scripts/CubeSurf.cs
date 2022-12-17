using System;
using UnityEngine;

public class CubeSurf : MonoBehaviour
{
    [SerializeField] private GameObject surfParent;
    [SerializeField] private GameObject cubePrefab;
    
    private int _cubeNumber = 0 ;
    private void Start()
    {
        ResetCubes();
    }
    
    public void AddCube()
    {
        Debug.Log("Added Cube");
        transform.position += Vector3.up;
        var cube = Instantiate(cubePrefab, surfParent.transform);
        cube.transform.position = transform.position + Vector3.down * _cubeNumber;
        _cubeNumber += 1;
    }

    public void RemoveCube()
    {
        Debug.Log("Removed Cube");
        //if no cubes game over
        if (surfParent.transform.childCount > 0)
        {
            var child = surfParent.transform.GetChild(surfParent.transform.childCount-1);
            child.GetComponent<Collider>().enabled = false;
            child.parent = null;
            _cubeNumber -= 1;
        }
        else
        {
            if (GameManager.ManagerInstance.HasWon)
            {
                GameManager.ManagerInstance.InvokeWinEvent();
            }
            else
            {
                GameManager.ManagerInstance.InvokeFailEvent();
            }
        }
    }

    public void ResetCubes()
    {
        for (int i = 0; i < _cubeNumber; i++)
        {
            RemoveCube();
        }
        AddCube();
    }
}
