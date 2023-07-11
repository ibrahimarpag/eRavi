using System;
using System.Collections.Generic;

namespace RaviDataManager.Models
{
    public class RaviList<T> : List<T>
    {
        private bool isDataLoaded;

        public event EventHandler Completed = delegate { };

        public bool IsDataLoaded
        {
            get { return isDataLoaded; }
            set
            {
                isDataLoaded = value;
                if (isDataLoaded)
                {
                    OnDataLoaded();
                }
            }
        }

        protected virtual void OnDataLoaded()
        {
            Completed.Invoke(this, EventArgs.Empty);
        }
        public string TableName { get; set; }
        public string StoreProcedureName { get; set; }
        public RaviList()
        {

        }
        public event EventHandler<T> AddRow = delegate { };
        public event EventHandler<List<T>> AddRows = delegate { };
        public void AddR(T veri)
        {
            base.Add(veri);
            AddRow.Invoke(this, veri);
        }
        public void AddRangeR(List<T> veri)
        {
            base.AddRange(veri);
            AddRows.Invoke(this, veri);
        }
    }
}
