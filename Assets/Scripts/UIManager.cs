using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIManager _instance;

    public UIManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}