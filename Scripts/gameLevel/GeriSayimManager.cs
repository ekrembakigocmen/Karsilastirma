using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject geriSayimBasla;
    
    [SerializeField]
    private Text geriSayimBaslatxt;

    GameManager gameManager;

    

    


    
    void Start()
    {
      gameManager=Object.FindObjectOfType<GameManager>();

      
        StartCoroutine(geriyeSayRoutine());
        
      
    }

    IEnumerator geriyeSayRoutine()
    {
     

      yield return new WaitForSeconds(1.55f);// giris animasyonu gelmesini bekletmek icin 1.55 sn 
      geriSayimBaslatxt.text = "4"; //suretext'in ici 4
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(1,2f).SetEase(Ease.OutBack);// animasyon bittiginde suretext scale x degerini 1 yap
      yield return new WaitForSeconds(1f);//1 sn beklet
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(0,0.6f).SetEase(Ease.InBack);// animasyon basladiginda suretext scale x degerini 0 yap
      geriSayimBaslatxt.text = "3"; //suretext'in ici 3
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(1,2f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);//1 sn beklet
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(0,0.6f).SetEase(Ease.InBack);
      geriSayimBaslatxt.text = "2";
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(1,2f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(0,0.6f).SetEase(Ease.InBack);
      geriSayimBaslatxt.text = "1";
      geriSayimBaslatxt.transform.GetComponent<RectTransform>().DOScale(1,2f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);
      geriSayimBasla.transform.GetComponent<RectTransform>().DOScale(0,0.6f); // sureImage scale x degerini 0 yap
      //boylece 3 den geriye sayimi olusturmus olduk
      StopAllCoroutines();// butun coroutine fonksiyonlerini durdur
      gameManager.tiklanmassa();//tiklanmassa rastgele seviye belirler
    }
}
