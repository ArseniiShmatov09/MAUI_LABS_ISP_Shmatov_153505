using _153505_Shmatov.Domain.Entities;
using _153505_ShmatovNEW.UI.ViewModels;

namespace _153505_ShmatovNEW.UI.Pages;

public partial class AddingBook : ContentPage
{
	public AddingBook(AuthorsViewModel authorsViewModel)
	{
		InitializeComponent();
		BindingContext = authorsViewModel;
	}

    private async void OnAddClicked(object sender, EventArgs e)
    {
        this.alertLabel.Text = "";

        Book book = new Book();
        try
        {
            book.Name = this.nameEntry.Text;
            book.Rating = Convert.ToDouble(this.ratingEntry.Text);
            book.YearOfPublication = this.yearEntry.Text;
            book.Price = Convert.ToInt32(this.priceEntry.Text);
            book.AuthorId = ((AuthorsViewModel)BindingContext).Authors.ToList().First(el => el.Name == this.authorNameEntry.Text).Id;
            book.imagePath = "picture0.jpg";

        }

        catch
        {
            this.alertLabel.Text = "Error input";

            return;
        }

        if (book.Name == "" || book.Rating == 0 || book.YearOfPublication == "" || book.Price == 0)
        {
            this.alertLabel.Text = "Error input";
            return;
        };

        await ((AuthorsViewModel)BindingContext).AddBookAsync(book);

    }
}