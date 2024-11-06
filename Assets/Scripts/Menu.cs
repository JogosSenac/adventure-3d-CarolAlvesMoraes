using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField]GameObject menuEsc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuEsc != null){
            if(Input.GetKeyUp(KeyCode.Escape)){
                Debug.Log("escape apertado");
                AbrirEsc(); 
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("fase1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void AbrirEsc(){
        menuEsc.SetActive(true);
    }
    public void FecharEsc(){
        menuEsc.SetActive(false);
    }
}
