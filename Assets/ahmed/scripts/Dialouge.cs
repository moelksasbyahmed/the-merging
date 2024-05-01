using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameText; // Reference to UI text element for character name
    [SerializeField] private Image image; // Reference to UI image element for character portrait
    [SerializeField] private Text dialogueText; // Reference to UI text element for dialogue
    [SerializeField] private RectTransform imageRect; // Reference to RectTransform of image for positioning

    private List<DialogueLine> dialogueLines; // List to store parsed dialogue lines

    private void Awake()
    {
        dialogueLines = ReadDialogueLines("3.txt"); // Replace "dialogue.txt" with your file name
    }

    public void LoadNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            // Handle end of dialogue (e.g., display "End of Conversation")
            return;
        }

        DialogueLine currentLine = dialogueLines[0];
        dialogueLines.RemoveAt(0); // Remove the line from the list

        nameText.text = currentLine.CharacterName;
        dialogueText.text = currentLine.DialogueText;

        // Load and display image
        image.sprite = Resources.Load<Sprite>(currentLine.PhotoName);

        // Position image based on side (right or left)
        if (currentLine.Side.ToLower() == "right")
        {
            imageRect.anchorMin = new Vector2(1, 0.5f);
            imageRect.anchorMax = new Vector2(1, 0.5f);
        }
        else
        {
            imageRect.anchorMin = new Vector2(0, 0.5f);
            imageRect.anchorMax = new Vector2(0, 0.5f);
        }
    }

    private List<DialogueLine> ReadDialogueLines(string fileName)
    {
        List<DialogueLine> lines = new List<DialogueLine>();
     string filePath = Path.Combine(Application.dataPath, "Resources/" + fileName);
 

        if (File.Exists(filePath))
        {
            string[] linesFromFile = File.ReadAllLines(filePath);
            foreach (string line in linesFromFile)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 4)
                {
                    lines.Add(new DialogueLine(parts[0], parts[1], parts[2], parts[3]));
                }
                else
                {
                    Debug.LogError("Invalid dialogue line format in " + Application.dataPath +"Resources/" + fileName);
                }
            }
        }
        else
        {
            Debug.LogError("Dialogue file not found: " + Application.dataPath + "Resources/" + fileName);
         
        }

        return lines;
    }

    private class DialogueLine
    {
        public string PhotoName { get; private set; }
        public string CharacterName { get; private set; }
        public string DialogueText { get; private set; }
        public string Side { get; private set; }

        public DialogueLine(string photoName, string characterName, string dialogueText, string side)
        {
            PhotoName = photoName;
            CharacterName = characterName;
            DialogueText = dialogueText;
            Side = side;
        }
    }
}
