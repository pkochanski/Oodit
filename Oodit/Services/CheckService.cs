using Oodit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oodit.Services
{
    public class CheckService:ICheckService
    {
        public ResultListViewModel<int> CheckArray(string stringInput)
        {
            var result = new ResultListViewModel<int>
            {
                List = new List<int>()
            };

            if (String.IsNullOrEmpty(stringInput)){
                return result;
            }
            var stringArray = stringInput.Split(',');
            try
            {
                var intArray = Array.ConvertAll(stringArray, x => ParseStringToInt(x));

                var groupedList = intArray.GroupBy(x => x).Where(x => x.Count() > 2).Select(x => x.Key).OrderByDescending(x => x);

                result.List = groupedList;
                return result;
            }
            catch (Exception)
            {
                result.ErrorMessage = "Error";
                return result;
            }
            
        }

        public static int ParseStringToInt(string value)
        {
            var success = Int32.TryParse(value, out int toReturn);

            if (success)
            {
                return toReturn;
            }

            throw new ArgumentException("Error");
        }
    }
}
