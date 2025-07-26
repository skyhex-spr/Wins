using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelController : MonoBehaviour
{
    protected GameManager _gameManager;
    public Button ExitButton;
    [Inject]
    private void Initial(KidController kid, GameManager gamemanager)
    {
        _gameManager = gamemanager;
    }

    public virtual void Awake()
    {
        ExitButton.onClick.AddListener(ClosePanel);
    }

    public GameObject panel;

    public virtual void OpenPanel()
    {
        panel.SetActive(true);
    }

    public virtual void ClosePanel()
    {
        panel.SetActive(false);
    }
}
