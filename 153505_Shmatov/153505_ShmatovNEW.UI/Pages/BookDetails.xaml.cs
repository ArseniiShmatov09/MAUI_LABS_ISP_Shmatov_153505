using _153505_ShmatovNEW.UI.ViewModels;

namespace _153505_ShmatovNEW.UI.Pages;

public partial class BookDetails : ContentPage
{
	public BookDetails(BookDetailsViewModel bookDetailsViewModel)
	{
		BindingContext = bookDetailsViewModel;
		InitializeComponent();
	}

    public void OnLoadPage(object sender, EventArgs e)
    {
        this.nameL.Text = "Name: " + ((BookDetailsViewModel)BindingContext).SelectedBook.Name;
        this.priceL.Text = "Price: " + ((BookDetailsViewModel)BindingContext).SelectedBook.Price.ToString();
        this.yearOfPublicationL.Text = "Year of publication: " + ((BookDetailsViewModel)BindingContext).SelectedBook.YearOfPublication;
        this.ratingL.Text = "Rating: " + ((BookDetailsViewModel)BindingContext).SelectedBook.Rating.ToString();
        this.image.Source = ((BookDetailsViewModel)BindingContext).SelectedBook.imagePath;

    }
}