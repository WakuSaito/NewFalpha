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
        PlayerManager playermanager;
        GameObject obj = GameObject.Find("Player");
        playermanager = obj.GetComponent<PlayerManager>();

        //最大体力をPlayermManagerから参照
        maxHealth = playermanager.playerHP;

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
