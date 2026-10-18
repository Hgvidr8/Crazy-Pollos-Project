using Unity.VectorGraphics;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    //Taper Fade
    public static FadeManager Instance { get; private set; }
    [SerializeField]private Animator fadeAnimator;
    bool isFading = false;
    public GameObject ParentCanvas;

    string sceneToLoad;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (ParentCanvas != null)
            {
                DontDestroyOnLoad(ParentCanvas);
            }
        }
    }

    public void SetFadeIn(string newScene)
    {
        if(isFading)
            return;

        sceneToLoad = newScene;
        fadeAnimator.SetTrigger("FadeIn");
        isFading = true;
    }

    public void OnFadeComplete()
    {
        isFading = false;
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}

