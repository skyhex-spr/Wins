using UnityEngine;

public class IntractionObjectController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        GameManager.OnModeChanged?.AddListener(OnSadness);
    }

    public virtual void OnSadness(bool sad)
    { 

    }
}
