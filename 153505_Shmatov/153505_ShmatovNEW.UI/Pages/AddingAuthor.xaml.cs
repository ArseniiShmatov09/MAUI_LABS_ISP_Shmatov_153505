using _153505_Shmatov.Domain.Entities;
using _153505_ShmatovNEW.UI.ViewModels;

namespace _153505_ShmatovNEW.UI.Pages;

public partial class AddingAuthor : ContentPage
{
    public AddingAuthor(AuthorsViewModel authorsViewModel)
    {
        InitializeComponent();

        BindingContext = authorsViewModel;
    }

    public async void OnAddClicked(object sender, EventArgs e)
    {
        Author author = new Author();
        try 
        { 

            author.Name = this.nameEntry.Text;
            author.Age = Convert.ToInt32(this.ageEntry.Text);
            author.DateOfBirth = this.dateEntry.Text;
            author.Books = new List<Book>(); 
        }

        catch
        {
            this.alertLabel.Text = "Error input";
            return;
        }
        if (author.Name == "" || author.Age == 0 || author.DateOfBirth == "") 
        {
            this.alertLabel.Text = "Error input";
            return;
        };

        await ((AuthorsViewModel)BindingContext).AddAuthorAsync(author);
    }
}