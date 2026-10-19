using UnityEngine;

public class CallFadeInstance : MonoBehaviour
{
    public string sceneToGo;

    public void Start()
    {
        FadeManager.Instance.SetFadeIn(sceneToGo);
    }
}