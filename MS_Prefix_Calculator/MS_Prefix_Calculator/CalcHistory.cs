using System;
using System.Collections.Generic;


namespace MS_Prefix_Calculator
{
    /// <summary>
    /// Collects Calulation and result's in List - Saved and Laoded
    /// </summary>
    [Serializable]
    class CalcHistory
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CalcHistory()
        {
            _results = new List<String>();
        }
        private List<String> _results;

        /// <summary>
        /// getter for List from obj.
        /// </summary>
        /// <returns>List of History entries</returns>
        public List<String> GetList()
        {
            return _results;
        }

        /// <summary>
        /// Adds new Element to List.
        /// </summary>
        /// <param name="add">Element to add</param>
        /// <returns></returns>
        public int AddResultToList(String add)
        {
            _results.Add(add);
            return 0;
        }


    }
}
