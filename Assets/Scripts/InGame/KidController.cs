using UnityEditor.Animations;
using UnityEngine;

public class KidController : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.OnModeChanged?.AddListener(OnSadness);

    }

    public void OnSadness(bool state)
    {
        animator.SetTrigger("SwapMode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
