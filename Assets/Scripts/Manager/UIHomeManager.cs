using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHomeManager : MonoBehaviour
{
    public static UIHomeManager instance;

    [SerializeField] Button btnPlay;
    [SerializeField] Text txtNameCharacter;
    [SerializeField] PopupManager popupManager;

    [Header("Select Character")]
    [SerializeField] Button btnArcher;
    [SerializeField] Button btnSword;
    [SerializeField] Button btnAxe;
    [SerializeField] CharacterShow characterShow;
    [SerializeField] Text txtNoneSelect;

    public CharacterAttribute characterAttribute;

    private const string titleNoneSelect = "Please select character !";
    private const string titleNoneName = "Please enter character name !";
    private const string scenePlay = "Play";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => ClickPlay());
        btnArcher.onClick.AddListener(() => SelectCharacter(0));
        btnSword.onClick.AddListener(() => SelectCharacter(1));
        btnAxe.onClick.AddListener(() => SelectCharacter(2));
    }

    // Update is called once per frame

    void ClickPlay()
    {
        Debug.Log("Click Button Play");
        if (string.IsNullOrEmpty(txtNameCharacter.text))
        {
            popupManager.ShowPopup(titleNoneName);
            return;
        }

        if(characterAttribute == null)
        {
            popupManager.ShowPopup(titleNoneSelect);
            return;
        }

        characterShow.GetCurrentCharacterSelect().GetComponent<CharacterAttribute>().name = txtNameCharacter.text;
        //set attribute to init character
        GameController.instance.SetAttribute(characterShow.GetCurrentCharacterSelect().GetComponent<CharacterAttribute>());
        StartCoroutine(GameController.instance.LoadSceneAsync(scenePlay));

    }

    void SelectCharacter(int index)
    {
        characterShow.ShowCharacter(index);
        txtNoneSelect.gameObject.SetActive(false);
    }

    public void SetCharacterAttribute(CharacterAttribute attribute)
    {
        characterAttribute = attribute;
    }

}
