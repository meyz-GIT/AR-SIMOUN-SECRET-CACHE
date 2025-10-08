using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueAfterLevel : MonoBehaviour
{

    public GameObject prof;
    public GameObject primo;
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public int level;

    private int index;

    [TextArea(3, 10)]
    public string[] lines;





    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            Trigger();
            StartCoroutine(TypeLine());

        }
        else
        {
            Debug.Log("DEBUG 1: Dialogue finished. Checking progression.");

            int currentlvl = LevelManager.Instance.getCurrentLevel(); // The potential crash point
            int level = this.level; // The level this dialogue relates to (e.g., 1)

            Debug.Log($"DEBUG 2: Current Level: {currentlvl}, Dialogue Level: {level}");

            if (level == currentlvl)
            {
                if (level == 10)
                {
                    SceneManager.LoadScene("EndingStory");
                    LevelManager.Instance.AddLevelData();
                    LevelManager.Instance.SaveLevelData();
                }
                else
                {
                    // Level Progression Logic
                    LevelManager.Instance.AddLevelData();
                    LevelManager.Instance.SaveLevelData();
                    Debug.Log("DEBUG 3A: Progression successful. Loading Levels scene.");
                    SceneManager.LoadScene("Levels");
                }
            }
            else
            {
                if (level == 10)
                {
                    SceneManager.LoadScene("EndingStory");
                }
                else
                {
                    // Replay Logic
                    Debug.Log("DEBUG 3B: Replay detected. Loading Levels scene.");
                    SceneManager.LoadScene("Levels");
                }
            }
        }
    }



    public void Trigger()
    {
        if (prof.activeInHierarchy == false)
        {
            prof.SetActive(true);
        }
        else
        {
            prof.SetActive(false);
        }

        if (primo.activeInHierarchy == false)
        {
            primo.SetActive(true);
        }
        else
        {
            primo.SetActive(false);
        }
    }
}
