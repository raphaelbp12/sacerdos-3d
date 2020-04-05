/* Example level loader */
using UnityEngine;
using System.Collections;

public class SkillBindingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    public bool GameIsPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {
            Debug.Log("TESTE!");
            PauseGame();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            Debug.Log("TESTE 2!");
            ResumeGame();
            return;
        }
    }
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
