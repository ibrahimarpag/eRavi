using DevExpress.XtraGrid.Views.Grid;
using RaviDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaviMalzeme
{
    public class RaviGridView : GridView
    {
        public GRIDFTIP GridFTip { get; set; }
        public GRIDEKEY GridEKey { get; set; }
        private CancellationToken token { get; set; }
        public CancellationTokenSource tokenSource { get; set; }
        public event EventHandler<int> GetData = delegate { };
        int pageNumber = 1;
        public object Data { get; set; } = null;
        public RaviGridView() : base()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }
        public void LoadData()
        {
            base.GridControl.DataSource = Data;
            ClearData();
            //GetData.Invoke(this, pageNumber);
        }
        public async void AddNewData<T>(List<T> Veri)
        {
            try
            {
                if (Data == null) Data = new List<T>();
                await Task.Factory.StartNew(() =>
                {
                    if (Veri.Count > 0)
                    {
                        if (Data is List<T> d)
                        {
                            foreach (var item in Veri) d.Add(item);

                            base.GridControl.RefreshDataSource();
                            GetData.Invoke(this, pageNumber++);
                        }
                    }
                }, tokenSource.Token);

            }
            catch (Exception ex)
            {

            }

        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            tokenSource.Cancel();
        }
        public void ClearData()
        {
            if (Data is List<object> d) d.Clear();
        }
        public T GetSelectedRow<T>()
        {
            if (base.GetFocusedRow() is T row) return row;
            return default(T);
        }
        public async Task CallFunction(Func<Task, int, Task> function)
        {
            //try
            //{
            //    await Task.Factory.StartNew(async () =>
            //    {
            //        await function.Invoke(Task.CompletedTask, pageNumber);
            //    }, tokenSource.Token); 
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}
