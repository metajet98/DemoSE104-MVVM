using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SinhVienDAL    

    {
        private static ObservableCollection<SinhVien> listSinhVien = new ObservableCollection<SinhVien>() { new SinhVien() { Id = 1, Ten = "Long" }, new SinhVien() { Id = 2, Ten = "Hoang" } ,new SinhVien() { Id = 3, Ten = "Phan" }, new SinhVien() { Id = 4, Ten = "Trung" }};
        
        public static ObservableCollection<SinhVien> getListSinhVienFromDatabase()
        {
           
            
            return listSinhVien;
        }
        public static void DeleteSinhVien(SinhVien sinhVien)
        {
            listSinhVien.Remove(sinhVien);
        }
        public static void AddSinhVien(SinhVien sinhVien)
        {
            listSinhVien.Add(sinhVien);
        }
        public static void ModifySinhVien(SinhVien sinhVien)
        {
            foreach (var sv in listSinhVien)
            {
                if(sv.Id==sinhVien.Id)
                {
                    sv.Ten = sinhVien.Ten;
                }
            }
        }

    }
}
