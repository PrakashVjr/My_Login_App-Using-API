using Microsoft.Toolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
   
    public partial  class EmployeeListModel: ObservableObject
    {
        private List<UserInfo> _allEmployeeList;
        private int _Pagesize = 200;
        public ObservableCollection<UserInfo> EmployeeList { get; set; } = new ObservableCollection<UserInfo>();
        private readonly EmployeeListService _employeeListService;

        public EmployeeListModel(EmployeeListService employeeListService)
        {
            _employeeListService = employeeListService;
            GetEmplyoeeList();
        }

        private void GetEmplyoeeList()
        {
            EmployeeList.Clear();
            Task.Run(async () =>
            {
                _allEmployeeList = await _employeeListService.GetUserInfo();

                App.Current.Dispatcher.Dispatch(() =>
                {
                    var recordsToAdded = _allEmployeeList.Take(_Pagesize).ToList();
                    foreach(var record in recordsToAdded)
                    {
                        EmployeeList.Add(record);
                    }

                });
            });
            
        }
    }
}
