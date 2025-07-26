using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BooksPanelController : PanelController
{
    public GameObject BookPrefab;
    public Transform bookslistparent;

    public TextMeshProUGUI SelectedName;
    public TextMeshProUGUI SelectedCategory;
    public TextMeshProUGUI SelectedAudioURL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager._apimanger.Get("0800381c-53ba-4849-8c2e-547ab4ce6228", onBooksFetched);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        _gameManager._apimanger.Get("0800381c-53ba-4849-8c2e-547ab4ce6228", onBooksFetched);
    }

    private void onBooksFetched(string data)
    { 
        BooksModel books = JsonUtility.FromJson<BooksModel>(data);

        foreach (Transform item in bookslistparent)
        {
            Destroy(item.gameObject);
        }

        foreach (var book in books.stories) 
        {
            GameObject thebook = Instantiate(BookPrefab, bookslistparent);
            thebook.GetComponentInChildren<TextMeshProUGUI>().text = book.name;
            Button btn = thebook.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() => ShowInfo(book.name, book.category, book.audio_url));
        }
    }

    public void ShowInfo(string name,string category,string url)
    {
        SelectedName.text = name;
        SelectedCategory.text = category;
        SelectedAudioURL.text = url;
    }

}
