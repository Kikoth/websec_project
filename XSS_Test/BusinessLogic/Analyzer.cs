using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class Analyzer
    {
        #region Member
        XSSEvalForm _responseForm;

        #endregion

        #region Constructor
        public Analyzer(XSSEvalForm frm)
        {
            _responseForm = frm;
        }

        #endregion

        #region Methods

        public void PerformAnalyzation()
        {
            foreach (var byPassObject in ByPassFilter.Filter)
            {
                // Update Status des FilterByPassObject (Logging)
                _responseForm.UpdateStatus(byPassObject.ID, "analyzing...");

                bool success = false;

                if (byPassObject.ResponseContent.Contains(byPassObject.ByPassString))
                    success = true;

                // Set Result und Ende
                _responseForm.SetResult(byPassObject.ID, success);
                _responseForm.UpdateStatus(byPassObject.ID, "...done"); 
            }
        }

        public void PerformAnalyzation(FilterByPassObject byPassObject)
        {
            // Update Status des FilterByPassObject (Logging)
            _responseForm.UpdateStatus(byPassObject.ID, "analyzing...");

            bool success = false;

            if (byPassObject.ResponseContent.Contains(byPassObject.ByPassString))
                success = true;

            // Set Result und Ende
            _responseForm.SetResult(byPassObject.ID, success);
            _responseForm.UpdateStatus(byPassObject.ID, "...done");
        }

        #endregion

    }
}
