using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Play Screen


    [Header ("Play Screen")]
    public GameObject PlayButtonCanvas;
    public Button playButton;


    //Character Select Screen

    [Header ("Character Select Screen")]
    public GameObject CharSelectCanvas;
    public Sprite FemaleImage;
    public Sprite MaleImage;
    public Sprite selectedImage;
    public Button MaleButton;
    public Button FemaleButton;
    private bool isCharSelected;

    public TMP_InputField PlayerNameInputF;
    public TextMeshProUGUI PlayerNamePlaceholder;
    
    public string PlayerName;



    //InGame Menu Screen
    
    [Header ("In Game Menu")]

    public GameObject InGameMenuCanvas;
    public GameObject CharImage;
    public Image healthBar;
    public Image xpBar;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI playerNameText;
    public float coin;
    public int daycounter;
    public float health;
    public int LevelCounter;
    public float xpCounter;
    private float nextLevelXP;
    public Button nextDayButton;
    public Button JobButton;
    private float hungerPoints;
    public TextMeshProUGUI hungerText;
    public Image hungerBar;


    // Stat Screen


    [Header ("Alt Stats")]
    
    public Button StatCloseButton;
    public Button StatOpenButton;
    public GameObject StatCanvas;

    private int StrLevel;
    private float StrXP;
    private float StrNextLevelXP;
    private float StrMulti = 1;
    public TextMeshProUGUI StrMultiText;

    private int AgiLevel;
    private float AgiXP;
    private float AgiNextLevelXP;
    private float AgiMulti = 1;
    public TextMeshProUGUI AgiMultiText;

    private int IntLevel;
    private float IntXP;
    private float IntNextLevelXP;
    private float IntMulti = 1;
    public TextMeshProUGUI IntMultiText;

    private int StaLevel;
    private float StaXP;
    private float StaNextLevelXP;
    private float StaMulti = 1;
    public TextMeshProUGUI StaMultiText;

    private int LuckLevel;
    private float LuckXP;
    private float LuckNextLevelXP;
    private float LuckMulti = 1;
    public TextMeshProUGUI LuckMultiText;


    public TextMeshProUGUI StrText;
    public Image StrBar;

    public TextMeshProUGUI IntText;
    public Image IntBar;

    public TextMeshProUGUI AgiText;
    public Image AgiBar;

    public TextMeshProUGUI StaText;
    public Image StaBar;

    public TextMeshProUGUI LuckText;
    public Image LuckBar;

    public TextMeshProUGUI strXpText;
    public TextMeshProUGUI agiXpText;
    public TextMeshProUGUI intXpText;
    public TextMeshProUGUI staminaXpText;
    public TextMeshProUGUI luckXpText;

    //Multiplier Buttons

    public Button StrAddButton;
    public Button AgilityAddButton;
    public Button IntAddButton;
    public Button StaminaAddButton;
    public Button LuckAddButton;
    private float statCounter;
    public GameObject statAddButtonCanvas;


    [Header("Jobs")]
    //Jobs

    public GameObject JobsCanvas;
    public Button jobScreenBackButton;

    public Button timbermanSelectButton;
    public TextMeshProUGUI timbermanSelectText;
    public bool isTimbermanSelected;

    public Button hunterSelectButton;
    public TextMeshProUGUI hunterSelectText;
    public bool isHunterSelected;

    public Button porterSelectButton;
    public TextMeshProUGUI porterSelectText;
    public bool isPorterSelected;

    public Button IntAlchSelectButton;
    public TextMeshProUGUI IntAlchSelectText;
    public bool isIntAlchSelected;




    // Start is called before the first frame update
    void Start()
    {


        //Button Click
        

        playButton.onClick.AddListener(PlayButtonClicked);
        FemaleButton.onClick.AddListener(FemaleClicked);
        MaleButton.onClick.AddListener(MaleClicked);

        //Starting Stats

        StatCloseButton.onClick.AddListener(StatClose);
        StatOpenButton.onClick.AddListener(StatButton);
        
        //InGame Menu Buttons

        nextDayButton.onClick.AddListener(NextDay);
        JobButton.onClick.AddListener(JobsButtonClicked);

        //Job Buttons

        jobScreenBackButton.onClick.AddListener(OpenInGameMenuCanvas);
        timbermanSelectButton.onClick.AddListener(selectTimberman);
        hunterSelectButton.onClick.AddListener(selectHunter);
        porterSelectButton.onClick.AddListener(selectPorter);

        LevelCounter = 1;
        nextLevelXP=100;
        GetHealth(100);
        GetXP(0);
        GetHunger(100);

        //

        StrLevel = 1;
        StrNextLevelXP = 100;
        
        AgiLevel = 1;
        AgiNextLevelXP = 100;

        IntLevel = 1;
        IntNextLevelXP = 100;

        StaLevel = 1;
        StaNextLevelXP = 100;

        LuckLevel = 1;
        LuckNextLevelXP = 100;

        //Multiplier Addition

        StrAddButton.onClick.AddListener(addStrength);
        AgilityAddButton.onClick.AddListener(addAgility);
        IntAddButton.onClick.AddListener(addIntellect);
        StaminaAddButton.onClick.AddListener(addStamina);
        LuckAddButton.onClick.AddListener(addLuck);

        //ReStarting

        OpenInGameMenuCanvas();

    }




    // Update is called once per frame
    void Update()
    {
        
    }


    // Buttons

    //Next Day

    public void NextDay ()
    {
        daycounter ++;
        dayText.text = daycounter.ToString();
        GetHunger(-10);
        
        if(isTimbermanSelected)
        {
            GetCoin(5);
            GetXP(20);
            getStrXP(20);
        }
        
        if(isHunterSelected)
        {
            GetCoin(8);
            GetXP(15);
            getAgiXP(20);
        }

        if(isPorterSelected)
        {
            GetCoin(10);
            GetXP(10);
            getStaXP(30);
        }

        if(isIntAlchSelected)
        {
            GetCoin(0);
            GetXP(30);
            getIntXP(30);
        }
    }

    //Char Select

    //OpenCanvasFuncions

    public void OpenPlayCanvas()
    {
        CharSelectCanvas.SetActive(false);
        InGameMenuCanvas.SetActive(false);
        PlayButtonCanvas.SetActive(true);
        StatCanvas.SetActive(false);
        JobsCanvas.SetActive(false);
    }

    public void OpenCharSelectCanvas()
    {
        CharSelectCanvas.SetActive(true);
        InGameMenuCanvas.SetActive(false);
        PlayButtonCanvas.SetActive(false);
        StatCanvas.SetActive(false);
        JobsCanvas.SetActive(false);
    }

    public void OpenInGameMenuCanvas()
    {
        CharSelectCanvas.SetActive(false);
        InGameMenuCanvas.SetActive(true);
        PlayButtonCanvas.SetActive(false);
        StatCanvas.SetActive(false);
        JobsCanvas.SetActive(false);
    }

    public void OpenJobsCanvas()
    {
        CharSelectCanvas.SetActive(false);
        InGameMenuCanvas.SetActive(false);
        PlayButtonCanvas.SetActive(false);
        StatCanvas.SetActive(false);
        JobsCanvas.SetActive(true);
    }



    void MaleClicked ()
    {
        
        CharImage.GetComponent<SpriteRenderer>().sprite = MaleImage;
        selectedImage = MaleImage;
        
        PlayerName = PlayerNameInputF.text;
        
        isCharSelected = true;


        if (PlayerName == null || PlayerName.Length == 0)
        {
            PlayerNamePlaceholder.text = "Invalid Nickname...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }

        else if (PlayerName.Length > 2)
        {
            playerNameText.text = PlayerName;
            OpenInGameMenuCanvas();
        }

        else if(PlayerName.Length <= 2)
        {
            PlayerNamePlaceholder.text = "Longer Than 2 Characters...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }

        else
        {
            PlayerNamePlaceholder.text = "Invalid Nickname...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }
    }

        void FemaleClicked ()
    {
        
        CharImage.GetComponent<SpriteRenderer>().sprite = FemaleImage;
        selectedImage = FemaleImage;

        isCharSelected = true;

        PlayerName = PlayerNameInputF.text;

        if (PlayerName == null || PlayerName.Length == 0)
        {
            PlayerNamePlaceholder.text = "Invalid Nickname...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }

        else if (PlayerName.Length > 2)
        {
            playerNameText.text = PlayerName;
            OpenInGameMenuCanvas();
        }

        else if(PlayerName.Length <= 2)
        {
            PlayerNamePlaceholder.text = "Longer Than 2 Characters...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }

        else
        {
            PlayerNamePlaceholder.text = "Invalid Nickname...";
            PlayerNamePlaceholder.color = Color.red;
            PlayerNameInputF.text = "";
        }
    }

        void PlayButtonClicked()
    {
        if(isCharSelected)
        {
            OpenInGameMenuCanvas();
            CharImage.GetComponent<SpriteRenderer>().sprite = selectedImage;
        }
        else
        {
            OpenCharSelectCanvas();
        }


    }



    // Stats

    public void GetCoin(int CoinAmount)
    {
        coin += CoinAmount;
        coinText.text = coin.ToString();
    }

    

    public void GetHealth(float healthAmount)
    {
        health += healthAmount;
        if(health < 0)
        {
            health = 0;
        }
        else if(health > 100)
        {
            health = 100;
        }
        healthText.text = health.ToString();
        healthBar.fillAmount = health / 100f;
    }

    public void GetXP(float xpAmount)
    {
        if (nextLevelXP > xpCounter + xpAmount)
        {
            xpCounter += xpAmount;
        }
        else if(nextLevelXP <= xpAmount + xpCounter)
        {
            xpCounter = xpAmount + xpCounter - nextLevelXP;
            LevelUP();
        }

        xpBar.fillAmount = xpCounter / nextLevelXP;
        xpText.text = xpCounter.ToString() + " / " + nextLevelXP.ToString();
        
         
    }

    public void LevelUP()
    {
        nextLevelXP += 75*LevelCounter;
        LevelCounter ++;
        LevelText.text = LevelCounter.ToString();

        if (LevelCounter > statCounter)
        {
            statAddButtonCanvas.SetActive(true);
        }
    }

    public void GetHunger(float hungerAmount)
    {
        
        hungerPoints += hungerAmount;

        if(hungerPoints < 0)
        {
            hungerPoints = 0;
        }
        
        if(hungerPoints > 100)
        {
            hungerPoints = 100;
        }

        hungerText.text = hungerPoints.ToString() + " / 100";
        hungerBar.fillAmount = hungerPoints / 100f;
    }

    // Alt StatLevels

    public void StatButton()
    {
        if(StatCanvas.activeSelf)
        {
            StatCanvas.SetActive(false);
        }

        else
        {
            StatCanvas.SetActive(true);
        }
    }

    public void StatClose()
    {
        StatCanvas.SetActive(false);
    }

    //STR

    public void getStrXP(float xpAmount)
    {
        float xpGain;

        xpGain = xpAmount*StrMulti;

        if (StrNextLevelXP > StrXP + xpGain)
        {
            StrXP += xpGain;
        }
        else if(StrNextLevelXP <= xpGain + StrXP)
        {
            StrXP = xpGain + StrXP - StrNextLevelXP;
            StrLevelUP();
        }

        StrBar.fillAmount = StrXP / StrNextLevelXP;
        strXpText.text = StrXP.ToString() + " / " + StrNextLevelXP.ToString();
         
    }

    public void StrLevelUP()
    {
        StrNextLevelXP += 25*StrLevel;
        StrLevel ++;
        StrText.text = StrLevel.ToString();
    }


    //AGI

        public void getAgiXP(float xpAmount)
    {
        float xpGain;

        xpGain = xpAmount*AgiMulti;

        if (AgiNextLevelXP > AgiXP + xpGain)
        {
            AgiXP += xpGain;
        }
        else if(AgiNextLevelXP <= xpGain + AgiXP)
        {
            AgiXP = xpGain + AgiXP - AgiNextLevelXP;
            AgiLevelUp();
        }

        AgiBar.fillAmount = AgiXP / AgiNextLevelXP;
        agiXpText.text = AgiXP.ToString() + " / " + AgiNextLevelXP.ToString();
         
    }

    public void AgiLevelUp()
    {
        AgiNextLevelXP += 25*AgiLevel;
        AgiLevel ++;
        AgiText.text = AgiLevel.ToString();
    }

    //INT

    public void getIntXP(float xpAmount)
    {
        float xpGain;

        xpGain = xpAmount*IntMulti;

        if (IntNextLevelXP > IntXP + xpGain)
        {
            IntXP += xpGain;
        }
        else if(IntNextLevelXP <= xpGain + IntXP)
        {
            IntXP = xpGain + IntXP - IntNextLevelXP;
            IntLevelUp();
        }

        IntBar.fillAmount = IntXP / IntNextLevelXP;
        intXpText.text = IntXP.ToString() + " / " + IntNextLevelXP.ToString();
         
    }

    public void IntLevelUp()
    {
        IntNextLevelXP += 25*IntLevel;
        IntLevel ++;
        IntText.text = IntLevel.ToString();
    }


    //STA


    public void getStaXP(float xpAmount)
    {
        float xpGain;

        xpGain = xpAmount*StaMulti;

        if (StaNextLevelXP > StaXP + xpGain)
        {
            StaXP += xpGain;
        }
        else if(StaNextLevelXP <= xpGain + StaXP)
        {
            StaXP = xpGain + StaXP - StaNextLevelXP;
            StaLevelUp();
        }

        StaBar.fillAmount = StaXP / StaNextLevelXP;
        staminaXpText.text = StaXP.ToString() + " / " + StaNextLevelXP.ToString();
         
    }

    public void StaLevelUp()
    {
        StaNextLevelXP += 25*StaLevel;
        StaLevel ++;
        StaText.text = StaLevel.ToString();
    }


    //LUCK

    public void getLuckXP(float xpAmount)
    {
        float xpGain;

        xpGain = xpAmount*LuckMulti;

        if (LuckNextLevelXP > LuckXP + xpGain)
        {
            LuckXP += xpGain;
        }
        else if(LuckNextLevelXP <= xpGain + LuckXP)
        {
            LuckXP = xpGain + LuckXP - LuckNextLevelXP;
            LuckLevelUp();
        }

        LuckBar.fillAmount = LuckXP / LuckNextLevelXP;
        luckXpText.text = LuckXP.ToString() + " / " + LuckNextLevelXP.ToString();
         
    }

    public void LuckLevelUp()
    {
        LuckNextLevelXP += 25*LuckLevel;
        LuckLevel ++;
        LuckText.text = LuckLevel.ToString();
    }


    //Add Stat Multi

    public void addStrength()
    {
        StrMulti += 0.1f;
        StrMultiText.text = StrMulti.ToString() + "x";  

        statCounter++;

        if (statCounter >= LevelCounter)
        {
            statAddButtonCanvas.SetActive(false);
        }  
    }

        public void addAgility()
    {
        AgiMulti += 0.1f;
        AgiMultiText.text = AgiMulti.ToString() + "x"; 

        statCounter++;

        if (statCounter >= LevelCounter)
        {
            statAddButtonCanvas.SetActive(false);
        }   
    }

        public void addIntellect()
    {
        IntMulti += 0.1f;
        IntMultiText.text = IntMulti.ToString() + "x";  

        statCounter++;

        if (statCounter >= LevelCounter)
        {
            statAddButtonCanvas.SetActive(false);
        }  
    }

        public void addStamina()
    {
        StaMulti += 0.1f;
        StaMultiText.text = StaMulti.ToString() + "x";  

        statCounter++;

        if (statCounter >= LevelCounter)
        {
            statAddButtonCanvas.SetActive(false);
        }  
    }

        public void addLuck()
    {
        LuckMulti += 0.1f;
        LuckMultiText.text = LuckMulti.ToString() + "x";

        statCounter++;

        if (statCounter >= LevelCounter)
        {
            statAddButtonCanvas.SetActive(false);
        }  
    }



    // Jobs

        public void JobsButtonClicked()
    {
        OpenJobsCanvas();
    }

        public void closeEveryJob()
        {
            isTimbermanSelected = false;
            timbermanSelectText.text = "Select";

            isHunterSelected = false;
            hunterSelectText.text = "Select";

            isPorterSelected = false;
            porterSelectText.text = "Select";

            isIntAlchSelected = false;
            IntAlchSelectText.text = "Selected";
        }

        public void selectTimberman()
        {
            closeEveryJob();
            isTimbermanSelected = true;
            timbermanSelectText.text = "Selected";
        }
    
        public void selectHunter()
        {
            closeEveryJob();
            isHunterSelected = true;
            hunterSelectText.text = "Selected";
        }

        public void selectPorter()
        {
            closeEveryJob();
            isPorterSelected = true;
            porterSelectText.text = "Selected";
        }

        public void selectIntAlch()
        {
            closeEveryJob();
            isIntAlchSelected = true;
            IntAlchSelectText.text = "Selected";
        }



}