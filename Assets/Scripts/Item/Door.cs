using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    public int GameStep1;
    public int GameStep2;

    private float dist;
    [SerializeField] private bool isPointed;
    [SerializeField] private bool canBePicked;
    public PlayerController _playerController;
    [SerializeField] private float distDetect;

    [SerializeField] private GameObject FaderIn;
    [SerializeField] private GameObject FaderOut;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        FaderIn.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private void OnMouseEnter()
    {
        isPointed = true;
    }

    private void OnMouseExit()
    {
        isPointed = false;
    }

    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, _playerController.transform.position);

        if (dist < distDetect)
        {
            canBePicked = true;
        }
        else
        {
            canBePicked = false;
        }

        if (FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep1 ||
            FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Execute()
    {
        if ((FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep1 ||
             FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep2) && canBePicked == true && isPointed == true)
        {
            _playerController.CanMove = false;
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        FaderOut.SetActive(true);
        _playerController.CanMove = false;
        yield return new WaitForSeconds(1.8f);
        _playerController.CanMove = true;
        FindObjectOfType<DontDestroyOnLoad>().GameStep++;
        SceneManager.LoadScene("GameCommon");
    }

    IEnumerator FadeIn()
    {
        _playerController.CanMove = false;
        yield return new WaitForSeconds(3);
        FaderIn.SetActive(false);
        _playerController.CanMove = true;
    }
}