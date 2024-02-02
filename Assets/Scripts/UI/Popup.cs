using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Popup : MonoBehaviour
{
    public static Action PopupOpened;
    public static Action PopupClosed;

    protected CanvasGroup _canvasGroup;
    protected Action _callback;
    private bool _scale;

    public void Show(bool scale = true)
    {
        _scale = scale;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.DOFade(1, 0.25f).SetEase(Ease.OutQuad);
        if (scale) transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutQuad);
        PopupOpened?.Invoke();
    }

    public virtual void Hide(Action onComplete, bool destroy = true)
    {
        if (_scale) transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InQuad);
        _canvasGroup.DOFade(0, 0.2f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            onComplete();
            if (destroy)
            {
                Destroy(gameObject);
            }
        });

        PopupClosed?.Invoke();
    }

    public void Kill()
    {
        _canvasGroup.alpha = 0;
        Destroy(gameObject);
    }

    public abstract void Init(Action onComplete);
}

