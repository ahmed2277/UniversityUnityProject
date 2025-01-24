using UnityEngine;
using UnityEngine.SceneManagement;

public class next : MonoBehaviour
{
    // Generic method to load any level by index
    public void LoadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
