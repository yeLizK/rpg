using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ConfiguratorUIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private static ConfiguratorUIManager _instance;
    public static ConfiguratorUIManager Instance { get { return _instance; } }


    [SerializeField] private GameObject ModularCharacter;

    private bool isCharRotating;
    private Vector3 mouseInitialPos;
    private Vector3 mouseOffset;
    private float mouseDragSensitivity;
    private Vector3 charRotation;

    [SerializeField] private TMP_Text HairText, ClotheText;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        isCharRotating = false;
        mouseDragSensitivity = 0.4f;
    }

    private void Update()
    {
        if (isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * 0.5f;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //Character Rotation
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        mouseInitialPos = Input.mousePosition;
        isCharRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        isCharRotating = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log("OnPointerMove !isCharRotating");

        if (isCharRotating)
        {
            Debug.Log("OnPointerMove isCharRotating");
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * -mouseDragSensitivity;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //UI Elements Functionality - Gender Selection
    public void SelectMaleButton()
    {
        CharCustomiser.Instance.SelectMale();
    }

    public void SelectFemaleButton()
    {
        CharCustomiser.Instance.SelectFemale();
    }

    //UI Elements Functionality - Skin Colour Selection
    public void SelectBlackSkinColorButton()
    {
        CharCustomiser.Instance.ChangeSkinColorToBlack();
    }

    public void SelectBrownSkinColorButton()
    {
        CharCustomiser.Instance.ChangeSkinColorToBrown();
    }

    public void SelectWhiteSkinColorButton()
    {
        CharCustomiser.Instance.ChangeSkinColorToWhite();
    }

    public void UpdateHairText(int selectionNumber)
    {
        HairText.text = "Hair  " + selectionNumber;
    }
    //UI Elements Functionality - Hair Selection
    public void ClickRightHairSelectionButton()
    {
        CharCustomiser.Instance.ChangeHairRightSelection();
        int temp = CharCustomiser.Instance.hairIndex+1;
        UpdateHairText(temp);
    }

    public void ClickLeftHairSelectionButton()
    {
        CharCustomiser.Instance.ChangeHairLeftSelection();
        int temp = CharCustomiser.Instance.hairIndex + 1;
        UpdateHairText(temp);

    }
    public void UpdateClotheText(int selectionNumber)
    {
        ClotheText.text = "Clothe " + selectionNumber;
    }
    public void ClickRightClotheSelectionButton()
    {
        CharCustomiser.Instance.ChangeClothingRightSelection();
        int temp = CharCustomiser.Instance.clotheIndex + 1;
        UpdateClotheText(temp);

    }
    public void ClickLeftClotheSelectionButton()
    {
        CharCustomiser.Instance.ChangeClothingLeftSelection();
        int temp = CharCustomiser.Instance.clotheIndex + 1;
        UpdateClotheText(temp);
    }


    //UI Elements Functionality - Clothe Colour Selection
    public void ClickClotheColorBlackButton()
    {
        CharCustomiser.Instance.clotheColourIndex = 0;
        CharCustomiser.Instance.UpdateCharacterAppereance();
    }
    public void ClickClotheColorBlueButton()
    {
        CharCustomiser.Instance.clotheColourIndex = 1;
        CharCustomiser.Instance.UpdateCharacterAppereance();
    }
    public void ClickClotheColorCyanButton()
    {
        CharCustomiser.Instance.clotheColourIndex = 2;
        CharCustomiser.Instance.UpdateCharacterAppereance();
    }
    public void ClickClotheColorPurpleButton()
    {
        CharCustomiser.Instance.clotheColourIndex = 3;
        CharCustomiser.Instance.UpdateCharacterAppereance();
    }
    public void ClickClotheColorWhiteButton()
    {
        CharCustomiser.Instance.clotheColourIndex = 4;
        CharCustomiser.Instance.UpdateCharacterAppereance();
    }
    //UI Elements Functionality - Hair Colour Selection
    public void ClickHairColorToBlackButton()
    {
        CharCustomiser.Instance.ChangeHairColorToBlack();
    }
    public void ClickHairColorToYellowButton()
    {
        CharCustomiser.Instance.ChangeHairColorToYellow();
    }
    public void ClickHairColorToBrownButton()
    {
        CharCustomiser.Instance.ChangeHairColorToBrown();
    }
    public void ClickHairColorToCyanButton()
    {
        CharCustomiser.Instance.ChangeHairColorToCyan();
    }
    public void ClickHairColorToPurpleButton()
    {
        CharCustomiser.Instance.ChangeHairColorToPurple();
    }
    public void ClickHairColorToRedButton()
    {
        CharCustomiser.Instance.ChangeHairColorToRed();
    }
    public void ClickHairColorToWhiteButton()
    {
        CharCustomiser.Instance.ChangeHairColorToWhite();
    }
}
