using UnityEngine;
using UnityEngine.Video;

public class TVContrller : IntractionObjectController
{

    private VideoPlayer player;

    public VideoClip clip;
    private VideoClip IntialVideo;
    public override void Start()
    {
        base.Start();

        player = GetComponent<VideoPlayer>();

        IntialVideo = player.clip;
    }

    public override void OnSadness(bool state)
    {
        if (clip != null)
        {
            if (state)
                player.clip = clip;
            else
                player.clip = IntialVideo;
        }
        else
        {
            if (state)
                player.Pause();
            else
                player.Play();
        }
    }

    private void OnMouseDown()
    {
        if (player.isPaused)
            player.Play();
        else 
            player.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
