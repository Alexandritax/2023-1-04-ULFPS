using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FaceHealthUI : MonoBehaviour
{
    public List<Sprite> healthSprites;
    private Image mImage;
    private int imageIdx = 0;

    private void Awake()
    {
        mImage = GetComponent<Image>();
    }

    private void Start()
    {
        PlayerController.Instance.OnPlayerDamage += OnPlayerDamage;
        mImage.sprite = healthSprites[imageIdx];
    }

    private void OnPlayerDamage(object sender, EventArgs e)
    {
        if(imageIdx < healthSprites.Count - 1)
        {
            imageIdx++;
            mImage.sprite = healthSprites[imageIdx];
        }
        else
        {
            Debug.Log("Player is dead");
        }
    }
}
