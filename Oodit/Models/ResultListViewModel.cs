using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oodit.Models
{
    public class ResultListViewModel<T>
    {
        public IEnumerable<T> List { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get { return String.IsNullOrEmpty(ErrorMessage); }} 
    }
}
