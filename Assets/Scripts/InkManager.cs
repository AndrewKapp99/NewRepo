using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using DG.Tweening;

public class InkManager : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField] private Text _dialogueField;

    [SerializeField] private VerticalLayoutGroup _layoutGroup;
    [SerializeField] private Button _choiceButtonPrefab;
    [SerializeField] private Image Astro;
    [SerializeField] private Image Alien;
    [SerializeField] private Image DialogueSpace;
    [SerializeField] private GameObject SeedSpace, WaterSpace;
    public Player playerData;

    public bool isTalking;

    public int choiceCount;

    private string resource;
    private bool correct;

    void Start(){
        if (playerData.hasSeeds)
            SeedSpace.SetActive(true);
        if (playerData.hasWater)
            WaterSpace.SetActive(true);
    }

    public void InitializeConversation(){
        StartStory();
        Astro?.GetComponent<RectTransform>().transform.DOMoveX(-8f, 0.5f, false);
        Alien?.GetComponent<RectTransform>().transform.DOMoveX(8f, 0.5f, false);
        DialogueSpace.GetComponent<RectTransform>().transform.DOMoveY(4f, 0.5f, false);
    }

    public void StartStory(){
        _story = new Story(_inkJsonAsset.text);
        resource = (string)_story.variablesState["resource"];
        if(resource == "Pirate"){{
            correct = (bool)_story.variablesState["correct"];
        }}
        isTalking = true;
        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line
            
            text = text?.Trim(); // removes white space from text
            
            _dialogueField.text = text; // displays new text
        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
            choiceCount++;
        }
        else if (!_story.canContinue)
            closeConvo();
    }

    private void DisplayChoices(){
        // checks if choices are already being displaye
        if (_layoutGroup.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++) // iterates through all choices
        {

            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text){
        //creates button from prefabs
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_layoutGroup.transform, false);

        //sets button text
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        DisplayNextLine();

    }

    void RefreshChoiceView()
    {
        if (_layoutGroup != null)
        {
            foreach (var button in _layoutGroup.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    private void closeConvo()
    {
        Astro?.GetComponent<RectTransform>().transform.DOMoveX(-16f, 0.5f, false);
        Alien?.GetComponent<RectTransform>().transform.DOMoveX(16f, 0.5f, false);
        DialogueSpace.GetComponent<RectTransform>().transform.DOMoveY(8f, 0.5f, false);

        if(choiceCount>1)
        {
            if(resource == "water")
            {
                playerData.hasWater = true;
            }
                
            if(resource == "seeds")
            {
                playerData.hasSeeds = true;
            }

            
        }

        if(resource == "Pirate")
        {
            if(!correct)
            {
                playerData.hasSeeds = false;
                playerData.hasWater = false;
            }
        }
            
        isTalking = false;
    }

    public void OnClick()
    {
        DisplayNextLine();
    }

}
