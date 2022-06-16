using GridWithCommandBindingWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GridWithCommandBindingWpfApp.ViewModel
{
    class EmployeeListView
    {
        private ICommand m_RowClickCommand;
        ICommand m_RowRemoveCommand;
        ObservableCollection<Employee> _list;
        public EmployeeListView()
        {

        }
        public Employee SelectedData { get; set; }
        public ICommand RowClickCommand
        {
            get
            {
                if (m_RowClickCommand == null)
                {
                    m_RowClickCommand = new DelegateCommand(CanClickRow, ClickRow);
                }
                return m_RowClickCommand;
            }
        }

        private void ClickRow(object parameter)
        {
            var set = this.SelectedData;
            if (set != null)
            {
                MessageBox.Show(set.FirstName, "First Name");
            }
        }
        public ObservableCollection<Employee> EmployeeList
        {
            get
            {
                if (_list == null)
                {
                    _list = new ObservableCollection<Employee>();
                    _list.Add(new Employee() { FirstName = "John", LastName = "Wayne", Age = 35 });
                    _list.Add(new Employee() { FirstName = "Maximus", LastName = "Decimus", Age = 33 });
                    _list.Add(new Employee() { FirstName = "Alexander", LastName = "Conklin", Age = 42 });
                    _list.Add(new Employee() { FirstName = "Jason", LastName = "Bourne", Age = 66 });
                }
                return _list;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (m_RowRemoveCommand == null)
                {
                    m_RowRemoveCommand = new DelegateCommand(CanRemoveRow, RemoveRow);
                }
                return m_RowRemoveCommand;
            }
        }
        private void RemoveRow(object parameter)
        {
            int index = EmployeeList.IndexOf(parameter as Employee);
            if (index > -1 && index < EmployeeList.Count)
            {
                EmployeeList.RemoveAt(index);
            }
        }

        private bool CanClickRow(object parameter)
        {
            return true;
        }
        private bool CanRemoveRow(object parameter)
        {
            return true;
        }


    }
}
