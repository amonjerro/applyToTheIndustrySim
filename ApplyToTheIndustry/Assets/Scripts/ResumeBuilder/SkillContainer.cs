using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/* CLASS: SkillContainer
 * Used for holding information on any individual skill
 * that'll be used to add to player resume
 */
public class SkillContainer : MonoBehaviour
{
    // Public fields
    public TextMeshProUGUI skillTMPTitle;
    public Skill skill;
    private ResumeComponent target;
    private ResumeComponent parent;
    public int index;

    /// <summary>
    /// Used for updating UI text with
    /// information from skill
    /// </summary>
    public void UpdateUIText()
    {
        skillTMPTitle.text = skill.name;
    }

    /// <summary>
    /// Called upon clicking container button
    /// </summary>
    public void OnChoose()
    {
        // Add skill to player resume
        target.AddSkill(skill);
        parent.PopSkill(index);
        
        // Update onboarding manager
        // Get onboarding manager
        OnboardingManager onboardingMngr = ServiceLocator.Instance.GetService<OnboardingManager>();

        // If the tutorial is still active then proceed with the next tutorial step
        if(onboardingMngr != null)
        {
            if (onboardingMngr.tutorialActive)
            {
                // Disable instructions to let multiple clicks
                onboardingMngr.DisableInstructions();

                // Increase click counter and advance tutorial when ready
                target.tutorialClicks++;
                if (target.tutorialClicks == target.neededClicks)
                {
                    onboardingMngr.readyProceed = true;
                    onboardingMngr.AdvanceTutorial();
                }
            }
        }
    }

    public void SetTarget(ResumeComponent component)
    {
        target = component;
    }
    public void SetParent(ResumeComponent papa)
    {
        parent = papa;
    }

    public void SetIndex(int value)
    {
        index = value;
    }
}
