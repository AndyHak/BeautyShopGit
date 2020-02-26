using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.InMemory
{
    class VisitDataInMemory : IVisitData
    {
        private List<Visit> visits;

        public VisitDataInMemory()
        {
            visits = new List<Visit>();
        }

        public int Commit()
        {
            return 0;
        }

        public Visit Create(Visit visit)
        {
            visit.Id = visits.Any() ? visits.Max(v => v.Id) + 1 : 1;
            visits.Add(visit);
            return visit;
        }

        public Visit GetVisitById(int visitId)
        {
            return visits.SingleOrDefault(v => v.Id == visitId);
        }

        public Visit GetVisitFullObjById(int id)
        {
            return GetVisitById(id);
        }

        public IEnumerable<Visit> GetVisits(string searchTerm = null)
        {
            return visits
                .Where(v => string.IsNullOrEmpty(searchTerm)
                || v.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                || v.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(v => v.Customer.FirstName);
        }
    }
}
