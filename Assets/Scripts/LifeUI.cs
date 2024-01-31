using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] GameObject _lifeContainer;
    [SerializeField] PlayerController _playerController;

    [Space]
    [SerializeField] List<GameObject> _heartSprites;

    // Start is called before the first frame update
    void Start()
    {
        _lifeContainer.SetActive(true);
        //_heartSprites.ForEach(heart => heart.SetActive(true));
    }

    public void UpdateUI()
    {
        switch (_playerController.Health)
        {
            case 2:
                _heartSprites[2].SetActive(false);
                break;
            case 1:
                _heartSprites[1].SetActive(false);
                break;
            case 0:
                _heartSprites[0].SetActive(false);
                break;
            default:
                _heartSprites.ForEach(heart => heart.SetActive(true));
                break;
        }
    }
}