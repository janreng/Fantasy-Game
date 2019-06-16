using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager instance;

    [SerializeField] Image handleExp;
    [SerializeField] ParticleSystem levelUpEffect;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        handleExp.fillAmount = 0;
    }

    public float GetExpCurrentLevel(int currentLevel)
    {
        return (5 * (27 * currentLevel * currentLevel + 28 * currentLevel + 75));
    }

    public void SetUIExpGive(float currentExp, float expUpLevel)
    {
        handleExp.fillAmount = currentExp / expUpLevel;
    }

    public void ResetUIExp()
    {
        handleExp.fillAmount = 0;
    }

    public void PlayEffectLevelUp()
    {
        levelUpEffect.Play();
    }
}
