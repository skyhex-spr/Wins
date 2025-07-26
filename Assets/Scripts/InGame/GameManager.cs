using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    private bool SadnessMode;

    public Volume volume;

    private Coroutine ModeChanger;

    public Button ChangeModeBtn;

    public static UnityEvent<bool> OnModeChanged = new UnityEvent<bool>();

    public KidController _kid;

    public ApiManager _apimanger;

    [Inject]
    private void Initial(KidController kid, ApiManager apimanger)
    {
        _kid = kid;
        _apimanger = apimanger;
    }

    void Start()
    {
        ChangeModeBtn.onClick.AddListener(ChangeMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMode()
    {
        SadnessMode = !SadnessMode;

        if (SadnessMode)
        {
            FadeGlobalVolume(1, 1);
        }
        else
        { 
            FadeGlobalVolume(0, 1); 
        }
    }

    public void FadeGlobalVolume(float toVolume, float time)
    {
        if (ModeChanger != null)
            StopCoroutine(ModeChanger);

        ModeChanger = StartCoroutine(FadeCoroutine(toVolume, time));
    }

    private IEnumerator FadeCoroutine(float to, float time)
    {
        float from = volume.weight;
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            volume.weight = Mathf.Lerp(from, to, elapsed / time);
            yield return null;
        }

        AudioListener.volume = to;

        OnModeChanged?.Invoke(SadnessMode);
    }
}
