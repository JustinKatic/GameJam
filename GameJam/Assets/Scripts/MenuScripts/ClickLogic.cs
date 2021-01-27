using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Text myText;
    public MenuButtons myEnum;
    [SerializeField] Color HighlightColour, DefaultColour, ClickColour;
    [SerializeField] GameEvent PlayOneShot, ClickEvent;
    [SerializeField] ScriptableAudioClip Clip;
    [SerializeField] ScriptableMenuEnum MenuEnum;
    [SerializeField] AudioClip Click, MouseOver;

    bool inFocus;
    private void OnEnable()
    {
        SetColour(DefaultColour);
        inFocus = false;
    }
    public void OnPointerDown(PointerEventData eventData) 
    {
        SetColour(ClickColour);
        PlayClip(Click);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        inFocus = true;
        SetColour(HighlightColour);
        PlayClip(MouseOver);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        inFocus = false;
        SetColour(DefaultColour);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (inFocus)
        {
            SetColour(HighlightColour);

            MenuEnum.Value = myEnum;
            ClickEvent.Raise();
        }
    }
    void PlayClip(AudioClip ac)
    {
        Clip.Value = ac;
        PlayOneShot.Raise();
    }
    void SetColour(Color c) => myText.color = c;
}
