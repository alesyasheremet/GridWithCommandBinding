using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridWithCommandBindingWpfApp.Model
{
    class Employee : IEquatable<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public bool Equals(Employee other)
        {
            if (other is null)
                return false;

            return this.LastName == other.LastName && this.FirstName == other.FirstName;
        }

        public override bool Equals(object obj) => Equals(obj as Employee);
        public override int GetHashCode() => (this.LastName + this.FirstName).GetHashCode();

    }
}
