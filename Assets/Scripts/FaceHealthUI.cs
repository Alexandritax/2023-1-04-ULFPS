using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class FaceHealthUI : MonoBehaviour
{
    public List<Sprite> healthSprites;
    private Image mImage;
    private TextMeshProUGUI mText;
    private int imageIdx = 0;

    private void Awake()
    {
        mImage = GameObject.Find("Image").GetComponent<Image>();
        mText = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        PlayerController.Instance.OnPlayerDamage += OnPlayerDamage;
        mImage.sprite = healthSprites[imageIdx];
        mText.text = (healthSprites.Count - imageIdx)*10 + "%";
    }

    private void OnPlayerDamage(object sender, EventArgs e)
    {
        if(imageIdx < healthSprites.Count - 1)
        {
            imageIdx++;
            mImage.sprite = healthSprites[imageIdx];
            mText.text = (healthSprites.Count - imageIdx)*10 + "%";
        }
        else
        {
            mText.text = "0%";
            Debug.Log("Player is dead");
        }
    }
}
