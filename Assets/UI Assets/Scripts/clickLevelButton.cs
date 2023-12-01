using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickLevelButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img; //Img show
    [SerializeField] private Sprite _default, _pressed; //Img load when unpressed / pressed
    [SerializeField] private AudioClip _compressClip, _uncompressClip; //Audio play when press, unpress
    [SerializeField] private AudioSource _source; //Audio source

    public GameObject mainMenuObj = null;
    public GameObject levelMenuObj = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
        mainMenuObj.SetActive(false);
        levelMenuObj.SetActive(true);
    }
}
