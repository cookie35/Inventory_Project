using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text attackNum;
    [SerializeField] private TMP_Text shieldNum;
    [SerializeField] private TMP_Text healthNum;
    [SerializeField] private TMP_Text criticalHitNum;
    [SerializeField] private Button backBtn;

    // Start is called before the first frame update
    private void Start()
    {
        backBtn.onClick.AddListener(() => UiManager.Instance.ShowMainMenu());
    }

    public void SetStatusInfo(Character character)
    {
        attackNum.text = character.attack.ToString();
        shieldNum.text = character.shield.ToString();
        healthNum.text = character.health.ToString();
        criticalHitNum.text = character.criticalHit.ToString();
    }

}
