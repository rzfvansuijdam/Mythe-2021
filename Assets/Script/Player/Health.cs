using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : Player
{
    [SerializeField] private float _maxLives = 100f;
    public static float _lives = 40f;

    private bool _isSpotted = false;
    private bool coroutineBusy = false;

    private RectTransform db;
    private Vector3 dbSize;

    private void Start()
    {
        db = GameObject.Find("DetectionBar").GetComponent<RectTransform>();
        dbSize = db.lossyScale;
    }

    private void Update()
    {

        UpdateDbUI();

        if (_isSpotted)
        {
            if (!coroutineBusy)
            {
                StartCoroutine("SpotCountdown");
            }
        }
        else
        {
            _lives = _maxLives;
        }

        if(_lives <= 0)
        {
            GameOver();
        }

        db.gameObject.SetActive(_isSpotted);
    }

    void UpdateDbUI()
    {
        db.localScale = new Vector3((_lives/10) * dbSize.x, dbSize.y * 2, 0);
    }

    IEnumerator SpotCountdown()
    {
        coroutineBusy = true;
        yield return new WaitForSeconds(0.1f);
        _lives -= 1;
        coroutineBusy = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _isSpotted = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _isSpotted = false;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
