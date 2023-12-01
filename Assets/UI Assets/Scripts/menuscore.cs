using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuscore : MonoBehaviour
{
    public Button nextButton = null;
    public Button lastButton = null;
    public Button exitButton = null;
    public string LevelToLoad = "";

    void Start()
    {
        if (nextButton != null)
	        nextButton.onClick.AddListener(_onNext);
        if (lastButton != null)
	        lastButton.onClick.AddListener(_onLast);
        if (exitButton != null)
	        exitButton.onClick.AddListener(_onExit);
    }

    private void _onNext()
    {
        Debug.Log("Next level");
    }

    private void _onLast()
    {
        Debug.Log("Last level");
    }

    private void _onExit()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
