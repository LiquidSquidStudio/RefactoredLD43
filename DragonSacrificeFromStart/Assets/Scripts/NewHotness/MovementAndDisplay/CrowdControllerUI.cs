using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdControllerUI : MonoBehaviour
{
    public Slider CrowdSlider;

    [Header("Panel Stuff")]
    public GameObject NPeasantPanel;
    public Text CurrentValueLabel;
    public Text MaxValueLabel;

    private void Start()
    {
        //    // TODO: Codesmell. This class shouldn't be worried about UI
        //    CrowdSlider.onValueChanged.AddListener(delegate { NumberOfPeasantsChanged(); });

        UpdatePeasantPanel();
    }

    //public void UpdatePeasantNumberPanel()
    //{
    //    // get nubmer of peasants at origin
    //    int nPeasants = ResourceCore.GetPeasantsAt(ResourceLocation.CrowdPit).Count();

    //    // update UI
    //    CrowdSlider.maxValue = nPeasants;
    //    CrowdSlider.value = 1;
    //    CrowdSlider.minValue = 1;

    //    MaxValueLabel.text = nPeasants.ToString();
    //    CurrentValueLabel.text = 1.ToString();
    //}

    public void UpdatePeasantPanel()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (CrowdSlider.value < CrowdSlider.maxValue)
            {
                int currentValue = (int)CrowdSlider.value;
                currentValue++;
                //_nPeasantsToMove = currentValue;
                CrowdSlider.value = currentValue;
                CurrentValueLabel.text = currentValue.ToString();
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (CrowdSlider.value > CrowdSlider.minValue)
            {
                int currentValue = (int)CrowdSlider.value;
                currentValue--;
                //_nPeasantsToMove = currentValue;
                CrowdSlider.value = currentValue;
                CurrentValueLabel.text = currentValue.ToString();
            }
        }
    }
}
