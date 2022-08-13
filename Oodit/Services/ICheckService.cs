using Oodit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oodit.Services
{
    public interface ICheckService
    {
        public ResultListViewModel<int> CheckArray(string stringInput);
    }
}
