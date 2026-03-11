using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene("TicTacToe");
    }
}
