using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerManager : MonoBehaviour
{
    public GameResources GameResources;
    public UserController UserController;
    public PopupController PopupController;

    public static ControllerManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }


    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
        PopupController.FadeImage.DOFade(0, 1).OnComplete(() => PopupController.FadeImage.gameObject.SetActive(false));
    }
}
