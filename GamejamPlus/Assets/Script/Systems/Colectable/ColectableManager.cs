using UnityEngine;

public class ColectableManager : MonoBehaviour
{
    public static ColectableManager Instance;

    int currentColectableCount = 0;
    [SerializeField] int colectableNum;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void IncreaseColectableCount()
    {
        currentColectableCount++;
        if (currentColectableCount >= colectableNum)
        {
            //acaba jogo gamer uhuul
        }
    }
}