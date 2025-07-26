using UnityEngine;

public class AirplaneController : IntractionObjectController
{
    private bool EngineOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void  Start()
    {
       base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (EngineOn)
            transform.Rotate(0, -1, 0);
    }

    public override void OnSadness(bool sad)
    {
        if(sad)
            EngineOn = false;
        else
            EngineOn = true;
    }
}
