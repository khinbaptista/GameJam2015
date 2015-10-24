using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroTextTyperScript : MonoBehaviour
{

    private bool _mouseEnabled = true;
    private bool _endText = false;
    public GameObject speech;
    private MovementIntroAI _mv;
    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {

        GameObject character = GameObject.FindGameObjectWithTag("Player");
        _mv = character.GetComponentInChildren<MovementIntroAI>();
        _mv.SendMessage("Flip");
        _mv.enabled = false;
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
            StartCoroutine(TypeText());
        
    }

    void Update()
    {
        if (_endText)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
            {
                if (_mouseEnabled)
                {
                    _mouseEnabled = false;
                    speech.SetActive(false);
                    _mv.enabled = true;
                    _mv.SendMessage("Flip");
                    GameObject.Find("PlayerCamera").GetComponentInChildren<SmoothFollow>().enabled = false;
                }
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