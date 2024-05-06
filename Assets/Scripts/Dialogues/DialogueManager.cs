using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour
{
    /*El sistema de di�logos utiliza el paquete gratuito de INK para hacer los dialogos y las elecciones,
    de esta forma todos los dialogos se guardan en un archivo JSON*/
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;

    [Header("Globals Ink File")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private AudioClip textSound;
    [SerializeField] private TextMeshProUGUI textMission;

    private static DialogueManager instance;
    private Story currentStory;
    public bool dialogueIsPlaying { get; set; }
    private TextMeshProUGUI[] choicesText;
    public bool storyHasStarted; //Variable provisional antes de crear efectos para el dialogo
    private DialogueVariables dialogueVariables;
    private Coroutine displayLineCoroutine;
    private float typingSpeed;

    private void Awake()
    {
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        typingSpeed = 0.01f;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        //Ocultar la interfaz
        dialogueIsPlaying = false;
        storyHasStarted = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            choices[index].SetActive(false);
            index++;
        }
    }

    void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        //Continuar la historia al hacer click mientras las opciones no est�n en pantalla
        if (Input.GetMouseButtonDown(0) && !choices[0].activeInHierarchy)
        {
            if (storyHasStarted)
                ContinueStory();
            else
                storyHasStarted = true;
        }
        textMission.text = ((Ink.Runtime.StringValue)GetVariableState("current_mission")).value;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Muestra la interfaz de dialogo
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);
        //Time.timeScale = 0; //Pausa el juego

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueVariables.StopListening(currentStory);
        storyHasStarted = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        //Time.timeScale = 1; //Quita la pausa del juego
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            //dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        //Al llegar a una elecci�n se mostraran las opciones
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Error");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        //Oculta las opciones sobrantes si hay menos que las opciones m�ximas
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        //Al elegir una opci�n el dialogo continua 
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null:  " + variableName);
        }
        return variableValue;
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        bool willSound = true;

        foreach (char letter in line.ToCharArray())
        {
            if (willSound)
                SoundFXManager.instance.PlaySoundFXClip(textSound, transform, 1f);
            willSound = !willSound;
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        DisplayChoices();

    }
}