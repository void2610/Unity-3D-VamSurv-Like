using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpPanel : MonoBehaviour
{
    public PowerUp powerUp;

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI descriptionText;
    private Image iconImage;

    public void OnClick()
    {
        if (powerUp)
        {
            if (powerUp is StatusChange)
            {
                StatusChange statusChange = powerUp as StatusChange;
                statusChange.ChangeStatus();
            }
            else if (powerUp is Summon)
            {
                Summon summon = powerUp as Summon;
                summon.SummonObject();
            }

            UIManager.instance.ChangeActiveUI(GameState.InGame);
            Time.timeScale = 1;
        }
    }

    public void SetPowerUp(Type powerUpType)
    {

        PowerUp powerUp = this.gameObject.AddComponent(powerUpType) as PowerUp;
        if (!powerUp || powerUp.name == null || powerUp.description == null || powerUp.iconPath == null)
        {
            return;
        }

        this.powerUp = powerUp;
        nameText.text = this.powerUp.name;
        descriptionText.text = powerUp.description;
        Sprite icon = Resources.Load<Sprite>("Images/Icons/" + powerUp.iconPath);
        iconImage.sprite = icon;
    }

    void Start()
    {
        //子オブジェクトのTextMeshProUGUIコンポーネントを取得
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        descriptionText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        iconImage = transform.GetChild(3).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
