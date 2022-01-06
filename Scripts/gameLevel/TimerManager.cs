using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text geriSayim;
    [SerializeField]
    private GameObject sonucPanel;
    int kalanSure=10,kontrol;

    GameManager gameManager;
    void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
       
        
    }
public void geriSayimBasla()
    {
        kalanSure += gameManager.sureArttir();
        StartCoroutine(geriSayimRoutine());
       
    }
     

    IEnumerator geriSayimRoutine()
    {
        
        Debug.Log("+ sure "+gameManager.sureArttir());
        yield return new WaitForSeconds(0.5f);
        while(kalanSure>=0)
        {
            geriSayim.GetComponent<Text>().text = kalanSure.ToString();
            yield return new WaitForSeconds(1f);
            kalanSure--;
            
        }
       kontrol++;
       
        if(kontrol==1)
        {
            
           sonucuGetir();
        }
       


       
    }
    

    public void sonucuGetir()
    {
        gameManager.skor();
        gameManager.yildizBelirle();
        sonucPanel.transform.GetComponent<RectTransform>().DOScaleX(1,0.5f).SetEase(Ease.OutExpo);
    }
    
}
