using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    public GameObject MainMenu, OptionsMenu;
    [SerializeField] ScriptableMenuEnum MenuEnum;

    private void OnEnable()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void ButtonClicked()
    {
        switch(MenuEnum.Value)
        {
            case MenuButtons.Back:
                OptionsMenu.SetActive(false);
                MainMenu.SetActive(true);
                break;
            case MenuButtons.Exit:
                Application.Quit();
                break;
            case MenuButtons.Options:
                OptionsMenu.SetActive(true);
                MainMenu.SetActive(false);
                break;
            case MenuButtons.Play:
                //load next scene
                break;
        }
    }
}