using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public LevDeck singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = FindObjectOfType<LevDeck>();
        StartCoroutine(Death());
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(10f);
        Destroy(singleton.gameObject);
        SceneManager.LoadScene("Start");
    }
}
