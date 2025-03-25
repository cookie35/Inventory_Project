using System;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UiStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text attackNum;
    [SerializeField] private TMP_Text shieldNum;
    [SerializeField] private TMP_Text healthNum;
    [SerializeField] private TMP_Text criticalHitNum;
    [SerializeField] private Button backBtn;

    private void Start()
    {
        backBtn.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());
    }

    public void SetStatusInfo(Character character)
    {
        attackNum.text = character.baseAttack.ToString();
        shieldNum.text = character.baseShield.ToString();
        healthNum.text = character.baseHealth.ToString();
        criticalHitNum.text = character.baseCriticalHit.ToString();
    }

    public void UpdateStatus(ItemInfo nowItem, Character character)
    {
        if (character.bonusAttack > 0)
        {
            attackNum.text = $"{character.baseAttack.ToString()}" + " + " + $"{character.bonusAttack.ToString()}";
        } 
        else
        {
            attackNum.text = character.baseAttack.ToString();
        }

        if (character.bonusShield > 0)
        {
            shieldNum.text = $"{character.baseShield.ToString()}" + " + " + $"{character.bonusShield.ToString()}";
        }
        else
        {
            shieldNum.text = character.baseShield.ToString();
        }

        if (character.bonusHealth > 0)
        {
            healthNum.text = $"{character.baseHealth.ToString()}" + " + " + $"{character.bonusHealth.ToString()}";
        }
        else
        {
            healthNum.text = character.baseHealth.ToString();
        }

        if (character.bonusCriticalHit > 0)
        {
            criticalHitNum.text = $"{character.baseCriticalHit.ToString()}" + " + " + $"{character.bonusCriticalHit.ToString()}";
        }
        else
        {
            criticalHitNum.text = character.baseCriticalHit.ToString();
        }
            
    }
}
