using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingButton : MonoBehaviour
{
    public event Action<BuildingButton, bool> SelectedChanged;

    private BuildingData buildingData;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text priceText;
    [SerializeField]
    private Image image;

    public BuildingData BuildingData => buildingData;

    Button button;

    bool selected = false;

    public void SetData(BuildingData buildingData)
    {
        button = GetComponent<Button>();

        this.buildingData = buildingData;
        nameText.text = buildingData.Name;
        priceText.text = buildingData.Price.ToString();
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        if (ResourceManger.Instance.Coins >= buildingData.Price)
        {
            if(selected)
            {
                SelectedChanged?.Invoke(this, false);
            } else
            {
                SelectedChanged?.Invoke(this, true);
            }
        }
    }

    public void SelectButton()
    {
        image.color = Color.green;
        selected = true;
    }

    public void DeselectButton()
    {
        image.color = Color.white;
        selected = false;
    }
}

