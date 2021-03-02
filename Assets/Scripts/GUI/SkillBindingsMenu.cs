/* Example level loader */
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillBindingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    public bool GameIsPaused = false;
    public bool menuIsOpen = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Keyboard.current[Key.Escape].wasPressedThisFrame && !menuIsOpen) {
            Debug.Log("open menu");
            menuIsOpen = true;
            pauseMenuUI.SetActive(true);
            return;
        }
        if (Keyboard.current[Key.Escape].wasPressedThisFrame && menuIsOpen) {
            Debug.Log("close menu");
            menuIsOpen = false;
            pauseMenuUI.SetActive(false);
            return;
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
