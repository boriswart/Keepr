using System.Collections.Generic;

namespace Keepr.Interfaces
{
  public interface IRepo<T>
  {
    List<T> GetAll();
    T Create(T data);
    T GetById(int id);
    T Update(T data);
  }
}