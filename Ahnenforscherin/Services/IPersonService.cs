using Ahnenforscherin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Ahnenforscherin.Services;

public partial interface IRepository<T>
{
    Task AddAsync(T entity);
    // Weitere Methoden wie Update, Delete, GetAll können hier definiert werden

    public void AddPerson(Person person);
}
