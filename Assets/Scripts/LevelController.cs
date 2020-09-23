using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private BoardController _boardController;
    private GameObject _currentLevel;
    private static int _index;

    public void HighlightSpheres()
    {
        _boardController = FindObjectOfType<BoardController>();
        _boardController.HighlightSpheres();
    }

    public void LoadNextLevel()
    {
        DestroyLevel();
        _currentLevel = Instantiate(levels[_index]);
        IncreaseIndex();
    }

    public void RestartLevel()
    {
        DestroyLevel();
        DecreaseIndex();
        _currentLevel = Instantiate(levels[_index]);
    }

    private void IncreaseIndex()
    {
        if (_index < levels.Length - 1)
            _index++;
    }

    private void DecreaseIndex()
    {
        if (_index > 0 && _index != levels.Length - 1)
            _index--;
    }

    public void DestroyLevel()
    {
        if (_currentLevel)
            Destroy(_currentLevel);
    }
}