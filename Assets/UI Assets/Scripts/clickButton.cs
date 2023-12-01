using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class clickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _img; //Img show
    [SerializeField] private Sprite _default, _pressed; //Img load when unpressed / pressed
    [SerializeField] private AudioClip _compressClip, _uncompressClip; //Audio play when press, unpress
    [SerializeField] private AudioSource _source; //Audio source
    public string LevelToLoad; //Game scene

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click down DETECTED ON RIFFLE IMAGE");
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("click up DETECTED ON RIFFLE IMAGE");
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
        SceneManager.LoadScene(LevelToLoad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter on object DETECTED ON RIFFLE IMAGE");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit object DETECTED ON RIFFLE IMAGE");
    }
}
