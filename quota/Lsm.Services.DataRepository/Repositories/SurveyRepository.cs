using System.Linq;
using DoE.Lsm.Logger;
using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Data.Repository.Norms;
using System;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repositories.Norms
{

    public class SurveyRepository : RepositoryFactory<InterfaceSurvey>, ISurveysRepository
    {

        public string BookYear
        {
            get
            {
                try { return Db.InterfaceSurveys.Where(c => c.IsEffective == true).SingleOrDefault().Label; } catch { return ""; }
            }
        }

        public string SurveyId
        {
            get
            {
                try { return Db.InterfaceSurveys.Where(c => c.IsEffective == true).SingleOrDefault().SurveyKey; } catch  { return ""; }
            }
        }



        public DateTime ExpiresOn
        {
            get
            {
                try { return Db.InterfaceSurveys.Where(c => c.IsEffective == true).SingleOrDefault().ExpiresOn; } catch { return DateTime.Today.AddDays(-1); }
            }
        }

        public DateTime EffectiveFrom
        {
            get
            {
                try { return Db.InterfaceSurveys.Where(c => c.IsEffective == true).SingleOrDefault().EffectiveFrom; } catch { return DateTime.Today.AddDays(1);}
            }
        }

        public bool IsSurveyEntityInstalled(string surveyId, string entityId, DateTime expiresOn)
        {
            try
            {
                var entity = Db.SurveysEntities.Where(c => c.EntityId.Equals(entityId))
                                               .Where(c => c.InterfaceSurveyId.Equals(surveyId))
                                               .Where(c => c.InstalledOn < expiresOn)
                                               .SingleOrDefault();
                return (entity != null);
            }
            catch {return false;}

        }

        public string GetNorm(string normGroup, string label, string bookYear)
        {
            throw new NotImplementedException();
        }

        public string SurveyCD
        {
            get
            {
                try { return Db.InterfaceSurveys.Where(c => c.IsEffective == true).SingleOrDefault().Id.ToString(); } catch { return ""; }
            }
        }

        #region Boiler Plate Helpers


        public SurveyRepository(PortalLsm dbContext, ILogger logger) : base(dbContext, logger) { }

        private PortalLsm Db { get { return this._DbContext as PortalLsm; } }



        //public IEnumerable<vw_RequisitionsNorms> GetNorms(int EmisCode, string bookyear)
        //{
        //    try
        //    {
        //        return LsmEntityDB.vw_RequisitionsNorms
        //                 .Where(c => c.EmisCode == EmisCode)
        //                 .Where(c => c.BookYear.Equals(bookyear));
        //    }
        //    catch (Exception e)
        //    {
        //        throw new EntityNotFoundException( e.InnerException.ToString(), "Unable To Load Calendar", "Ensure that calendar configurations for this year is active." , LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //    }
        //}

        //[DataMember]
        //public int AccountingTerm
        //{
        //    get
        //    {
        //        try
        //        {

        //            var calendar = LsmEntityDB.vw_RequisitionsNorms
        //                          .Take(1)
        //                          .Select(c => c.Term)
        //                          .Single();
        //            return calendar;
        //        }
        //        catch (Exception e)
        //        {
        //            throw new EntityNotFoundException(e.InnerException.ToString(), "Unable To Load Term", "Ensure that the term configurations are active.", LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //        }
        //    }
        //}

        //[DataMember]
        //public string AccountingYear
        //{
        //    get
        //    {
        //        try
        //        {

        //            var calendar = LsmEntityDB.vw_RequisitionsNorms
        //                          .Take(1)
        //                          .Select(c => c.Year)
        //                          .Single();
        //            return calendar.ToString();
        //        }
        //        catch (Exception e)
        //        {
        //            throw new EntityNotFoundException(e.InnerException.ToString(), "Unable To Load Calendar", "Ensure calendar for this book year is active.", LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //        }
        //    }
        //}
        #endregion
    }
}