using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{
    ResourceManager rm;
    public InterfaceGroup dependentUI;
    public ActionCost cost;
    Grader feedback;

    // Start is called before the first frame update
    void Start()
    {
        rm = ServiceLocator.Instance.GetService<ResourceManager>();
        feedback = ServiceLocator.Instance.GetService<Grader>();
    }

    public void DoAction()
    {
        Debug.Log(cost.time.value);
        if(rm.IsCostViable(cost))
        {
            rm.ManageCost(cost);
        }
    }

    public void OpenInterface()
    {
        DoAction();
        dependentUI.gameObject.SetActive(true);
        gameObject.GetComponentInParent<InterfaceGroup>().gameObject.SetActive(false);
    }

    public void OpenFeedbackScene()
    {
        SceneManager.LoadScene("FeedbackScene");
        feedback.GetFeedback();
    }
}
