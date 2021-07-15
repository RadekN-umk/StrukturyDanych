using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StrukturyDanych.Commands;

namespace StrukturyDanych.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Model.MainModel context = new Model.MainModel();
        private List<Model.ProductLastDateView> itemSourceDataGrid1;
        private List<Grid2Class> itemSourceDataGrid2;

        public MainViewModel()
        {
            WindowLoad = new RelayCommand(Window_Loaded);
            RowClick = new RelayCommand(MouseClick);

        }

        private void Window_Loaded(object obj)
        {
            ItemSourceDataGrid1 = context.ProductLastDateView.ToList();
        }
        private void MouseClick(object obj)
        {
            var querry = context.Change.Where(x => x.ProductID == SelectedRow.ID).Select(x => new Grid2Class 
            { 
                ID = x.ID, 
                ChangeDescription = x.ChangeDescription, 
                ChangeDate = x.ChangeDate, 
                Tools = x.Tool.Select(y => y.AlphanumericKey).ToList()
            }).ToList();

            foreach (var item in querry)
            {
                item.Tools = string.Join(";", (List<string>)item.Tools);
            }
            ItemSourceDataGrid2 = querry;
        }

        public ICommand WindowLoad { get; set; }
        public ICommand RowClick { get; set; }
        public List<Model.ProductLastDateView> ItemSourceDataGrid1
        {
            get => itemSourceDataGrid1; 
            set
            {
                itemSourceDataGrid1 = value;
                OnPropertyChanged();
            }
        }
        public List<Grid2Class> ItemSourceDataGrid2
        {
            get => itemSourceDataGrid2;
            set
            {
                itemSourceDataGrid2 = value;
                OnPropertyChanged();
            }
        }
        public Model.ProductLastDateView SelectedRow { get; set; }

        public class Grid2Class
        {
            public int ID { get; set; }
            public string ChangeDescription { get; set; }
            public DateTime? ChangeDate { get; set; }
            public object Tools { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
