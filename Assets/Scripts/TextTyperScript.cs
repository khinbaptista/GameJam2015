using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyperScript : MonoBehaviour
{

    private bool _endText = false;
    public GameObject speech;
    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
            StartCoroutine(TypeText());
        
    }

    void Update()
    {
        if (_endText)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                
                speech.SetActive(false);

                GameObject character = GameObject.Find("Character");
                MovementIntroAI mv = character.GetComponentInChildren<MovementIntroAI>();
                mv.enabled = true;
                mv.SendMessage("Flip");
                GameObject.Find("PlayerCamera").GetComponentInChildren<SmoothFollow>().enabled = false;
            }
        }
    }
    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        _endText = true;
    }
}