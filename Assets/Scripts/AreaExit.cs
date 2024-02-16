using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string _sceneToLoad;
    [SerializeField] string _areaTransitionName;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.transitionName = _areaTransitionName;
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
