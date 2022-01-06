using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePanel;

    [SerializeField]
    private GameObject puanKapPanael, buyukSayiyiSec;

    [SerializeField]
    private GameObject seviyePanel;

    [SerializeField]
    private Text ustDikdortgenTxt, altDikdortgenTxt;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Text dogruSayisi, yanlisSayisi,skorPuan,skorTxt;

    [SerializeField]
    private GameObject solYildizImage, ortaYildizImage, sagYildizImage;

   






    TimerManager timerManager;

    int altDeger, ustDeger, secilenDeger;
    public int btnDeger;


    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen, sure;
    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();

    }
    void Start()
    {
        sahneEkraniGuncelle();
        solYildizImage.SetActive(false);
        ortaYildizImage.SetActive(false);
        sagYildizImage.SetActive(false);
    }

    void sahneEkraniGuncelle()
    {

        puanSurePanel.GetComponent<CanvasGroup>().DOFade(1, 1.2f);
        puanKapPanael.GetComponent<CanvasGroup>().DOFade(1, 1.2f);
        ustDikdortgen.transform.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.InOutBack);
        altDikdortgen.transform.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.InOutBack);
        sure.transform.GetComponent<RectTransform>().DOScale(1, 1.5f).SetEase(Ease.InOutBack);
        seviyePanel.transform.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);



    }

    public void oyunaBasla()
    {
        puanKapPanael.transform.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);//puanKap yazisi
        buyukSayiyiSec.transform.GetComponent<RectTransform>().DOScale(1, 1.5f).SetEase(Ease.OutBack).SetDelay(0.6f);// buyukSayiyiSec yazisi
        Debug.Log("oyun basladi");

    }


    public void seviyeBelirle()
    {
        
       
        switch (btnDeger)
        {
            case 1:
                kolaySeviye();
                seviyePanel.transform.GetComponent<RectTransform>().DOScale(0, 1f).SetEase(Ease.InBack);
                break;

            case 2:
                ortaSeviye();
                seviyePanel.transform.GetComponent<RectTransform>().DOScale(0, 1f).SetEase(Ease.InBack);
                break;

            case 3:
                zorSeviye();
                seviyePanel.transform.GetComponent<RectTransform>().DOScale(0, 1f).SetEase(Ease.InBack);
                break;
           }

        }

    int maxDeger, puanArti, puanEksi, skorpuan=0;
    public void soruYenile()//SORU YENILEME  , DOGRU YANLIS KONTROL VE PUAN YAZDIRMA
    {

        if (btnDeger == 1)
        {
            maxDeger = Mathf.Max(ustDeger, altDeger);
            if (maxDeger == secilenDeger)
            {
                
                puanArti++;
                kolaySeviye();

            }
            else
            {
                
                puanEksi++;
                kolaySeviye();

            }
            skorpuan = puanArti - puanEksi;
            if (skorpuan <= 0)
            {
                skorpuan = 0;
            }
            else
            {
                skorpuan = (skorpuan * 25) - (puanEksi * 10);
            }
            if (skorpuan <= 0)
            {
                skorpuan = 0;
            }
            skorTxt.text = skorpuan.ToString();

        }
        else if (btnDeger == 2)
        {
            maxDeger = Mathf.Max(ustDeger, altDeger);
            if (maxDeger == secilenDeger)
            {
                
                puanArti++;
                ortaSeviye();

            }
            else
            {
               
                puanEksi++;
                ortaSeviye();
            }
            skorpuan = puanArti - puanEksi;
            if (skorpuan <= 0)
            {
                skorpuan = 0;
            }
            else
            {
                skorpuan = (skorpuan * 25) - (puanEksi * 10);
            }
            if (skorpuan <= 0)
            {
                skorpuan = 0;
            }
            skorTxt.text = skorpuan.ToString();
        }
        else
        {
            maxDeger = Mathf.Max(ustDeger, altDeger);
            if (maxDeger == secilenDeger)
            {
                
                puanArti++;
                zorSeviye();
            }
            else
            {
                
                puanEksi++;
                zorSeviye();
            }
            skorpuan = puanArti - puanEksi;
            if (skorpuan <= 0)
            {
                skorpuan = 0;
            }
            else
            {
                skorpuan =(skorpuan* 25)-(puanEksi*10);
            }
            if (skorpuan<=0)
            {
                skorpuan = 0;
            }
            skorTxt.text = skorpuan.ToString();
        }
        

        dogruSayisi.text = "Dogru = " + puanArti.ToString();
        yanlisSayisi.text = "Yanlis = " + puanEksi.ToString();
    }



    public void kolaySeviye()
    {

        int rastgeleDeger = Random.Range(1, 51);

        if (rastgeleDeger <= 20)
        {
            ustDeger = rastgeleDeger;
            altDeger = ustDeger + Random.Range(1, 16);

        }
        else
        {
            ustDeger = rastgeleDeger + Random.Range(10, 25);
            altDeger = ustDeger - Random.Range(1, 16);
        }


        ustDikdortgenTxt.text = ustDeger.ToString();
        altDikdortgenTxt.text = altDeger.ToString();

    }

    public void ortaSeviye()
    {
        int rastgeleDeger = Random.Range(1, 21);
        int rastgeleDeger2 = Random.Range(1, 21);
        int rastgeleDeger3 = Random.Range(1, 21);
        int rastgeleDeger4 = Random.Range(1, 21);

        ustDeger = rastgeleDeger3 * rastgeleDeger4;
        altDeger = rastgeleDeger * rastgeleDeger2;

        ustDikdortgenTxt.text = rastgeleDeger3.ToString() + " X " + rastgeleDeger4.ToString();
        altDikdortgenTxt.text = rastgeleDeger.ToString() + " X " + rastgeleDeger2.ToString();

    }

    public void zorSeviye()
    {
        int rastgeleDeger = Random.Range(1, 11);
        int rastgeleDeger2 = Random.Range(11, 21);
        int rastgeleDeger3 = Random.Range(1, 11);
        int rastgeleDeger4 = Random.Range(10, 21);
        int x, y, z;
        x = rastgeleDeger3 + rastgeleDeger + 3;
        y = rastgeleDeger4 + rastgeleDeger2;
        z = x + y;
        ustDeger = ((Mathf.Abs(y + rastgeleDeger3) - Mathf.Abs(x + rastgeleDeger4)));
        altDeger = ((Mathf.Abs(z - x) - Mathf.Abs(rastgeleDeger + rastgeleDeger2)));

        ustDikdortgenTxt.text = "(" + y.ToString() + "+" + rastgeleDeger3.ToString() + ")" + "-" + "(" + x.ToString() + "+" + rastgeleDeger4.ToString() + ")";

        altDikdortgenTxt.text = "(" + z.ToString() + "-" + x.ToString() + ")" + "-" + "(" + rastgeleDeger.ToString() + "+" + rastgeleDeger2.ToString() + ")";

    }

    int tiklandi = 1;
    public void kolaybutton()
    {
        tiklandi = 4;
        btnDeger = 1;
        seviyeBelirle();
        oyunaBasla();
        timerManager.geriSayimBasla();

    }
    public void ortabutton()
    {
        tiklandi = 4;
        btnDeger = 2;
        seviyeBelirle();
        oyunaBasla();
        timerManager.geriSayimBasla();


    }
    public void zorbutton()
    {
        tiklandi = 4;
        btnDeger = 3;
        seviyeBelirle();
        oyunaBasla();
        timerManager.geriSayimBasla();


    }

    public void tiklanmassa()//tiklanmdaigi durumda rastgele seviye secmesi icin
    {

        if (tiklandi == 1)
        {
            btnDeger = Random.Range(1, 4);
            Debug.Log("seviyeniz: " + btnDeger);
            seviyeBelirle();
            oyunaBasla();
            timerManager.geriSayimBasla();
            tiklandi = 4;
        }
        else ;
    }

    public void secilenBtn(string butonAdi)
    {
        if (butonAdi == "ustBtn")
        {
            secilenDeger = ustDeger;
        }
        else
        {
            secilenDeger = altDeger;
        }

        Debug.Log("asd "+secilenDeger);

    }


    public void yenidenOyna()
    {
        SceneManager.LoadScene("gameLevel");
    }
    public void menu()
    {
        SceneManager.LoadScene("menuLevel");
    }


    public void puaseBtn()
    {
        pausePanel.SetActive(true);


    }


    public void yildizBelirle()
    {
        if ((puanArti - puanEksi) <= 15)
        {
            solYildizImage.SetActive(true);
            ortaYildizImage.SetActive(false);
            sagYildizImage.SetActive(false);
        }
        else if ((puanArti-puanEksi) > 15 && (puanArti-puanEksi) <= 25)
        {

            
            solYildizImage.SetActive(true);
            ortaYildizImage.SetActive(true);
            sagYildizImage.SetActive(false);

        }
        else if ((puanArti-puanEksi)>25)
        {
            
            solYildizImage.SetActive(true);
            ortaYildizImage.SetActive(true);
            sagYildizImage.SetActive(true);

        }
         if (skorpuan <= 0)
        {
            
            solYildizImage.SetActive(false);
            ortaYildizImage.SetActive(false);
            sagYildizImage.SetActive(false);
        }
       


    }

    public void skor()
    {
        
        skorPuan.text = skorpuan.ToString();

    }
    public int arttir;
    public int sureArttir()
    {

        if (btnDeger == 2)
        {
            arttir = 20;
        }
        else if( btnDeger == 3)
        {
            arttir = 40;
        }
        

        return arttir;
    }
    
}
