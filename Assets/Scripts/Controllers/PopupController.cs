using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [Header("Popups")]
    public SamplePopup SamplePopup;

    [Header("Components")]
    public Canvas PopupCanvas;
    public Image DarkImage;
    public Image FadeImage;

    private Popup _activePopup;
    private Popup _hiddenPopup;

    public void ShowSamplePopup(Action onComplete = null)
    {
        CloseActivePopup(false, () =>
        {
            DarkImage.gameObject.SetActive(true);
            var popup = Instantiate(SamplePopup, PopupCanvas.transform);
            popup.Init(onComplete);
            _activePopup = popup;
            popup.Show(false);
        });
    }

    public void OnDarkImageClicked()
    {
        CloseActivePopup(true);
    }


    public void CloseActivePopup(bool closeDark, Action onComplete = null)
    {
        if (_activePopup != null)
        {
            _activePopup.Hide(() =>
            {
                _activePopup = null;
                if (closeDark) DarkImage.gameObject.SetActive(false);
                if (onComplete != null) onComplete();
                if (_hiddenPopup != null)
                {
                    _hiddenPopup.Show();
                    _activePopup = _hiddenPopup;
                    _hiddenPopup = null;
                }
            });
        }
        else
        {
            if (onComplete != null) onComplete();
        }
    }

}
