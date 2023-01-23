using UnityEngine;
using UnityEngine.SceneManagement;


namespace Initial
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Base", LoadSceneMode.Additive);
            SceneManager.LoadScene("Menu");
        }
    }
}
