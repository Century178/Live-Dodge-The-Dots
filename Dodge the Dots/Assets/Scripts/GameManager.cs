using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //You can use TextMesh Pro instead; download the TextMesh Pro package then type "using TMPro;".

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private float _scoreSpeed;
    private int _score; //If the variable right after the [Header] attribute isn't visible in the inspector, the header itself won't be either.
    [SerializeField] private Text _scoreText;

    [Header("Platform")]
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _platformDestroyTime;

    private bool _gameOver = false;

    private void Awake()
    {
        Destroy(_platform, _platformDestroyTime);

        InvokeRepeating(nameof(ScoreIncrease), _platformDestroyTime, _scoreSpeed); //Using nameof(Method) instead of a string is better practice.
    }

    private void Update()
    {
        if (Player.Instance._isDead && !_gameOver)
        {
            CancelInvoke(nameof(ScoreIncrease)); //Stops the method from repeating.
            _gameOver = true;
        }

        if (_gameOver)
        {
            _scoreText.text = "Final Score: " + _score + " Press space to restart.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene.
            }
        }
    }

    private void ScoreIncrease()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
