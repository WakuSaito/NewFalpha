using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image hpBarcurrent;
    private float maxHealth;//最大体力

    //private float currentHealth;//現在の体力

    void Awake()
    {
        //PlayerManagerの読み込み
        PlayerStatusManager playerStatusManager;
        GameObject obj = GameObject.Find("DataInfo");
        playerStatusManager = obj.GetComponent<PlayerStatusManager>();

        //最大体力をPlayermStatusManagerから参照
        maxHealth = playerStatusManager.MaxHP;

        ////現在のHPを初期化
        //currentHealth = maxHealth;
    }

    //体力更新関数
    public void UpdateHP(float currentHealth)
    {
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        hpBarcurrent.fillAmount = currentHealth / maxHealth;
    }
}
