
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkillsManager : MonoBehaviour
{
    public static PlayerSkillsManager Instance;

    
    SkillGroup playerSkills;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        playerSkills = new SkillGroup();
    }

    public void AddToSkills(SkillGroup trainingReward)
    {
        playerSkills += trainingReward;
    }

    public SkillGroup GetSkills()
    {
        return playerSkills;
    }
}