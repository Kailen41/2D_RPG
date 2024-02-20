using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string _sceneToLoad;
    [SerializeField] string _areaTransitionName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.transitionName = _areaTransitionName;

            CanvasManager.instance.FadeImage();

            StartCoroutine(LoadSceneCoroutine());
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(_sceneToLoad);
    }
}
