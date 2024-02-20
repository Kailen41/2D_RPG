using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Image _fadeImage;

    public static CanvasManager instance;

    private void Start()
    {
        instance = this;
    }

    public void FadeImage()
    {
        _fadeImage.GetComponent<Animator>().SetTrigger("StartFade");
    }
}
