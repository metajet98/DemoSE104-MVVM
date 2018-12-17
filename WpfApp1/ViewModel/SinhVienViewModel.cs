using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using Model;

namespace ViewModel
{
    public class SinhVienViewModel
    {
        private ObservableCollection<SinhVien> listSinhVien;

        public ObservableCollection<SinhVien> ListSinhVien
        {
            get { return listSinhVien; }
            set { listSinhVien = value; }
        }
        public SinhVienViewModel()
        {
            updateSinhVien();
            ModifyCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) => {
                int id = 0;
                string ten = "";
                bool isIDInt = false;

                foreach (var item in p)
                {
                    TextBox a = item as TextBox;
                    if (a == null)
                        continue;
                    switch (a.Name)
                    {
                        case "txbID":
                            isIDInt = Int32.TryParse(a.Text, out id);
                            break;
                        case "txbTen":
                            ten = a.Text;
                            break;

                    }

                }
                if (!isIDInt || string.IsNullOrEmpty(ten))
                {
                    return;
                }
                SinhVien b = new SinhVien() { Id = id, Ten = ten };
                SinhVienDAL.ModifySinhVien(b);
                updateSinhVien();
            });
            DeleteCommand = new RelayCommand<object>((p) => p != null, (p) => {
               SinhVienDAL.DeleteSinhVien(p as SinhVien);
                updateSinhVien();
            });
            AddCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) => {
                int id = 0;
                string ten = "";
                bool isIDInt = false;

                foreach (var item in p)
                {
                    TextBox a = item as TextBox;
                    if (a == null)
                        continue;
                    switch(a.Name)
                    {
                        case "txbID":
                            isIDInt = Int32.TryParse(a.Text, out id);
                            break;
                        case "txbTen":
                            ten = a.Text;
                            break;

                    }
                    
                }
                if (!isIDInt || string.IsNullOrEmpty(ten))
                {
                    return;
                }
                SinhVien b = new SinhVien() { Id = id, Ten = ten };
                SinhVienDAL.AddSinhVien(b);
                updateSinhVien();
            });


        }
        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand ModifyCommand { get; set; }
        void updateSinhVien()
        {
            listSinhVien = SinhVienDAL.getListSinhVienFromDatabase();

        }

    }

}
