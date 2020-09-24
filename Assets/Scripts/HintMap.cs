﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintMap : MonoBehaviour
{
    [SerializeField] private GameObject fullMap;
    private float _highlightedDuration = 3f;

    public void ReminderButtonOnClick()
    {
        //TODO add pause
        fullMap.SetActive(true);
        StartCoroutine(GameNavCoroutine());
    }

    private IEnumerator GameNavCoroutine()
    {
        yield return new WaitForSeconds(_highlightedDuration);
        fullMap.SetActive(false);
    }
}