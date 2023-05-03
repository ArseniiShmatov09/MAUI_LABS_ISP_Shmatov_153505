using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_ShmatovNEW.UI.ViewModels
{
    public partial class BookEditViewModel : IQueryAttributable
    {
        public IAuthorService _authorService;
        public Book SelectedBook { get; set; }
        public BookEditViewModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            SelectedBook = (Book)query["selectedBook"];
        }

    }
}
