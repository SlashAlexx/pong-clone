using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMenuNavigation : MonoBehaviour
{

    [SerializeField] private GameObject themeSelectionMenu;
    [SerializeField] private GameObject playerSelectionMenu;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    private void Start()
    {
        themeSelectionMenu.SetActive(false);
    }

    public void RightArrowPress()
    {
        playerSelectionMenu.SetActive(false);
        themeSelectionMenu.SetActive(true);
        leftArrow.GetComponent<Button>().interactable = true;
        rightArrow.GetComponent<Button>().interactable = false;
    }

    public void LeftArrowPress()
    {
        playerSelectionMenu.SetActive(true);
        themeSelectionMenu.SetActive(false);
        leftArrow.GetComponent<Button>().interactable = false;
        rightArrow.GetComponent<Button>().interactable = true;
    }   
}
