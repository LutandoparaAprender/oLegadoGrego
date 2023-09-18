using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credi : MonoBehaviour
{
    [SerializeField] private string nomedolevel;
    [SerializeField] private GameObject painelcredi;
    [SerializeField] private GameObject painelmenu;

    public void creditos()
    {
        painelmenu.SetActive(false);
        painelcredi.SetActive(true);
    }
    public void sair()
    {
        painelmenu.SetActive(true);
        painelcredi.SetActive(false);
    }
    public void gameplay()
    { 
        SceneManager.LoadScene(nomedolevel);
        }

        
    }

