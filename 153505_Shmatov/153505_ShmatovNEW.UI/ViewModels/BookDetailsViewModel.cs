using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Domain.Entities;
using _153505_ShmatovNEW.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_ShmatovNEW.UI.ViewModels
{
    public partial class BookDetailsViewModel : IQueryAttributable
    {
        public Book SelectedBook { get; set; }
        private IBookService _bookService;
        private AuthorsViewModel _authorsViewModel;

        public BookDetailsViewModel(IBookService bookService, AuthorsViewModel authorsViewModel)
        {
            _bookService = bookService;
            _authorsViewModel = authorsViewModel;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedBook = (Book)query["Book"];
        }

        [RelayCommand]
        public async void EditBook() => await GotoEditBook();

        public async Task GotoEditBook()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "selectedBook", SelectedBook }
            };

            await Shell.Current.GoToAsync(nameof(EditingBook), parameters);
        }

        [RelayCommand]
        public async void ChangePhoto()
        {
            var result = await FilePicker.Default.PickAsync();

            if ((result != null && (result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)
                || result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase))) && result.FileName.StartsWith("picture", StringComparison.OrdinalIgnoreCase))
            {
                SelectedBook.imagePath = result.FileName;

                await _authorsViewModel.UpdateBookAsync(SelectedBook);
            }

            else
            {
                SelectedBook.imagePath = "picture0.jpg";
                await _authorsViewModel.UpdateBookAsync(SelectedBook);

            }
        }
    }
}
