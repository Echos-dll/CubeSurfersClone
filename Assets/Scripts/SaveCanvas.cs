using UnityEngine;

public class SaveCanvas : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
