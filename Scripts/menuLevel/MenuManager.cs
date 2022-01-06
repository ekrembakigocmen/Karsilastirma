using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform kafa,baslaButton,cikisButton;

    AdmobManager admobManager;


    void Awake()
    {
        admobManager = Object.FindObjectOfType<AdmobManager>();
    }
        void Start()
    {

        
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(1,1f).SetEase(Ease.InOutExpo);
        baslaButton.transform.GetComponent<RectTransform>().DOLocalMoveX(1,1f).SetEase(Ease.InOutExpo);
        cikisButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-650,1f).SetEase(Ease.InOutExpo);
        admobManager.showBanner();
    }
   
 public void oyunaBasla()
 {
     SceneManager.LoadScene("gameLevel");
 }

 public void oyunCikisi()
 {
     Application.Quit();
 }

    
}
