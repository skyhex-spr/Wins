using UnityEngine;
using UnityEngine.UI;

public class FanController : IntractionObjectController
{
    private bool TurnOn = true;
    void OnMouseDown()
    {
        TurnOn = !TurnOn;
    }

    private void Update()
    {
        if (TurnOn) 
        {
            transform.Rotate(0, 0, 1);
        }
    }

}
