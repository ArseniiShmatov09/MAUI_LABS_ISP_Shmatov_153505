using MAUI_LABS.Entities;
using MAUI_LABS.Services;
using System.Collections.ObjectModel;

namespace MAUI_LABS;

public partial class DataBase : ContentPage
{
    private readonly IDbService _dbService;
    private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();
    private readonly ObservableCollection<Author> _authors = new ObservableCollection<Author>();
    private string _selectedAuthorName;

    public DataBase(IDbService dbService)
    {

        this._dbService = dbService;

        dbService.DeleteAllData();
        dbService.Init();
        InitializeComponent();
        LoadAuthors();

        booksCollectionView.ItemsSource = _books;

    }
    private void LoadAuthors()
    {
        var authors = _dbService.GetAllAuthors();
        foreach (var author in authors)
        {
            _authors.Add(author);
        }

        AuthorPicker.ItemsSource = _authors;
        AuthorPicker.ItemDisplayBinding = new Binding("Name");
    }

    private void OnAuthorPickerSelectedIndexChanged(object sender, System.EventArgs e)
    {
        Author author = (Author)AuthorPicker.SelectedItem;

        if (author == null) return;

        _selectedAuthorName = author.Name;

        _books.Clear();

        var books = _dbService.GetAuthorBooks(author.Id);
        
        foreach (var book in books)
        {
            _books.Add(book);

        }

        LTitle.Text = "Title";
        LYearOfPublication.Text = "Year of publication";
        LPrice.Text = "Price($)";
    }


}