using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsUI : MonoBehaviour
{
    static BuildingsUI instance;
    public static BuildingsUI Instance => instance;

    [SerializeField]
    BuildingDataScriptable dataForBuildings;

    [SerializeField]
    BuildingButton buttonPrefab;

    private List<BuildingButton> buttons;

    private BuildingButton currentButton;
    public BuildingButton BuildingButton { get { return currentButton; } }

    public bool CanBuild { get
        {
            if (currentButton == null) return false;
            if (currentButton.BuildingData.Price > ResourceManger.Instance.Coins) return false;
            return true;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        buttons = new List<BuildingButton>();
        foreach (var bldData in dataForBuildings.Buildings)
        {
            var btn = Instantiate(buttonPrefab, transform);
            btn.SetData(bldData);
            btn.SelectedChanged += OnSelectChanged;
            buttons.Add(btn);
        }
    }

    private void OnSelectChanged(BuildingButton button, bool select)
    {
        if (select)
        {
            if (currentButton != null) { currentButton.DeselectButton(); }
            button.SelectButton();
            currentButton = button;
        }
        else
        {
            button.DeselectButton();
            currentButton = null;
        }
    }

    internal void DeselectCurrentButton()
    {
        if (currentButton)
        {
            currentButton.DeselectButton();
            currentButton = null;
        }
    }
}
