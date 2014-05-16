using System.Collections.Generic;

namespace Agenda.Dominio.IRepositorio
{
    public interface IRepositorioBase<T> where T : class
    {
        T RetornaPorId(int id);
        IList<T> RetornaTodos();
        IList<T> RetornaPorHql(string hql);
        T Salva(T item);
        T Exclui(T item);
    }
}