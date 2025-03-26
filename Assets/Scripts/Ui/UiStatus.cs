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

    private void SetStatTxt(TMP_Text tmp, int baseValue, int bonusValue)
    {
        if (bonusValue > 0)
        {
            tmp.text = $"{baseValue.ToString()}" + " + " + $"{bonusValue.ToString()}";
        }
        else
        {
            tmp.text = baseValue.ToString();
        }
    }

    public void UpdateStatus(ItemInfo nowItem, Character character)
    {
        SetStatTxt(attackNum, character.baseAttack, character.bonusAttack);
        SetStatTxt(shieldNum, character.baseShield, character.bonusShield);
        SetStatTxt(healthNum, character.baseHealth, character.bonusHealth);
        SetStatTxt(criticalHitNum, character.baseCriticalHit, character.bonusCriticalHit);
            
    }
}
