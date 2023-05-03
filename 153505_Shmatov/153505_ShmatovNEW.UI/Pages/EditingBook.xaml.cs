using _153505_Shmatov.Domain.Entities;
using _153505_ShmatovNEW.UI.ViewModels;

namespace _153505_ShmatovNEW.UI.Pages;

public partial class EditingBook : ContentPage
{
	AuthorsViewModel _authorsViewModel;

	public EditingBook(BookEditViewModel bookEditViewModel, AuthorsViewModel authorsViewModel)
	{
		InitializeComponent();
		_authorsViewModel = authorsViewModel;
		BindingContext = bookEditViewModel;
	}

    private async void OnAddClicked(object sender, EventArgs e)
    {
        this.alertLabel.Text = "";

        
        
        try
        {
            ((BookEditViewModel)BindingContext).SelectedBook.Name = this.nameEntry.Text;
            ((BookEditViewModel)BindingContext).SelectedBook.Rating = Convert.ToDouble(this.ratingEntry.Text);
            ((BookEditViewModel)BindingContext).SelectedBook.YearOfPublication = this.yearEntry.Text;
            ((BookEditViewModel)BindingContext).SelectedBook.Price = Convert.ToInt32(this.priceEntry.Text);
            ((BookEditViewModel)BindingContext).SelectedBook.AuthorId = (await((BookEditViewModel)BindingContext)
                ._authorService.GetAllAsync()).Where(el => el.Name == this.authorNameEntry.Text).First().Id;
           // ((BookEditViewModel)BindingContext).SelectedBook.Id = 9;
        }

        catch
        {
            this.alertLabel.Text = "Error input";

            return;
        }

        if (((BookEditViewModel)BindingContext).SelectedBook.Name == "" || ((BookEditViewModel)BindingContext).SelectedBook.Rating == 0 || 
            ((BookEditViewModel)BindingContext).SelectedBook.YearOfPublication == "" || ((BookEditViewModel)BindingContext).SelectedBook.Price == 0)
        {
            this.alertLabel.Text = "Error input";
            return;
        };

        await _authorsViewModel.UpdateBookAsync(((BookEditViewModel)BindingContext).SelectedBook);

    }

	public async void  OnLoadedPage(object sender, EventArgs e)
	{
        this.nameEntry.Text = ((BookEditViewModel)BindingContext).SelectedBook.Name;
        this.ratingEntry.Text = ((BookEditViewModel)BindingContext).SelectedBook.Rating.ToString();
        this.priceEntry.Text = ((BookEditViewModel)BindingContext).SelectedBook.Price.ToString();
        this.yearEntry.Text = ((BookEditViewModel)BindingContext).SelectedBook.YearOfPublication;
        this.authorNameEntry.Text = (await ((BookEditViewModel)BindingContext)._authorService
            .GetByIdAsync(((BookEditViewModel)BindingContext).SelectedBook.AuthorId)).Name;
    }
}