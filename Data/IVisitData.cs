using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IVisitData
    {
        Visit Create(Visit visit);
        Visit GetVisitById(int visitId);
        Visit GetVisitFullObjById(int id);
        IEnumerable<Visit> GetVisits(string searchTerm = null);
        int Commit();
    }
}
